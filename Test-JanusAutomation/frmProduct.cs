using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Test_JanusAutomation
{
    public partial class frmProduct : Form
    {
        public static int idSelected;
        public static string operation;
        public static string productNameSelected;

        public frmProduct()
        {
            InitializeComponent();
        }

        private void frmProductos_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'testDataSet.vw_StockProducto' table. You can move, or remove it, as needed.
            this.vw_StockProductoTableAdapter.Fill(this.testDataSet.vw_StockProducto);
            cargarGrillaProductos();
            tbxProdFilter.Text = "Search a product...";
            tbxProdFilter.ForeColor = System.Drawing.Color.Gray;
        }

        private void tbxProdFilter_TextChanged(object sender, EventArgs e)
        {
            cargarGrillaProductos();
        }

        private void tbxProdFilter_MouseClick(object sender, EventArgs e)
        {
            tbxProdFilter.Text = String.Empty;
        }

        private void tbxProdFilter_Enter(object sender, EventArgs e)
        {
            if (tbxProdFilter.Text == "Search a product...")
            {
                tbxProdFilter.Text = "";
                tbxProdFilter.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void tbxProdFilter_Leave(object sender, EventArgs e)
        {
            if (tbxProdFilter.Text == String.Empty)
            {
                tbxProdFilter.Text = "Search a product...";
                tbxProdFilter.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show($"Are you sure that you want to delete '{dgvProductos.SelectedRows[0].Cells[0].Value.ToString()}?'", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            Module module = new Module();
            String sqlString;

            if (d == DialogResult.Yes)
            {
                sqlString = $"Exec sp_EliminarProducto '{dgvProductos.SelectedRows[0].Cells[0].Value.ToString()}'";
                module.Execute(sqlString);
                MessageBox.Show($"'{dgvProductos.SelectedRows[0].Cells[0].Value.ToString()}' was deleted.","Information",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cargarGrillaProductos();
            }
            
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddModifyProd frmAddModifyProd = new frmAddModifyProd();
            Module module = new Module();
            DataTable table = new DataTable();
            productNameSelected = dgvProductos.SelectedRows[0].Cells[0].Value.ToString();
            string sqlString = $"SELECT id FROM Producto WHERE nombre = '{productNameSelected}'";

            module.Recover(sqlString, ref table);

            idSelected = Int32.Parse(table.Rows[0]["id"].ToString());
            operation = "MODIFY";
            frmAddModifyProd.ShowDialog();

        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            frmAddModifyProd frmAddModifyProd = new frmAddModifyProd();

            operation = "ADD";
            frmAddModifyProd.ShowDialog();
        }

        private void btnPrintPDF_Click(object sender, EventArgs e)
        {
            int i = 0;

            if (dgvProductos.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();

                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = $"Stock-Report_{DateTime.Now.ToString("dd-MM-yyyy")}.pdf";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("Error:." + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            PdfPTable pdfTable = new PdfPTable(dgvProductos.Columns.Count);
                            pdfTable.DefaultCell.Padding = 5;
                            pdfTable.WidthPercentage = 100;
                            pdfTable.HorizontalAlignment = Element.ALIGN_CENTER;

                       
                            foreach (DataGridViewColumn column in dgvProductos.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, FontFactory.GetFont("Tahoma", 9.75F,iTextSharp.text.Font.BOLD)));
                                cell.BackgroundColor = iTextSharp.text.Color.ORANGE;
                                cell.MinimumHeight = 40;
                                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                                cell.BorderWidth = 1;
                                cell.BorderColor = iTextSharp.text.Color.WHITE;
                                
                                pdfTable.AddCell(cell);
                            }

                            foreach (DataGridViewRow row in dgvProductos.Rows)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    if (i % 2 == 0)
                                    {
                                        pdfTable.DefaultCell.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                                    }
                                    else
                                    {
                                        pdfTable.DefaultCell.BackgroundColor = iTextSharp.text.Color.WHITE;
                                    }
                                    pdfTable.DefaultCell.BorderColor = iTextSharp.text.Color.WHITE;
                                    pdfTable.DefaultCell.MinimumHeight = 40;
                                    pdfTable.AddCell(cell.Value.ToString());
                                }
                                i++;
                            }

                            using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                            {
                                Document pdfDoc = new Document(PageSize.A4, 20f, 20f, 20f, 20f);
                                PdfWriter.GetInstance(pdfDoc, stream);
                                pdfDoc.Open();
                                pdfDoc.Add(pdfTable);
                                pdfDoc.Close();
                                stream.Close();
                            }

                            MessageBox.Show("PDF created succesfully!", "Info");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error :" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No Record To Export !!!", "Info");
            }
        }

        public void cargarGrillaProductos()
        {
            Module module = new Module();

            module.CargarDataGriedView(ref tbxProdFilter, ref dgvProductos);
        }
    }
}
