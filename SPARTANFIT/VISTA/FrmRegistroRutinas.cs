using System;
using System.Data;
using System.Windows.Forms;
using SPARTANFIT.CONTROLADOR;
using SPARTANFIT.MODELO;

namespace SPARTANFIT.VISTA
{
    public partial class FrmRegistroRutinas : Form
    {
        public FrmRegistroRutinas()
        {
            InitializeComponent();

            btnNuevo.Click += btnNuevo_Click;
            btnRegistrar.Click += btnRegistrar_Click;
            btnCancelar.Click += btnCancelar_Click;
            dgvRegistroRutinas.SelectionChanged += dgvRegistroRutinas_SelectionChanged;

            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;

            CargarRutinas();
            CargarMiembros();
            CargarRegistros();
        }

        private void CargarRutinas()
        {
            cmbRutina.DataSource = RutinaControlador.Listar();
            cmbRutina.DisplayMember = "NOMBRE";
            cmbRutina.ValueMember = "ID_RUTINA";
            cmbRutina.SelectedIndex = -1;
        }

        private void CargarMiembros()
        {
            DataTable tabla = MiembroControlador.Listar();

            if (!tabla.Columns.Contains("NOMBRE_COMPLETO"))
                tabla.Columns.Add("NOMBRE_COMPLETO", typeof(string), "NOMBRE + ' ' + APELLIDO");

            cmbMiembro.DataSource = tabla;
            cmbMiembro.DisplayMember = "NOMBRE_COMPLETO";
            cmbMiembro.ValueMember = "ID_MIEMBRO";
            cmbMiembro.SelectedIndex = -1;
        }

        private void CargarRegistros()
        {
            dgvRegistroRutinas.DataSource = RutinaControlador.ListarRegistros();

            if (dgvRegistroRutinas.Columns.Contains("ID_REGISTRO"))
                dgvRegistroRutinas.Columns["ID_REGISTRO"].HeaderText = "ID";

            if (dgvRegistroRutinas.Columns.Contains("RUTINA"))
                dgvRegistroRutinas.Columns["RUTINA"].HeaderText = "RUTINA";

            if (dgvRegistroRutinas.Columns.Contains("MIEMBRO"))
                dgvRegistroRutinas.Columns["MIEMBRO"].HeaderText = "MIEMBRO";

            if (dgvRegistroRutinas.Columns.Contains("FECHA"))
                dgvRegistroRutinas.Columns["FECHA"].HeaderText = "FECHA";

            if (dgvRegistroRutinas.Columns.Contains("RESULTADO"))
                dgvRegistroRutinas.Columns["RESULTADO"].HeaderText = "RESULTADO";

            if (dgvRegistroRutinas.Columns.Contains("ID_RUTINA"))
                dgvRegistroRutinas.Columns["ID_RUTINA"].Visible = false;

            if (dgvRegistroRutinas.Columns.Contains("ID_MIEMBRO"))
                dgvRegistroRutinas.Columns["ID_MIEMBRO"].Visible = false;
        }

        private RegistroRutina ObtenerRegistro()
        {
            return new RegistroRutina
            {
                IdRutina = Convert.ToInt32(cmbRutina.SelectedValue),
                IdMiembro = Convert.ToInt32(cmbMiembro.SelectedValue),
                Fecha = dtpFecha.Value,
                Resultado = txtResultado.Text.Trim()
            };
        }

        private bool ValidarDatos()
        {
            if (cmbRutina.SelectedValue == null)
            {
                MessageBox.Show("Selecciona una rutina.", "SPARTANFIT",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbMiembro.SelectedValue == null)
            {
                MessageBox.Show("Selecciona un miembro.", "SPARTANFIT",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtResultado.Text))
            {
                MessageBox.Show("Ingresa el resultado de la rutina.", "SPARTANFIT",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtResultado.Focus();
                return false;
            }

            return true;
        }

        private void LimpiarCampos()
        {
            txtIdRegistro.Clear();
            cmbRutina.SelectedIndex = -1;
            cmbMiembro.SelectedIndex = -1;
            dtpFecha.Value = DateTime.Now;
            txtResultado.Clear();
            dgvRegistroRutinas.ClearSelection();
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
            if (!ValidarDatos())
                return;

            RegistroRutina registro = ObtenerRegistro();
            string mensaje;

            if (RutinaControlador.RegistrarResultado(registro, out mensaje))
            {
                MessageBox.Show("Registro de rutina guardado correctamente.",
                    "SPARTANFIT", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarRegistros();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show(mensaje, "SPARTANFIT",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvRegistroRutinas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRegistroRutinas.CurrentRow == null)
                return;

            if (!(dgvRegistroRutinas.CurrentRow.DataBoundItem is DataRowView))
                return;

            DataRowView fila = (DataRowView)dgvRegistroRutinas.CurrentRow.DataBoundItem;

            txtIdRegistro.Text = fila["ID_REGISTRO"].ToString();

            if (fila["ID_RUTINA"] != DBNull.Value)
                cmbRutina.SelectedValue = Convert.ToInt32(fila["ID_RUTINA"]);

            if (fila["ID_MIEMBRO"] != DBNull.Value)
                cmbMiembro.SelectedValue = Convert.ToInt32(fila["ID_MIEMBRO"]);

            if (fila["FECHA"] != DBNull.Value)
                dtpFecha.Value = Convert.ToDateTime(fila["FECHA"]);

            txtResultado.Text = fila["RESULTADO"] == DBNull.Value
                ? ""
                : fila["RESULTADO"].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmMenuPrincipal menu = new FrmMenuPrincipal();
            menu.Show();
            this.Hide();
        }
    }
}