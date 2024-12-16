namespace Ung_Dung_Quan_Li_Nha_Hang
{
    partial class Login
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
            this.butTaoTK = new System.Windows.Forms.Button();
            this.but_thoat = new System.Windows.Forms.Button();
            this.but_dangNhap = new System.Windows.Forms.Button();
            this.txBox_matKhau = new System.Windows.Forms.TextBox();
            this.lb_matkhau = new System.Windows.Forms.Label();
            this.lb_tenDN = new System.Windows.Forms.Label();
            this.txBox_dangNhap = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(133, 120);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 0;
            // 
            // butTaoTK
            // 
            this.butTaoTK.Location = new System.Drawing.Point(111, 167);
            this.butTaoTK.Name = "butTaoTK";
            this.butTaoTK.Size = new System.Drawing.Size(75, 23);
            this.butTaoTK.TabIndex = 13;
            this.butTaoTK.Text = "Đăng Kí";
            this.butTaoTK.UseVisualStyleBackColor = true;
            this.butTaoTK.Click += new System.EventHandler(this.butTaoTK_Click);
            // 
            // but_thoat
            // 
            this.but_thoat.Location = new System.Drawing.Point(273, 138);
            this.but_thoat.Name = "but_thoat";
            this.but_thoat.Size = new System.Drawing.Size(75, 23);
            this.but_thoat.TabIndex = 12;
            this.but_thoat.Text = "Thoát";
            this.but_thoat.UseVisualStyleBackColor = true;
            this.but_thoat.Click += new System.EventHandler(this.but_thoat_Click);
            // 
            // but_dangNhap
            // 
            this.but_dangNhap.Location = new System.Drawing.Point(111, 138);
            this.but_dangNhap.Name = "but_dangNhap";
            this.but_dangNhap.Size = new System.Drawing.Size(75, 23);
            this.but_dangNhap.TabIndex = 11;
            this.but_dangNhap.Text = "Đăng Nhập";
            this.but_dangNhap.UseVisualStyleBackColor = true;
            this.but_dangNhap.Click += new System.EventHandler(this.but_dangNhap_Click);
            // 
            // txBox_matKhau
            // 
            this.txBox_matKhau.Location = new System.Drawing.Point(111, 101);
            this.txBox_matKhau.Name = "txBox_matKhau";
            this.txBox_matKhau.PasswordChar = '*';
            this.txBox_matKhau.Size = new System.Drawing.Size(236, 20);
            this.txBox_matKhau.TabIndex = 10;
            this.txBox_matKhau.Tag = "";
            // 
            // lb_matkhau
            // 
            this.lb_matkhau.AutoSize = true;
            this.lb_matkhau.Location = new System.Drawing.Point(5, 104);
            this.lb_matkhau.Name = "lb_matkhau";
            this.lb_matkhau.Size = new System.Drawing.Size(53, 13);
            this.lb_matkhau.TabIndex = 9;
            this.lb_matkhau.Text = "Mật Khẩu";
            // 
            // lb_tenDN
            // 
            this.lb_tenDN.AutoSize = true;
            this.lb_tenDN.Location = new System.Drawing.Point(5, 69);
            this.lb_tenDN.Name = "lb_tenDN";
            this.lb_tenDN.Size = new System.Drawing.Size(84, 13);
            this.lb_tenDN.TabIndex = 8;
            this.lb_tenDN.Text = "Tên Đăng Nhập";
            // 
            // txBox_dangNhap
            // 
            this.txBox_dangNhap.Location = new System.Drawing.Point(111, 66);
            this.txBox_dangNhap.Name = "txBox_dangNhap";
            this.txBox_dangNhap.Size = new System.Drawing.Size(236, 20);
            this.txBox_dangNhap.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(79, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 34);
            this.label2.TabIndex = 14;
            this.label2.Text = "Quản Lý Nhà Hàng ";
            this.label2.UseMnemonic = false;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 198);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.butTaoTK);
            this.Controls.Add(this.but_thoat);
            this.Controls.Add(this.but_dangNhap);
            this.Controls.Add(this.txBox_matKhau);
            this.Controls.Add(this.lb_matkhau);
            this.Controls.Add(this.lb_tenDN);
            this.Controls.Add(this.txBox_dangNhap);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lí Nhà Hàng";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button butTaoTK;
        private System.Windows.Forms.Button but_thoat;
        private System.Windows.Forms.Button but_dangNhap;
        private System.Windows.Forms.TextBox txBox_matKhau;
        private System.Windows.Forms.Label lb_matkhau;
        private System.Windows.Forms.Label lb_tenDN;
        private System.Windows.Forms.TextBox txBox_dangNhap;
        private System.Windows.Forms.Label label2;
    }
}

