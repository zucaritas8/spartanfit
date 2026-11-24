using System;
using System.Data;
using System.Windows.Forms;
using SPARTANFIT.CONTROLADOR;
using SPARTANFIT.MODELO;

namespace SPARTANFIT.VISTA
{
    public partial class FrmSeguimiento : Form
    {
        public FrmSeguimiento()
        {
            InitializeComponent();
            btnNuevo.Click += btnNuevo_Click;
            btnRegistrar.Click += btnRegistrar_Click;
            btnEditar.Click += btnEditar_Click;
            btnEliminar.Click += btnEliminar_Click;
            btnCancelar.Click += btnCancelar_Click;
            dgvSeguimiento.SelectionChanged += dgvSeguimiento_SelectionChanged;
            CargarObjetivos(); CargarCoaches(); CargarSeguimiento();
        }

        private void CargarObjetivos()
        {
            DataTable tabla = ObjetivoControlador.Listar();
            if (!tabla.Columns.Contains("OBJETIVO_COMPLETO")) tabla.Columns.Add("OBJETIVO_COMPLETO", typeof(string), "TIPO + ' - ' + MIEMBRO");
            cmbObjetivo.DataSource = tabla; cmbObjetivo.DisplayMember = "OBJETIVO_COMPLETO"; cmbObjetivo.ValueMember = "ID_OBJETIVO"; cmbObjetivo.SelectedIndex = -1;
        }

        private void CargarCoaches()
        {
            DataTable tabla = CoachControlador.Listar();
            cmbCoach.DataSource = tabla; cmbCoach.DisplayMember = "COACH"; cmbCoach.ValueMember = "ID_COACH"; cmbCoach.SelectedIndex = -1;
        }

        private void CargarSeguimiento() { dgvSeguimiento.DataSource = SeguimientoControlador.Listar(); }

        private Seguimiento ObtenerSeguimiento()
        {
            int id; int.TryParse(txtIdSeguimiento.Text, out id);
            return new Seguimiento { Id = id, IdObjetivo = cmbObjetivo.SelectedValue == null ? 0 : Convert.ToInt32(cmbObjetivo.SelectedValue), IdCoach = cmbCoach.SelectedValue == null ? (int?)null : Convert.ToInt32(cmbCoach.SelectedValue), Fecha = dtpFecha.Value, Valor = numValor.Value, Comentario = txtComentario.Text.Trim() };
        }

        private bool ValidarDatos()
        {
            if (cmbObjetivo.SelectedValue == null || numValor.Value <= 0) { MessageBox.Show("Selecciona un objetivo e ingresa un valor válido.", "SPARTANFIT", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
            return true;
        }

        private void LimpiarCampos()
        {
            txtIdSeguimiento.Clear(); cmbObjetivo.SelectedIndex = -1; cmbCoach.SelectedIndex = -1; dtpFecha.Value = DateTime.Now; numValor.Value = 0; txtComentario.Clear(); dgvSeguimiento.ClearSelection();
        }

        private void btnNuevo_Click(object sender, EventArgs e) { LimpiarCampos(); }
        private void btnCancelar_Click(object sender, EventArgs e) { LimpiarCampos(); }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos()) return;
            string mensaje;
            if (SeguimientoControlador.Registrar(ObtenerSeguimiento(), out mensaje)) { CargarSeguimiento(); LimpiarCampos(); MessageBox.Show("Seguimiento registrado.", "SPARTANFIT", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            else MessageBox.Show(mensaje, "SPARTANFIT", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int id;
            if (!ValidarDatos() || !int.TryParse(txtIdSeguimiento.Text, out id) || id <= 0) { MessageBox.Show("Selecciona un seguimiento.", "SPARTANFIT", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            string mensaje;
            if (SeguimientoControlador.Actualizar(ObtenerSeguimiento(), out mensaje)) { CargarSeguimiento(); LimpiarCampos(); MessageBox.Show("Seguimiento actualizado.", "SPARTANFIT", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            else MessageBox.Show(mensaje, "SPARTANFIT", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id;
            if (!int.TryParse(txtIdSeguimiento.Text, out id) || id <= 0) { MessageBox.Show("Selecciona un seguimiento.", "SPARTANFIT", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (MessageBox.Show("¿Eliminar este seguimiento?", "SPARTANFIT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            string mensaje;
            if (SeguimientoControlador.Eliminar(id, out mensaje)) { CargarSeguimiento(); LimpiarCampos(); }
            else MessageBox.Show(mensaje, "SPARTANFIT", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvSeguimiento_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSeguimiento.CurrentRow == null || !(dgvSeguimiento.CurrentRow.DataBoundItem is DataRowView)) return;
            DataRowView fila = (DataRowView)dgvSeguimiento.CurrentRow.DataBoundItem;
            txtIdSeguimiento.Text = fila["ID_SEGUIMIENTO"].ToString(); cmbObjetivo.SelectedValue = Convert.ToInt32(fila["ID_OBJETIVO"]);
            cmbCoach.SelectedValue = fila["ID_COACH"] == DBNull.Value ? -1 : Convert.ToInt32(fila["ID_COACH"]);
            dtpFecha.Value = Convert.ToDateTime(fila["FECHA"]); numValor.Value = Convert.ToDecimal(fila["VALOR"]); txtComentario.Text = fila["COMENTARIO"] == DBNull.Value ? "" : fila["COMENTARIO"].ToString();
        }
    }
}
