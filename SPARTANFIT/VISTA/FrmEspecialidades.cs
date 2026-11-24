
using System;
using System.Data;
using System.Windows.Forms;
using SPARTANFIT.CONTROLADOR;
using SPARTANFIT.MODELO;

namespace SPARTANFIT.VISTA
{
    public partial class FrmEspecialidades : Form
    {
        public FrmEspecialidades()
        {
            InitializeComponent();

            ConfigurarEventos();
            ConfigurarTabla();
            CargarEspecialidades();
            EstadoInicial();
        }

        private void ConfigurarEventos()
        {
            btnNuevo.Click += btnNuevo_Click;
            btnRegistrar.Click += btnRegistrar_Click;
            btnEditar.Click += btnEditar_Click;
            btnEliminar.Click += btnEliminar_Click;
            btnCancelar.Click += btnCancelar_Click;
            dgvEspecialidades.CellClick += dgvEspecialidades_CellClick;
        }

        private void ConfigurarTabla()
        {
            dgvEspecialidades.AutoGenerateColumns = true;
            dgvEspecialidades.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEspecialidades.MultiSelect = false;
            dgvEspecialidades.ReadOnly = true;
            dgvEspecialidades.AllowUserToAddRows = false;
            dgvEspecialidades.AllowUserToDeleteRows = false;
        }

        private void CargarEspecialidades()
        {
            try
            {
                dgvEspecialidades.DataSource = EspecialidadControlador.Listar();

                if (dgvEspecialidades.Columns.Contains("ID_ESPECIALIDAD"))
                    dgvEspecialidades.Columns["ID_ESPECIALIDAD"].HeaderText = "ID";

                if (dgvEspecialidades.Columns.Contains("NOMBRE"))
                    dgvEspecialidades.Columns["NOMBRE"].HeaderText = "ESPECIALIDAD";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar las especialidades: " + ex.Message,
                    "SPARTANFIT",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void EstadoInicial()
        {
            txtIdEspecialidad.Clear();
            txtNombre.Clear();

            btnRegistrar.Enabled = true;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;

            dgvEspecialidades.ClearSelection();
            txtNombre.Focus();
        }

        private bool ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show(
                    "Ingrese el nombre de la especialidad.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtNombre.Focus();
                return false;
            }

            if (txtNombre.Text.Trim().Length > 50)
            {
                MessageBox.Show(
                    "El nombre no puede superar los 50 caracteres.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtNombre.Focus();
                return false;
            }

            return true;
        }

        private Especialidad ObtenerDatos()
        {
            return new Especialidad
            {
                Id = string.IsNullOrWhiteSpace(txtIdEspecialidad.Text)
                    ? 0
                    : Convert.ToInt32(txtIdEspecialidad.Text),

                Nombre = txtNombre.Text.Trim()
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

            Especialidad especialidad = ObtenerDatos();

            if (EspecialidadControlador.Registrar(especialidad, out string mensaje))
            {
                MessageBox.Show(
                    "Especialidad registrada correctamente.",
                    "SPARTANFIT",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                CargarEspecialidades();
                EstadoInicial();
            }
            else
            {
                MessageBox.Show(
                    "No se pudo registrar la especialidad: " + mensaje,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdEspecialidad.Text))
            {
                MessageBox.Show("Seleccione una especialidad para editar.");
                return;
            }

            if (!ValidarDatos())
                return;

            Especialidad especialidad = ObtenerDatos();

            if (EspecialidadControlador.Actualizar(especialidad, out string mensaje))
            {
                MessageBox.Show(
                    "Especialidad actualizada correctamente.",
                    "SPARTANFIT",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                CargarEspecialidades();
                EstadoInicial();
            }
            else
            {
                MessageBox.Show(
                    "No se pudo actualizar la especialidad: " + mensaje,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdEspecialidad.Text))
            {
                MessageBox.Show("Seleccione una especialidad para eliminar.");
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Está seguro de que desea eliminar esta especialidad?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (respuesta != DialogResult.Yes)
                return;

            int id = Convert.ToInt32(txtIdEspecialidad.Text);

            if (EspecialidadControlador.Eliminar(id, out string mensaje))
            {
                MessageBox.Show(
                    "Especialidad eliminada correctamente.",
                    "SPARTANFIT",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                CargarEspecialidades();
                EstadoInicial();
            }
            else
            {
                MessageBox.Show(
                    "No se pudo eliminar la especialidad: " + mensaje,
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

        private void dgvEspecialidades_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow fila = dgvEspecialidades.Rows[e.RowIndex];

            txtIdEspecialidad.Text =
                fila.Cells["ID_ESPECIALIDAD"].Value?.ToString() ?? "";

            txtNombre.Text =
                fila.Cells["NOMBRE"].Value?.ToString() ?? "";

            btnRegistrar.Enabled = false;
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmMenuPrincipal menu = new FrmMenuPrincipal();
            menu.Show();
            this.Close();
        }
    }
}
