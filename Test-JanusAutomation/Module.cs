using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

namespace Test_JanusAutomation
{
    internal class Module
    {
        public void Execute(string sqlString)
        {
            string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=Test;Integrated Security=True";
            SqlConnection sqlConnection;
            SqlCommand command;

            sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = connectionString;
            sqlConnection.Open();
            command = new SqlCommand();
            command.Connection = sqlConnection;
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = sqlString;
            command.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void Recover(string sqlString, ref DataTable table)
        {
            string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=Test;Integrated Security=True";
            SqlConnection sqlConnection;
            SqlCommand command;

            sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = connectionString;
            sqlConnection.Open();
            command = new SqlCommand();
            command.Connection = sqlConnection;
            command.CommandType = CommandType.Text;
            command.CommandText = sqlString;
            table = new DataTable();
            table.Load(command.ExecuteReader());
            sqlConnection.Close();
        }

        public void CargarDataGriedView(ref TextBox tbxFilter,ref DataGridView dgv)
        {
            string cadenaSQL = "";
            DataTable table = new DataTable();
            Module module = new Module();


            try
            {
                if (dgv.Name.ToString() == "dgvProductos")
                {
                    cadenaSQL = (tbxFilter.Text.Trim() == String.Empty || tbxFilter.Text.Trim() == "Search a product...")
                    ? "SELECT * FROM vw_StockProducto ORDER BY nombre ASC"
                    : $"SELECT * FROM vw_StockProducto WHERE nombre LIKE '{tbxFilter.Text.Trim()}%' ORDER BY nombre ASC";
                }
                else if (dgv.Name.ToString() == "dgvUser")
                {
                    if (tbxFilter.Text.Trim() == String.Empty || tbxFilter.Text.Trim() == "Search an user...")
                    {
                        cadenaSQL = "SELECT * FROM Usuarios ORDER BY nombre ASC";
                    }
                    else
                    {
                        cadenaSQL = $"SELECT * FROM Usuarios WHERE nombre LIKE '{tbxFilter.Text.Trim()}%' ORDER BY nombre ASC";
                    }
                }
                module.Recover(cadenaSQL, ref table);

                dgv.DataSource = table;
                dgv.AllowUserToAddRows = false;
                dgv.AllowUserToDeleteRows = false;
                dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.AntiqueWhite;
                dgv.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.Goldenrod;
                dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.ColumnHeadersHeight = 50;
                dgv.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9.75F, FontStyle.Bold);
                dgv.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Goldenrod;

            }
            catch(Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
