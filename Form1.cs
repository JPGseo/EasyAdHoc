using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AdHocZone
{
    public partial class Form1 : Form
    {
        // Importar funciones de la API de Windows
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // Mantiene la barra de título sin bordes ajustables
            this.MaximizeBox = false;  // Oculta el botón de maximizar
            this.MinimizeBox = true;   // Muestra el botón de minimizar
            this.ControlBox = true;    // Mantiene la barra de título visible con minimizar y cerrar
      
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0xA1, 0x2, 0);
            }
        }

        private void btnOn_Click(object sender, EventArgs e)
        {
            string ssid = txtSSID.Text;
            string password = txtPassword.Text;

            // Verificar que la contraseña tenga al menos 8 caracteres
            if (string.IsNullOrWhiteSpace(password) || password.Length < 8)
            {
                MessageBox.Show("La contraseña debe tener al menos 8 caracteres.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Verificar que el campo ssid no esté vacío
            if (string.IsNullOrWhiteSpace(ssid) || password.Length < 1)
            {
                MessageBox.Show("SSID no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string command = $"netsh wlan set hostednetwork mode=allow ssid={ssid} key={password}; netsh wlan start hostednetwork";
            EjecutarPowerShell(command);

            // Abrir el Panel de control en la sección de "Redes e Internet\Conexiones de red"
            Process.Start("control.exe", "ncpa.cpl");
        }

        private void btnOff_Click(object sender, EventArgs e)
        {
            string command = "netsh wlan stop hostednetwork";
            EjecutarPowerShell(command);
        }

        private void EjecutarPowerShell(string comando)
        {
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = "powershell.exe";
            psi.Arguments = $"-NoProfile -ExecutionPolicy Bypass -Command \"{comando}\"";
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;

            using (Process proceso = Process.Start(psi))
            {
                string resultado = proceso.StandardOutput.ReadToEnd();
                string error = proceso.StandardError.ReadToEnd();
                proceso.WaitForExit();

                if (!string.IsNullOrEmpty(error))
                {
                    MessageBox.Show("Error: " + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // No se necesita verificar el estado al cargar el formulario
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AcercaDeForm acercaDeForm = new AcercaDeForm();
            acercaDeForm.ShowDialog();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            // Detener la red hospedada al cerrar el formulario si la casilla está marcada
            if (checkBox1.Checked)
            {
                btnOff_Click(this, EventArgs.Empty);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void acercaDeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AcercaDeForm acercaDeForm = new AcercaDeForm();
            acercaDeForm.ShowDialog();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ayudaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AcercaDeForm ayuda = new AcercaDeForm();
            ayuda.ShowDialog();
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void txtSSID_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
