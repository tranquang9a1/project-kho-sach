namespace CocBook
{
    partial class BillDetail
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
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.RowISBN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowBookName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowDiscount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.lbDetail = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBoxDetail = new System.Windows.Forms.GroupBox();
            this.btnViewStore = new System.Windows.Forms.Button();
            this.btnSaveDetail = new System.Windows.Forms.Button();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBookName = new System.Windows.Forms.TextBox();
            this.btnChooseBook = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBoxDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(6, 69);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(180, 17);
            this.linkLabel1.TabIndex = 5;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "www.facebook.com/cocbook";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowISBN,
            this.RowBookName,
            this.RowUnit,
            this.RowQuantity,
            this.RowPrice,
            this.RowDiscount,
            this.RowValue});
            this.dataGridView1.Location = new System.Drawing.Point(31, 40);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(894, 238);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
            // 
            // RowISBN
            // 
            this.RowISBN.DataPropertyName = "ISBNBook";
            this.RowISBN.HeaderText = "Mã hàng";
            this.RowISBN.Name = "RowISBN";
            // 
            // RowBookName
            // 
            this.RowBookName.DataPropertyName = "BookName";
            this.RowBookName.HeaderText = "Tên sách";
            this.RowBookName.Name = "RowBookName";
            this.RowBookName.Width = 250;
            // 
            // RowUnit
            // 
            this.RowUnit.DataPropertyName = "Unit";
            this.RowUnit.HeaderText = "Đơn vị tính";
            this.RowUnit.Name = "RowUnit";
            // 
            // RowQuantity
            // 
            this.RowQuantity.DataPropertyName = "Quantity";
            this.RowQuantity.HeaderText = "Số lượng";
            this.RowQuantity.Name = "RowQuantity";
            // 
            // RowPrice
            // 
            this.RowPrice.DataPropertyName = "Price";
            this.RowPrice.HeaderText = "Giá bìa";
            this.RowPrice.Name = "RowPrice";
            // 
            // RowDiscount
            // 
            this.RowDiscount.DataPropertyName = "Discount";
            this.RowDiscount.HeaderText = "Chiết khấu";
            this.RowDiscount.Name = "RowDiscount";
            // 
            // RowValue
            // 
            this.RowValue.DataPropertyName = "Value";
            this.RowValue.HeaderText = "Thành tiền";
            this.RowValue.Name = "RowValue";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CocBook.Properties.Resources.Logo;
            this.pictureBox1.Location = new System.Drawing.Point(9, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(173, 63);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(436, 318);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Xóa dòng";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(186, 318);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Thêm dòng";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(692, 318);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "Xuất Excel";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.linkLabel1);
            this.panel1.Location = new System.Drawing.Point(98, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(427, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 24);
            this.label1.TabIndex = 11;
            this.label1.Text = "CHI TIẾT ĐƠN HÀNG";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Excel 2003|*.xls";
            // 
            // lbDetail
            // 
            this.lbDetail.AutoSize = true;
            this.lbDetail.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDetail.Location = new System.Drawing.Point(427, 85);
            this.lbDetail.Name = "lbDetail";
            this.lbDetail.Size = new System.Drawing.Size(59, 22);
            this.lbDetail.TabIndex = 12;
            this.lbDetail.Text = "label2";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnExport);
            this.groupBox3.Controls.Add(this.btnDelete);
            this.groupBox3.Controls.Add(this.dataGridView1);
            this.groupBox3.Controls.Add(this.btnAdd);
            this.groupBox3.Location = new System.Drawing.Point(12, 171);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(962, 381);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Danh sách";
            // 
            // groupBoxDetail
            // 
            this.groupBoxDetail.Controls.Add(this.btnViewStore);
            this.groupBoxDetail.Controls.Add(this.btnSaveDetail);
            this.groupBoxDetail.Controls.Add(this.txtDiscount);
            this.groupBoxDetail.Controls.Add(this.txtQuantity);
            this.groupBoxDetail.Controls.Add(this.label3);
            this.groupBoxDetail.Controls.Add(this.label2);
            this.groupBoxDetail.Controls.Add(this.txtBookName);
            this.groupBoxDetail.Controls.Add(this.btnChooseBook);
            this.groupBoxDetail.Enabled = false;
            this.groupBoxDetail.Location = new System.Drawing.Point(994, 171);
            this.groupBoxDetail.Name = "groupBoxDetail";
            this.groupBoxDetail.Size = new System.Drawing.Size(246, 381);
            this.groupBoxDetail.TabIndex = 14;
            this.groupBoxDetail.TabStop = false;
            this.groupBoxDetail.Text = "Chi tiết";
            // 
            // btnViewStore
            // 
            this.btnViewStore.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewStore.Location = new System.Drawing.Point(142, 255);
            this.btnViewStore.Name = "btnViewStore";
            this.btnViewStore.Size = new System.Drawing.Size(75, 23);
            this.btnViewStore.TabIndex = 7;
            this.btnViewStore.Text = "Xem kho";
            this.btnViewStore.UseVisualStyleBackColor = true;
            this.btnViewStore.Click += new System.EventHandler(this.btnViewStore_Click);
            // 
            // btnSaveDetail
            // 
            this.btnSaveDetail.Location = new System.Drawing.Point(42, 255);
            this.btnSaveDetail.Name = "btnSaveDetail";
            this.btnSaveDetail.Size = new System.Drawing.Size(75, 23);
            this.btnSaveDetail.TabIndex = 6;
            this.btnSaveDetail.Text = "Lưu đơn hàng";
            this.btnSaveDetail.UseVisualStyleBackColor = true;
            this.btnSaveDetail.Click += new System.EventHandler(this.btnSaveDetail_Click);
            // 
            // txtDiscount
            // 
            this.txtDiscount.Location = new System.Drawing.Point(120, 162);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(107, 20);
            this.txtDiscount.TabIndex = 5;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(120, 108);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(107, 20);
            this.txtQuantity.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 14);
            this.label3.TabIndex = 3;
            this.label3.Text = "Chiết khấu (%) :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Số lượng :";
            // 
            // txtBookName
            // 
            this.txtBookName.Location = new System.Drawing.Point(120, 29);
            this.txtBookName.Multiline = true;
            this.txtBookName.Name = "txtBookName";
            this.txtBookName.ReadOnly = true;
            this.txtBookName.Size = new System.Drawing.Size(107, 58);
            this.txtBookName.TabIndex = 1;
            // 
            // btnChooseBook
            // 
            this.btnChooseBook.Enabled = false;
            this.btnChooseBook.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChooseBook.Location = new System.Drawing.Point(16, 29);
            this.btnChooseBook.Name = "btnChooseBook";
            this.btnChooseBook.Size = new System.Drawing.Size(75, 23);
            this.btnChooseBook.TabIndex = 0;
            this.btnChooseBook.Text = "Chọn sách :";
            this.btnChooseBook.UseVisualStyleBackColor = true;
            this.btnChooseBook.Click += new System.EventHandler(this.btnChooseBook_Click);
            // 
            // BillDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1252, 579);
            this.Controls.Add(this.groupBoxDetail);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.lbDetail);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "BillDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi tiết đơn hàng";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBoxDetail.ResumeLayout(false);
            this.groupBoxDetail.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label lbDetail;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBoxDetail;
        private System.Windows.Forms.Button btnChooseBook;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowISBN;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowBookName;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowDiscount;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowValue;
        private System.Windows.Forms.TextBox txtBookName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Button btnSaveDetail;
        private System.Windows.Forms.Button btnViewStore;
    }
}