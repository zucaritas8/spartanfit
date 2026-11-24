
using System;
using System.Data;
using System.Windows.Forms;
using SPARTANFIT.MODELO;
using SPARTANFIT.CONTROLADOR;

namespace SPARTANFIT.VISTA
{
    public partial class FrmCredenciales : Form
    {
        public FrmCredenciales()
        {
            InitializeComponent();

            btnNuevo.Click += btnNuevo_Click;
            btnRegistrar.Click += btnRegistrar_Click;
            btnEditar.Click += btnEditar_Click;
            btnEliminar.Click += btnEliminar_Click;
            btnCancelar.Click += btnCancelar_Click;

            ConfigurarFormulario();
            CargarMiembros();
            CargarCredenciales();
            LimpiarFormulario();
        }

        private void ConfigurarFormulario()
        {
            dgvCredenciales.AutoGenerateColumns = true;
            dgvCredenciales.ReadOnly = true;
            dgvCredenciales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCredenciales.MultiSelect = false;
            dgvCredenciales.AllowUserToAddRows = false;
            dgvCredenciales.AllowUserToDeleteRows = false;

            cmbEstado.Items.Clear();
            cmbEstado.Items.Add("ACTIVO");
            cmbEstado.Items.Add("INACTIVO");
            cmbEstado.Items.Add("SUSPENDIDO");

            btnRegistrar.Enabled = true;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private void CargarMiembros()
        {
            try
            {
                DataTable tabla = MiembroControlador.Listar();

                if (!tabla.Columns.Contains("NOMBRE_COMPLETO"))
                {
                    tabla.Columns.Add("NOMBRE_COMPLETO", typeof(string));

                    foreach (DataRow fila in tabla.Rows)
                    {
                        string nombre = fila["NOMBRE"].ToString();
                        string apellido = fila["APELLIDO"].ToString();
                        string ci = fila["CI"].ToString();

                        fila["NOMBRE_COMPLETO"] =
                            ci + " - " + nombre + " " + apellido;
                    }
                }

                cmbMiembro.DataSource = tabla;
                cmbMiembro.DisplayMember = "NOMBRE_COMPLETO";
                cmbMiembro.ValueMember = "ID_MIEMBRO";
                cmbMiembro.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar los miembros: " + ex.Message,
                    "SPARTANFIT",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void CargarCredenciales()
        {
            try
            {
                DataTable tabla = CredencialControlador.Listar();

                dgvCredenciales.DataSource = tabla;

                if (dgvCredenciales.Columns.Contains("ID_MIEMBRO"))
                    dgvCredenciales.Columns["ID_MIEMBRO"].Visible = false;

                if (dgvCredenciales.Columns.Contains("ID_CREDENCIAL"))
                    dgvCredenciales.Columns["ID_CREDENCIAL"].HeaderText = "ID";

                if (dgvCredenciales.Columns.Contains("MIEMBRO"))
                    dgvCredenciales.Columns["MIEMBRO"].HeaderText = "MIEMBRO";

                if (dgvCredenciales.Columns.Contains("CI"))
                    dgvCredenciales.Columns["CI"].HeaderText = "CÉDULA";

                if (dgvCredenciales.Columns.Contains("TIPO"))
                    dgvCredenciales.Columns["TIPO"].HeaderText = "TIPO";

                if (dgvCredenciales.Columns.Contains("VALOR"))
                    dgvCredenciales.Columns["VALOR"].HeaderText = "VALOR / CÓDIGO";

                if (dgvCredenciales.Columns.Contains("ESTADO"))
                    dgvCredenciales.Columns["ESTADO"].HeaderText = "ESTADO";

                dgvCredenciales.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar las credenciales: " + ex.Message,
                    "SPARTANFIT",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void LimpiarFormulario()
        {
            txtIdCredencial.Clear();
            cmbMiembro.SelectedIndex = -1;
            txtTipo.Clear();
            txtValor.Clear();
            cmbEstado.SelectedItem = "ACTIVO";

            btnRegistrar.Enabled = true;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;

            dgvCredenciales.ClearSelection();
            txtTipo.Focus();
        }

        private bool ValidarFormulario()
        {
            if (cmbMiembro.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Seleccione un miembro.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                cmbMiembro.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTipo.Text))
            {
                MessageBox.Show(
                    "Ingrese el tipo de credencial.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtTipo.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtValor.Text))
            {
                MessageBox.Show(
                    "Ingrese el valor o código de la credencial.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtValor.Focus();
                return false;
            }

            if (cmbEstado.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Seleccione el estado de la credencial.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                cmbEstado.Focus();
                return false;
            }

            return true;
        }

        private Credencial ObtenerCredencial()
        {
            return new Credencial
            {
                Id = string.IsNullOrWhiteSpace(txtIdCredencial.Text)
                    ? 0
                    : Convert.ToInt32(txtIdCredencial.Text),

                IdMiembro = Convert.ToInt32(cmbMiembro.SelectedValue),
                Tipo = txtTipo.Text.Trim(),
                Valor = txtValor.Text.Trim(),
                Estado = cmbEstado.SelectedItem.ToString()
            };
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario())
                return;

            Credencial credencial = ObtenerCredencial();

            string mensaje;

            if (CredencialControlador.Registrar(credencial, out mensaje))
            {
                MessageBox.Show(
                    "Credencial registrada correctamente.",
                    "SPARTANFIT",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                CargarCredenciales();
                LimpiarFormulario();
            }
            else
            {
                MessageBox.Show(
                    "No se pudo registrar la credencial.\n" + mensaje,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdCredencial.Text))
            {
                MessageBox.Show(
                    "Seleccione una credencial para editar.",
                    "SPARTANFIT",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            if (!ValidarFormulario())
                return;

            Credencial credencial = ObtenerCredencial();

            string mensaje;

            if (CredencialControlador.Actualizar(credencial, out mensaje))
            {
                MessageBox.Show(
                    "Credencial actualizada correctamente.",
                    "SPARTANFIT",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                CargarCredenciales();
                LimpiarFormulario();
            }
            else
            {
                MessageBox.Show(
                    "No se pudo actualizar la credencial.\n" + mensaje,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdCredencial.Text))
            {
                MessageBox.Show(
                    "Seleccione una credencial para desactivar.",
                    "SPARTANFIT",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Está seguro de que desea desactivar esta credencial?",
                "Confirmar desactivación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (respuesta != DialogResult.Yes)
                return;

            int id = Convert.ToInt32(txtIdCredencial.Text);

            string mensaje;

            if (CredencialControlador.CambiarEstado(
                id, "INACTIVO", out mensaje))
            {
                MessageBox.Show(
                    "Credencial desactivada correctamente.",
                    "SPARTANFIT",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                CargarCredenciales();
                LimpiarFormulario();
            }
            else
            {
                MessageBox.Show(
                    "No se pudo desactivar la credencial.\n" + mensaje,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void dgvCredenciales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow fila = dgvCredenciales.Rows[e.RowIndex];

            txtIdCredencial.Text =
                fila.Cells["ID_CREDENCIAL"].Value.ToString();

            cmbMiembro.SelectedValue =
                Convert.ToInt32(fila.Cells["ID_MIEMBRO"].Value);

            txtTipo.Text = fila.Cells["TIPO"].Value.ToString();
            txtValor.Text = fila.Cells["VALOR"].Value.ToString();
            cmbEstado.SelectedItem = fila.Cells["ESTADO"].Value.ToString();

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
