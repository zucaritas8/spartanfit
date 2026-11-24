
using System;
using System.Data;
using System.Windows.Forms;
using SPARTANFIT.CONTROLADOR;
using SPARTANFIT.MODELO;

namespace SPARTANFIT.VISTA
{
    public partial class FrmRutinas : Form
    {
        private DataTable ejerciciosPendientes;
        private bool cargandoDatos;

        public FrmRutinas()
        {
            InitializeComponent();

            btnNuevo.Click += btnNuevo_Click;
            btnRegistrar.Click += btnRegistrar_Click;
            btnEditar.Click += btnEditar_Click;
            btnEliminar.Click += btnEliminar_Click;
            btnCancelar.Click += btnCancelar_Click;

            dgvRutinas.SelectionChanged += dgvRutinas_SelectionChanged;
            cmbEjercicio.SelectionChangeCommitted += cmbEjercicio_SelectionChangeCommitted;
            dgvRutinaEjercicios.KeyDown += dgvRutinaEjercicios_KeyDown;

            CrearTablaEjercicios();
            CargarCoaches();
            CargarEjercicios();
            CargarRutinas();
            LimpiarCampos();
        }

        private void CrearTablaEjercicios()
        {
            ejerciciosPendientes = new DataTable();
            ejerciciosPendientes.Columns.Add("ID_EJERCICIO", typeof(int));
            ejerciciosPendientes.Columns.Add("EJERCICIO", typeof(string));
            ejerciciosPendientes.Columns.Add("NUMERO_SERIES", typeof(int));
            ejerciciosPendientes.Columns.Add("ORDEN", typeof(int));
            ejerciciosPendientes.Columns.Add("REPETICIONES", typeof(int));
            ejerciciosPendientes.Columns.Add("GUARDADO", typeof(bool));

            dgvRutinaEjercicios.DataSource = ejerciciosPendientes;

            if (dgvRutinaEjercicios.Columns.Contains("GUARDADO"))
                dgvRutinaEjercicios.Columns["GUARDADO"].Visible = false;
        }

        private void CargarCoaches()
        {
            cmbCoach.DataSource = CoachControlador.Listar();
            cmbCoach.DisplayMember = "COACH";
            cmbCoach.ValueMember = "ID_COACH";
            cmbCoach.SelectedIndex = -1;
        }

        private void CargarEjercicios()
        {
            cmbEjercicio.DataSource = EjercicioControlador.Listar();
            cmbEjercicio.DisplayMember = "NOMBRE";
            cmbEjercicio.ValueMember = "ID_EJERCICIO";
            cmbEjercicio.SelectedIndex = -1;
        }

        private void CargarRutinas()
        {
            dgvRutinas.DataSource = RutinaControlador.Listar();
            dgvRutinas.ClearSelection();
        }

        private Rutina ObtenerRutina()
        {
            int id;
            int.TryParse(txtIdRutina.Text, out id);

            return new Rutina
            {
                Id = id,
                IdCoach = cmbCoach.SelectedValue == null ? 0 : Convert.ToInt32(cmbCoach.SelectedValue),
                Nombre = txtNombre.Text.Trim(),
                Tiempo = Convert.ToInt32(numTiempo.Value),
                UnidadTiempo = cmbUnidadTiempo.Text.Trim(),
                Descripcion = txtDescripcion.Text.Trim()
            };
        }

