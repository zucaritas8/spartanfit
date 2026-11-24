using System;
using System.Data;
using System.Windows.Forms;
using SPARTANFIT.CONTROLADOR;
using SPARTANFIT.MODELO;

namespace SPARTANFIT.VISTA
{
    public partial class FrmUsuarios : Form
    {
        public FrmUsuarios()
        {
            InitializeComponent();

            btnNuevo.Click += btnNuevo_Click;
            btnRegistrar.Click += btnRegistrar_Click;
            btnEditar.Click += btnEditar_Click;
            btnEliminar.Click += btnEliminar_Click;
            btnCancelar.Click += btnCancelar_Click;

            dgvUsuarios.SelectionChanged += dgvUsuarios_SelectionChanged;

            dgvUsuarios.AutoGenerateColumns = false;

            colId.DataPropertyName = "ID_USUARIO";
            colUsuario.DataPropertyName = "USUARIO";
            colEstado.DataPropertyName = "ESTADO";
            colFecha.DataPropertyName = "FECHA_CREACION";
            colRol.DataPropertyName = "ROL";

            // El ID no se modifica manualmente.
            txtIdUsuario.ReadOnly = true;

            CargarUsuarios();
        }

        private void CargarUsuarios()
        {
            dgvUsuarios.DataSource = UsuarioControlador.Listar();
        }

        private Usuario ObtenerUsuario()
        {
            int id;
            int.TryParse(txtIdUsuario.Text, out id);

            return new Usuario
            {
                Id = id,
                NombreUsuario = txtUsuario.Text.Trim(),
                PasswordHash = LoginControlador.Hash(txtPassword.Text),
                Rol = cmbRol.Text,
                Estado = cmbEstado.Text
            };
        }

        private bool ValidarDatos(bool editar)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text) ||
                cmbRol.SelectedIndex < 0 ||
                cmbEstado.SelectedIndex < 0)
            {
                MessageBox.Show(
                    "Completa el usuario, rol y estado.",
                    "SPARTANFIT",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show(
                    editar
                        ? "Ingresa la nueva contraseña para actualizar el usuario."
                        : "Ingresa una contraseña.",
                    "SPARTANFIT",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return false;
            }

            return true;
        }

        private void LimpiarCampos()
        {
            txtIdUsuario.Clear();
            txtUsuario.Clear();
            txtPassword.Clear();

            cmbRol.SelectedIndex = -1;
            cmbEstado.SelectedIndex = -1;

            dgvUsuarios.ClearSelection();

            txtUsuario.Focus();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos(false))
                return;

            string mensaje;

            if (UsuarioControlador.Registrar(ObtenerUsuario(), out mensaje))
            {
                MessageBox.Show(
                    "Usuario registrado correctamente.",
                    "SPARTANFIT",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                CargarUsuarios();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show(
                    mensaje,
                    "SPARTANFIT",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos(true))
                return;

            int id;

            if (!int.TryParse(txtIdUsuario.Text, out id) || id <= 0)
            {
                MessageBox.Show(
                    "Selecciona un usuario de la lista.",
                    "SPARTANFIT",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            string mensaje;

            if (UsuarioControlador.Actualizar(ObtenerUsuario(), out mensaje))
            {
                MessageBox.Show(
                    "Usuario actualizado correctamente.",
                    "SPARTANFIT",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                CargarUsuarios();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show(
                    mensaje,
                    "SPARTANFIT",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id;

            if (!int.TryParse(txtIdUsuario.Text, out id) || id <= 0)
            {
                MessageBox.Show(
                    "Selecciona un usuario de la lista.",
                    "SPARTANFIT",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            DialogResult resultado = MessageBox.Show(
                "¿Estás seguro de eliminar este usuario?",
                "SPARTANFIT",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resultado != DialogResult.Yes)
                return;

            string mensaje;

            if (UsuarioControlador.Eliminar(id, out mensaje))
            {
                MessageBox.Show(
                    "Usuario eliminado correctamente.",
                    "SPARTANFIT",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                CargarUsuarios();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show(
                    mensaje,
                    "SPARTANFIT",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void dgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow == null ||
                !(dgvUsuarios.CurrentRow.DataBoundItem is DataRowView))
            {
                return;
            }

            DataRowView fila =
                (DataRowView)dgvUsuarios.CurrentRow.DataBoundItem;

            txtIdUsuario.Text = fila["ID_USUARIO"].ToString();
            txtUsuario.Text = fila["USUARIO"].ToString();
            cmbEstado.Text = fila["ESTADO"].ToString();
            cmbRol.Text = fila["ROL"].ToString();

            // Nunca mostramos ni cargamos el hash de la contraseña.
            txtPassword.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmMenuPrincipal menu = new FrmMenuPrincipal();
            menu.Show();
            this.Close();
        }
    }
}