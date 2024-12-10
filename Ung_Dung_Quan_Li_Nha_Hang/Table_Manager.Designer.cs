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
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxGiamGia = new System.Windows.Forms.ComboBox();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnThemMonAn = new System.Windows.Forms.Button();
            this.cbb_ShowLoaiMonAn = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.admin = new System.Windows.Forms.ToolStripMenuItem();
            this.thongtintaikhoan = new System.Windows.Forms.ToolStripMenuItem();
            this.thongtincanhan = new System.Windows.Forms.ToolStripMenuItem();
            this.dangxuat = new System.Windows.Forms.ToolStripMenuItem();
            this.flp_Ban = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(577, 468);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "Thành Tiền";
            // 
            // txtTongTien
            // 
            this.txtTongTien.Location = new System.Drawing.Point(565, 484);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.Size = new System.Drawing.Size(92, 20);
            this.txtTongTien.TabIndex = 31;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(315, 18);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(56, 20);
            this.numericUpDown1.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(480, 468);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Giảm Giá";
            // 
            // comboBoxGiamGia
            // 
            this.comboBoxGiamGia.FormattingEnabled = true;
            this.comboBoxGiamGia.Items.AddRange(new object[] {
            "5%",
            "10%",
            "20%",
            "30%",
            "40%",
            "50%",
            "60%",
            "70%",
            "80%",
            "90%",
            "100%"});
            this.comboBoxGiamGia.Location = new System.Drawing.Point(461, 484);
            this.comboBoxGiamGia.Name = "comboBoxGiamGia";
            this.comboBoxGiamGia.Size = new System.Drawing.Size(88, 21);
            this.comboBoxGiamGia.TabIndex = 28;
            this.comboBoxGiamGia.Text = "5%";
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.Location = new System.Drawing.Point(680, 448);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(88, 76);
            this.btnThanhToan.TabIndex = 25;
            this.btnThanhToan.Text = "Thanh Toán";
            this.btnThanhToan.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnThemMonAn);
            this.panel1.Controls.Add(this.cbb_ShowLoaiMonAn);
            this.panel1.Controls.Add(this.numericUpDown1);
            this.panel1.Location = new System.Drawing.Point(402, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(375, 57);
            this.panel1.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(93, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 15);
            this.label3.TabIndex = 30;
            this.label3.Text = "Tìm Theo Loại";
            // 
            // btnThemMonAn
            // 
            this.btnThemMonAn.Location = new System.Drawing.Point(251, 0);
            this.btnThemMonAn.Name = "btnThemMonAn";
            this.btnThemMonAn.Size = new System.Drawing.Size(58, 53);
            this.btnThemMonAn.TabIndex = 2;
            this.btnThemMonAn.Text = "Thêm Món";
            this.btnThemMonAn.UseVisualStyleBackColor = true;
            this.btnThemMonAn.Click += new System.EventHandler(this.btnThemMonAn_Click);
            // 
            // cbb_ShowLoaiMonAn
            // 
            this.cbb_ShowLoaiMonAn.FormattingEnabled = true;
            this.cbb_ShowLoaiMonAn.Items.AddRange(new object[] {
            "Danh sách món ăn",
            "Nước",
            "Gỏi",
            "Rau Củ",
            "Mì",
            "Cơm",
            "Mực",
            "Gà"});
            this.cbb_ShowLoaiMonAn.Location = new System.Drawing.Point(3, 32);
            this.cbb_ShowLoaiMonAn.Name = "cbb_ShowLoaiMonAn";
            this.cbb_ShowLoaiMonAn.Size = new System.Drawing.Size(242, 21);
            this.cbb_ShowLoaiMonAn.TabIndex = 3;
            this.cbb_ShowLoaiMonAn.Text = "Danh sách món ăn";
            this.cbb_ShowLoaiMonAn.SelectedIndexChanged += new System.EventHandler(this.cbb_ShowLoaiMonAn_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.listView1);
            this.panel2.Location = new System.Drawing.Point(377, 90);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(439, 354);
            this.panel2.TabIndex = 24;
            // 
            // listView1
            // 
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(3, 3);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(433, 348);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
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
            this.menuStrip1.Size = new System.Drawing.Size(830, 24);
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
            this.thongtintaikhoan.Size = new System.Drawing.Size(126, 20);
            this.thongtintaikhoan.Text = "Thông Tin Tài Khoản";
            // 
            // thongtincanhan
            // 
            this.thongtincanhan.Name = "thongtincanhan";
            this.thongtincanhan.Size = new System.Drawing.Size(176, 22);
            this.thongtincanhan.Text = "Thông Tin Cá Nhân";
            this.thongtincanhan.Click += new System.EventHandler(this.thongtincanhan_Click);
            // 
            // dangxuat
            // 
            this.dangxuat.Name = "dangxuat";
            this.dangxuat.Size = new System.Drawing.Size(176, 22);
            this.dangxuat.Text = "Đăng Xuất";
            this.dangxuat.Click += new System.EventHandler(this.dangxuat_Click);
            // 
            // flp_Ban
            // 
            this.flp_Ban.Location = new System.Drawing.Point(12, 30);
            this.flp_Ban.Name = "flp_Ban";
            this.flp_Ban.Size = new System.Drawing.Size(362, 494);
            this.flp_Ban.TabIndex = 34;
            // 
            // Table_Manager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 531);
            this.Controls.Add(this.flp_Ban);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTongTien);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxGiamGia);
            this.Controls.Add(this.btnThanhToan);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "Table_Manager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lí Nhà Hàng";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxGiamGia;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnThemMonAn;
        private System.Windows.Forms.ComboBox cbb_ShowLoaiMonAn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem admin;
        private System.Windows.Forms.ToolStripMenuItem thongtintaikhoan;
        private System.Windows.Forms.ToolStripMenuItem thongtincanhan;
        private System.Windows.Forms.ToolStripMenuItem dangxuat;
        private System.Windows.Forms.FlowLayoutPanel flpBan;
        private System.Windows.Forms.FlowLayoutPanel flp_Ban;
        private System.Windows.Forms.Label label3;
    }
}