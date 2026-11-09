using Parcial_3_Actividad_2.Forms;

namespace Parcial_3_Actividad_2
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new FrmLogin());
        }
    }
}
