namespace CocBook
{
    partial class ViewStore
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdPrice = new System.Windows.Forms.RadioButton();
            this.rdPulisher = new System.Windows.Forms.RadioButton();
            this.rdName = new System.Windows.Forms.RadioButton();
            this.rdISBN = new System.Windows.Forms.RadioButton();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnViewAll = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(307, 16);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdPrice);
            this.panel1.Controls.Add(this.rdPulisher);
            this.panel1.Controls.Add(this.rdName);
            this.panel1.Controls.Add(this.rdISBN);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Location = new System.Drawing.Point(50, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(490, 88);
            this.panel1.TabIndex = 1;
            // 
            // rdPrice
            // 
            this.rdPrice.AutoSize = true;
            this.rdPrice.Location = new System.Drawing.Point(389, 56);
            this.rdPrice.Name = "rdPrice";
            this.rdPrice.Size = new System.Drawing.Size(41, 18);
            this.rdPrice.TabIndex = 5;
            this.rdPrice.TabStop = true;
            this.rdPrice.Text = "Giá";
            this.rdPrice.UseVisualStyleBackColor = true;
            // 
            // rdPulisher
            // 
            this.rdPulisher.AutoSize = true;
            this.rdPulisher.Location = new System.Drawing.Point(247, 56);
            this.rdPulisher.Name = "rdPulisher";
            this.rdPulisher.Size = new System.Drawing.Size(89, 18);
            this.rdPulisher.TabIndex = 4;
            this.rdPulisher.TabStop = true;
            this.rdPulisher.Text = "Nhà xuất bản";
            this.rdPulisher.UseVisualStyleBackColor = true;
            // 
            // rdName
            // 
            this.rdName.AutoSize = true;
            this.rdName.Location = new System.Drawing.Point(119, 56);
            this.rdName.Name = "rdName";
            this.rdName.Size = new System.Drawing.Size(70, 18);
            this.rdName.TabIndex = 3;
            this.rdName.TabStop = true;
            this.rdName.Text = "Tên sách";
            this.rdName.UseVisualStyleBackColor = true;
            // 
            // rdISBN
            // 
            this.rdISBN.AutoSize = true;
            this.rdISBN.Location = new System.Drawing.Point(22, 56);
            this.rdISBN.Name = "rdISBN";
            this.rdISBN.Size = new System.Drawing.Size(48, 18);
            this.rdISBN.TabIndex = 2;
            this.rdISBN.TabStop = true;
            this.rdISBN.Text = "ISBN";
            this.rdISBN.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(22, 16);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(251, 20);
            this.txtSearch.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Quantity});
            this.dataGridView1.Location = new System.Drawing.Point(18, 132);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(642, 171);
            this.dataGridView1.TabIndex = 2;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "ISBNBook";
            this.Column1.HeaderText = "ISBNBook";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "BookName";
            this.Column2.HeaderText = "Tên sách";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Publisher";
            this.Column3.HeaderText = "NXB";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Unit";
            this.Column4.HeaderText = "ĐVT";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "Price";
            this.Column5.HeaderText = "Giá";
            this.Column5.Name = "Column5";
            // 
            // Quantity
            // 
            this.Quantity.DataPropertyName = "Quantity";
            this.Quantity.HeaderText = "Số lượng";
            this.Quantity.Name = "Quantity";
            // 
            // btnViewAll
            // 
            this.btnViewAll.Location = new System.Drawing.Point(569, 63);
            this.btnViewAll.Name = "btnViewAll";
            this.btnViewAll.Size = new System.Drawing.Size(75, 23);
            this.btnViewAll.TabIndex = 3;
            this.btnViewAll.Text = "Xem toàn bộ";
            this.btnViewAll.UseVisualStyleBackColor = true;
            this.btnViewAll.Click += new System.EventHandler(this.btnViewAll_Click);
            // 
            // ViewStore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 317);
            this.Controls.Add(this.btnViewAll);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "ViewStore";
            this.Text = "Chi tiết kho";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.RadioButton rdPrice;
        private System.Windows.Forms.RadioButton rdPulisher;
        private System.Windows.Forms.RadioButton rdName;
        private System.Windows.Forms.RadioButton rdISBN;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.Button btnViewAll;
    }
}