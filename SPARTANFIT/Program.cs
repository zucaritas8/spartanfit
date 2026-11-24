using System;
using System.Windows.Forms;
using SPARTANFIT.VISTA;

namespace SPARTANFIT
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmPresentacion());
        }
    }
}