        private bool ValidarRutina()
        {
            if (cmbCoach.SelectedValue == null)
            {
                MessageBox.Show("Selecciona un coach.", "SPARTANFIT",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Escribe el nombre de la rutina.", "SPARTANFIT",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }

            if (cmbUnidadTiempo.SelectedIndex == -1)
            {
                MessageBox.Show("Selecciona la unidad de tiempo.", "SPARTANFIT",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool GuardarEjercicios(int idRutina, out string mensaje)
        {
            mensaje = "";

            foreach (DataRow fila in ejerciciosPendientes.Rows)
            {
                if (Convert.ToBoolean(fila["GUARDADO"]))
                    continue;

                RutinaEjercicio detalle = new RutinaEjercicio
                {
                    IdRutina = idRutina,
                    IdEjercicio = Convert.ToInt32(fila["ID_EJERCICIO"]),
                    NumeroSeries = Convert.ToInt32(fila["NUMERO_SERIES"]),
                    Orden = Convert.ToInt32(fila["ORDEN"]),
                    Repeticiones = Convert.ToInt32(fila["REPETICIONES"])
                };

                if (!RutinaControlador.GuardarEjercicio(detalle, out mensaje))
                    return false;

                fila["GUARDADO"] = true;
            }

            return true;
        }

        private void cmbEjercicio_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbEjercicio.SelectedValue == null)
                return;

            int idEjercicio = Convert.ToInt32(cmbEjercicio.SelectedValue);

            foreach (DataRow fila in ejerciciosPendientes.Rows)
            {
                if (Convert.ToInt32(fila["ID_EJERCICIO"]) == idEjercicio)
                {
                    MessageBox.Show("Ese ejercicio ya está agregado.", "SPARTANFIT",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            ejerciciosPendientes.Rows.Add(
                idEjercicio,
                cmbEjercicio.Text,
                Convert.ToInt32(numNumeroSeries.Value),
                Convert.ToInt32(numOrden.Value),
                Convert.ToInt32(numRepeticiones.Value),
                false
            );

            cmbEjercicio.SelectedIndex = -1;
        }

        private void dgvRutinaEjercicios_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete || dgvRutinaEjercicios.CurrentRow == null)
                return;

            int indice = dgvRutinaEjercicios.CurrentRow.Index;

            if (indice < 0 || indice >= ejerciciosPendientes.Rows.Count)
                return;

            DataRow fila = ejerciciosPendientes.Rows[indice];

            if (Convert.ToBoolean(fila["GUARDADO"]))
            {
                int idRutina;
                if (!int.TryParse(txtIdRutina.Text, out idRutina) || idRutina <= 0)
                    return;

                string mensaje;

                if (!RutinaControlador.QuitarEjercicio(
                    idRutina,
                    Convert.ToInt32(fila["ID_EJERCICIO"]),
                    out mensaje))
                {
                    MessageBox.Show(mensaje, "SPARTANFIT",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            ejerciciosPendientes.Rows.RemoveAt(indice);
            e.Handled = true;
        }

        private void LimpiarCampos()
        {
            cargandoDatos = true;

            txtIdRutina.Clear();
            cmbCoach.SelectedIndex = -1;
            txtNombre.Clear();
            numTiempo.Value = 0;
            cmbUnidadTiempo.SelectedIndex = 0;
            txtDescripcion.Clear();
            cmbEjercicio.SelectedIndex = -1;

            ejerciciosPendientes.Rows.Clear();
            dgvRutinas.ClearSelection();

            cargandoDatos = false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (!ValidarRutina())
                return;

            string mensaje;
            Rutina rutina = ObtenerRutina();

            if (!RutinaControlador.Registrar(rutina, out mensaje))
            {
                MessageBox.Show(mensaje, "SPARTANFIT",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CargarRutinas();

            foreach (DataGridViewRow fila in dgvRutinas.Rows)
            {
                if (Convert.ToString(fila.Cells["NOMBRE"].Value) == rutina.Nombre &&
                    Convert.ToInt32(fila.Cells["ID_COACH"].Value) == rutina.IdCoach)
                {
                    int candidato = Convert.ToInt32(fila.Cells["ID_RUTINA"].Value);

                    if (candidato > rutina.Id)
                        rutina.Id = candidato;
                }
            }

            if (rutina.Id <= 0)
            {
                MessageBox.Show(
                    "La rutina se registró, pero no se pudo identificar su ID para guardar los ejercicios.",
                    "SPARTANFIT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool ejerciciosGuardados = GuardarEjercicios(rutina.Id, out mensaje);

            CargarRutinas();

            if (ejerciciosGuardados)
            {
                MessageBox.Show("Rutina registrada correctamente.", "SPARTANFIT",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show(
                    "La rutina se registró, pero hubo un problema al guardar sus ejercicios: " + mensaje,
                    "SPARTANFIT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!ValidarRutina())
                return;

            int id;

            if (!int.TryParse(txtIdRutina.Text, out id) || id <= 0)
            {
                MessageBox.Show("Selecciona una rutina.", "SPARTANFIT",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string mensaje;
            Rutina rutina = ObtenerRutina();

            if (!RutinaControlador.Actualizar(rutina, out mensaje))
            {
                MessageBox.Show(mensaje, "SPARTANFIT",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool ejerciciosGuardados = GuardarEjercicios(id, out mensaje);

            CargarRutinas();

            if (ejerciciosGuardados)
            {
                MessageBox.Show("Rutina actualizada correctamente.", "SPARTANFIT",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show(
                    "La rutina se actualizó, pero hubo un problema al guardar los ejercicios: " + mensaje,
                    "SPARTANFIT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id;

            if (!int.TryParse(txtIdRutina.Text, out id) || id <= 0)
            {
                MessageBox.Show("Selecciona una rutina.", "SPARTANFIT",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Eliminar esta rutina y sus ejercicios asociados?",
                "SPARTANFIT",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
                return;

            string mensaje;

            if (RutinaControlador.Eliminar(id, out mensaje))
            {
                CargarRutinas();
                LimpiarCampos();

                MessageBox.Show("Rutina eliminada correctamente.", "SPARTANFIT",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(mensaje, "SPARTANFIT",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvRutinas_SelectionChanged(object sender, EventArgs e)
        {
            if (cargandoDatos || dgvRutinas.CurrentRow == null)
                return;

            if (!(dgvRutinas.CurrentRow.DataBoundItem is DataRowView))
                return;

            DataRowView fila = (DataRowView)dgvRutinas.CurrentRow.DataBoundItem;

            cargandoDatos = true;

            txtIdRutina.Text = fila["ID_RUTINA"].ToString();

            cmbCoach.SelectedValue = Convert.ToInt32(fila["ID_COACH"]);

            txtNombre.Text = fila["NOMBRE"].ToString();

            numTiempo.Value = fila["TIEMPO"] == DBNull.Value
                ? 0
                : Math.Max(numTiempo.Minimum,
                    Math.Min(numTiempo.Maximum, Convert.ToDecimal(fila["TIEMPO"])));

            string unidad = fila["UNIDAD_TIEMPO"] == DBNull.Value
                ? "MINUTOS"
                : fila["UNIDAD_TIEMPO"].ToString();

            cmbUnidadTiempo.SelectedItem = unidad;

            if (cmbUnidadTiempo.SelectedIndex == -1)
                cmbUnidadTiempo.SelectedIndex = 0;

            txtDescripcion.Text = fila["DESCRIPCION"] == DBNull.Value
                ? ""
                : fila["DESCRIPCION"].ToString();

            ejerciciosPendientes.Rows.Clear();

            DataTable detalle = RutinaControlador.ListarEjercicios(
                Convert.ToInt32(fila["ID_RUTINA"]));

            foreach (DataRow item in detalle.Rows)
            {
                ejerciciosPendientes.Rows.Add(
                    Convert.ToInt32(item["ID_EJERCICIO"]),
                    item["NOMBRE"].ToString(),
                    item["NUMERO_SERIES"] == DBNull.Value
                        ? 1 : Convert.ToInt32(item["NUMERO_SERIES"]),
                    Convert.ToInt32(item["ORDEN"]),
                    item["REPETICIONES"] == DBNull.Value
                        ? 1 : Convert.ToInt32(item["REPETICIONES"]),
                    true
                );
            }

            cargandoDatos = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmMenuPrincipal menu = new FrmMenuPrincipal();
            menu.Show();
            this.Hide();
        }
    }
}
