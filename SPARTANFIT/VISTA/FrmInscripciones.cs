
using System;
using System.Data;
using System.Windows.Forms;
using SPARTANFIT.CONTROLADOR;
using SPARTANFIT.MODELO;

namespace SPARTANFIT.VISTA
{
    public partial class FrmInscripciones : Form
    {
        public FrmInscripciones()
        {
            InitializeComponent();

            ConfigurarEventos();
            ConfigurarTabla();
            CargarMiembros();
            CargarInscripciones();
            EstadoInicial();
        }

        private void ConfigurarEventos()
        {
            btnNuevo.Click += btnNuevo_Click;
            btnRegistrar.Click += btnRegistrar_Click;
            btnEditar.Click += btnEditar_Click;
            btnEliminar.Click += btnEliminar_Click;
            btnCancelar.Click += btnCancelar_Click;
            dgvInscripciones.CellClick += dgvInscripciones_CellClick;
        }

        private void ConfigurarTabla()
        {
            dgvInscripciones.AutoGenerateColumns = true;
            dgvInscripciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInscripciones.MultiSelect = false;
            dgvInscripciones.ReadOnly = true;
            dgvInscripciones.AllowUserToAddRows = false;
            dgvInscripciones.AllowUserToDeleteRows = false;
            dgvInscripciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarMiembros()
        {
            try
            {
                DataTable tabla = MiembroControlador.Listar("");

                if (!tabla.Columns.Contains("NOMBRE_COMPLETO"))
                {
                    tabla.Columns.Add("NOMBRE_COMPLETO", typeof(string));

                    foreach (DataRow fila in tabla.Rows)
                    {
                        fila["NOMBRE_COMPLETO"] =
                            fila["NOMBRE"].ToString() + " " +
                            fila["APELLIDO"].ToString();
                    }
                }

                cmbMiembro.DataSource = null;
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

        private void CargarInscripciones()
        {
            try
            {
                dgvInscripciones.DataSource = InscripcionControlador.Listar("");

                if (dgvInscripciones.Columns.Contains("ID_INSCRIPCION"))
                    dgvInscripciones.Columns["ID_INSCRIPCION"].HeaderText = "ID";

                if (dgvInscripciones.Columns.Contains("ID_MIEMBRO"))
                    dgvInscripciones.Columns["ID_MIEMBRO"].Visible = false;

                if (dgvInscripciones.Columns.Contains("CI"))
                    dgvInscripciones.Columns["CI"].HeaderText = "CÉDULA";

                if (dgvInscripciones.Columns.Contains("MIEMBRO"))
                    dgvInscripciones.Columns["MIEMBRO"].HeaderText = "MIEMBRO";

                if (dgvInscripciones.Columns.Contains("FECHA_INICIO"))
                    dgvInscripciones.Columns["FECHA_INICIO"].HeaderText = "FECHA DE INICIO";

                if (dgvInscripciones.Columns.Contains("FECHA_FIN"))
                    dgvInscripciones.Columns["FECHA_FIN"].HeaderText = "FECHA DE FIN";

                if (dgvInscripciones.Columns.Contains("MODALIDAD"))
                    dgvInscripciones.Columns["MODALIDAD"].HeaderText = "MODALIDAD";

                if (dgvInscripciones.Columns.Contains("ESTADO"))
                    dgvInscripciones.Columns["ESTADO"].HeaderText = "ESTADO";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar las inscripciones: " + ex.Message,
                    "SPARTANFIT",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void EstadoInicial()
        {
            txtIdInscripcion.Clear();
            cmbMiembro.SelectedIndex = -1;
            dtpFechaInicio.Value = DateTime.Today;
            dtpFechaFin.Value = DateTime.Today.AddMonths(1);
            cmbModalidad.SelectedIndex = -1;
            cmbEstado.SelectedItem = "ACTIVO";

            btnRegistrar.Enabled = true;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;

            dgvInscripciones.ClearSelection();
        }

        private bool ValidarDatos()
        {
            if (cmbMiembro.SelectedIndex < 0 || cmbMiembro.SelectedValue == null)
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

            if (cmbModalidad.SelectedIndex < 0)
            {
                MessageBox.Show(
                    "Seleccione una modalidad.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                cmbModalidad.Focus();
                return false;
            }

            if (cmbEstado.SelectedIndex < 0)
            {
                MessageBox.Show(
                    "Seleccione un estado.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                cmbEstado.Focus();
                return false;
            }

            if (dtpFechaFin.Value.Date < dtpFechaInicio.Value.Date)
            {
                MessageBox.Show(
                    "La fecha de finalización no puede ser anterior a la fecha de inicio.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                dtpFechaFin.Focus();
                return false;
            }

            return true;
        }

        private Inscripcion ObtenerDatos()
        {
            return new Inscripcion
            {
                Id = string.IsNullOrWhiteSpace(txtIdInscripcion.Text)
                    ? 0
                    : Convert.ToInt32(txtIdInscripcion.Text),

                IdMiembro = Convert.ToInt32(cmbMiembro.SelectedValue),
                FechaInicio = dtpFechaInicio.Value.Date,
                FechaFin = dtpFechaFin.Value.Date,
                Modalidad = cmbModalidad.Text,
                Estado = cmbEstado.Text
            };
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            EstadoInicial();
            cmbMiembro.Focus();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos())
                return;

            Inscripcion inscripcion = ObtenerDatos();

            if (InscripcionControlador.Registrar(inscripcion, out string mensaje))
            {
                MessageBox.Show(
                    "Inscripción registrada correctamente.",
                    "SPARTANFIT",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                CargarInscripciones();
                EstadoInicial();
            }
            else
            {
                MessageBox.Show(
                    "No se pudo registrar la inscripción: " + mensaje,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdInscripcion.Text))
            {
                MessageBox.Show("Seleccione una inscripción para editar.");
                return;
            }

            if (!ValidarDatos())
                return;

            Inscripcion inscripcion = ObtenerDatos();

            if (InscripcionControlador.Actualizar(inscripcion, out string mensaje))
            {
                MessageBox.Show(
                    "Inscripción actualizada correctamente.",
                    "SPARTANFIT",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                CargarInscripciones();
                EstadoInicial();
            }
            else
            {
                MessageBox.Show(
                    "No se pudo actualizar la inscripción: " + mensaje,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdInscripcion.Text))
            {
                MessageBox.Show("Seleccione una inscripción para cancelar.");
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Está seguro de que desea cancelar esta inscripción?",
                "Confirmar cancelación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (respuesta != DialogResult.Yes)
                return;

            int id = Convert.ToInt32(txtIdInscripcion.Text);

            if (InscripcionControlador.Cancelar(id, out string mensaje))
            {
                MessageBox.Show(
                    "Inscripción cancelada correctamente.",
                    "SPARTANFIT",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                CargarInscripciones();
                EstadoInicial();
            }
            else
            {
                MessageBox.Show(
                    "No se pudo cancelar la inscripción: " + mensaje,
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

        private void dgvInscripciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow fila = dgvInscripciones.Rows[e.RowIndex];

            txtIdInscripcion.Text = fila.Cells["ID_INSCRIPCION"].Value.ToString();

            cmbMiembro.SelectedValue = Convert.ToInt32(
                fila.Cells["ID_MIEMBRO"].Value
            );

            dtpFechaInicio.Value = Convert.ToDateTime(
                fila.Cells["FECHA_INICIO"].Value
            );

            dtpFechaFin.Value = Convert.ToDateTime(
                fila.Cells["FECHA_FIN"].Value
            );

            cmbModalidad.SelectedItem = fila.Cells["MODALIDAD"].Value.ToString();
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
        }
    }
}
