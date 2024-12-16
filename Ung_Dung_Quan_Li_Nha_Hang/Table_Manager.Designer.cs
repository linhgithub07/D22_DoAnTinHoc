namespace Ung_Dung_Quan_Li_Nha_Hang
{
    partial class Table_Manager
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxGiamGia = new System.Windows.Forms.ComboBox();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.admin = new System.Windows.Forms.ToolStripMenuItem();
            this.thongtintaikhoan = new System.Windows.Forms.ToolStripMenuItem();
            this.thongtincanhan = new System.Windows.Forms.ToolStripMenuItem();
            this.dangxuat = new System.Windows.Forms.ToolStripMenuItem();
            this.flpBan = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(141, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "Thành Tiền";
            // 
            // txtTongTien
            // 
            this.txtTongTien.Location = new System.Drawing.Point(129, 31);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.Size = new System.Drawing.Size(92, 20);
            this.txtTongTien.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Giảm Giá";
            // 
            // comboBoxGiamGia
            // 
            this.comboBoxGiamGia.FormattingEnabled = true;
            this.comboBoxGiamGia.Location = new System.Drawing.Point(6, 30);
            this.comboBoxGiamGia.Name = "comboBoxGiamGia";
            this.comboBoxGiamGia.Size = new System.Drawing.Size(88, 21);
            this.comboBoxGiamGia.TabIndex = 28;
            this.comboBoxGiamGia.Text = "5%";
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.Location = new System.Drawing.Point(255, 3);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(59, 53);
            this.btnThanhToan.TabIndex = 25;
            this.btnThanhToan.Text = "Thanh Toán";
            this.btnThanhToan.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.admin,
            this.thongtintaikhoan});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(753, 24);
            this.menuStrip1.TabIndex = 33;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // admin
            // 
            this.admin.Name = "admin";
            this.admin.Size = new System.Drawing.Size(55, 20);
            this.admin.Text = "Admin";
            this.admin.Click += new System.EventHandler(this.admin_Click);
            // 
            // thongtintaikhoan
            // 
            this.thongtintaikhoan.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thongtincanhan,
            this.dangxuat});
            this.thongtintaikhoan.Name = "thongtintaikhoan";
            this.thongtintaikhoan.Size = new System.Drawing.Size(129, 20);
            this.thongtintaikhoan.Text = "Thông Tin Tài Khoản";
            // 
            // thongtincanhan
            // 
            this.thongtincanhan.Name = "thongtincanhan";
            this.thongtincanhan.Size = new System.Drawing.Size(178, 22);
            this.thongtincanhan.Text = "Thông Tin Cá Nhân";
            this.thongtincanhan.Click += new System.EventHandler(this.thongtincanhan_Click);
            // 
            // dangxuat
            // 
            this.dangxuat.Name = "dangxuat";
            this.dangxuat.Size = new System.Drawing.Size(178, 22);
            this.dangxuat.Text = "Đăng Xuất";
            this.dangxuat.Click += new System.EventHandler(this.dangxuat_Click);
            // 
            // flpBan
            // 
            this.flpBan.Location = new System.Drawing.Point(12, 30);
            this.flpBan.Name = "flpBan";
            this.flpBan.Size = new System.Drawing.Size(510, 391);
            this.flpBan.TabIndex = 34;
            // 
            // Table_Manager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 456);
            this.Controls.Add(this.flpBan);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Table_Manager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lí Nhà Hàng";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxGiamGia;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem admin;
        private System.Windows.Forms.ToolStripMenuItem thongtintaikhoan;
        private System.Windows.Forms.ToolStripMenuItem thongtincanhan;
        private System.Windows.Forms.ToolStripMenuItem dangxuat;
        private System.Windows.Forms.FlowLayoutPanel flpBan;
    }
}