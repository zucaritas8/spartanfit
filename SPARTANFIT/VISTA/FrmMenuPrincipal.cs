using System;
using System.Drawing;
using System.Windows.Forms;

namespace SPARTANFIT.VISTA
{
    public partial class FrmMenuPrincipal : Form
    {
        private readonly int idUsuario;
        private readonly string rol;
        private readonly string nombreCompleto;
        private ContextMenuStrip menuRegistros;

        public FrmMenuPrincipal() : this(0, "ADMIN", "Administrador")
        {
        }

        public FrmMenuPrincipal(string rol) : this(0, rol, string.Empty)
        {
        }

        public FrmMenuPrincipal(int idUsuario, string rol, string nombreCompleto)
        {
            InitializeComponent();

            this.idUsuario = idUsuario;
            this.rol = NormalizarRol(rol);
            this.nombreCompleto = nombreCompleto ?? string.Empty;

            CrearMenuRegistros();
            ConectarEventos();
            ActualizarEncabezado();

            this.FormClosed += new FormClosedEventHandler(FrmMenuPrincipal_FormClosed);
        }

        public int IdUsuarioActual
        {
            get { return idUsuario; }
        }

        public string RolActual
        {
            get { return rol; }
        }

        public string NombreUsuarioActual
        {
            get { return nombreCompleto; }
        }

        private string NormalizarRol(string valor)
        {
            string texto = (valor ?? string.Empty).Trim().ToUpperInvariant();

            if (texto == "ADMIN" || texto == "ADMINISTRADOR")
                return "ADMIN";

            if (texto == "COACH")
                return "COACH";

            if (texto == "MIEMBRO" || texto == "ATLETA")
                return "MIEMBRO";

            return string.Empty;
        }

        private void ActualizarEncabezado()
        {
            if (!string.IsNullOrWhiteSpace(nombreCompleto))
                lblPanelPrincipal.Text = "Panel principal - " + nombreCompleto;

            if (rol == "ADMIN")
                lblSubtitulo.Text = "Sistema de gestión de CrossFit | Administrador";
            else if (rol == "COACH")
                lblSubtitulo.Text = "Sistema de gestión de CrossFit | Coach";
            else if (rol == "MIEMBRO")
                lblSubtitulo.Text = "Sistema de gestión de CrossFit | Atleta";
            else
                lblSubtitulo.Text = "Sistema de gestión de CrossFit";
        }

        private void CrearMenuRegistros()
        {
            menuRegistros = new ContextMenuStrip();
            menuRegistros.BackColor = Color.FromArgb(35, 35, 35);
            menuRegistros.ForeColor = Color.White;
            menuRegistros.Font = new Font("Segoe UI", 10F);

            ToolStripMenuItem itemRutinas = new ToolStripMenuItem("Registros de rutinas");
            ToolStripMenuItem itemEstaciones = new ToolStripMenuItem("Registros de estaciones");

            itemRutinas.Click += new EventHandler(btnRegistroRutinas_Click);
            itemEstaciones.Click += new EventHandler(btnRegistroEstaciones_Click);

            menuRegistros.Items.Add(itemRutinas);
            menuRegistros.Items.Add(itemEstaciones);
        }

        private void ConectarEventos()
        {
            btnUsuarios.Click += new EventHandler(btnUsuarios_Click);
            btnCoaches.Click += new EventHandler(btnCoaches_Click);
            btnMiembros.Click += new EventHandler(btnMiembros_Click);
            btnEspecialidades.Click += new EventHandler(btnEspecialidades_Click);
            btnEjercicios.Click += new EventHandler(btnEjercicios_Click);
            btnEstaciones.Click += new EventHandler(btnEstaciones_Click);
            btnCredenciales.Click += new EventHandler(btnCredenciales_Click);
            btnInscripciones.Click += new EventHandler(btnInscripciones_Click);
            btnAsistencias.Click += new EventHandler(btnAsistencias_Click);
            btnRutinas.Click += new EventHandler(btnRutinas_Click);
            btnRegistros.Click += new EventHandler(btnRegistros_Click);
            btnDietas.Click += new EventHandler(btnDietas_Click);
            btnObjetivos.Click += new EventHandler(btnObjetivos_Click);
            btnSeguimiento.Click += new EventHandler(btnSeguimiento_Click);
        }

        private void AbrirFormulario(Form formulario)
        {
            if (formulario == null)
                return;

            this.Hide();

            try
            {
                formulario.StartPosition = FormStartPosition.CenterScreen;
                formulario.ShowDialog(this);
            }
            finally
            {
                if (!formulario.IsDisposed)
                    formulario.Dispose();

                if (!this.IsDisposed)
                {
                    this.Show();
                    this.Activate();
                }
            }
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmUsuarios());
        }

        private void btnCoaches_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmCoaches());
        }

        private void btnMiembros_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmMiembros());
        }

        private void btnEspecialidades_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmEspecialidades());
        }

        private void btnEjercicios_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmEjercicios());
        }

        private void btnEstaciones_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmEstaciones());
        }

        private void btnCredenciales_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmCredenciales());
        }

        private void btnInscripciones_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmInscripciones());
        }

        private void btnAsistencias_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmAsistencias());
        }

        private void btnRutinas_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmRutinas());
        }

        private void btnRegistros_Click(object sender, EventArgs e)
        {
            menuRegistros.Show(btnRegistros, new Point(0, btnRegistros.Height));
        }

        private void btnRegistroRutinas_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmRegistroRutinas());
        }

        private void btnRegistroEstaciones_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmRegistroEstaciones());
        }

        private void btnDietas_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmDietas());
        }

        private void btnObjetivos_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmObjetivos());
        }

        private void btnSeguimiento_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmSeguimiento());
        }

        private void FrmMenuPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (menuRegistros != null)
            {
                menuRegistros.Dispose();
                menuRegistros = null;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                "¿Estás seguro de que deseas cerrar sesión?",
                "Cerrar sesión",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Retry;
                this.Close();
            }
        }
    }
}
