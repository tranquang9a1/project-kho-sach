namespace CocBook
{
    partial class _5_1AddExport
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
            this.btnConsign = new System.Windows.Forms.Button();
            this.btnSale = new System.Windows.Forms.Button();
            this.btnStore = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnConsign
            // 
            this.btnConsign.Location = new System.Drawing.Point(75, 55);
            this.btnConsign.Name = "btnConsign";
            this.btnConsign.Size = new System.Drawing.Size(75, 23);
            this.btnConsign.TabIndex = 0;
            this.btnConsign.Text = "Kí gửi";
            this.btnConsign.UseVisualStyleBackColor = true;
            // 
            // btnSale
            // 
            this.btnSale.Location = new System.Drawing.Point(185, 55);
            this.btnSale.Name = "btnSale";
            this.btnSale.Size = new System.Drawing.Size(75, 23);
            this.btnSale.TabIndex = 1;
            this.btnSale.Text = "Bán lẻ";
            this.btnSale.UseVisualStyleBackColor = true;
            // 
            // btnR
            // 
            this.btnStore.Location = new System.Drawing.Point(298, 55);
            this.btnStore.Name = "btnR";
            this.btnStore.Size = new System.Drawing.Size(75, 23);
            this.btnStore.TabIndex = 2;
            this.btnStore.Text = "Nhập trả";
            this.btnStore.UseVisualStyleBackColor = true;
            // 
            // _5_1AddImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 261);
            this.Controls.Add(this.btnStore);
            this.Controls.Add(this.btnSale);
            this.Controls.Add(this.btnConsign);
            this.Name = "_5_1AddImport";
            this.Text = "Lựa chọn nhập";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnConsign;
        private System.Windows.Forms.Button btnSale;
        private System.Windows.Forms.Button btnR;
    }
}