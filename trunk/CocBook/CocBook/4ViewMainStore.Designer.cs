namespace CocBook
{
    partial class _4ViewMainStore
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
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.rdISBN = new System.Windows.Forms.RadioButton();
            this.rdName = new System.Windows.Forms.RadioButton();
            this.rdPulisher = new System.Windows.Forms.RadioButton();
            this.rdQuantity = new System.Windows.Forms.RadioButton();
            this.rdUnit = new System.Windows.Forms.RadioButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(251, 16);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdUnit);
            this.panel1.Controls.Add(this.rdQuantity);
            this.panel1.Controls.Add(this.rdPulisher);
            this.panel1.Controls.Add(this.rdName);
            this.panel1.Controls.Add(this.rdISBN);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Location = new System.Drawing.Point(25, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(355, 108);
            this.panel1.TabIndex = 1;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(22, 16);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(205, 20);
            this.txtSearch.TabIndex = 1;
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
            // rdName
            // 
            this.rdName.AutoSize = true;
            this.rdName.Location = new System.Drawing.Point(94, 56);
            this.rdName.Name = "rdName";
            this.rdName.Size = new System.Drawing.Size(70, 18);
            this.rdName.TabIndex = 3;
            this.rdName.TabStop = true;
            this.rdName.Text = "Tên sách";
            this.rdName.UseVisualStyleBackColor = true;
            // 
            // rdPulisher
            // 
            this.rdPulisher.AutoSize = true;
            this.rdPulisher.Location = new System.Drawing.Point(184, 56);
            this.rdPulisher.Name = "rdPulisher";
            this.rdPulisher.Size = new System.Drawing.Size(89, 18);
            this.rdPulisher.TabIndex = 4;
            this.rdPulisher.TabStop = true;
            this.rdPulisher.Text = "Nhà xuất bản";
            this.rdPulisher.UseVisualStyleBackColor = true;
            // 
            // rdQuantity
            // 
            this.rdQuantity.AutoSize = true;
            this.rdQuantity.Location = new System.Drawing.Point(22, 81);
            this.rdQuantity.Name = "rdQuantity";
            this.rdQuantity.Size = new System.Drawing.Size(69, 18);
            this.rdQuantity.TabIndex = 5;
            this.rdQuantity.TabStop = true;
            this.rdQuantity.Text = "Số lượng";
            this.rdQuantity.UseVisualStyleBackColor = true;
            // 
            // rdUnit
            // 
            this.rdUnit.AutoSize = true;
            this.rdUnit.Location = new System.Drawing.Point(98, 81);
            this.rdUnit.Name = "rdUnit";
            this.rdUnit.Size = new System.Drawing.Size(78, 18);
            this.rdUnit.TabIndex = 6;
            this.rdUnit.TabStop = true;
            this.rdUnit.Text = "Đơn vị tính";
            this.rdUnit.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(25, 155);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(355, 150);
            this.dataGridView1.TabIndex = 2;
            // 
            // _4ViewMainStore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 317);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "_4ViewMainStore";
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
        private System.Windows.Forms.RadioButton rdUnit;
        private System.Windows.Forms.RadioButton rdQuantity;
        private System.Windows.Forms.RadioButton rdPulisher;
        private System.Windows.Forms.RadioButton rdName;
        private System.Windows.Forms.RadioButton rdISBN;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}