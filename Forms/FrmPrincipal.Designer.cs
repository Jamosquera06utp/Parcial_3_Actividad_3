#nullable disable
namespace Parcial_3_Actividad_2.Forms
{
    partial class FrmPrincipal
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblIntentos = new Label();
            dgvIntentos = new DataGridView();
            btnActualizar = new Button();
            btnCerrarSesion = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvIntentos).BeginInit();
            SuspendLayout();
            // 
            // lblIntentos
            // 
            lblIntentos.AutoSize = true;
            lblIntentos.Location = new Point(17, 87);
            lblIntentos.Name = "lblIntentos";
            lblIntentos.Size = new Size(216, 20);
            lblIntentos.TabIndex = 1;
            lblIntentos.Text = "Historial de intentos de acceso:";
            lblIntentos.Click += lblIntentos_Click;
            // 
            // dgvIntentos
            // 
            dgvIntentos.AllowUserToAddRows = false;
            dgvIntentos.AllowUserToDeleteRows = false;
            dgvIntentos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvIntentos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvIntentos.ColumnHeadersHeight = 29;
            dgvIntentos.Location = new Point(17, 120);
            dgvIntentos.Margin = new Padding(3, 4, 3, 4);
            dgvIntentos.Name = "dgvIntentos";
            dgvIntentos.ReadOnly = true;
            dgvIntentos.RowHeadersVisible = false;
            dgvIntentos.RowHeadersWidth = 51;
            dgvIntentos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvIntentos.Size = new Size(766, 373);
            dgvIntentos.TabIndex = 0;
            // 
            // btnActualizar
            // 
            btnActualizar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnActualizar.Location = new Point(17, 513);
            btnActualizar.Margin = new Padding(3, 4, 3, 4);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(171, 45);
            btnActualizar.TabIndex = 1;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCerrarSesion.Location = new Point(611, 513);
            btnCerrarSesion.Margin = new Padding(3, 4, 3, 4);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(171, 45);
            btnCerrarSesion.TabIndex = 3;
            btnCerrarSesion.Text = "Cerrar sesión";
            btnCerrarSesion.UseVisualStyleBackColor = true;
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 580);
            Controls.Add(dgvIntentos);
            Controls.Add(lblIntentos);
            Controls.Add(btnActualizar);
            Controls.Add(btnCerrarSesion);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(637, 518);
            Name = "FrmPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Panel principal";
            ((System.ComponentModel.ISupportInitialize)dgvIntentos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private System.Windows.Forms.Label lblIntentos;
        private System.Windows.Forms.DataGridView dgvIntentos;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnCerrarSesion;
    }
}
