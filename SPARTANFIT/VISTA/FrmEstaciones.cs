using System;
using System.Data;
using System.Windows.Forms;
using SPARTANFIT.CONTROLADOR;
using SPARTANFIT.MODELO;

namespace SPARTANFIT.VISTA
{
    public partial class FrmEstaciones : Form
    {
        public FrmEstaciones()
        {
            InitializeComponent();

            ConfigurarEventos();
            ConfigurarTabla();

            txtIdEstacion.ReadOnly = true;

            CargarEstaciones();
            EstadoInicial();
        }

        private void ConfigurarEventos()
        {
            btnNuevo.Click += btnNuevo_Click;
            btnRegistrar.Click += btnRegistrar_Click;
            btnEditar.Click += btnEditar_Click;
            btnEliminar.Click += btnEliminar_Click;
            btnCancelar.Click += btnCancelar_Click;

            dgvEstaciones.CellClick += dgvEstaciones_CellClick;
        }

        private void ConfigurarTabla()
        {
            dgvEstaciones.AutoGenerateColumns = true;
            dgvEstaciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEstaciones.MultiSelect = false;
            dgvEstaciones.ReadOnly = true;
            dgvEstaciones.AllowUserToAddRows = false;
            dgvEstaciones.AllowUserToDeleteRows = false;
        }

        private void CargarEstaciones()
        {
            try
            {
                dgvEstaciones.DataSource = EstacionControlador.Listar("");

                if (dgvEstaciones.Columns.Contains("ID_ESTACION"))
                    dgvEstaciones.Columns["ID_ESTACION"].HeaderText = "ID";

                if (dgvEstaciones.Columns.Contains("NOMBRE"))
                    dgvEstaciones.Columns["NOMBRE"].HeaderText = "NOMBRE";

                if (dgvEstaciones.Columns.Contains("DESCRIPCION"))
                    dgvEstaciones.Columns["DESCRIPCION"].HeaderText = "DESCRIPCIÓN";

                if (dgvEstaciones.Columns.Contains("EQUIPAMIENTO"))
                    dgvEstaciones.Columns["EQUIPAMIENTO"].HeaderText = "EQUIPAMIENTO";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar las estaciones: " + ex.Message,
                    "SPARTANFIT",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void EstadoInicial()
        {
            txtIdEstacion.Clear();
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtEquipamiento.Clear();

            btnRegistrar.Enabled = true;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;

            dgvEstaciones.ClearSelection();

            txtNombre.Focus();
        }

        private bool ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show(
                    "Ingrese el nombre de la estación.",
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

            if (txtEquipamiento.Text.Trim().Length > 255)
            {
                MessageBox.Show(
                    "El equipamiento no puede superar los 255 caracteres.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtEquipamiento.Focus();
                return false;
            }

            return true;
        }

        private Estacion ObtenerDatos()
        {
            int id = 0;
            int.TryParse(txtIdEstacion.Text, out id);

            return new Estacion
            {
                Id = id,
                Nombre = txtNombre.Text.Trim(),
                Descripcion = txtDescripcion.Text.Trim(),
                Equipamiento = txtEquipamiento.Text.Trim()
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

            Estacion estacion = ObtenerDatos();

            string mensaje;

            if (EstacionControlador.Registrar(estacion, out mensaje))
            {
                MessageBox.Show(
                    "Estación registrada correctamente.",
                    "SPARTANFIT",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                CargarEstaciones();
                EstadoInicial();
            }
            else
            {
                MessageBox.Show(
                    "No se pudo registrar la estación: " + mensaje,
                    "SPARTANFIT",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int id;

            if (!int.TryParse(txtIdEstacion.Text, out id) || id <= 0)
            {
                MessageBox.Show(
                    "Seleccione una estación para editar.",
                    "SPARTANFIT",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            if (!ValidarDatos())
                return;

            Estacion estacion = ObtenerDatos();

            string mensaje;

            if (EstacionControlador.Actualizar(estacion, out mensaje))
            {
                MessageBox.Show(
                    "Estación actualizada correctamente.",
                    "SPARTANFIT",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                CargarEstaciones();
                EstadoInicial();
            }
            else
            {
                MessageBox.Show(
                    "No se pudo actualizar la estación: " + mensaje,
                    "SPARTANFIT",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id;

            if (!int.TryParse(txtIdEstacion.Text, out id) || id <= 0)
            {
                MessageBox.Show(
                    "Seleccione una estación para eliminar.",
                    "SPARTANFIT",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Está seguro de que desea eliminar esta estación?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (respuesta != DialogResult.Yes)
                return;

            string mensaje;

            if (EstacionControlador.Eliminar(id, out mensaje))
            {
                MessageBox.Show(
                    "Estación eliminada correctamente.",
                    "SPARTANFIT",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                CargarEstaciones();
                EstadoInicial();
            }
            else
            {
                MessageBox.Show(
                    "No se pudo eliminar la estación: " + mensaje,
                    "SPARTANFIT",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            EstadoInicial();
        }

        private void dgvEstaciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow fila = dgvEstaciones.Rows[e.RowIndex];

            txtIdEstacion.Text = fila.Cells["ID_ESTACION"].Value == DBNull.Value
                ? ""
                : fila.Cells["ID_ESTACION"].Value.ToString();

            txtNombre.Text = fila.Cells["NOMBRE"].Value == DBNull.Value
                ? ""
                : fila.Cells["NOMBRE"].Value.ToString();

            txtDescripcion.Text = fila.Cells["DESCRIPCION"].Value == DBNull.Value
                ? ""
                : fila.Cells["DESCRIPCION"].Value.ToString();

            txtEquipamiento.Text = fila.Cells["EQUIPAMIENTO"].Value == DBNull.Value
                ? ""
                : fila.Cells["EQUIPAMIENTO"].Value.ToString();

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