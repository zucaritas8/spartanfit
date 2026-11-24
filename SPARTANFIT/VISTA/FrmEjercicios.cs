
using System;
using System.Windows.Forms;
using SPARTANFIT.CONTROLADOR;
using SPARTANFIT.MODELO;

namespace SPARTANFIT.VISTA
{
    public partial class FrmEjercicios : Form
    {
        public FrmEjercicios()
        {
            InitializeComponent();

            ConfigurarEventos();
            ConfigurarTabla();
            CargarEjercicios();
            EstadoInicial();
        }

        private void ConfigurarEventos()
        {
            btnNuevo.Click += btnNuevo_Click;
            btnRegistrar.Click += btnRegistrar_Click;
            btnEditar.Click += btnEditar_Click;
            btnEliminar.Click += btnEliminar_Click;
            btnCancelar.Click += btnCancelar_Click;
            dgvEjercicios.CellClick += dgvEjercicios_CellClick;
        }

        private void ConfigurarTabla()
        {
            dgvEjercicios.AutoGenerateColumns = true;
            dgvEjercicios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEjercicios.MultiSelect = false;
            dgvEjercicios.ReadOnly = true;
            dgvEjercicios.AllowUserToAddRows = false;
            dgvEjercicios.AllowUserToDeleteRows = false;
        }

        private void CargarEjercicios()
        {
            try
            {
                dgvEjercicios.DataSource = EjercicioControlador.Listar("");

                if (dgvEjercicios.Columns.Contains("ID_EJERCICIO"))
                    dgvEjercicios.Columns["ID_EJERCICIO"].HeaderText = "ID";

                if (dgvEjercicios.Columns.Contains("NOMBRE"))
                    dgvEjercicios.Columns["NOMBRE"].HeaderText = "NOMBRE";

                if (dgvEjercicios.Columns.Contains("DESCRIPCION"))
                    dgvEjercicios.Columns["DESCRIPCION"].HeaderText = "DESCRIPCIÓN";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar los ejercicios: " + ex.Message,
                    "SPARTANFIT",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void EstadoInicial()
        {
            txtIdEjercicio.Clear();
            txtNombre.Clear();
            txtDescripcion.Clear();

            btnRegistrar.Enabled = true;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;

            dgvEjercicios.ClearSelection();
            txtNombre.Focus();
        }

        private bool ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show(
                    "Ingrese el nombre del ejercicio.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtNombre.Focus();
                return false;
            }

            if (txtNombre.Text.Trim().Length > 100)
            {
                MessageBox.Show(
                    "El nombre no puede superar los 100 caracteres.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtNombre.Focus();
                return false;
            }

            if (txtDescripcion.Text.Trim().Length > 255)
            {
                MessageBox.Show(
                    "La descripción no puede superar los 255 caracteres.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtDescripcion.Focus();
                return false;
            }

            return true;
        }

        private Ejercicio ObtenerDatos()
        {
            return new Ejercicio
            {
                Id = string.IsNullOrWhiteSpace(txtIdEjercicio.Text)
                    ? 0
                    : Convert.ToInt32(txtIdEjercicio.Text),

                Nombre = txtNombre.Text.Trim(),
                Descripcion = txtDescripcion.Text.Trim()
            };
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            EstadoInicial();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos())
                return;

            Ejercicio ejercicio = ObtenerDatos();

            if (EjercicioControlador.Registrar(ejercicio, out string mensaje))
            {
                MessageBox.Show(
                    "Ejercicio registrado correctamente.",
                    "SPARTANFIT",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                CargarEjercicios();
                EstadoInicial();
            }
            else
            {
                MessageBox.Show(
                    "No se pudo registrar el ejercicio: " + mensaje,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdEjercicio.Text))
            {
                MessageBox.Show("Seleccione un ejercicio para editar.");
                return;
            }

            if (!ValidarDatos())
                return;

            Ejercicio ejercicio = ObtenerDatos();

            if (EjercicioControlador.Actualizar(ejercicio, out string mensaje))
            {
                MessageBox.Show(
                    "Ejercicio actualizado correctamente.",
                    "SPARTANFIT",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                CargarEjercicios();
                EstadoInicial();
            }
            else
            {
                MessageBox.Show(
                    "No se pudo actualizar el ejercicio: " + mensaje,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdEjercicio.Text))
            {
                MessageBox.Show("Seleccione un ejercicio para eliminar.");
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Está seguro de que desea eliminar este ejercicio?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (respuesta != DialogResult.Yes)
                return;

            int id = Convert.ToInt32(txtIdEjercicio.Text);

            if (EjercicioControlador.Eliminar(id, out string mensaje))
            {
                MessageBox.Show(
                    "Ejercicio eliminado correctamente.",
                    "SPARTANFIT",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                CargarEjercicios();
                EstadoInicial();
            }
            else
            {
                MessageBox.Show(
                    "No se pudo eliminar el ejercicio: " + mensaje,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            EstadoInicial();
        }

        private void dgvEjercicios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow fila = dgvEjercicios.Rows[e.RowIndex];

            txtIdEjercicio.Text =
                fila.Cells["ID_EJERCICIO"].Value?.ToString() ?? "";

            txtNombre.Text =
                fila.Cells["NOMBRE"].Value?.ToString() ?? "";

            txtDescripcion.Text =
                fila.Cells["DESCRIPCION"].Value?.ToString() ?? "";

            btnRegistrar.Enabled = false;
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmMenuPrincipal menu = new FrmMenuPrincipal();
            menu.Show();
            this.Hide();
            this.Close();
        }
    }
}
