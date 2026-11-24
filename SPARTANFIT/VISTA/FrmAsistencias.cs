
using System;
using System.Data;
using System.Windows.Forms;
using SPARTANFIT.MODELO;
using SPARTANFIT.CONTROLADOR;

namespace SPARTANFIT.VISTA
{
    public partial class FrmAsistencias : Form
    {
        public FrmAsistencias()
        {
            InitializeComponent();

            btnNuevo.Click += btnNuevo_Click;
            btnRegistrar.Click += btnRegistrar_Click;
            btnEditar.Click += btnEditar_Click;
            btnEliminar.Click += btnEliminar_Click;
            btnCancelar.Click += btnCancelar_Click;

            dgvAsistencias.CellClick += dgvAsistencias_CellClick;

            CargarInscripciones();
            CargarCredenciales();
            CargarAsistencias();

            LimpiarCampos();
        }

        private void CargarInscripciones()
        {
            try
            {
                DataTable tabla = InscripcionControlador.Listar();

                if (!tabla.Columns.Contains("DESCRIPCION"))
                    tabla.Columns.Add("DESCRIPCION", typeof(string));

                foreach (DataRow fila in tabla.Rows)
                {
                    fila["DESCRIPCION"] =
                        fila["MIEMBRO"].ToString() +
                        " | CI: " + fila["CI"].ToString() +
                        " | " + fila["MODALIDAD"].ToString() +
                        " | " + fila["ESTADO"].ToString();
                }

                cmbInscripcion.DataSource = null;
                cmbInscripcion.DataSource = tabla;
                cmbInscripcion.DisplayMember = "DESCRIPCION";
                cmbInscripcion.ValueMember = "ID_INSCRIPCION";
                cmbInscripcion.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las inscripciones:\n" + ex.Message,
                    "SPARTANFIT", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarCredenciales()
        {
            try
            {
                DataTable tabla = CredencialControlador.Listar();

                if (!tabla.Columns.Contains("DESCRIPCION"))
                    tabla.Columns.Add("DESCRIPCION", typeof(string));

                foreach (DataRow fila in tabla.Rows)
                {
                    fila["DESCRIPCION"] =
                        fila["MIEMBRO"].ToString() +
                        " | " + fila["TIPO"].ToString() +
                        ": " + fila["VALOR"].ToString() +
                        " | " + fila["ESTADO"].ToString();
                }

                cmbCredencial.DataSource = null;
                cmbCredencial.DataSource = tabla;
                cmbCredencial.DisplayMember = "DESCRIPCION";
                cmbCredencial.ValueMember = "ID_CREDENCIAL";
                cmbCredencial.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las credenciales:\n" + ex.Message,
                    "SPARTANFIT", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarAsistencias()
        {
            try
            {
                DataTable tabla = AsistenciaControlador.Listar();

                dgvAsistencias.DataSource = null;
                dgvAsistencias.AutoGenerateColumns = true;
                dgvAsistencias.DataSource = tabla;

                dgvAsistencias.ReadOnly = true;
                dgvAsistencias.AllowUserToAddRows = false;
                dgvAsistencias.AllowUserToDeleteRows = false;
                dgvAsistencias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvAsistencias.MultiSelect = false;
                dgvAsistencias.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.DisplayedCells;

                ConfigurarColumna("ID_ASISTENCIA", "ID ASISTENCIA");
                ConfigurarColumna("ID_INSCRIPCION", "ID INSCRIPCIÓN");
                ConfigurarColumna("ID_CREDENCIAL", "ID CREDENCIAL");
                ConfigurarColumna("ID_MIEMBRO", "ID MIEMBRO");
                ConfigurarColumna("MIEMBRO", "MIEMBRO");
                ConfigurarColumna("CI", "CI");
                ConfigurarColumna("FECHA", "FECHA");
                ConfigurarColumna("HORA_ENTRADA", "HORA ENTRADA");
                ConfigurarColumna("ESTADO_INSCRIPCION", "ESTADO INSCRIPCIÓN");
                ConfigurarColumna("ESTADO_CREDENCIAL", "ESTADO CREDENCIAL");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las asistencias:\n" + ex.Message,
                    "SPARTANFIT", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarColumna(string nombre, string encabezado)
        {
            if (dgvAsistencias.Columns.Contains(nombre))
                dgvAsistencias.Columns[nombre].HeaderText = encabezado;
        }

        private void LimpiarCampos()
        {
            txtIdAsistencia.Clear();

            if (cmbInscripcion.DataSource != null)
                cmbInscripcion.SelectedIndex = -1;

            if (cmbCredencial.DataSource != null)
                cmbCredencial.SelectedIndex = -1;

            dtpFecha.Value = DateTime.Today;
            dtpHoraEntrada.Value = DateTime.Now;

            dgvAsistencias.ClearSelection();
        }

        private bool ValidarCampos()
        {
            if (cmbInscripcion.SelectedIndex == -1 ||
                cmbInscripcion.SelectedValue == null)
            {
                MessageBox.Show("Seleccione una inscripción.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbInscripcion.Focus();
                return false;
            }

            if (cmbCredencial.SelectedIndex == -1 ||
                cmbCredencial.SelectedValue == null)
            {
                MessageBox.Show("Seleccione una credencial.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCredencial.Focus();
                return false;
            }

            return true;
        }

        private Asistencia ObtenerAsistencia()
        {
            Asistencia asistencia = new Asistencia();

            if (!string.IsNullOrWhiteSpace(txtIdAsistencia.Text))
                asistencia.Id = Convert.ToInt32(txtIdAsistencia.Text);

            asistencia.IdInscripcion =
                Convert.ToInt32(cmbInscripcion.SelectedValue);

            asistencia.IdCredencial =
                Convert.ToInt32(cmbCredencial.SelectedValue);

            asistencia.Fecha = dtpFecha.Value.Date;
            asistencia.HoraEntrada = dtpHoraEntrada.Value.TimeOfDay;

            return asistencia;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            Asistencia asistencia = ObtenerAsistencia();

            string mensaje;

            if (AsistenciaControlador.Registrar(asistencia, out mensaje))
            {
                MessageBox.Show("Asistencia registrada correctamente.",
                    "SPARTANFIT", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarAsistencias();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("No se pudo registrar la asistencia:\n" + mensaje,
                    "SPARTANFIT", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdAsistencia.Text))
            {
                MessageBox.Show("Seleccione una asistencia de la tabla.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidarCampos())
                return;

            Asistencia asistencia = ObtenerAsistencia();

            string mensaje;

            if (AsistenciaControlador.Actualizar(asistencia, out mensaje))
            {
                MessageBox.Show("Asistencia actualizada correctamente.",
                    "SPARTANFIT", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarAsistencias();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("No se pudo actualizar la asistencia:\n" + mensaje,
                    "SPARTANFIT", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdAsistencia.Text))
            {
                MessageBox.Show("Seleccione una asistencia de la tabla.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Está seguro de que desea eliminar esta asistencia?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
                return;

            int id = Convert.ToInt32(txtIdAsistencia.Text);

            string mensaje;

            if (AsistenciaControlador.Eliminar(id, out mensaje))
            {
                MessageBox.Show("Asistencia eliminada correctamente.",
                    "SPARTANFIT", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarAsistencias();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("No se pudo eliminar la asistencia:\n" + mensaje,
                    "SPARTANFIT", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void dgvAsistencias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            try
            {
                DataGridViewRow fila = dgvAsistencias.Rows[e.RowIndex];

                txtIdAsistencia.Text =
                    fila.Cells["ID_ASISTENCIA"].Value.ToString();

                int idInscripcion =
                    Convert.ToInt32(fila.Cells["ID_INSCRIPCION"].Value);

                int idCredencial =
                    Convert.ToInt32(fila.Cells["ID_CREDENCIAL"].Value);

                cmbInscripcion.SelectedValue = idInscripcion;
                cmbCredencial.SelectedValue = idCredencial;

                if (fila.Cells["FECHA"].Value != DBNull.Value)
                {
                    dtpFecha.Value =
                        Convert.ToDateTime(fila.Cells["FECHA"].Value);
                }

                if (fila.Cells["HORA_ENTRADA"].Value != DBNull.Value)
                {
                    object valorHora = fila.Cells["HORA_ENTRADA"].Value;

                    if (valorHora is TimeSpan)
                    {
                        dtpHoraEntrada.Value =
                            DateTime.Today.Add((TimeSpan)valorHora);
                    }
                    else
                    {
                        dtpHoraEntrada.Value =
                            Convert.ToDateTime(valorHora);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar la asistencia:\n" + ex.Message,
                    "SPARTANFIT", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
