using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Ung_Dung_Quan_Li_Nha_Hang
{
    public partial class formAdmin : Form
    {
        private List<food> f = new List<food>();
        private List<tk_mk> ll_tkmk; // ll = load list
        private int pt = -1;
        public formAdmin()
        {
            InitializeComponent();
            // LoadFoodList(dgv_MonAn, f);
           // LoadTable();
        }


        #region PHẦN MÓN ĂN.
        private void LoadFoodList(DataGridView dgv_MonAn, List<food> f)
        {
            dgv_MonAn.DataSource = f.ToList();
        }
        private void dgv_MonAn_CellClick(object sender, DataGridViewCellEventArgs e) // chức năng của hàm: khi click vao bất cứ vị trí trên dong nào thì data của dòng đó được hiển thị.
        {
            pt = e.RowIndex;
            txt_ListFood.Text = f[pt].F_list;
            txt_FoodID.Text = f[pt].F_id;
            txt_FoodName.Text = f[pt].F_name;
            txt_FoodPrice.Text = f[pt].F_price;
        }
        private void btnThemMonAn_Click(object sender, EventArgs e)
        {
            // Phần lưu trữ món ăn vào file
        //    string filePath = "DanhSachMonAn.bin";
            string list = txt_ListFood.Text;
            string id = txt_FoodID.Text;
            string name = txt_FoodName.Text;
            string price = txt_FoodPrice.Text;
            // phần ghi món ăn vào DataGridView
            bool kq = false;
            food f_f = new food(list, id, name, price);
            foreach ( var item in f)
            {
                if (id == item.F_id)
                {
                    kq = true;
                    MessageBox.Show("Mã Món Ăn Bị Trùng!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            if (!kq) f.Add(f_f);
            LoadFoodList(dgv_MonAn, f);
        } // chưa có phần ghi dữ liệu vào file.
        private void btnSuaMonAn_Click(object sender, EventArgs e)
        {
            if (pt == -1) MessageBox.Show("Hãy chọn 1 đối tượng", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                string list = txt_ListFood.Text;
                string id = txt_FoodID.Text;
                string name = txt_FoodName.Text;
                string price = txt_FoodPrice.Text;
                food f_f = new food(list, id, name, price);
                f[pt] = f_f;
                LoadFoodList(dgv_MonAn, f);
                pt = -1;
            }
        }
        private void btnXoaMonAn_Click(object sender, EventArgs e)
        {
            if (pt == -1) MessageBox.Show("Hãy chọn 1 đối tượng", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                DialogResult kq = MessageBox.Show("Bạn chắc chắn muốn thay đổi!", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (kq == DialogResult.Yes)
                {
                    f.RemoveAt(pt);
                    LoadFoodList(dgv_MonAn, f);
                }
                pt = -1;
            }
        }
        private void btnTimMonAn_Click(object sender, EventArgs e)
        {

        }
        #endregion


        #region PHẦN BÀN ĂN

        #endregion

        #region PHẦN THÔNG TIN TÀI KHOẢN
        private void LoadAccountList(DataGridView dgv_AccountList, List<tk_mk> tkmk) { dgv_AccountList.DataSource = tkmk.ToList(); }
        private void dgv_AccountList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            pt = e.RowIndex;
            txbTen_tk.Text = ll_tkmk[pt].TaiKhoan;
        } // cần chỉnh sửa thêm
        private void btnThemTaiKhoan_Click(object sender, EventArgs e)
        {

        }

        #endregion

    
    }
}
