namespace Ung_Dung_Quan_Li_Nha_Hang
{
    partial class FormHoaDon
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
            this.comboBoxTenMonAn = new System.Windows.Forms.ComboBox();
            this.numUD_SLMonAn = new System.Windows.Forms.NumericUpDown();
            this.btnThemMonAn = new System.Windows.Forms.Button();
            this.dgvHoaDon = new System.Windows.Forms.DataGridView();
            this.listView1 = new System.Windows.Forms.ListView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.butThanhToan = new System.Windows.Forms.Button();
            this.txbTongTien = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTenBan = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_SLMonAn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxTenMonAn
            // 
            this.comboBoxTenMonAn.FormattingEnabled = true;
            this.comboBoxTenMonAn.Location = new System.Drawing.Point(12, 138);
            this.comboBoxTenMonAn.Name = "comboBoxTenMonAn";
            this.comboBoxTenMonAn.Size = new System.Drawing.Size(235, 21);
            this.comboBoxTenMonAn.TabIndex = 32;
            // 
            // numUD_SLMonAn
            // 
            this.numUD_SLMonAn.Location = new System.Drawing.Point(270, 138);
            this.numUD_SLMonAn.Name = "numUD_SLMonAn";
            this.numUD_SLMonAn.Size = new System.Drawing.Size(56, 20);
            this.numUD_SLMonAn.TabIndex = 33;
            this.numUD_SLMonAn.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnThemMonAn
            // 
            this.btnThemMonAn.Location = new System.Drawing.Point(343, 56);
            this.btnThemMonAn.Name = "btnThemMonAn";
            this.btnThemMonAn.Size = new System.Drawing.Size(101, 102);
            this.btnThemMonAn.TabIndex = 34;
            this.btnThemMonAn.Text = "Thêm Món";
            this.btnThemMonAn.UseVisualStyleBackColor = true;
            this.btnThemMonAn.Click += new System.EventHandler(this.btnThemMonAn_Click_1);
            // 
            // dgvHoaDon
            // 
            this.dgvHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoaDon.Location = new System.Drawing.Point(0, 4);
            this.dgvHoaDon.Name = "dgvHoaDon";
            this.dgvHoaDon.Size = new System.Drawing.Size(546, 430);
            this.dgvHoaDon.TabIndex = 35;
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 3);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(549, 434);
            this.listView1.TabIndex = 36;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvHoaDon);
            this.panel2.Controls.Add(this.listView1);
            this.panel2.Location = new System.Drawing.Point(12, 183);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(553, 437);
            this.panel2.TabIndex = 37;
            // 
            // butThanhToan
            // 
            this.butThanhToan.Location = new System.Drawing.Point(580, 186);
            this.butThanhToan.Name = "butThanhToan";
            this.butThanhToan.Size = new System.Drawing.Size(108, 68);
            this.butThanhToan.TabIndex = 38;
            this.butThanhToan.Text = "Thanh Toán";
            this.butThanhToan.UseVisualStyleBackColor = true;
            this.butThanhToan.Click += new System.EventHandler(this.butThanhToan_Click_1);
            // 
            // txbTongTien
            // 
            this.txbTongTien.Location = new System.Drawing.Point(580, 433);
            this.txbTongTien.Name = "txbTongTien";
            this.txbTongTien.Size = new System.Drawing.Size(112, 20);
            this.txbTongTien.TabIndex = 39;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(577, 405);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 40;
            this.label3.Text = "Thành tiền";
            // 
            // lblTenBan
            // 
            this.lblTenBan.AutoSize = true;
            this.lblTenBan.Location = new System.Drawing.Point(13, 13);
            this.lblTenBan.Name = "lblTenBan";
            this.lblTenBan.Size = new System.Drawing.Size(67, 13);
            this.lblTenBan.TabIndex = 41;
            this.lblTenBan.Text = "labelTenBan";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 77);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(236, 20);
            this.textBox1.TabIndex = 42;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 43;
            this.label1.Text = "Mã Hóa Đơn";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 44;
            this.label2.Text = "Món Ăn";
            // 
            // FormHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 632);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblTenBan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txbTongTien);
            this.Controls.Add(this.butThanhToan);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnThemMonAn);
            this.Controls.Add(this.numUD_SLMonAn);
            this.Controls.Add(this.comboBoxTenMonAn);
            this.Name = "FormHoaDon";
            this.Text = "FormHoaDon";
            this.Load += new System.EventHandler(this.FormHoaDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numUD_SLMonAn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBoxTenMonAn;
        private System.Windows.Forms.NumericUpDown numUD_SLMonAn;
        private System.Windows.Forms.Button btnThemMonAn;
        private System.Windows.Forms.DataGridView dgvHoaDon;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button butThanhToan;
        private System.Windows.Forms.TextBox txbTongTien;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTenBan;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}