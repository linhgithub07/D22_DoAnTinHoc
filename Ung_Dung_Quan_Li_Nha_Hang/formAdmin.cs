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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Ung_Dung_Quan_Li_Nha_Hang
{
    
    public partial class formAdmin : Form

    {
        private List<food> f = new List<food>();
        private List<tk_mk> f_tkmk = new List<tk_mk>(); // ll = load list
        private int pt = -1;
        public formAdmin()
        {
            InitializeComponent();
            Table_Manager tableManager = new Table_Manager();
            tableManager.Show();
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
        }
        private void btnThemMonAn_Click(object sender, EventArgs e)
        {
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
        private void btn_Xem_Click(object sender, EventArgs e)
        {
            LoadFoodList(dgv_MonAn, f);
        }
        private void btnTimMonAn_Click(object sender, EventArgs e)
        {
            List<food> srearch = new List<food>();
            foreach (var item in f)
            {
                if (item.F_id.Contains(txbTimMonAn.Text))
                {
                    srearch.Add(item);
                }    
            }
            LoadFoodList(dgv_MonAn,srearch);
        }
        #endregion


        #region PHẦN BÀN ĂN
        private List<BanAn> dsBanAn = new List<BanAn>();
        private Table_Manager formHienThi = new Table_Manager();

        private void btnThemBan_Click(object sender, EventArgs e)
        {
            string tenBan = txbTen_Ban.Text;
            string ID = txbID_Ban.Text;
            string trangThai = cbbTrangThai_Ban.Text;
            foreach (BanAn x in dsBanAn)
            {
                if (x.ID_Ban == null)
                {
                    dsBanAn.Add(x);
                    formHienThi.ThemBan(x);
                    MessageBox.Show("Thêm bàn thành công! ");
                }
                else
                {
                    MessageBox.Show("Bàn ăn đã tồn tại không thể thêm!!!", "Thông Tháo!");
                }
            }
        }

        private void btnXoaBan_Click(object sender, EventArgs e)
        {
            string tenBan = txbTen_Ban.Text;
            string ID = txbID_Ban.Text;
            string trangThai = cbbTrangThai_Ban.Text;
            foreach (BanAn x in dsBanAn)
            {
                if(x.ID_Ban != null)
                {
                    dsBanAn.Add(x);
                    formHienThi.XoaBan(x);
                    MessageBox.Show("Đã xóa bàn thành công! ");
                }
                else
                {
                    MessageBox.Show("Bàn không tồn tại!", "Thông báo!!!");
                }
            }
        }
        #endregion

        #region PHẦN THÔNG TIN TÀI KHOẢN
        private void LoadAccountList(DataGridView dgv_AccountList, List<tk_mk> tkmk) { dgv_AccountList.DataSource = tkmk.ToList(); }
        private void dgv_AccountList_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            pt = e.RowIndex;
            txb_TenTK.Text = f_tkmk[pt].TaiKhoan;
        }
        private void btnThemTaiKhoan_Click(object sender, EventArgs e)
        {
            string nameTK = txb_TenTK.Text;
            string fullName = txb_FullName.Text;
            string pass = txb_pass.Text;
            string loai = cbbLoai_tk.Text;

            bool kqtk = false;
            tk_mk newTK = new tk_mk(nameTK, pass);
            foreach (var item in f_tkmk)
            {
                if (nameTK == item.TaiKhoan)
                {
                    kqtk = true;
                    MessageBox.Show("Tên Tài Khoản Đã Tồn Tại!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            if (!kqtk) f_tkmk.Add(newTK);
            LoadAccountList(dgv_AccountList, f_tkmk);
        }
        private void btnXoaTaiKhoan_Click(object sender, EventArgs e)
        {
            if (pt == -1) MessageBox.Show("Hãy chọn 1 đối tượng", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                DialogResult kqtk = MessageBox.Show("Bạn chắc chắn muốn thay đổi!", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (kqtk == DialogResult.Yes)
                {
                    f_tkmk.RemoveAt(pt);
                    LoadAccountList(dgv_AccountList, f_tkmk);
                }
                pt = -1;
            }
        }

        private void btnSuaTaiKhoan_Click(object sender, EventArgs e)
        {
            if (pt == -1) MessageBox.Show("Hãy chọn 1 đối tượng", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                string nameTK = txb_TenTK.Text;
                string fullName = txb_FullName.Text;
                string pass = txb_pass.Text;
                string loai = cbbLoai_tk.Text;
                tk_mk newTK = new tk_mk(nameTK, pass);
                f_tkmk[pt] = newTK;
                LoadAccountList(dgv_AccountList, f_tkmk);
                pt = -1;
            }
        }




        #endregion

        
    }
}
