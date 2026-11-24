
using System;
using System.Data;
using System.Windows.Forms;
using SPARTANFIT.CONTROLADOR;
using SPARTANFIT.MODELO;

namespace SPARTANFIT.VISTA
{
    public partial class FrmRegistroEstaciones : Form
    {
        public FrmRegistroEstaciones()
        {
            InitializeComponent();

            btnNuevo.Click += btnNuevo_Click;
            btnRegistrar.Click += btnRegistrar_Click;
            btnCancelar.Click += btnCancelar_Click;
            dgvRegistroEstaciones.SelectionChanged += dgvRegistroEstaciones_SelectionChanged;

            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;

            CargarEstaciones();
            CargarMiembros();
            CargarRegistros();
        }

        private void CargarEstaciones()
        {
            cmbEstacion.DataSource = EstacionControlador.Listar();
            cmbEstacion.DisplayMember = "NOMBRE";
            cmbEstacion.ValueMember = "ID_ESTACION";
            cmbEstacion.SelectedIndex = -1;
        }

        private void CargarMiembros()
        {
            DataTable tabla = MiembroControlador.Listar();
            DataTable miembros = new DataTable();

            miembros.Columns.Add("ID_MIEMBRO", typeof(int));
            miembros.Columns.Add("NOMBRE_COMPLETO", typeof(string));

            foreach (DataRow fila in tabla.Rows)
            {
                miembros.Rows.Add(
                    Convert.ToInt32(fila["ID_MIEMBRO"]),
                    fila["NOMBRE"].ToString() + " " + fila["APELLIDO"].ToString()
                );
            }

            cmbMiembro.DataSource = miembros;
            cmbMiembro.DisplayMember = "NOMBRE_COMPLETO";
            cmbMiembro.ValueMember = "ID_MIEMBRO";
            cmbMiembro.SelectedIndex = -1;
        }

        private void CargarRegistros()
        {
            dgvRegistroEstaciones.DataSource = EstacionControlador.ListarRegistros();
            dgvRegistroEstaciones.ClearSelection();
        }

        private RegistroEstacion ObtenerRegistro()
        {
            int id = 0;
            int.TryParse(txtIdRegistro.Text, out id);

            return new RegistroEstacion
            {
                Id = id,
                IdEstacion = cmbEstacion.SelectedValue == null
                    ? 0
                    : Convert.ToInt32(cmbEstacion.SelectedValue),
                IdMiembro = cmbMiembro.SelectedValue == null
                    ? 0
                    : Convert.ToInt32(cmbMiembro.SelectedValue),
                Fecha = dtpFecha.Value,
                Resultado = txtResultado.Text.Trim()
            };
        }

        private bool ValidarRegistro()
        {
            if (cmbEstacion.SelectedValue == null)
            {
                MessageBox.Show("Selecciona una estación.", "SPARTANFIT",
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
                MessageBox.Show("Ingresa el resultado del registro.", "SPARTANFIT",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtResultado.Focus();
                return false;
            }

            return true;
        }

        private void LimpiarCampos()
        {
            txtIdRegistro.Clear();
            cmbEstacion.SelectedIndex = -1;
            cmbMiembro.SelectedIndex = -1;
            dtpFecha.Value = DateTime.Now;
            txtResultado.Clear();
            dgvRegistroEstaciones.ClearSelection();
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
            if (!ValidarRegistro())
                return;

            string mensaje;
            RegistroEstacion registro = ObtenerRegistro();

            if (EstacionControlador.RegistrarResultado(registro, out mensaje))
            {
                MessageBox.Show("Registro de estación guardado correctamente.",
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

        private void dgvRegistroEstaciones_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRegistroEstaciones.CurrentRow == null ||
                dgvRegistroEstaciones.CurrentRow.DataBoundItem == null)
                return;

            DataRowView fila = dgvRegistroEstaciones.CurrentRow.DataBoundItem as DataRowView;

            if (fila == null)
                return;

            txtIdRegistro.Text = fila["ID_REGISTRO"].ToString();

            cmbEstacion.SelectedValue = Convert.ToInt32(fila["ID_ESTACION"]);
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
