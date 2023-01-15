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
    public partial class Form1 : Form
    {
        private bool mouseDown;
        private Point lastLocation;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Module module = new Module();
            DataTable dt = new DataTable();
            frmPrincipal p = new frmPrincipal();
            string sqlstring;

            sqlstring = $"SELECT * FROM Usuarios WHERE username = '{tbxUsername.Text.ToUpper()}' and pass = '{tbxPassword.Text.GetHashCode()}'";
            module.Recover(sqlstring,ref dt);

            if (dt.Rows.Count == 1)
            {
                if(dt.Rows[0]["isBlocked"].ToString() == "False")
                {
                    sqlstring = $"SELECT nombre,idRango FROM Usuarios WHERE username = '{tbxUsername.Text.ToUpper()}'";
                    module.Recover(sqlstring, ref dt);
                    Properties.Settings.Default.Username = dt.Rows[0]["Nombre"].ToString();
                    Properties.Settings.Default.Rango = Int32.Parse(dt.Rows[0]["idRango"].ToString());
                    p.ShowDialog();
                }
                else
                {
                    MessageBox.Show("The user is blocked, contact your system administrator!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                
            }
            else
            {
                MessageBox.Show("Wrong username or password","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Module module = new Module();
            DataTable dt = new DataTable();
            frmPrincipal p = new frmPrincipal();
            string sqlstring;
            string username = "Admin";

            sqlstring = $"SELECT * FROM Usuarios";
            module.Recover(sqlstring, ref dt);
            if(dt.Rows.Count == 0)
            {
                sqlstring = $"Exec sp_InsertarUsuario 'AAA-000','{username}','{username}','','{username}','{username.GetHashCode()}','0',10";
                module.Execute(sqlstring);
            }
            CenterToScreen();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Close();
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
