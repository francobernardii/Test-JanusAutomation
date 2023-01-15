using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_JanusAutomation
{
    public partial class frmPrincipal : Form
    {
        private bool mouseDown;
        private Point lastLocation;
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            btnDashBar.BackColor = Color.WhiteSmoke;
            btnDashboard.BackColor = Color.DarkGoldenrod;

            if (Properties.Settings.Default.Rango == 10)
            {
                btnUser.Visible = true;
                btnDashboard.Visible = true;
                btnProductos.Visible = true;
            }
            else if (Properties.Settings.Default.Rango == 20)
            {
                btnUser.Visible = false;
                btnDashboard.Visible = true;
                btnProductos.Visible = true;
            }
            else
            {
                btnUser.Visible = false;
                btnProductos.Visible = false;
                btnDashboard.Visible = true;
            }
            AbrirFormulario<frmDashboard>();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            btnDashBar.BackColor = Color.White;
            btnDashboard.BackColor = Color.DarkGoldenrod;
            btnProdBar.BackColor = Color.Goldenrod;
            btnProductos.BackColor = Color.Goldenrod;
            btnUser.BackColor = Color.Goldenrod;
            btnUserBar.BackColor = Color.Goldenrod;
            AbrirFormulario<frmDashboard>();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            CenterToScreen();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnProductos_Click_1(object sender, EventArgs e)
        {
            
            btnProdBar.BackColor = Color.White;
            btnProductos.BackColor = Color.DarkGoldenrod;
            btnDashBar.BackColor = Color.Goldenrod;
            btnDashboard.BackColor = Color.Goldenrod;
            btnUser.BackColor = Color.Goldenrod;
            btnUserBar.BackColor = Color.Goldenrod;
            AbrirFormulario<frmProduct>();
        }

        private void AbrirFormulario<MiForm>() where MiForm : Form, new()
        {
            Form formulario;
            formulario = pnlFormularios.Controls.OfType<MiForm>().FirstOrDefault();

            //Si es la primera vez que abro el formulario
            if (formulario == null)
            {
                formulario = new MiForm();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;
                pnlFormularios.Controls.Add(formulario);
                pnlFormularios.Tag = formulario;
                formulario.Show();
                formulario.BringToFront();
            }
            //Si ya abri el formulario
            else
            {
                formulario.BringToFront();
            }
        
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            btnUserBar.BackColor = Color.White;
            btnUser.BackColor = Color.DarkGoldenrod;
            btnDashBar.BackColor = Color.Goldenrod;
            btnDashboard.BackColor = Color.Goldenrod;
            btnProductos.BackColor = Color.Goldenrod;
            btnProductos.BackColor = Color.Goldenrod;
            AbrirFormulario<frmUsers>();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
    }
}
