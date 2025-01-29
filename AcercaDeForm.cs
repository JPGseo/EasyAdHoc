using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace AdHocZone
{
    partial class AcercaDeForm : Form
    {
        public AcercaDeForm()
        {
            InitializeComponent();
            this.Text = String.Format("Acerca de {0}", AssemblyTitle);
        }

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void tableLayoutPanel_Paint(object sender, PaintEventArgs e)
        {
        }

        private void AcercaDeForm_Load(object sender, EventArgs e)
        {
            AddStyledTextToRichTextBox();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:kokesuzuki@gmail.com");
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void AddStyledTextToRichTextBox()
        {
            float titleFontSize = richTextBox1.Font.Size + 1;

            richTextBox1.SelectionFont = new Font(richTextBox1.Font.FontFamily, titleFontSize, FontStyle.Bold);
            richTextBox1.AppendText("¿Para qué sirve EasyAdHoc?\n\n");

            richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
            richTextBox1.AppendText("EasyAdHoc es una herramienta sencilla que te permite crear una red ad-hoc local a través del receptor WiFi de tu PC con solo unos clics. Este programa soluciona la limitación de Windows, que solo permite crear una \"Zona WiFi\" si estás conectado a Internet. Con EasyAdHoc, puedes crear esta red sin necesidad de estar conectado (offline).\n\n");

            richTextBox1.SelectionFont = new Font(richTextBox1.Font.FontFamily, titleFontSize, FontStyle.Bold);
            richTextBox1.AppendText("Situaciones típicas de uso:\n\n");

            richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
            richTextBox1.AppendText("- Crear un puente para establecer una conexión OFFline.\n");
            richTextBox1.AppendText("- Conectar dispositivos sin cables y sin Internet a tu PC para acceder a sus archivos, mediante aplicaciones FTP.\n");
            richTextBox1.AppendText("   Unos ejemplos:\n");
            richTextBox1.AppendText(" - FileZilla (Windows).\n");
            richTextBox1.AppendText(" - ES File Explorer o CX Explorer (Android).\n\n");

            richTextBox1.SelectionFont = new Font(richTextBox1.Font.FontFamily, titleFontSize, FontStyle.Bold);
            richTextBox1.AppendText("Uso:\n\n");

            richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
            richTextBox1.AppendText("1. Establece el SSID y la contraseña (mínimo 8 caracteres).\n");
            richTextBox1.AppendText("2. Haz clic en ON. Después de unos segundos, tu nueva red debería aparecer en la lista de Conexiones de Red.\n\n");

            richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Italic);
            richTextBox1.AppendText("*Nota:\n\n");

            richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
            richTextBox1.AppendText("\"Terminar proceso al salir\" está activado por defecto para asegurar que el proceso se cierre correctamente cuando no se está usando.");

            richTextBox1.SelectionStart = 0;
            richTextBox1.ScrollToCaret();
        }
    }
}


