namespace CocBook
{
    partial class InfoDetail
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtCheckNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDay = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCustomer = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdImport = new System.Windows.Forms.RadioButton();
            this.rdExport = new System.Windows.Forms.RadioButton();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Số phiếu:";
            // 
            // txtCheckNo
            // 
            this.txtCheckNo.Location = new System.Drawing.Point(190, 43);
            this.txtCheckNo.Name = "txtCheckNo";
            this.txtCheckNo.Size = new System.Drawing.Size(187, 20);
            this.txtCheckNo.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ngày:";
            // 
            // txtDay
            // 
            this.txtDay.Location = new System.Drawing.Point(190, 78);
            this.txtDay.Name = "txtDay";
            this.txtDay.Size = new System.Drawing.Size(187, 20);
            this.txtDay.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(64, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 14);
            this.label4.TabIndex = 5;
            this.label4.Text = "Loại:";
            // 
            // btnCustomer
            // 
            this.btnCustomer.Location = new System.Drawing.Point(67, 179);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Size = new System.Drawing.Size(116, 23);
            this.btnCustomer.TabIndex = 7;
            this.btnCustomer.Text = "Chọn khách hàng";
            this.btnCustomer.UseVisualStyleBackColor = true;
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(380, 218);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 8;
            this.btnNext.Text = "Tiếp";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(190, 181);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(187, 20);
            this.txtCustomerName.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdExport);
            this.panel1.Controls.Add(this.rdImport);
            this.panel1.Location = new System.Drawing.Point(190, 104);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(187, 30);
            this.panel1.TabIndex = 10;
            // 
            // rdImport
            // 
            this.rdImport.AutoSize = true;
            this.rdImport.Location = new System.Drawing.Point(3, 4);
            this.rdImport.Name = "rdImport";
            this.rdImport.Size = new System.Drawing.Size(50, 18);
            this.rdImport.TabIndex = 0;
            this.rdImport.TabStop = true;
            this.rdImport.Text = "Nhập";
            this.rdImport.UseVisualStyleBackColor = true;
            this.rdImport.CheckedChanged += new System.EventHandler(this.rdImport_CheckedChanged);
            // 
            // rdExport
            // 
            this.rdExport.AutoSize = true;
            this.rdExport.Location = new System.Drawing.Point(98, 4);
            this.rdExport.Name = "rdExport";
            this.rdExport.Size = new System.Drawing.Size(47, 18);
            this.rdExport.TabIndex = 1;
            this.rdExport.TabStop = true;
            this.rdExport.Text = "Xuất";
            this.rdExport.UseVisualStyleBackColor = true;
            this.rdExport.CheckedChanged += new System.EventHandler(this.rdExport_CheckedChanged);
            // 
            // cbType
            // 
            this.cbType.FormattingEnabled = true;
            this.cbType.Items.AddRange(new object[] {
            "Kí gửi",
            "Bán lẻ",
            "Khác"});
            this.cbType.Location = new System.Drawing.Point(190, 140);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(187, 22);
            this.cbType.TabIndex = 6;
            // 
            // InfoDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 261);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnCustomer);
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDay);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCheckNo);
            this.Controls.Add(this.label1);
            this.Name = "InfoDetail";
            this.Text = "Thông tin phiếu";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCheckNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCustomer;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rdExport;
        private System.Windows.Forms.RadioButton rdImport;
        private System.Windows.Forms.ComboBox cbType;
    }
}