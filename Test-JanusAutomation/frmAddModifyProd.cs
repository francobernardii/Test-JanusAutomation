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
    public partial class frmAddModifyProd : Form
    {
        private bool mouseDown;
        private Point lastLocation;
        public frmAddModifyProd()
        {
            InitializeComponent();
        }

        private void frmModifyProd_Load(object sender, EventArgs e)
        {
            Module module = new Module();
            DataTable table = new DataTable();
            string sqlString;

            sqlString = $"SELECT * FROM TipoProducto";
            module.Recover(sqlString, ref table);

            cbxProductType.DataSource = table;
            cbxProductType.DisplayMember = "descripcion";
            cbxProductType.ValueMember = "id";
            cbxProductType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxProductType.SelectedIndex = 0;

            if (frmProduct.operation == "MODIFY")
            {
                sqlString = $"SELECT * FROM vw_StockProducto WHERE nombre = '{frmProduct.productNameSelected}'";
                module.Recover(sqlString, ref table);

                btnAddModify.Text = "Modify";
                lblAddModify.Text = "Modify Product";
                tbxProdName.Text = table.Rows[0]["Nombre"].ToString();
                nudPrice.Value = Int32.Parse(table.Rows[0]["Precio"].ToString());
                nudQuantity.Value = Int32.Parse(table.Rows[0]["Cantidad"].ToString());

                sqlString = $"SELECT id FROM TipoProducto WHERE descripcion = '{table.Rows[0]["Categoría"].ToString()}'";
                module.Recover(sqlString, ref table);

                cbxProductType.SelectedValue = table.Rows[0]["id"];
            }else if (frmProduct.operation == "ADD")
            {
                btnAddModify.Text = "Add";
                lblAddModify.Text = "Add Product";
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

            if (frmProduct.operation == "MODIFY")
            {
                sqlString = $"SELECT * FROM Producto WHERE nombre = '{tbxProdName.Text}' and id != {frmProduct.idSelected}";
                module.Recover(sqlString, ref table);
                if (table.Rows.Count == 0)
                {
                    sqlString = $"Exec sp_ModificarProducto {frmProduct.idSelected},{cbxProductType.SelectedValue},{tbxProdName.Text.Trim()},{nudPrice.Value},{nudQuantity.Value}";
                    module.Execute(sqlString);
                    MessageBox.Show("The product was updated succesfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"There is a user called '{tbxProdName.Text}, please check the information.'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            else if (frmProduct.operation == "ADD")
            {
                sqlString = $"SELECT * FROM Producto WHERE Nombre = '{tbxProdName.Text}'";
                module.Recover(sqlString, ref table);
    
                if (table.Rows.Count == 0)
                {
                        sqlString = $"Exec sp_InsertarProducto {cbxProductType.SelectedValue},{tbxProdName.Text.Trim()},{nudPrice.Value},{nudQuantity.Value}";
                        module.Execute(sqlString);
                        MessageBox.Show($"The product '{tbxProdName.Text}' was added.!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"There is a product called '{tbxProdName.Text}' in the list, please check the information!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
