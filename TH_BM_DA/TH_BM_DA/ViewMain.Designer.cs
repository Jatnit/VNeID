namespace TH_BM_DA
{
    partial class ViewMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewMain));
            this.label1 = new System.Windows.Forms.Label();
            this.btnCongDan = new System.Windows.Forms.Button();
            this.btnHoKhau = new System.Windows.Forms.Button();
            this.btnGPLaiXe = new System.Windows.Forms.Button();
            this.btnDsLoaiGP = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(398, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(599, 91);
            this.label1.TabIndex = 0;
            this.label1.Text = "MENU TÁC VỤ";
            // 
            // btnCongDan
            // 
            this.btnCongDan.BackColor = System.Drawing.Color.OrangeRed;
            this.btnCongDan.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCongDan.Location = new System.Drawing.Point(267, 281);
            this.btnCongDan.Name = "btnCongDan";
            this.btnCongDan.Size = new System.Drawing.Size(406, 108);
            this.btnCongDan.TabIndex = 1;
            this.btnCongDan.Text = "Dữ liệu công dân";
            this.btnCongDan.UseVisualStyleBackColor = false;
            // 
            // btnHoKhau
            // 
            this.btnHoKhau.BackColor = System.Drawing.Color.OrangeRed;
            this.btnHoKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHoKhau.Location = new System.Drawing.Point(745, 281);
            this.btnHoKhau.Name = "btnHoKhau";
            this.btnHoKhau.Size = new System.Drawing.Size(406, 108);
            this.btnHoKhau.TabIndex = 1;
            this.btnHoKhau.Text = "Dữ liệu hộ khẩu";
            this.btnHoKhau.UseVisualStyleBackColor = false;
            // 
            // btnGPLaiXe
            // 
            this.btnGPLaiXe.BackColor = System.Drawing.Color.OrangeRed;
            this.btnGPLaiXe.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGPLaiXe.Location = new System.Drawing.Point(267, 404);
            this.btnGPLaiXe.Name = "btnGPLaiXe";
            this.btnGPLaiXe.Size = new System.Drawing.Size(406, 108);
            this.btnGPLaiXe.TabIndex = 2;
            this.btnGPLaiXe.Text = "Dữ liệu GP lái xe";
            this.btnGPLaiXe.UseVisualStyleBackColor = false;
            // 
            // btnDsLoaiGP
            // 
            this.btnDsLoaiGP.BackColor = System.Drawing.Color.OrangeRed;
            this.btnDsLoaiGP.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDsLoaiGP.Location = new System.Drawing.Point(745, 404);
            this.btnDsLoaiGP.Name = "btnDsLoaiGP";
            this.btnDsLoaiGP.Size = new System.Drawing.Size(406, 108);
            this.btnDsLoaiGP.TabIndex = 3;
            this.btnDsLoaiGP.Text = "dữ liệu bằng lái";
            this.btnDsLoaiGP.UseVisualStyleBackColor = false;
            // 
            // ViewMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = global::TH_BM_DA.Properties.Resources.images1456983_1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1420, 767);
            this.Controls.Add(this.btnDsLoaiGP);
            this.Controls.Add(this.btnGPLaiXe);
            this.Controls.Add(this.btnHoKhau);
            this.Controls.Add(this.btnCongDan);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ViewMain";
            this.Text = "VNeID";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCongDan;
        private System.Windows.Forms.Button btnHoKhau;
        private System.Windows.Forms.Button btnGPLaiXe;
        private System.Windows.Forms.Button btnDsLoaiGP;
    }
}