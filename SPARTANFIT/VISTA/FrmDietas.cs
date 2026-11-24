
using System;
using System.Data;
using System.Windows.Forms;
using SPARTANFIT.MODELO;
using SPARTANFIT.CONTROLADOR;

namespace SPARTANFIT.VISTA
{
    public partial class FrmDietas : Form
    {
        private int idDetalleSeleccionado = 0;

        public FrmDietas()
        {
            InitializeComponent();

            btnNuevo.Click += btnNuevo_Click;
            btnRegistrar.Click += btnRegistrar_Click;
            btnEditar.Click += btnEditar_Click;
            btnEliminar.Click += btnEliminar_Click;
            btnCancelar.Click += btnCancelar_Click;

            dgvDietas.CellClick += dgvDietas_CellClick;
            dgvDietaDetalle.CellClick += dgvDietaDetalle_CellClick;
            dgvDietaDetalle.KeyDown += dgvDietaDetalle_KeyDown;

            ConfigurarFormulario();
            CargarMiembros();
            CargarCoaches();
            CargarDietas();
            LimpiarFormulario();
        }

        private void ConfigurarFormulario()
        {
            txtIdDieta.ReadOnly = true;

            dgvDietas.AutoGenerateColumns = true;
            dgvDietas.ReadOnly = true;
            dgvDietas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDietas.MultiSelect = false;
            dgvDietas.AllowUserToAddRows = false;
            dgvDietas.AllowUserToDeleteRows = false;

            dgvDietaDetalle.AutoGenerateColumns = true;
            dgvDietaDetalle.ReadOnly = true;
            dgvDietaDetalle.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDietaDetalle.MultiSelect = false;
            dgvDietaDetalle.AllowUserToAddRows = false;
            dgvDietaDetalle.AllowUserToDeleteRows = false;

            dtpFechaFin.Checked = false;

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
                        string ci = fila["CI"] == DBNull.Value
                            ? ""
                            : fila["CI"].ToString();

                        string nombre = fila["NOMBRE"] == DBNull.Value
                            ? ""
                            : fila["NOMBRE"].ToString();

                        string apellido = fila["APELLIDO"] == DBNull.Value
                            ? ""
                            : fila["APELLIDO"].ToString();

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
                    MessageBoxIcon.Error);
            }
        }

        private void CargarCoaches()
        {
            try
            {
                DataTable tabla = CoachControlador.Listar();

                if (!tabla.Columns.Contains("NOMBRE_COMPLETO"))
                {
                    tabla.Columns.Add("NOMBRE_COMPLETO", typeof(string));

                    foreach (DataRow fila in tabla.Rows)
                    {
                        string nombre = fila["NOMBRE"] == DBNull.Value
                            ? ""
                            : fila["NOMBRE"].ToString();

                        string apellido = fila["APELLIDO"] == DBNull.Value
                            ? ""
                            : fila["APELLIDO"].ToString();

                        fila["NOMBRE_COMPLETO"] =
                            nombre + " " + apellido;
                    }
                }

                DataTable coaches = tabla.Clone();

                DataRow sinCoach = coaches.NewRow();
                sinCoach["ID_COACH"] = 0;
                sinCoach["NOMBRE_COMPLETO"] = "SIN COACH";
                coaches.Rows.Add(sinCoach);

                foreach (DataRow fila in tabla.Rows)
                {
                    coaches.ImportRow(fila);
                }

                cmbCoach.DataSource = coaches;
                cmbCoach.DisplayMember = "NOMBRE_COMPLETO";
                cmbCoach.ValueMember = "ID_COACH";
                cmbCoach.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar los coaches: " + ex.Message,
                    "SPARTANFIT",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void CargarDietas()
        {
            try
            {
                dgvDietas.DataSource = DietaControlador.Listar();

                if (dgvDietas.Columns.Contains("ID_DIETA"))
                    dgvDietas.Columns["ID_DIETA"].HeaderText = "ID";

                if (dgvDietas.Columns.Contains("MIEMBRO"))
                    dgvDietas.Columns["MIEMBRO"].HeaderText = "MIEMBRO";

                if (dgvDietas.Columns.Contains("COACH"))
                    dgvDietas.Columns["COACH"].HeaderText = "COACH";

                if (dgvDietas.Columns.Contains("FECHA_INICIO"))
                    dgvDietas.Columns["FECHA_INICIO"].HeaderText = "INICIO";

                if (dgvDietas.Columns.Contains("FECHA_FIN"))
                    dgvDietas.Columns["FECHA_FIN"].HeaderText = "FIN";

                if (dgvDietas.Columns.Contains("DESCRIPCION"))
                    dgvDietas.Columns["DESCRIPCION"].HeaderText = "DESCRIPCIÓN";

                if (dgvDietas.Columns.Contains("ID_MIEMBRO"))
                    dgvDietas.Columns["ID_MIEMBRO"].Visible = false;

                if (dgvDietas.Columns.Contains("ID_COACH"))
                    dgvDietas.Columns["ID_COACH"].Visible = false;

                if (dgvDietas.Columns.Contains("CARBOHIDRATOS_DIARIOS"))
                    dgvDietas.Columns["CARBOHIDRATOS_DIARIOS"].HeaderText = "CARBOHIDRATOS";

                if (dgvDietas.Columns.Contains("CALORIAS_DIARIAS"))
                    dgvDietas.Columns["CALORIAS_DIARIAS"].HeaderText = "CALORÍAS";

                if (dgvDietas.Columns.Contains("PROTEINAS_DIARIAS"))
                    dgvDietas.Columns["PROTEINAS_DIARIAS"].HeaderText = "PROTEÍNAS";

                if (dgvDietas.Columns.Contains("GRASAS_TOTALES"))
                    dgvDietas.Columns["GRASAS_TOTALES"].HeaderText = "GRASAS";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar las dietas: " + ex.Message,
                    "SPARTANFIT",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void CargarDetalles(int idDieta)
        {
            try
            {
                dgvDietaDetalle.DataSource =
                    DietaControlador.ListarDetalles(idDieta);

                if (dgvDietaDetalle.Columns.Contains("ID_DETALLE"))
                    dgvDietaDetalle.Columns["ID_DETALLE"].HeaderText = "ID";

                if (dgvDietaDetalle.Columns.Contains("ID_DIETA"))
                    dgvDietaDetalle.Columns["ID_DIETA"].Visible = false;

                if (dgvDietaDetalle.Columns.Contains("TIEMPO_COMIDA"))
                    dgvDietaDetalle.Columns["TIEMPO_COMIDA"].HeaderText = "COMIDA";

                if (dgvDietaDetalle.Columns.Contains("DESCRIPCION"))
                    dgvDietaDetalle.Columns["DESCRIPCION"].HeaderText = "DESCRIPCIÓN";

                idDetalleSeleccionado = 0;
                txtDescripcionDetalle.Clear();
                cmbTiempoComida.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar los detalles: " + ex.Message,
                    "SPARTANFIT",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LimpiarFormulario()
        {
            txtIdDieta.Clear();

            cmbMiembro.SelectedIndex = -1;

            if (cmbCoach.Items.Count > 0)
                cmbCoach.SelectedIndex = 0;

            dtpFechaInicio.Value = DateTime.Today;
            dtpFechaFin.Value = DateTime.Today;
            dtpFechaFin.Checked = false;

            numCarbohidratos.Value = 0;
            numCalorias.Value = 0;
            numProteinas.Value = 0;
            numGrasas.Value = 0;

            txtDescripcion.Clear();
            txtDescripcionDetalle.Clear();

            cmbTiempoComida.SelectedIndex = -1;

            idDetalleSeleccionado = 0;

            dgvDietaDetalle.DataSource = null;

            btnRegistrar.Enabled = true;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private bool ValidarFormulario()
        {
            if (cmbMiembro.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione un miembro.");
                cmbMiembro.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("Ingrese la descripción de la dieta.");
                txtDescripcion.Focus();
                return false;
            }

            if (dtpFechaFin.Checked &&
                dtpFechaFin.Value.Date < dtpFechaInicio.Value.Date)
            {
                MessageBox.Show(
                    "La fecha de finalización no puede ser anterior a la fecha de inicio.");
                return false;
            }

            return true;
        }

        private Dieta ObtenerDieta()
        {
            Dieta dieta = new Dieta();

            if (!string.IsNullOrWhiteSpace(txtIdDieta.Text))
                dieta.Id = Convert.ToInt32(txtIdDieta.Text);

            dieta.IdMiembro = Convert.ToInt32(cmbMiembro.SelectedValue);

            int idCoach = Convert.ToInt32(cmbCoach.SelectedValue);

            dieta.IdCoach = idCoach > 0 ? (int?)idCoach : null;

            dieta.FechaInicio = dtpFechaInicio.Value.Date;

            dieta.FechaFin = dtpFechaFin.Checked
                ? (DateTime?)dtpFechaFin.Value.Date
                : null;

            dieta.Descripcion = txtDescripcion.Text.Trim();

            dieta.CarbohidratosDiarios =
                Convert.ToInt32(numCarbohidratos.Value) > 0
                ? (int?)Convert.ToInt32(numCarbohidratos.Value)
                : null;

            dieta.CaloriasDiarias =
                Convert.ToInt32(numCalorias.Value) > 0
                ? (int?)Convert.ToInt32(numCalorias.Value)
                : null;

            dieta.ProteinasDiarias =
                Convert.ToInt32(numProteinas.Value) > 0
                ? (int?)Convert.ToInt32(numProteinas.Value)
                : null;

            dieta.GrasasTotales =
                Convert.ToInt32(numGrasas.Value) > 0
                ? (int?)Convert.ToInt32(numGrasas.Value)
                : null;

            return dieta;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            cmbMiembro.Focus();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario())
                return;

            try
            {
                Dieta dieta = ObtenerDieta();
                string mensaje;

                if (DietaControlador.Registrar(dieta, out mensaje))
                {
                    MessageBox.Show(
                        "Dieta registrada correctamente.",
                        "SPARTANFIT",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    CargarDietas();
                    LimpiarFormulario();
                }
                else
                {
                    MessageBox.Show(
                        mensaje,
                        "Error al registrar",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error: " + ex.Message,
                    "SPARTANFIT",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdDieta.Text))
            {
                MessageBox.Show("Seleccione una dieta para editar.");
                return;
            }

            if (!ValidarFormulario())
                return;

            try
            {
                Dieta dieta = ObtenerDieta();
                string mensaje;

                if (DietaControlador.Actualizar(dieta, out mensaje))
                {
                    MessageBox.Show(
                        "Dieta actualizada correctamente.",
                        "SPARTANFIT",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    CargarDietas();
                    LimpiarFormulario();
                }
                else
                {
                    MessageBox.Show(
                        mensaje,
                        "Error al actualizar",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error: " + ex.Message,
                    "SPARTANFIT",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdDieta.Text))
            {
                MessageBox.Show("Seleccione una dieta para eliminar.");
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Está seguro de eliminar esta dieta y todos sus detalles?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (respuesta != DialogResult.Yes)
                return;

            try
            {
                int id = Convert.ToInt32(txtIdDieta.Text);
                string mensaje;

                if (DietaControlador.Eliminar(id, out mensaje))
                {
                    MessageBox.Show(
                        "Dieta eliminada correctamente.",
                        "SPARTANFIT",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    CargarDietas();
                    LimpiarFormulario();
                }
                else
                {
                    MessageBox.Show(
                        mensaje,
                        "Error al eliminar",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error: " + ex.Message,
                    "SPARTANFIT",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void dgvDietas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            try
            {
                DataGridViewRow fila = dgvDietas.Rows[e.RowIndex];

                txtIdDieta.Text =
                    fila.Cells["ID_DIETA"].Value.ToString();

                cmbMiembro.SelectedValue =
                    Convert.ToInt32(fila.Cells["ID_MIEMBRO"].Value);

                object valorCoach = fila.Cells["ID_COACH"].Value;

                if (valorCoach == null || valorCoach == DBNull.Value)
                    cmbCoach.SelectedValue = 0;
                else
                    cmbCoach.SelectedValue = Convert.ToInt32(valorCoach);

                dtpFechaInicio.Value =
                    Convert.ToDateTime(fila.Cells["FECHA_INICIO"].Value);

                object fechaFin = fila.Cells["FECHA_FIN"].Value;

                if (fechaFin == null || fechaFin == DBNull.Value)
                {
                    dtpFechaFin.Checked = false;
                }
                else
                {
                    dtpFechaFin.Value = Convert.ToDateTime(fechaFin);
                    dtpFechaFin.Checked = true;
                }

                txtDescripcion.Text =
                    fila.Cells["DESCRIPCION"].Value == DBNull.Value
                    ? ""
                    : fila.Cells["DESCRIPCION"].Value.ToString();

                numCarbohidratos.Value = ObtenerValorNumerico(
                    fila.Cells["CARBOHIDRATOS_DIARIOS"].Value,
                    numCarbohidratos);

                numCalorias.Value = ObtenerValorNumerico(
                    fila.Cells["CALORIAS_DIARIAS"].Value,
                    numCalorias);

                numProteinas.Value = ObtenerValorNumerico(
                    fila.Cells["PROTEINAS_DIARIAS"].Value,
                    numProteinas);

                numGrasas.Value = ObtenerValorNumerico(
                    fila.Cells["GRASAS_TOTALES"].Value,
                    numGrasas);

                btnRegistrar.Enabled = false;
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;

                CargarDetalles(Convert.ToInt32(txtIdDieta.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al seleccionar la dieta: " + ex.Message,
                    "SPARTANFIT",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private decimal ObtenerValorNumerico(object valor, NumericUpDown control)
        {
            if (valor == null || valor == DBNull.Value)
                return 0;

            decimal numero = Convert.ToDecimal(valor);

            if (numero < control.Minimum)
                return control.Minimum;

            if (numero > control.Maximum)
                return control.Maximum;

            return numero;
        }

        private void dgvDietaDetalle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            try
            {
                DataGridViewRow fila = dgvDietaDetalle.Rows[e.RowIndex];

                idDetalleSeleccionado =
                    Convert.ToInt32(fila.Cells["ID_DETALLE"].Value);

                cmbTiempoComida.SelectedItem =
                    fila.Cells["TIEMPO_COMIDA"].Value.ToString();

                txtDescripcionDetalle.Text =
                    fila.Cells["DESCRIPCION"].Value == DBNull.Value
                    ? ""
                    : fila.Cells["DESCRIPCION"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al seleccionar el detalle: " + ex.Message);
            }
        }

        private void dgvDietaDetalle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete)
                return;

            if (idDetalleSeleccionado <= 0)
                return;

            DialogResult respuesta = MessageBox.Show(
                "¿Desea eliminar este detalle de comida?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (respuesta != DialogResult.Yes)
                return;

            string mensaje;

            if (DietaControlador.EliminarDetalle(
                idDetalleSeleccionado, out mensaje))
            {
                MessageBox.Show("Detalle eliminado correctamente.");

                CargarDetalles(Convert.ToInt32(txtIdDieta.Text));
            }
            else
            {
                MessageBox.Show(mensaje, "Error");
            }

            e.Handled = true;
        }

        private void GuardarDetalle()
        {
            if (string.IsNullOrWhiteSpace(txtIdDieta.Text))
            {
                MessageBox.Show("Primero debe registrar o seleccionar una dieta.");
                return;
            }

            if (cmbTiempoComida.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione el tiempo de comida.");
                cmbTiempoComida.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDescripcionDetalle.Text))
            {
                MessageBox.Show("Ingrese la descripción del detalle.");
                txtDescripcionDetalle.Focus();
                return;
            }

            DietaDetalle detalle = new DietaDetalle();

            detalle.IdDieta = Convert.ToInt32(txtIdDieta.Text);
            detalle.TiempoComida = cmbTiempoComida.SelectedItem.ToString();
            detalle.Descripcion = txtDescripcionDetalle.Text.Trim();

            string mensaje;
            bool resultado;

            if (idDetalleSeleccionado > 0)
            {
                detalle.Id = idDetalleSeleccionado;

                resultado = DietaControlador.ActualizarDetalle(
                    detalle, out mensaje);
            }
            else
            {
                resultado = DietaControlador.GuardarDetalle(
                    detalle, out mensaje);
            }

            if (resultado)
            {
                MessageBox.Show(
                    "Detalle guardado correctamente.",
                    "SPARTANFIT",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarDetalles(detalle.IdDieta);
            }
            else
            {
                MessageBox.Show(
                    mensaje,
                    "Error al guardar el detalle",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void txtIdDieta_TextChanged(object sender, EventArgs e)
        {
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
