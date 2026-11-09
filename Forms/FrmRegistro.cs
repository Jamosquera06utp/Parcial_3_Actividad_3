using Parcial_3_Actividad_2.Services;

namespace Parcial_3_Actividad_2.Forms
{
    public partial class FrmRegistro : Form
    {
        private readonly AuthService _auth = new();

        public FrmRegistro()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text != txtConfirmar.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Registro",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var (ok, mensaje, hash) = _auth.Registrar(txtUsuario.Text, txtNombre.Text, txtPassword.Text);

                if (ok)
                {
                    txtHash.Text = hash;   // se muestra el hash BCrypt generado
                    MessageBox.Show(mensaje, "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnGuardar.Enabled = false;
                    btnCancelar.Text = "Cerrar";
                }
                else
                {
                    MessageBox.Show(mensaje, "Registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de base de datos:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
