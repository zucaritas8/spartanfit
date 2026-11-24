
using System;
using System.Windows.Forms;
using SPARTANFIT.CONTROLADOR;

namespace SPARTANFIT.VISTA
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string clave = txtClave.Text;

            if (usuario.Length == 0 || clave.Length == 0)
            {
                lblMensaje.Text = "Ingresa tu usuario y contraseña.";
                return;
            }

            lblMensaje.Text = "";
            btnIngresar.Enabled = false;
            this.Cursor = Cursors.WaitCursor;

            string rol;
            string mensaje;

            bool ok = LoginControlador.Autenticar(
                usuario, clave, out rol, out mensaje);

            this.Cursor = Cursors.Default;
            btnIngresar.Enabled = true;

            if (!ok)
            {
                lblMensaje.Text = mensaje;
                txtClave.Clear();
                txtClave.Focus();
                return;
            }

            this.Hide();

            using (FrmMenuPrincipal menu = new FrmMenuPrincipal())
            {
                menu.ShowDialog();
            }

            txtClave.Clear();
            txtUsuario.Clear();
            lblMensaje.Text = "";
            this.Show();
            this.Activate();
        }

        private void chkMostrar_CheckedChanged(object sender, EventArgs e)
        {
            txtClave.UseSystemPasswordChar = !chkMostrar.Checked;
        }

        private void lblMensaje_Click(object sender, EventArgs e)
        {
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
