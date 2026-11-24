
namespace SPARTANFIT.VISTA
{
    public partial class FrmMiembros : System.Windows.Forms.Form
    {
        private bool modoEdicion = false;

        public FrmMiembros(string usuario)
        {
            InitializeComponent();

            btnNuevo.Click += btnNuevo_Click;
            btnRegistrar.Click += btnRegistrar_Click;
            btnEditar.Click += btnEditar_Click;
            btnEliminar.Click += btnEliminar_Click;
            btnCancelar.Click += btnCancelar_Click;
            dgvMiembros.CellClick += dgvMiembros_CellClick;

            ConfigurarFormulario();
            ListarMiembros();
        }

        public FrmMiembros()
        {
            InitializeComponent();

            btnNuevo.Click += btnNuevo_Click;
            btnRegistrar.Click += btnRegistrar_Click;
            btnEditar.Click += btnEditar_Click;
            btnEliminar.Click += btnEliminar_Click;
            btnCancelar.Click += btnCancelar_Click;
            dgvMiembros.CellClick += dgvMiembros_CellClick;

            ConfigurarFormulario();
            ListarMiembros();
        }

        private void ConfigurarFormulario()
        {
            dgvMiembros.AutoGenerateColumns = true;
            dgvMiembros.AllowUserToAddRows = false;
            dgvMiembros.ReadOnly = true;
            dgvMiembros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvMiembros.MultiSelect = false;

            cmbUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;

            LimpiarFormulario();
        }

