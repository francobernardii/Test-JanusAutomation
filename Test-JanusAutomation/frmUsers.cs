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
    public partial class frmUsers : Form
    {
        public static int idSelected;
        public static string operation;
        public static string userNameSelected;
        public frmUsers()
        {
            InitializeComponent();
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            Module m = new Module();
            // TODO: This line of code loads data into the 'testDataSet3.Usuarios' table. You can move, or remove it, as needed.
            this.usuariosTableAdapter.Fill(this.testDataSet3.Usuarios);
            m.CargarDataGriedView(ref tbxUserFilter, ref dgvUser);
            tbxUserFilter.Text = "Search an user...";
            tbxUserFilter.ForeColor = System.Drawing.Color.Gray;
        }

        private void tbxUserFilter_TextChanged(object sender, EventArgs e)
        {
            Module m = new Module();
            m.CargarDataGriedView(ref tbxUserFilter, ref dgvUser);
        }

        private void tbxUserFilter_MouseClick(object sender, EventArgs e)
        {
            tbxUserFilter.Text = String.Empty;
        }

        private void tbxUserFilter_Enter(object sender, EventArgs e)
        {
            if (tbxUserFilter.Text == "Search an user...")
            {
                tbxUserFilter.Text = "";
                tbxUserFilter.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void tbxUserFilter_Leave(object sender, EventArgs e)
        {
            if (tbxUserFilter.Text == String.Empty)
            {
                tbxUserFilter.Text = "Search an user...";
                tbxUserFilter.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void modifyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddModifyUser frmAddModifyUser = new frmAddModifyUser();
            Module module = new Module();
            DataTable table = new DataTable();
            userNameSelected = dgvUser.SelectedRows[0].Cells[4].Value.ToString();
            string sqlString = $"SELECT id FROM Usuarios WHERE username = '{userNameSelected}'";

            module.Recover(sqlString, ref table);

            idSelected = Int32.Parse(table.Rows[0]["id"].ToString());
            operation = "MODIFY";
            frmAddModifyUser.ShowDialog();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmAddModifyUser frmAddModifyUser = new frmAddModifyUser();

            operation = "ADD";
            frmAddModifyUser.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show($"Are you sure that you want to delete the username '{dgvUser.SelectedRows[0].Cells[4].Value.ToString()}' from the system?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            Module module = new Module();
            string sqlString;
            DataTable table = new DataTable();

            if (d == DialogResult.Yes)
            {
                userNameSelected = dgvUser.SelectedRows[0].Cells[4].Value.ToString();
                sqlString = $"Exec sp_EliminarUsuario '{frmUsers.userNameSelected}'";
                module.Execute(sqlString);
                MessageBox.Show($"'{dgvUser.SelectedRows[0].Cells[4].Value.ToString()}' was deleted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                module.CargarDataGriedView(ref tbxUserFilter, ref dgvUser);
            }
        }
    }
}
