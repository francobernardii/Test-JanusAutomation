using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
namespace Test_JanusAutomation
{
    public partial class frmAddModifyUser : Form
    {
        private bool mouseDown;
        private Point lastLocation;
        public frmAddModifyUser()
        {
            InitializeComponent();
        }

        private void frmAddModifyUser_Load(object sender, EventArgs e)
        {
            Module module = new Module();
            DataTable table = new DataTable();
            string sqlString;

            sqlString = $"SELECT * FROM Rangos";
            module.Recover(sqlString, ref table);

            cbxRange.DataSource = table;
            cbxRange.DisplayMember = "descripcion";
            cbxRange.ValueMember = "idRango";
            cbxRange.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxRange.SelectedIndex = 0;

            if (frmUsers.operation == "MODIFY")
            {
                btnAddModify.Text = "Edit";
                lblAddModifyUser.Text = "Edit User";

                sqlString = $"SELECT * FROM Usuarios WHERE username = '{frmUsers.userNameSelected}'";
                module.Recover(sqlString, ref table);

                tbxFileName.Text = table.Rows[0]["nro_legajo"].ToString();
                tbxName.Text = table.Rows[0]["nombre"].ToString();
                tbxLastname.Text = table.Rows[0]["apellido"].ToString();
                tbxEmail.Text = table.Rows[0]["email"].ToString();
                tbxUsername.Text = table.Rows[0]["username"].ToString();
                if(bool.Parse(table.Rows[0]["isBlocked"].ToString()) == false)
                {
                    cbxBlocked.Checked = false;
                }
                else if(bool.Parse(table.Rows[0]["isBlocked"].ToString()) == true)
                {
                    cbxBlocked.Checked = true;
                }
                cbxRange.SelectedValue = table.Rows[0]["idRango"];
            }
            else if (frmUsers.operation == "ADD")
            {
                btnAddModify.Text = "Add";
                lblAddModifyUser.Text = "Add User";
            }
            CenterToScreen();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddModify_Click(object sender, EventArgs e)
        {
            Module module = new Module();
            string sqlString;
            DataTable table = new DataTable();

            if (frmUsers.operation == "MODIFY")
            {
                sqlString = $"SELECT * FROM Usuarios WHERE username = '{tbxUsername.Text}' and id != {frmUsers.idSelected}";
                module.Recover(sqlString, ref table);
                if (table.Rows.Count == 0)
                {
                    if(tbxPassword.Text == String.Empty)
                    {
                        sqlString = $"SELECT pass FROM Usuarios WHERE username = '{tbxUsername.Text}' and id = {frmUsers.idSelected}";
                        module.Recover(sqlString, ref table);
                        sqlString = $"Exec sp_ModificarUsuario {frmUsers.idSelected},'{tbxFileName.Text.Trim().ToUpper()}','{tbxName.Text.Trim()}','{tbxLastname.Text.Trim()}','{tbxEmail.Text.Trim().ToUpper()}','{tbxUsername.Text.Trim().ToUpper()}','{table.Rows[0]["pass"]}',{cbxBlocked.Checked},{cbxRange.SelectedValue}";
                        module.Execute(sqlString);
                        MessageBox.Show("The user was updated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        sqlString = $"Exec sp_ModificarUsuario {frmUsers.idSelected},'{tbxFileName.Text.Trim().ToUpper()}','{tbxName.Text.Trim()}','{tbxLastname.Text.Trim()}','{tbxEmail.Text.Trim().ToUpper()}','{tbxUsername.Text.Trim().ToUpper()}','{tbxPassword.Text.Trim().ToString().GetHashCode()}',{cbxBlocked.Checked},{cbxRange.SelectedValue}";
                        module.Execute(sqlString);
                        MessageBox.Show("The user was updated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                     
                }
                else
                {
                    MessageBox.Show($"There is a user with the username '{tbxUsername.Text}' on the list, please check the information!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (frmUsers.operation == "ADD")
            {
                sqlString = $"SELECT * FROM Usuarios WHERE username = '{tbxUsername.Text}'";
                module.Recover(sqlString, ref table);
                if (table.Rows.Count == 0)
                {
                    sqlString = $"Exec sp_InsertarUsuario '{tbxFileName.Text.Trim().ToUpper()}','{tbxName.Text.Trim()}','{tbxLastname.Text.Trim()}','{tbxEmail.Text.Trim().ToUpper()}','{tbxUsername.Text.Trim().ToUpper()}','{tbxPassword.Text.Trim().GetHashCode()}',{cbxBlocked.Checked},{cbxRange.SelectedValue}";
                    module.Execute(sqlString);
                    MessageBox.Show($"The user {tbxUsername.Text} was added succesfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"There is a user with the username '{tbxUsername.Text}' on the list,  please check the information!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
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

        private void pbxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pbxMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
