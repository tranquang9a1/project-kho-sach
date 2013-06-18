namespace CocBook
{
    partial class MainMenuForm
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
            this.btnImportExport = new System.Windows.Forms.Button();
            this.btnBookManage = new System.Windows.Forms.Button();
            this.btnViewStore = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnImportExport);
            this.groupBox1.Controls.Add(this.btnBookManage);
            this.groupBox1.Controls.Add(this.btnViewStore);
            this.groupBox1.Location = new System.Drawing.Point(247, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(220, 218);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Công việc: ";
            // 
            // btnImportExport
            // 
            this.btnImportExport.Location = new System.Drawing.Point(22, 147);
            this.btnImportExport.Name = "btnImportExport";
            this.btnImportExport.Size = new System.Drawing.Size(178, 23);
            this.btnImportExport.TabIndex = 2;
            this.btnImportExport.Text = "Quản lí nhập/xuất";
            this.btnImportExport.UseVisualStyleBackColor = true;
            this.btnImportExport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnBookManage
            // 
            this.btnBookManage.Location = new System.Drawing.Point(22, 74);
            this.btnBookManage.Name = "btnBookManage";
            this.btnBookManage.Size = new System.Drawing.Size(178, 23);
            this.btnBookManage.TabIndex = 1;
            this.btnBookManage.Text = "Quản lí sách";
            this.btnBookManage.UseVisualStyleBackColor = true;
            this.btnBookManage.Click += new System.EventHandler(this.txtBookManage_Click);
            // 
            // btnViewStore
            // 
            this.btnViewStore.Location = new System.Drawing.Point(22, 108);
            this.btnViewStore.Name = "btnViewStore";
            this.btnViewStore.Size = new System.Drawing.Size(178, 23);
            this.btnViewStore.TabIndex = 0;
            this.btnViewStore.Text = "Xem kho";
            this.btnViewStore.UseVisualStyleBackColor = true;
            this.btnViewStore.Click += new System.EventHandler(this.txtViewMainStore_Click);
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
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 272);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "MainMenuForm";
            this.Text = "Main Menu";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainMenuForm_FormClosed);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBookManage;
        private System.Windows.Forms.Button btnViewStore;
        private System.Windows.Forms.Button btnImportExport;
    }
}