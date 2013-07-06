namespace CocBook
{
    partial class ImExManage
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.CheckNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Day = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSearch = new System.Windows.Forms.Button();
            this.rbExport = new System.Windows.Forms.RadioButton();
            this.rbImport = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnLoadAll = new System.Windows.Forms.Button();
            this.groupBoxDetail = new System.Windows.Forms.GroupBox();
            this.btnCheckDetail = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.btnChooseCustomer = new System.Windows.Forms.Button();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.radioButtonExport = new System.Windows.Forms.RadioButton();
            this.radioButtonImport = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDay = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCheckNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBoxDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(289, 404);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CheckNo,
            this.Day,
            this.IE,
            this.Type,
            this.CustomerName});
            this.dataGridView1.Location = new System.Drawing.Point(44, 93);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(643, 273);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
            // 
            // CheckNo
            // 
            this.CheckNo.DataPropertyName = "CheckNo";
            this.CheckNo.HeaderText = "Số phiếu";
            this.CheckNo.Name = "CheckNo";
            this.CheckNo.ReadOnly = true;
            // 
            // Day
            // 
            this.Day.DataPropertyName = "Date";
            this.Day.HeaderText = "Ngày";
            this.Day.Name = "Day";
            this.Day.ReadOnly = true;
            // 
            // IE
            // 
            this.IE.DataPropertyName = "ImEx";
            this.IE.HeaderText = "Nhập/Xuất";
            this.IE.Name = "IE";
            this.IE.ReadOnly = true;
            // 
            // Type
            // 
            this.Type.DataPropertyName = "Type";
            this.Type.HeaderText = "Loại";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            // 
            // CustomerName
            // 
            this.CustomerName.DataPropertyName = "CustomerName";
            this.CustomerName.HeaderText = "Tên khách hàng";
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.ReadOnly = true;
            this.CustomerName.Width = 200;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(209, 16);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 25);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Lọc";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // rbExport
            // 
            this.rbExport.AutoSize = true;
            this.rbExport.Location = new System.Drawing.Point(103, 19);
            this.rbExport.Name = "rbExport";
            this.rbExport.Size = new System.Drawing.Size(47, 18);
            this.rbExport.TabIndex = 1;
            this.rbExport.TabStop = true;
            this.rbExport.Text = "Xuất";
            this.rbExport.UseVisualStyleBackColor = true;
            // 
            // rbImport
            // 
            this.rbImport.AutoSize = true;
            this.rbImport.Location = new System.Drawing.Point(23, 19);
            this.rbImport.Name = "rbImport";
            this.rbImport.Size = new System.Drawing.Size(50, 18);
            this.rbImport.TabIndex = 0;
            this.rbImport.TabStop = true;
            this.rbImport.Text = "Nhập";
            this.rbImport.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(27, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(722, 448);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách";
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(395, 404);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnLoadAll);
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Controls.Add(this.rbImport);
            this.groupBox2.Controls.Add(this.rbExport);
            this.groupBox2.Location = new System.Drawing.Point(44, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(411, 48);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Lọc";
            // 
            // btnLoadAll
            // 
            this.btnLoadAll.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadAll.Location = new System.Drawing.Point(303, 16);
            this.btnLoadAll.Name = "btnLoadAll";
            this.btnLoadAll.Size = new System.Drawing.Size(75, 23);
            this.btnLoadAll.TabIndex = 3;
            this.btnLoadAll.Text = "Toàn bộ";
            this.btnLoadAll.UseVisualStyleBackColor = true;
            this.btnLoadAll.Click += new System.EventHandler(this.btnLoadAll_Click);
            // 
            // groupBoxDetail
            // 
            this.groupBoxDetail.Controls.Add(this.btnCheckDetail);
            this.groupBoxDetail.Controls.Add(this.btnSave);
            this.groupBoxDetail.Controls.Add(this.txtCustomerName);
            this.groupBoxDetail.Controls.Add(this.btnChooseCustomer);
            this.groupBoxDetail.Controls.Add(this.cbType);
            this.groupBoxDetail.Controls.Add(this.label4);
            this.groupBoxDetail.Controls.Add(this.radioButtonExport);
            this.groupBoxDetail.Controls.Add(this.radioButtonImport);
            this.groupBoxDetail.Controls.Add(this.label3);
            this.groupBoxDetail.Controls.Add(this.txtDay);
            this.groupBoxDetail.Controls.Add(this.label2);
            this.groupBoxDetail.Controls.Add(this.txtCheckNo);
            this.groupBoxDetail.Controls.Add(this.label1);
            this.groupBoxDetail.Enabled = false;
            this.groupBoxDetail.Location = new System.Drawing.Point(756, 31);
            this.groupBoxDetail.Name = "groupBoxDetail";
            this.groupBoxDetail.Size = new System.Drawing.Size(300, 448);
            this.groupBoxDetail.TabIndex = 6;
            this.groupBoxDetail.TabStop = false;
            this.groupBoxDetail.Text = "Chi tiết";
            // 
            // btnCheckDetail
            // 
            this.btnCheckDetail.Location = new System.Drawing.Point(160, 364);
            this.btnCheckDetail.Name = "btnCheckDetail";
            this.btnCheckDetail.Size = new System.Drawing.Size(101, 23);
            this.btnCheckDetail.TabIndex = 12;
            this.btnCheckDetail.Text = "Chi tiết đơn hàng";
            this.btnCheckDetail.UseVisualStyleBackColor = true;
            this.btnCheckDetail.Click += new System.EventHandler(this.btnCheckDetail_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(32, 364);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(140, 272);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(135, 20);
            this.txtCustomerName.TabIndex = 10;
            // 
            // btnChooseCustomer
            // 
            this.btnChooseCustomer.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChooseCustomer.Location = new System.Drawing.Point(23, 271);
            this.btnChooseCustomer.Name = "btnChooseCustomer";
            this.btnChooseCustomer.Size = new System.Drawing.Size(111, 23);
            this.btnChooseCustomer.TabIndex = 9;
            this.btnChooseCustomer.Text = "Chọn khách hàng";
            this.btnChooseCustomer.UseVisualStyleBackColor = true;
            this.btnChooseCustomer.Click += new System.EventHandler(this.btnChooseCustomer_Click);
            // 
            // cbType
            // 
            this.cbType.FormattingEnabled = true;
            this.cbType.Location = new System.Drawing.Point(140, 203);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(135, 22);
            this.cbType.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(20, 203);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Loại : ";
            // 
            // radioButtonExport
            // 
            this.radioButtonExport.AutoSize = true;
            this.radioButtonExport.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonExport.Location = new System.Drawing.Point(224, 146);
            this.radioButtonExport.Name = "radioButtonExport";
            this.radioButtonExport.Size = new System.Drawing.Size(51, 19);
            this.radioButtonExport.TabIndex = 6;
            this.radioButtonExport.TabStop = true;
            this.radioButtonExport.Text = "Xuất";
            this.radioButtonExport.UseVisualStyleBackColor = true;
            this.radioButtonExport.CheckedChanged += new System.EventHandler(this.radioButtonImportExport_CheckedChanged);
            // 
            // radioButtonImport
            // 
            this.radioButtonImport.AutoSize = true;
            this.radioButtonImport.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonImport.Location = new System.Drawing.Point(140, 145);
            this.radioButtonImport.Name = "radioButtonImport";
            this.radioButtonImport.Size = new System.Drawing.Size(54, 19);
            this.radioButtonImport.TabIndex = 5;
            this.radioButtonImport.TabStop = true;
            this.radioButtonImport.Text = "Nhập";
            this.radioButtonImport.UseVisualStyleBackColor = true;
            this.radioButtonImport.CheckedChanged += new System.EventHandler(this.radioButtonImportExport_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Lựa chọn : ";
            // 
            // txtDay
            // 
            this.txtDay.Location = new System.Drawing.Point(140, 93);
            this.txtDay.Name = "txtDay";
            this.txtDay.Size = new System.Drawing.Size(135, 20);
            this.txtDay.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ngày : ";
            // 
            // txtCheckNo
            // 
            this.txtCheckNo.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCheckNo.Location = new System.Drawing.Point(140, 41);
            this.txtCheckNo.Name = "txtCheckNo";
            this.txtCheckNo.ReadOnly = true;
            this.txtCheckNo.Size = new System.Drawing.Size(135, 22);
            this.txtCheckNo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Số phiếu : ";
            // 
            // ImExManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 507);
            this.Controls.Add(this.groupBoxDetail);
            this.Controls.Add(this.groupBox1);
            this.Name = "ImExManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lí nhập/xuất";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBoxDetail.ResumeLayout(false);
            this.groupBoxDetail.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.RadioButton rbExport;
        private System.Windows.Forms.RadioButton rbImport;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBoxDetail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCheckNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioButtonImport;
        private System.Windows.Forms.RadioButton radioButtonExport;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Button btnChooseCustomer;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCheckDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn CheckNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Day;
        private System.Windows.Forms.DataGridViewTextBoxColumn IE;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.Button btnLoadAll;
        private System.Windows.Forms.Button btnDelete;
    }
}