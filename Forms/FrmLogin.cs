using Parcial_3_Actividad_2.Services;

namespace Parcial_3_Actividad_2.Forms
{
    public partial class FrmLogin : Form
    {
        private readonly AuthService _auth = new();

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MostrarMensaje("Ingrese usuario y contraseña.", false);
                return;
            }

            try
            {
                var resultado = _auth.IniciarSesion(txtUsuario.Text, txtPassword.Text);

                if (resultado.Exitoso)
                {
                    MostrarMensaje(string.Empty, true);
                    txtPassword.Clear();

                    Hide();
                    using (var principal = new FrmPrincipal(resultado.Usuario!))
                    {
                        principal.ShowDialog();
                    }
                    txtUsuario.Clear();
                    Show();
                    txtUsuario.Focus();
                }
                else
                {
                    MostrarMensaje(resultado.Mensaje, false);
                    txtPassword.Clear();
                    txtPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de base de datos:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            using var frm = new FrmRegistro();
            frm.ShowDialog(this);
        }

        private void MostrarMensaje(string texto, bool ok)
        {
            lblMensaje.ForeColor = ok ? Color.SeaGreen : Color.Firebrick;
            lblMensaje.Text = texto;
        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }
    }
}
