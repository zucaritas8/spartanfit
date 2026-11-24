
using System;
using System.Data;
using System.Windows.Forms;
using SPARTANFIT.CONTROLADOR;
using SPARTANFIT.MODELO;

namespace SPARTANFIT.VISTA
{
    public partial class FrmObjetivos : Form
    {
        public FrmObjetivos()
        {
            InitializeComponent();

            ConfigurarFormulario();
            CargarMiembros();
            CargarObjetivos();
            LimpiarCampos();
        }

        private void ConfigurarFormulario()
        {
            btnNuevo.Click += btnNuevo_Click;
            btnRegistrar.Click += btnRegistrar_Click;
            btnEditar.Click += btnEditar_Click;
            btnEliminar.Click += btnEliminar_Click;
            btnCancelar.Click += btnCancelar_Click;

            dgvObjetivos.AutoGenerateColumns = true;
            dgvObjetivos.SelectionChanged += dgvObjetivos_SelectionChanged;

            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private void CargarMiembros()
        {
            try
            {
                DataTable tabla = MiembroControlador.Listar("");

                cmbMiembro.DataSource = tabla;
                cmbMiembro.DisplayMember = "NOMBRE_COMPLETO";
                cmbMiembro.ValueMember = "ID_MIEMBRO";
                cmbMiembro.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los miembros: " + ex.Message,
                    "SPARTANFIT", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarObjetivos()
        {
            try
            {
                dgvObjetivos.DataSource = ObjetivoControlador.Listar("");

                if (dgvObjetivos.Columns.Contains("ID_OBJETIVO"))
                {
                    dgvObjetivos.Columns["ID_OBJETIVO"].HeaderText = "ID";
                    dgvObjetivos.Columns["ID_OBJETIVO"].Width = 45;
                }

                if (dgvObjetivos.Columns.Contains("ID_MIEMBRO"))
                    dgvObjetivos.Columns["ID_MIEMBRO"].Visible = false;

                if (dgvObjetivos.Columns.Contains("MIEMBRO"))
                    dgvObjetivos.Columns["MIEMBRO"].HeaderText = "MIEMBRO";

                if (dgvObjetivos.Columns.Contains("TIPO"))
                    dgvObjetivos.Columns["TIPO"].HeaderText = "TIPO";

                if (dgvObjetivos.Columns.Contains("DESCRIPCION"))
                    dgvObjetivos.Columns["DESCRIPCION"].HeaderText = "DESCRIPCIÓN";

                if (dgvObjetivos.Columns.Contains("VALOR_INICIAL"))
                    dgvObjetivos.Columns["VALOR_INICIAL"].HeaderText = "VALOR INICIAL";

                if (dgvObjetivos.Columns.Contains("VALOR_META"))
                    dgvObjetivos.Columns["VALOR_META"].HeaderText = "VALOR META";

                if (dgvObjetivos.Columns.Contains("UNIDAD"))
                    dgvObjetivos.Columns["UNIDAD"].HeaderText = "UNIDAD";

                if (dgvObjetivos.Columns.Contains("FECHA_INICIO"))
                    dgvObjetivos.Columns["FECHA_INICIO"].HeaderText = "FECHA INICIO";

                if (dgvObjetivos.Columns.Contains("FECHA_FIN"))
                    dgvObjetivos.Columns["FECHA_FIN"].HeaderText = "FECHA FIN";

                dgvObjetivos.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los objetivos: " + ex.Message,
                    "SPARTANFIT", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarDatos()
        {
            if (cmbMiembro.SelectedValue == null ||
                cmbTipo.SelectedIndex == -1 ||
                cmbUnidad.SelectedIndex == -1)
            {
                MessageBox.Show("Selecciona un miembro, tipo y unidad.",
                    "SPARTANFIT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (numValorInicial.Value <= 0 || numValorMeta.Value <= 0)
            {
                MessageBox.Show("Los valores deben ser mayores que cero.",
                    "SPARTANFIT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (numValorMeta.Value <= numValorInicial.Value)
            {
                MessageBox.Show("El valor meta debe ser mayor que el valor inicial.",
                    "SPARTANFIT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dtpFechaFin.Checked &&
                dtpFechaFin.Value.Date < dtpFechaInicio.Value.Date)
            {
                MessageBox.Show("La fecha final no puede ser anterior a la fecha inicial.",
                    "SPARTANFIT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private Objetivo ObtenerObjetivo()
        {
            return new Objetivo
            {
                Id = string.IsNullOrWhiteSpace(txtIdObjetivo.Text)
                    ? 0
                    : Convert.ToInt32(txtIdObjetivo.Text),

                IdMiembro = Convert.ToInt32(cmbMiembro.SelectedValue),
                Tipo = cmbTipo.Text,
                Descripcion = txtDescripcion.Text.Trim(),
                ValorInicial = numValorInicial.Value,
                ValorMeta = numValorMeta.Value,
                Unidad = cmbUnidad.Text,
                FechaInicio = dtpFechaInicio.Value.Date,
                FechaFin = dtpFechaFin.Checked
                    ? (DateTime?)dtpFechaFin.Value.Date
                    : null
            };
        }

        private void RegistrarObjetivo()
        {
            if (!ValidarDatos())
                return;

            string mensaje;

            if (ObjetivoControlador.Registrar(ObtenerObjetivo(), out mensaje))
            {
                MessageBox.Show("Objetivo registrado correctamente.",
                    "SPARTANFIT", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarObjetivos();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("No se pudo registrar el objetivo:\n" + mensaje,
                    "SPARTANFIT", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditarObjetivo()
        {
            if (string.IsNullOrWhiteSpace(txtIdObjetivo.Text))
            {
                MessageBox.Show("Selecciona un objetivo de la lista.",
                    "SPARTANFIT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidarDatos())
                return;

            string mensaje;

            if (ObjetivoControlador.Actualizar(ObtenerObjetivo(), out mensaje))
            {
                MessageBox.Show("Objetivo actualizado correctamente.",
                    "SPARTANFIT", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarObjetivos();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("No se pudo actualizar el objetivo:\n" + mensaje,
                    "SPARTANFIT", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EliminarObjetivo()
        {
            if (string.IsNullOrWhiteSpace(txtIdObjetivo.Text))
            {
                MessageBox.Show("Selecciona un objetivo de la lista.",
                    "SPARTANFIT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Estás seguro de que deseas desactivar este objetivo?",
                "Confirmar operación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
                return;

            string mensaje;
            int id = Convert.ToInt32(txtIdObjetivo.Text);

            if (ObjetivoControlador.Eliminar(id, out mensaje))
            {
                MessageBox.Show("Objetivo eliminado correctamente.",
                    "SPARTANFIT", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarObjetivos();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("No se pudo eliminar el objetivo:\n" + mensaje,
                    "SPARTANFIT", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            txtIdObjetivo.Clear();

            cmbMiembro.SelectedIndex = -1;
            cmbTipo.SelectedIndex = -1;
            cmbUnidad.SelectedIndex = -1;

            txtDescripcion.Clear();

            numValorInicial.Value = 0;
            numValorMeta.Value = 0;

            dtpFechaInicio.Value = DateTime.Today;
            dtpFechaFin.Value = DateTime.Today;
            dtpFechaFin.Checked = false;

            dgvObjetivos.ClearSelection();

            btnRegistrar.Enabled = true;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;

            cmbMiembro.Focus();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            RegistrarObjetivo();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            EditarObjetivo();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarObjetivo();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void dgvObjetivos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvObjetivos.CurrentRow == null ||
                dgvObjetivos.CurrentRow.IsNewRow ||
                dgvObjetivos.CurrentRow.Cells["ID_OBJETIVO"].Value == null)
                return;

            DataGridViewRow fila = dgvObjetivos.CurrentRow;

            txtIdObjetivo.Text = Convert.ToString(
                fila.Cells["ID_OBJETIVO"].Value);

            cmbMiembro.SelectedValue = Convert.ToInt32(
                fila.Cells["ID_MIEMBRO"].Value);

            cmbTipo.Text = Convert.ToString(
                fila.Cells["TIPO"].Value);

            cmbUnidad.Text = Convert.ToString(
                fila.Cells["UNIDAD"].Value);

            txtDescripcion.Text =
                fila.Cells["DESCRIPCION"].Value == DBNull.Value
                    ? ""
                    : Convert.ToString(fila.Cells["DESCRIPCION"].Value);

            numValorInicial.Value =
                fila.Cells["VALOR_INICIAL"].Value == DBNull.Value
                    ? 0
                    : Convert.ToDecimal(fila.Cells["VALOR_INICIAL"].Value);

            numValorMeta.Value =
                fila.Cells["VALOR_META"].Value == DBNull.Value
                    ? 0
                    : Convert.ToDecimal(fila.Cells["VALOR_META"].Value);

            dtpFechaInicio.Value = Convert.ToDateTime(
                fila.Cells["FECHA_INICIO"].Value);

            if (fila.Cells["FECHA_FIN"].Value == DBNull.Value)
            {
                dtpFechaFin.Value = DateTime.Today;
                dtpFechaFin.Checked = false;
            }
            else
            {
                dtpFechaFin.Value = Convert.ToDateTime(
                    fila.Cells["FECHA_FIN"].Value);

                dtpFechaFin.Checked = true;
            }

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

        private void lblDescripcion_Click(object sender, EventArgs e) { }
        private void lblValorInicial_Click(object sender, EventArgs e) { }
        private void lblValorMeta_Click(object sender, EventArgs e) { }
        private void lblFechaInicio_Click(object sender, EventArgs e) { }
        private void lblFechaFin_Click(object sender, EventArgs e) { }
        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e) { }
        private void txtDescripcion_TextChanged(object sender, EventArgs e) { }
        private void numValorInicial_ValueChanged(object sender, EventArgs e) { }
        private void numValorMeta_ValueChanged(object sender, EventArgs e) { }
        private void dtpFechaInicio_ValueChanged(object sender, EventArgs e) { }
        private void dtpFechaFin_ValueChanged(object sender, EventArgs e) { }
    }
}
