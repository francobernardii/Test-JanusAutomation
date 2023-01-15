namespace Test_JanusAutomation
{
    partial class frmProduct
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoríaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsProductos = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.modificarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vwStockProductoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.testDataSet = new Test_JanusAutomation.TestDataSet();
            this.tbxProdFilter = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.vw_StockProductoTableAdapter = new Test_JanusAutomation.TestDataSetTableAdapters.vw_StockProductoTableAdapter();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.btnPrintPDF = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.cmsProductos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vwStockProductoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.testDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProductos
            // 
            this.dgvProductos.AutoGenerateColumns = false;
            this.dgvProductos.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvProductos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProductos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombreDataGridViewTextBoxColumn,
            this.precioDataGridViewTextBoxColumn,
            this.categoríaDataGridViewTextBoxColumn,
            this.cantidadDataGridViewTextBoxColumn});
            this.dgvProductos.ContextMenuStrip = this.cmsProductos;
            this.dgvProductos.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgvProductos.DataSource = this.vwStockProductoBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Tan;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProductos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvProductos.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvProductos.EnableHeadersVisualStyles = false;
            this.dgvProductos.GridColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvProductos.Location = new System.Drawing.Point(0, 171);
            this.dgvProductos.MultiSelect = false;
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Goldenrod;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProductos.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvProductos.RowHeadersVisible = false;
            this.dgvProductos.RowTemplate.Height = 40;
            this.dgvProductos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductos.Size = new System.Drawing.Size(827, 354);
            this.dgvProductos.TabIndex = 0;
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            this.nombreDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre";
            this.nombreDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            this.nombreDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // precioDataGridViewTextBoxColumn
            // 
            this.precioDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.precioDataGridViewTextBoxColumn.DataPropertyName = "Precio";
            this.precioDataGridViewTextBoxColumn.HeaderText = "Price";
            this.precioDataGridViewTextBoxColumn.Name = "precioDataGridViewTextBoxColumn";
            this.precioDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // categoríaDataGridViewTextBoxColumn
            // 
            this.categoríaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.categoríaDataGridViewTextBoxColumn.DataPropertyName = "Categoría";
            this.categoríaDataGridViewTextBoxColumn.HeaderText = "Category";
            this.categoríaDataGridViewTextBoxColumn.Name = "categoríaDataGridViewTextBoxColumn";
            this.categoríaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cantidadDataGridViewTextBoxColumn
            // 
            this.cantidadDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cantidadDataGridViewTextBoxColumn.DataPropertyName = "Cantidad";
            this.cantidadDataGridViewTextBoxColumn.HeaderText = "Quantity";
            this.cantidadDataGridViewTextBoxColumn.Name = "cantidadDataGridViewTextBoxColumn";
            this.cantidadDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cmsProductos
            // 
            this.cmsProductos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modificarToolStripMenuItem,
            this.eliminarToolStripMenuItem});
            this.cmsProductos.Name = "cmsProductos";
            this.cmsProductos.Size = new System.Drawing.Size(181, 70);
            // 
            // modificarToolStripMenuItem
            // 
            this.modificarToolStripMenuItem.Name = "modificarToolStripMenuItem";
            this.modificarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.modificarToolStripMenuItem.Text = "Edit";
            this.modificarToolStripMenuItem.Click += new System.EventHandler(this.modificarToolStripMenuItem_Click);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.eliminarToolStripMenuItem.Text = "Delete";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // vwStockProductoBindingSource
            // 
            this.vwStockProductoBindingSource.DataMember = "vw_StockProducto";
            this.vwStockProductoBindingSource.DataSource = this.testDataSet;
            // 
            // testDataSet
            // 
            this.testDataSet.DataSetName = "TestDataSet";
            this.testDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tbxProdFilter
            // 
            this.tbxProdFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbxProdFilter.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxProdFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxProdFilter.Location = new System.Drawing.Point(236, 71);
            this.tbxProdFilter.Name = "tbxProdFilter";
            this.tbxProdFilter.Size = new System.Drawing.Size(333, 19);
            this.tbxProdFilter.TabIndex = 1;
            this.tbxProdFilter.TextChanged += new System.EventHandler(this.tbxProdFilter_TextChanged);
            this.tbxProdFilter.Enter += new System.EventHandler(this.tbxProdFilter_Enter);
            this.tbxProdFilter.Leave += new System.EventHandler(this.tbxProdFilter_Leave);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Location = new System.Drawing.Point(226, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(354, 41);
            this.panel1.TabIndex = 2;
            // 
            // vw_StockProductoTableAdapter
            // 
            this.vw_StockProductoTableAdapter.ClearBeforeFill = true;
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.BackColor = System.Drawing.Color.Goldenrod;
            this.btnAddProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddProduct.FlatAppearance.BorderSize = 0;
            this.btnAddProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddProduct.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnAddProduct.Location = new System.Drawing.Point(226, 122);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(156, 31);
            this.btnAddProduct.TabIndex = 26;
            this.btnAddProduct.Text = "Agregar Producto";
            this.btnAddProduct.UseVisualStyleBackColor = false;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // btnPrintPDF
            // 
            this.btnPrintPDF.BackColor = System.Drawing.Color.Goldenrod;
            this.btnPrintPDF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrintPDF.FlatAppearance.BorderSize = 0;
            this.btnPrintPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintPDF.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnPrintPDF.Location = new System.Drawing.Point(424, 122);
            this.btnPrintPDF.Name = "btnPrintPDF";
            this.btnPrintPDF.Size = new System.Drawing.Size(156, 31);
            this.btnPrintPDF.TabIndex = 27;
            this.btnPrintPDF.Text = "Imprimir PDF";
            this.btnPrintPDF.UseVisualStyleBackColor = false;
            this.btnPrintPDF.Click += new System.EventHandler(this.btnPrintPDF_Click);
            // 
            // frmProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 525);
            this.Controls.Add(this.btnPrintPDF);
            this.Controls.Add(this.btnAddProduct);
            this.Controls.Add(this.tbxProdFilter);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvProductos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmProduct";
            this.Text = "frmProductos";
            this.Load += new System.EventHandler(this.frmProductos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.cmsProductos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vwStockProductoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.testDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.TextBox tbxProdFilter;
        private System.Windows.Forms.Panel panel1;
        private TestDataSet testDataSet;
        private System.Windows.Forms.BindingSource vwStockProductoBindingSource;
        private TestDataSetTableAdapters.vw_StockProductoTableAdapter vw_StockProductoTableAdapter;
        private System.Windows.Forms.ContextMenuStrip cmsProductos;
        private System.Windows.Forms.ToolStripMenuItem modificarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoríaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnPrintPDF;
    }
}