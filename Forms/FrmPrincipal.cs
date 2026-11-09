using Parcial_3_Actividad_2.Models;
using Parcial_3_Actividad_2.Services;

namespace Parcial_3_Actividad_2.Forms
{
    public partial class FrmPrincipal : Form
    {
        private readonly Usuario _usuario;
        private readonly AuthService _auth = new();

        public FrmPrincipal(Usuario usuario)
        {
            InitializeComponent();
            _usuario = usuario;

            // Acceso exitoso: se indica el nombre del usuario
            lblBienvenida.Text = $"¡Acceso exitoso! Bienvenido, {_usuario.NombreCompleto} ({_usuario.NombreUsuario})";
            CargarIntentos();
        }

        private void CargarIntentos()
        {
            try
            {
                dgvIntentos.DataSource = _auth.ObtenerIntentos();

                foreach (DataGridViewRow fila in dgvIntentos.Rows)
                {
                    bool exitoso = (bool)fila.Cells["Exitoso"].Value;
                    fila.DefaultCellStyle.BackColor = exitoso ? Color.Honeydew : Color.MistyRose;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de base de datos:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e) => CargarIntentos();


        private void btnCerrarSesion_Click(object sender, EventArgs e) => Close();

        private void lblIntentos_Click(object sender, EventArgs e)
        {

        }
    }
}
