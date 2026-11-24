
using System;
using System.Data;
using System.Windows.Forms;
using SPARTANFIT.MODELO;
using SPARTANFIT.CONTROLADOR;

namespace SPARTANFIT.VISTA
{
    public partial class FrmCoaches : Form
    {
        private DataTable tablaCoaches;

        public FrmCoaches()
        {
            InitializeComponent();

            btnNuevo.Click += btnNuevo_Click;
            btnRegistrar.Click += btnRegistrar_Click;
            btnEditar.Click += btnEditar_Click;
            btnEliminar.Click += btnEliminar_Click;
            btnCancelar.Click += btnCancelar_Click;

            dgvCoaches.CellClick += dgvCoaches_CellClick;

            CargarEspecialidades();
            CargarUsuarios();
            CargarCoaches();
            LimpiarCampos();
        }

        private void CargarUsuarios(int? idSeleccionado = null, string usuarioSeleccionado = null)
        {
            try
            {
                DataTable usuarios = UsuarioControlador.Listar();

                DataTable tabla = new DataTable();
                tabla.Columns.Add("ID_USUARIO", typeof(int));
                tabla.Columns.Add("USUARIO", typeof(string));

                foreach (DataRow fila in usuarios.Rows)
                {
                    string estado = fila["ESTADO"].ToString();
                    string rol = fila["ROL"].ToString();
                    int id = Convert.ToInt32(fila["ID_USUARIO"]);

                    bool esSeleccionado = idSeleccionado.HasValue &&
                                          idSeleccionado.Value == id;

                    if (estado.Equals("ACTIVO", StringComparison.OrdinalIgnoreCase) &&
                        (!rol.Equals("COACH", StringComparison.OrdinalIgnoreCase) || esSeleccionado))
                    {
                        tabla.Rows.Add(id, fila["USUARIO"].ToString());
                    }
                }

                if (idSeleccionado.HasValue)
                {
                    bool existe = false;

                    foreach (DataRow fila in tabla.Rows)
                    {
                        if (Convert.ToInt32(fila["ID_USUARIO"]) == idSeleccionado.Value)
                        {
                            existe = true;
                            break;
                        }
                    }

                    if (!existe)
                    {
                        tabla.Rows.Add(idSeleccionado.Value, usuarioSeleccionado ?? "");
                    }
                }

                cmbUsuario.DataSource = null;
                cmbUsuario.DataSource = tabla;
                cmbUsuario.DisplayMember = "USUARIO";
                cmbUsuario.ValueMember = "ID_USUARIO";
                cmbUsuario.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los usuarios: " + ex.Message,
                    "SPARTANFIT", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarEspecialidades()
        {
            try
            {
                DataTable especialidades = EspecialidadControlador.Listar();

                DataTable tabla = new DataTable();
                tabla.Columns.Add("ID_ESPECIALIDAD", typeof(int));
                tabla.Columns.Add("NOMBRE", typeof(string));

                tabla.Rows.Add(0, "SIN ESPECIALIDAD");

                foreach (DataRow fila in especialidades.Rows)
                {
                    int id = Convert.ToInt32(fila["ID_ESPECIALIDAD"]);
                    string nombre = fila["NOMBRE"].ToString();

                    tabla.Rows.Add(id, nombre);
                }

                cmbEspecialidad.DataSource = null;
                cmbEspecialidad.DataSource = tabla;
                cmbEspecialidad.DisplayMember = "NOMBRE";
                cmbEspecialidad.ValueMember = "ID_ESPECIALIDAD";
                cmbEspecialidad.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las especialidades: " + ex.Message,
                    "SPARTANFIT", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarCoaches()
        {
            try
            {
                tablaCoaches = CoachControlador.Listar();

                dgvCoaches.DataSource = null;
                dgvCoaches.AutoGenerateColumns = true;
                dgvCoaches.DataSource = tablaCoaches;

                dgvCoaches.ReadOnly = true;
                dgvCoaches.AllowUserToAddRows = false;
                dgvCoaches.AllowUserToDeleteRows = false;
                dgvCoaches.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvCoaches.MultiSelect = false;
                dgvCoaches.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                if (dgvCoaches.Columns.Contains("ID_COACH"))
                    dgvCoaches.Columns["ID_COACH"].HeaderText = "ID COACH";

                if (dgvCoaches.Columns.Contains("ID_USUARIO"))
                    dgvCoaches.Columns["ID_USUARIO"].Visible = false;

                if (dgvCoaches.Columns.Contains("USUARIO"))
                    dgvCoaches.Columns["USUARIO"].HeaderText = "USUARIO";

                if (dgvCoaches.Columns.Contains("CI"))
                    dgvCoaches.Columns["CI"].HeaderText = "CI";

                if (dgvCoaches.Columns.Contains("CODIGO"))
                    dgvCoaches.Columns["CODIGO"].HeaderText = "CÓDIGO";

                if (dgvCoaches.Columns.Contains("NOMBRE"))
                    dgvCoaches.Columns["NOMBRE"].HeaderText = "NOMBRE";

                if (dgvCoaches.Columns.Contains("APELLIDO"))
                    dgvCoaches.Columns["APELLIDO"].HeaderText = "APELLIDO";

                if (dgvCoaches.Columns.Contains("DIRECCION"))
                    dgvCoaches.Columns["DIRECCION"].HeaderText = "DIRECCIÓN";

                if (dgvCoaches.Columns.Contains("TELEFONO"))
                    dgvCoaches.Columns["TELEFONO"].HeaderText = "TELÉFONO";

                if (dgvCoaches.Columns.Contains("ID_ESPECIALIDAD"))
                    dgvCoaches.Columns["ID_ESPECIALIDAD"].Visible = false;

                if (dgvCoaches.Columns.Contains("ESPECIALIDAD"))
                    dgvCoaches.Columns["ESPECIALIDAD"].HeaderText = "ESPECIALIDAD";

                if (dgvCoaches.Columns.Contains("FECHA_EMISION"))
                    dgvCoaches.Columns["FECHA_EMISION"].HeaderText = "FECHA EMISIÓN";

                if (dgvCoaches.Columns.Contains("FECHA_EXPIRACION"))
                    dgvCoaches.Columns["FECHA_EXPIRACION"].HeaderText = "FECHA EXPIRACIÓN";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los coaches: " + ex.Message,
                    "SPARTANFIT", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            txtIdCoach.Clear();

            if (cmbUsuario.DataSource != null)
                cmbUsuario.SelectedIndex = -1;

            txtCI.Clear();
            txtCodigo.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();

            if (cmbEspecialidad.DataSource != null)
                cmbEspecialidad.SelectedIndex = 0;

            dtpFechaEmision.Value = DateTime.Today;
            dtpFechaEmision.Checked = false;

            dtpFechaExpiracion.Value = DateTime.Today;
            dtpFechaExpiracion.Checked = false;

            dgvCoaches.ClearSelection();
            txtCI.Focus();
        }

        private bool ValidarCampos()
        {
            if (cmbUsuario.SelectedIndex == -1 || cmbUsuario.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un usuario.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbUsuario.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCI.Text))
            {
                MessageBox.Show("Ingrese el CI del coach.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCI.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                MessageBox.Show("Ingrese el código del coach.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCodigo.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Ingrese el nombre del coach.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("Ingrese el apellido del coach.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtApellido.Focus();
                return false;
            }

            return true;
        }

        private Coach ObtenerCoach()
        {
            Coach coach = new Coach();

            if (!string.IsNullOrWhiteSpace(txtIdCoach.Text))
                coach.Id = Convert.ToInt32(txtIdCoach.Text);

            coach.IdUsuario = Convert.ToInt32(cmbUsuario.SelectedValue);
            coach.CI = txtCI.Text.Trim();
            coach.Codigo = txtCodigo.Text.Trim();
            coach.Nombre = txtNombre.Text.Trim();
            coach.Apellido = txtApellido.Text.Trim();
            coach.Direccion = txtDireccion.Text.Trim();
            coach.Telefono = txtTelefono.Text.Trim();

            int idEspecialidad = Convert.ToInt32(cmbEspecialidad.SelectedValue);
            coach.IdEspecialidad = idEspecialidad == 0
                ? (int?)null
                : idEspecialidad;

            coach.FechaEmision = dtpFechaEmision.Checked
                ? dtpFechaEmision.Value.Date
                : (DateTime?)null;

            coach.FechaExpiracion = dtpFechaExpiracion.Checked
                ? dtpFechaExpiracion.Value.Date
                : (DateTime?)null;

            return coach;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            Coach coach = ObtenerCoach();

            string mensaje;

            if (CoachControlador.Registrar(coach, out mensaje))
            {
                MessageBox.Show("Coach registrado correctamente.",
                    "SPARTANFIT", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarUsuarios();
                CargarCoaches();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("No se pudo registrar el coach:\n" + mensaje,
                    "SPARTANFIT", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdCoach.Text))
            {
                MessageBox.Show("Seleccione un coach de la tabla para editar.",
                    "SPARTANFIT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidarCampos())
                return;

            Coach coach = ObtenerCoach();

            string mensaje;

            if (CoachControlador.Actualizar(coach, out mensaje))
            {
                MessageBox.Show("Coach actualizado correctamente.",
                    "SPARTANFIT", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarUsuarios();
                CargarCoaches();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("No se pudo actualizar el coach:\n" + mensaje,
                    "SPARTANFIT", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdCoach.Text))
            {
                MessageBox.Show("Seleccione un coach de la tabla para desactivarlo.",
                    "SPARTANFIT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbUsuario.SelectedValue == null)
            {
                MessageBox.Show("No se pudo identificar el usuario del coach.",
                    "SPARTANFIT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Está seguro de que desea desactivar este coach?",
                "Confirmar desactivación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
                return;

            int idUsuario = Convert.ToInt32(cmbUsuario.SelectedValue);

            string mensaje;

            if (CoachControlador.Desactivar(idUsuario, out mensaje))
            {
                MessageBox.Show("Coach desactivado correctamente.",
                    "SPARTANFIT", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarUsuarios();
                CargarCoaches();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("No se pudo desactivar el coach:\n" + mensaje,
                    "SPARTANFIT", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void dgvCoaches_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            try
            {
                DataGridViewRow fila = dgvCoaches.Rows[e.RowIndex];

                txtIdCoach.Text = fila.Cells["ID_COACH"].Value?.ToString();
                txtCI.Text = fila.Cells["CI"].Value?.ToString();
                txtCodigo.Text = fila.Cells["CODIGO"].Value?.ToString();
                txtNombre.Text = fila.Cells["NOMBRE"].Value?.ToString();
                txtApellido.Text = fila.Cells["APELLIDO"].Value?.ToString();
                txtDireccion.Text = fila.Cells["DIRECCION"].Value?.ToString();
                txtTelefono.Text = fila.Cells["TELEFONO"].Value?.ToString();

                int idUsuario = Convert.ToInt32(fila.Cells["ID_USUARIO"].Value);
                string usuario = fila.Cells["USUARIO"].Value?.ToString();

                CargarUsuarios(idUsuario, usuario);
                cmbUsuario.SelectedValue = idUsuario;

                if (fila.Cells["ID_ESPECIALIDAD"].Value != DBNull.Value &&
                    fila.Cells["ID_ESPECIALIDAD"].Value != null)
                {
                    int idEspecialidad = Convert.ToInt32(
                        fila.Cells["ID_ESPECIALIDAD"].Value);

                    cmbEspecialidad.SelectedValue = idEspecialidad;
                }
                else
                {
                    cmbEspecialidad.SelectedValue = 0;
                }

                if (fila.Cells["FECHA_EMISION"].Value != DBNull.Value &&
                    fila.Cells["FECHA_EMISION"].Value != null)
                {
                    dtpFechaEmision.Value = Convert.ToDateTime(
                        fila.Cells["FECHA_EMISION"].Value);
                    dtpFechaEmision.Checked = true;
                }
                else
                {
                    dtpFechaEmision.Value = DateTime.Today;
                    dtpFechaEmision.Checked = false;
                }

                if (fila.Cells["FECHA_EXPIRACION"].Value != DBNull.Value &&
                    fila.Cells["FECHA_EXPIRACION"].Value != null)
                {
                    dtpFechaExpiracion.Value = Convert.ToDateTime(
                        fila.Cells["FECHA_EXPIRACION"].Value);
                    dtpFechaExpiracion.Checked = true;
                }
                else
                {
                    dtpFechaExpiracion.Value = DateTime.Today;
                    dtpFechaExpiracion.Checked = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar el coach: " + ex.Message,
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
