namespace CocBook
{
    partial class Form2
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRetailManage = new System.Windows.Forms.Button();
            this.btnConsignManage = new System.Windows.Forms.Button();
            this.txtBookManage = new System.Windows.Forms.Button();
            this.txtViewMainStore = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRetailManage);
            this.groupBox1.Controls.Add(this.btnConsignManage);
            this.groupBox1.Controls.Add(this.txtBookManage);
            this.groupBox1.Controls.Add(this.txtViewMainStore);
            this.groupBox1.Location = new System.Drawing.Point(247, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(220, 218);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Công việc: ";
            // 
            // btnRetailManage
            // 
            this.btnRetailManage.Location = new System.Drawing.Point(25, 146);
            this.btnRetailManage.Name = "btnRetailManage";
            this.btnRetailManage.Size = new System.Drawing.Size(178, 23);
            this.btnRetailManage.TabIndex = 3;
            this.btnRetailManage.Text = "Quản lí bán lẻ";
            this.btnRetailManage.UseVisualStyleBackColor = true;
            // 
            // btnConsignManage
            // 
            this.btnConsignManage.Location = new System.Drawing.Point(25, 102);
            this.btnConsignManage.Name = "btnConsignManage";
            this.btnConsignManage.Size = new System.Drawing.Size(178, 23);
            this.btnConsignManage.TabIndex = 2;
            this.btnConsignManage.Text = "Quản lí ký gửi";
            this.btnConsignManage.UseVisualStyleBackColor = true;
            // 
            // txtBookManage
            // 
            this.txtBookManage.Location = new System.Drawing.Point(25, 29);
            this.txtBookManage.Name = "txtBookManage";
            this.txtBookManage.Size = new System.Drawing.Size(178, 23);
            this.txtBookManage.TabIndex = 1;
            this.txtBookManage.Text = "Quản lí sách";
            this.txtBookManage.UseVisualStyleBackColor = true;
            // 
            // txtViewMainStore
            // 
            this.txtViewMainStore.Location = new System.Drawing.Point(25, 63);
            this.txtViewMainStore.Name = "txtViewMainStore";
            this.txtViewMainStore.Size = new System.Drawing.Size(178, 23);
            this.txtViewMainStore.TabIndex = 0;
            this.txtViewMainStore.Text = "Xem kho";
            this.txtViewMainStore.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = global::CocBook.Properties.Resources.Logo;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(29, 92);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(173, 63);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 272);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form2";
            this.Text = "Main Menu";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button txtBookManage;
        private System.Windows.Forms.Button txtViewMainStore;
        private System.Windows.Forms.Button btnRetailManage;
        private System.Windows.Forms.Button btnConsignManage;
    }
}