        private void ListarMiembros()
        {
            try
            {
                dgvMiembros.DataSource = SPARTANFIT.CONTROLADOR.MiembroControlador.Listar("");

                if (dgvMiembros.Columns.Contains("ID_MIEMBRO"))
                    dgvMiembros.Columns["ID_MIEMBRO"].HeaderText = "ID";

                if (dgvMiembros.Columns.Contains("ID_USUARIO"))
                    dgvMiembros.Columns["ID_USUARIO"].HeaderText = "ID Usuario";

                if (dgvMiembros.Columns.Contains("CI"))
                    dgvMiembros.Columns["CI"].HeaderText = "CI";

                if (dgvMiembros.Columns.Contains("NOMBRE"))
                    dgvMiembros.Columns["NOMBRE"].HeaderText = "Nombre";

                if (dgvMiembros.Columns.Contains("APELLIDOS"))
                    dgvMiembros.Columns["APELLIDOS"].HeaderText = "Apellidos";

                if (dgvMiembros.Columns.Contains("DIRECCION"))
                    dgvMiembros.Columns["DIRECCION"].HeaderText = "Dirección";

                if (dgvMiembros.Columns.Contains("TELEFONO"))
                    dgvMiembros.Columns["TELEFONO"].HeaderText = "Teléfono";

                if (dgvMiembros.Columns.Contains("CORREO"))
                    dgvMiembros.Columns["CORREO"].HeaderText = "Correo";

                if (dgvMiembros.Columns.Contains("FECHA_NACIMIENTO"))
                    dgvMiembros.Columns["FECHA_NACIMIENTO"].HeaderText = "Fecha nacimiento";
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(
                    "Error al cargar los miembros: " + ex.Message,
                    "SPARTANFIT",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private void LimpiarFormulario()
        {
            txtIdMiembro.Clear();
            cmbUsuario.SelectedIndex = -1;
            cmbUsuario.Text = "";
            txtCI.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            dtpFechaNacimiento.Value = System.DateTime.Today;

            modoEdicion = false;

            btnRegistrar.Enabled = true;
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;

            dgvMiembros.ClearSelection();
        }

        private bool ValidarFormulario()
        {
            if (string.IsNullOrWhiteSpace(txtCI.Text))
            {
                System.Windows.Forms.MessageBox.Show("Ingrese el CI del miembro.");
                txtCI.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                System.Windows.Forms.MessageBox.Show("Ingrese el nombre del miembro.");
                txtNombre.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                System.Windows.Forms.MessageBox.Show("Ingrese los apellidos del miembro.");
                txtApellido.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(cmbUsuario.Text))
            {
                System.Windows.Forms.MessageBox.Show("Seleccione o ingrese la modalidad correspondiente.");
                cmbUsuario.Focus();
                return false;
            }

            if (dtpFechaNacimiento.Value.Date >= System.DateTime.Today)
            {
                System.Windows.Forms.MessageBox.Show("La fecha de nacimiento debe ser anterior a la fecha actual.");
                return false;
            }

            return true;
        }

        private SPARTANFIT.MODELO.Miembro ObtenerMiembro()
        {
            return new SPARTANFIT.MODELO.Miembro
            {
                Id = string.IsNullOrWhiteSpace(txtIdMiembro.Text) ? 0 : System.Convert.ToInt32(txtIdMiembro.Text),
                CI = txtCI.Text.Trim(),
                Nombre = txtNombre.Text.Trim(),
                Apellidos = txtApellido.Text.Trim(),
                Direccion = txtDireccion.Text.Trim(),
                Telefono = txtTelefono.Text.Trim(),
                Correo = txtCorreo.Text.Trim(),
                FechaNacimiento = dtpFechaNacimiento.Value.Date
            };
        }

        private void btnNuevo_Click(object sender, System.EventArgs e)
        {
            LimpiarFormulario();
            txtCI.Focus();
        }

        private void btnRegistrar_Click(object sender, System.EventArgs e)
        {
            if (!ValidarFormulario())
                return;

            try
            {
                SPARTANFIT.MODELO.Miembro miembro = ObtenerMiembro();

                string usuario;
                string mensaje;

                bool resultado = SPARTANFIT.CONTROLADOR.MiembroControlador.Registrar(
                    miembro,
                    cmbUsuario.Text.Trim(),
                    out usuario,
                    out mensaje);

                if (resultado)
                {
                    System.Windows.Forms.MessageBox.Show(
                        "Miembro registrado correctamente.\nUsuario generado: " + usuario,
                        "SPARTANFIT",
                        System.Windows.Forms.MessageBoxButtons.OK,
                        System.Windows.Forms.MessageBoxIcon.Information);

                    ListarMiembros();
                    LimpiarFormulario();
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show(
                        mensaje,
                        "No se pudo registrar",
                        System.Windows.Forms.MessageBoxButtons.OK,
                        System.Windows.Forms.MessageBoxIcon.Warning);
                }
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(
                    "Error al registrar: " + ex.Message,
                    "SPARTANFIT",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdMiembro.Text))
            {
                System.Windows.Forms.MessageBox.Show("Seleccione un miembro de la tabla.");
                return;
            }

            if (!ValidarFormulario())
                return;

            try
            {
                string mensaje;
                SPARTANFIT.MODELO.Miembro miembro = ObtenerMiembro();

                bool resultado = SPARTANFIT.CONTROLADOR.MiembroControlador.Actualizar(
                    miembro,
                    out mensaje);

                if (resultado)
                {
                    System.Windows.Forms.MessageBox.Show(
                        "Miembro actualizado correctamente.",
                        "SPARTANFIT",
                        System.Windows.Forms.MessageBoxButtons.OK,
                        System.Windows.Forms.MessageBoxIcon.Information);

                    ListarMiembros();
                    LimpiarFormulario();
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show(
                        mensaje,
                        "No se pudo actualizar",
                        System.Windows.Forms.MessageBoxButtons.OK,
                        System.Windows.Forms.MessageBoxIcon.Warning);
                }
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(
                    "Error al actualizar: " + ex.Message,
                    "SPARTANFIT",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, System.EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show(
                "Tu MiembroControlador todavía no tiene implementado el método para desactivar o eliminar miembros.",
                "SPARTANFIT",
                System.Windows.Forms.MessageBoxButtons.OK,
                System.Windows.Forms.MessageBoxIcon.Information);
        }

        private void btnCancelar_Click(object sender, System.EventArgs e)
        {
            LimpiarFormulario();
        }

        private void dgvMiembros_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            try
            {
                System.Windows.Forms.DataGridViewRow fila = dgvMiembros.Rows[e.RowIndex];

                txtIdMiembro.Text = ObtenerValorFila(fila, "ID_MIEMBRO");
                txtCI.Text = ObtenerValorFila(fila, "CI");
                txtNombre.Text = ObtenerValorFila(fila, "NOMBRE");
                txtApellido.Text = ObtenerValorFila(fila, "APELLIDOS");
                txtDireccion.Text = ObtenerValorFila(fila, "DIRECCION");
                txtTelefono.Text = ObtenerValorFila(fila, "TELEFONO");
                txtCorreo.Text = ObtenerValorFila(fila, "CORREO");

                string fecha = ObtenerValorFila(fila, "FECHA_NACIMIENTO");

                System.DateTime fechaNacimiento;

                if (System.DateTime.TryParse(fecha, out fechaNacimiento))
                    dtpFechaNacimiento.Value = fechaNacimiento;

                modoEdicion = true;
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(
                    "Error al seleccionar el miembro: " + ex.Message);
            }
        }

        private string ObtenerValorFila(System.Windows.Forms.DataGridViewRow fila, string columna)
        {
            if (!dgvMiembros.Columns.Contains(columna))
                return "";

            object valor = fila.Cells[columna].Value;

            return valor == null || valor == System.DBNull.Value
                ? ""
                : valor.ToString();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            FrmMenuPrincipal menu = new FrmMenuPrincipal();
            menu.Show();
            this.Hide();
        }
    }
}
