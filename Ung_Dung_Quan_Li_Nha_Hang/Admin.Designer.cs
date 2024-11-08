namespace Ung_Dung_Quan_Li_Nha_Hang
{
    partial class Admin
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
            this.tc_Admin = new System.Windows.Forms.TabControl();
            this.tp_Bill = new System.Windows.Forms.TabPage();
            this.tp_Food = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txb_SearchFoodName = new System.Windows.Forms.TextBox();
            this.bt_SearchFood = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lb_FoodID = new System.Windows.Forms.Label();
            this.tb_FoodID = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bt_DeleteFood = new System.Windows.Forms.Button();
            this.bt_AddFood = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtgv_Food = new System.Windows.Forms.DataGridView();
            this.tp_ListFood = new System.Windows.Forms.TabPage();
            this.tp_Table = new System.Windows.Forms.TabPage();
            this.tc_Admin.SuspendLayout();
            this.tp_Food.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_Food)).BeginInit();
            this.SuspendLayout();
            // 
            // tc_Admin
            // 
            this.tc_Admin.Controls.Add(this.tp_Bill);
            this.tc_Admin.Controls.Add(this.tp_Food);
            this.tc_Admin.Controls.Add(this.tp_ListFood);
            this.tc_Admin.Controls.Add(this.tp_Table);
            this.tc_Admin.Location = new System.Drawing.Point(12, 12);
            this.tc_Admin.Name = "tc_Admin";
            this.tc_Admin.SelectedIndex = 0;
            this.tc_Admin.Size = new System.Drawing.Size(770, 427);
            this.tc_Admin.TabIndex = 0;
            // 
            // tp_Bill
            // 
            this.tp_Bill.Location = new System.Drawing.Point(4, 22);
            this.tp_Bill.Name = "tp_Bill";
            this.tp_Bill.Padding = new System.Windows.Forms.Padding(3);
            this.tp_Bill.Size = new System.Drawing.Size(762, 401);
            this.tp_Bill.TabIndex = 0;
            this.tp_Bill.Text = "Doanh Thu";
            this.tp_Bill.UseVisualStyleBackColor = true;
            // 
            // tp_Food
            // 
            this.tp_Food.Controls.Add(this.panel4);
            this.tp_Food.Controls.Add(this.panel3);
            this.tp_Food.Controls.Add(this.panel2);
            this.tp_Food.Controls.Add(this.panel1);
            this.tp_Food.Location = new System.Drawing.Point(4, 22);
            this.tp_Food.Name = "tp_Food";
            this.tp_Food.Padding = new System.Windows.Forms.Padding(3);
            this.tp_Food.Size = new System.Drawing.Size(762, 401);
            this.tp_Food.TabIndex = 1;
            this.tp_Food.Text = "Thức Ăn";
            this.tp_Food.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txb_SearchFoodName);
            this.panel4.Controls.Add(this.bt_SearchFood);
            this.panel4.Location = new System.Drawing.Point(475, 6);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(278, 77);
            this.panel4.TabIndex = 3;
            // 
            // txb_SearchFoodName
            // 
            this.txb_SearchFoodName.Location = new System.Drawing.Point(3, 28);
            this.txb_SearchFoodName.Name = "txb_SearchFoodName";
            this.txb_SearchFoodName.Size = new System.Drawing.Size(191, 20);
            this.txb_SearchFoodName.TabIndex = 3;
            // 
            // bt_SearchFood
            // 
            this.bt_SearchFood.Location = new System.Drawing.Point(200, 8);
            this.bt_SearchFood.Name = "bt_SearchFood";
            this.bt_SearchFood.Size = new System.Drawing.Size(75, 59);
            this.bt_SearchFood.TabIndex = 2;
            this.bt_SearchFood.Text = "Tìm Món";
            this.bt_SearchFood.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Location = new System.Drawing.Point(472, 89);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(284, 306);
            this.panel3.TabIndex = 2;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lb_FoodID);
            this.panel5.Controls.Add(this.tb_FoodID);
            this.panel5.Location = new System.Drawing.Point(3, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(275, 56);
            this.panel5.TabIndex = 0;
            // 
            // lb_FoodID
            // 
            this.lb_FoodID.AutoSize = true;
            this.lb_FoodID.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_FoodID.Location = new System.Drawing.Point(27, 17);
            this.lb_FoodID.Name = "lb_FoodID";
            this.lb_FoodID.Size = new System.Drawing.Size(30, 23);
            this.lb_FoodID.TabIndex = 1;
            this.lb_FoodID.Text = "ID:";
            this.lb_FoodID.Click += new System.EventHandler(this.lb_IdFood_Click);
            // 
            // tb_FoodID
            // 
            this.tb_FoodID.Location = new System.Drawing.Point(97, 19);
            this.tb_FoodID.Name = "tb_FoodID";
            this.tb_FoodID.ReadOnly = true;
            this.tb_FoodID.Size = new System.Drawing.Size(154, 20);
            this.tb_FoodID.TabIndex = 0;
            this.tb_FoodID.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.bt_DeleteFood);
            this.panel2.Controls.Add(this.bt_AddFood);
            this.panel2.Location = new System.Drawing.Point(6, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(460, 77);
            this.panel2.TabIndex = 1;
            // 
            // bt_DeleteFood
            // 
            this.bt_DeleteFood.Location = new System.Drawing.Point(267, 8);
            this.bt_DeleteFood.Name = "bt_DeleteFood";
            this.bt_DeleteFood.Size = new System.Drawing.Size(75, 59);
            this.bt_DeleteFood.TabIndex = 1;
            this.bt_DeleteFood.Text = "Xóa Món";
            this.bt_DeleteFood.UseVisualStyleBackColor = true;
            // 
            // bt_AddFood
            // 
            this.bt_AddFood.Location = new System.Drawing.Point(129, 8);
            this.bt_AddFood.Name = "bt_AddFood";
            this.bt_AddFood.Size = new System.Drawing.Size(75, 59);
            this.bt_AddFood.TabIndex = 0;
            this.bt_AddFood.Text = "Thêm Món";
            this.bt_AddFood.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtgv_Food);
            this.panel1.Location = new System.Drawing.Point(6, 89);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(460, 306);
            this.panel1.TabIndex = 0;
            // 
            // dtgv_Food
            // 
            this.dtgv_Food.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_Food.Location = new System.Drawing.Point(3, 3);
            this.dtgv_Food.Name = "dtgv_Food";
            this.dtgv_Food.Size = new System.Drawing.Size(454, 300);
            this.dtgv_Food.TabIndex = 0;
            // 
            // tp_ListFood
            // 
            this.tp_ListFood.Location = new System.Drawing.Point(4, 22);
            this.tp_ListFood.Name = "tp_ListFood";
            this.tp_ListFood.Padding = new System.Windows.Forms.Padding(3);
            this.tp_ListFood.Size = new System.Drawing.Size(762, 401);
            this.tp_ListFood.TabIndex = 2;
            this.tp_ListFood.Text = "Danh Sách Món Ăn";
            this.tp_ListFood.UseVisualStyleBackColor = true;
            // 
            // tp_Table
            // 
            this.tp_Table.Location = new System.Drawing.Point(4, 22);
            this.tp_Table.Name = "tp_Table";
            this.tp_Table.Padding = new System.Windows.Forms.Padding(3);
            this.tp_Table.Size = new System.Drawing.Size(762, 401);
            this.tp_Table.TabIndex = 3;
            this.tp_Table.Text = "Bàn Ăn";
            this.tp_Table.UseVisualStyleBackColor = true;
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 451);
            this.Controls.Add(this.tc_Admin);
            this.Name = "Admin";
            this.Text = "Quản Lí";
            this.tc_Admin.ResumeLayout(false);
            this.tp_Food.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_Food)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tc_Admin;
        private System.Windows.Forms.TabPage tp_Bill;
        private System.Windows.Forms.TabPage tp_Food;
        private System.Windows.Forms.TabPage tp_ListFood;
        private System.Windows.Forms.TabPage tp_Table;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dtgv_Food;
        private System.Windows.Forms.Button bt_DeleteFood;
        private System.Windows.Forms.Button bt_AddFood;
        private System.Windows.Forms.Button bt_SearchFood;
        private System.Windows.Forms.TextBox txb_SearchFoodName;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lb_FoodID;
        private System.Windows.Forms.TextBox tb_FoodID;
    }
}