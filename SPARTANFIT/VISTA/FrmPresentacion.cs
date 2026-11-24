using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;
using SPARTANFIT.CONTROLADOR;

namespace SPARTANFIT.VISTA
{
    public partial class FrmPresentacion : Form
    {
        public FrmPresentacion()
        {
            InitializeComponent();
        }

        private void linkInstagram_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(
                new System.Diagnostics.ProcessStartInfo
                {
                    FileName = "https://www.instagram.com/spartanfit_cross?cnvx=MW11YzEydngyN2MxNQ==",
                    UseShellExecute = true
                }
            );
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(
                new System.Diagnostics.ProcessStartInfo
                {
                    FileName = "https://www.facebook.com/share/1BnpH25bt4/?mibextid=wwXIfr",
                    UseShellExecute = true
                }
            );
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(
                new System.Diagnostics.ProcessStartInfo
                {
                    FileName = "https://maps.app.goo.gl/jZj8KLKb1XLKmnaJ7",
                    UseShellExecute = true
                }
            );
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Type tipo = Assembly.GetExecutingAssembly().GetTypes()
                .FirstOrDefault(t => t.Name == "FrmLogin" && typeof(Form).IsAssignableFrom(t));

            if (tipo == null)
            {
                MessageBox.Show("No se encontró el formulario FrmLogin en el proyecto.",
                    "SPARTANFIT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                using (Form login = (Form)Activator.CreateInstance(tipo))
                {
                    login.StartPosition = FormStartPosition.CenterParent;
                    login.ShowDialog(this);
                }
            }
            catch (MissingMethodException)
            {
                MessageBox.Show("FrmLogin necesita un constructor sin parámetros.",
                    "SPARTANFIT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
