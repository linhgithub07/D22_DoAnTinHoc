using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ung_Dung_Quan_Li_Nha_Hang;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Ung_Dung_Quan_Li_Nha_Hang
{
    public partial class formAdmin : Form
    {
        private int pt = -1;
        private List<food> f = new List<food>();
        private List<tk_mk> f_tkmk = new List<tk_mk>();
        private List<ThongTinTK_MK> f_tttkmk = new List<ThongTinTK_MK>();
        private Table_Manager formHienThi;
        private List<BanAn> DanhSachBanAn;
        public delegate void ButtonAddedEventHandler(BanAn newTable);
        public event ButtonAddedEventHandler ButtonAdded;

        public formAdmin(List<BanAn> dsBan)
        {
            InitializeComponent();
            formHienThi = new Table_Manager();
            formHienThi.Show();
            if (dsBan == null)
            {
                MessageBox.Show("Danh sách bàn không hợp lệ!");
                return;
            }
            DanhSachBanAn = new List<BanAn>(dsBan);
            hienthi();
        }

        private void butThongKe_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        #region Bàn Ăn
        private void dgv_Ban_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            txbID_Ban.Text = dgv_Ban.Rows[e.RowIndex].Cells[0].Value.ToString();
            txbTen_Ban.Text = dgv_Ban.Rows[e.RowIndex].Cells[1].Value.ToString();
            cb_TrangThaiBan.Text = dgv_Ban.Rows[e.RowIndex].Cells[2].Value.ToString();
        }
        private void formAdmin_Load(object sender, EventArgs e)
        {

            //dsBanAn = new List<BanAn>();
            LoadFile();
            hienthi();
        }
        private void hienthi()
        {
            dgv_Ban.DataSource = DanhSachBanAn.ToList();
        }

        private BanAn timBan(string ma)
        {
            foreach (BanAn x in DanhSachBanAn)
                if (x.ID == ma) return x;
            return null;
        }
        private void btnThemBan_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txbID_Ban.Text))
            {
                MessageBox.Show("ID không được để trống!");
                return;
            }
            BanAn banAn = new BanAn();
            banAn.ID = txbID_Ban.Text;
            banAn.TenBan = txbTen_Ban.Text;
            banAn.TrangThai = cb_TrangThaiBan.Text;
            if (timBan(banAn.ID) == null)
            {
                DanhSachBanAn.Add(banAn);
                ButtonAdded?.Invoke(banAn);
                hienthi();
            }
            else
            {
                MessageBox.Show("Bàn đã tồn tại!");
            }
        }
        private void btnSuaBan_Click_1(object sender, EventArgs e)
        {
            string ma = txbID_Ban.Text;
            BanAn banAn = timBan(ma);
            if (banAn != null)
            {
                banAn.TenBan = txbTen_Ban.Text;
                banAn.TrangThai = cb_TrangThaiBan.Text;
                ButtonAdded?.Invoke(null);
                hienthi();
                MessageBox.Show("Cập nhật bàn thành công!");
            }
            else
            {
                MessageBox.Show("Không tìm thấy bàn để sửa!");
            }
        }
        private void btnXoaBan_Click_1(object sender, EventArgs e)
        {
            string ma = txbID_Ban.Text;
            if (timBan(ma) != null)
            {
                DanhSachBanAn.Remove(timBan(ma));
                ButtonAdded?.Invoke(null);
                hienthi();
            }
            else
            {
                MessageBox.Show("không tìm thấy bàn để xóa!");
            }
        }
        private void btnGhiBan_Click_1(object sender, EventArgs e)
        {
            try
            {
                using (Stream file = File.Open("dsBanAn.bin", FileMode.Create))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(file, this.DanhSachBanAn);
                }
                MessageBox.Show("Ghi Thanh Cong.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void LoadFile()
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            string strFileLocation = "DanhSachBanAn.bin";
            if (File.Exists(strFileLocation))
            {
                using (FileStream readerFileStream = new FileStream(strFileLocation, FileMode.Open, System.IO.FileAccess.Read))
                {
                    DanhSachBanAn = (List<BanAn>)binaryFormatter.Deserialize(readerFileStream);
                }
            }
        }

        #endregion


        #region MÓN ĂN.

        #region Phần Lưu Món Ăn
        private void SaveFoodListToFile(string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                BinaryFormatter sf = new BinaryFormatter();
                sf.Serialize(fs, f);
            }
            MessageBox.Show("Danh sách món ăn đã được lưu vào file thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SaveFoodListToFile("DanhSachMonAn.dat");
        }
        private void LoadFoodListFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    f = (List<food>)formatter.Deserialize(fs);
                    LoadFoodList(dgv_MonAn, f);
                }
                MessageBox.Show("Danh sách món ăn đã được tải từ file!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("File không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        private void LoadFoodList(DataGridView dgv_MonAn, List<food> f)
        {
            dgv_MonAn.DataSource = f.ToList();
        }
        private void dgv_MonAn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            pt = e.RowIndex;
            cb_DanhMucMonAn.Text = f[pt].F_list;
            txb_IDMonAn.Text = f[pt].F_id;
            txb_TenMonAn.Text = f[pt].F_name;
            txb_GiaMonAn.Text = f[pt].F_price;
        }// chức năng của hàm: khi click vao bất cứ vị trí trên dong nào thì data của dòng đó được hiển thị.
        private void btnThemMonAn_Click_1(object sender, EventArgs e)
        {
            string list = cb_DanhMucMonAn.SelectedItem.ToString();
            string id = txb_IDMonAn.Text;
            string name = txb_TenMonAn.Text;
            string price = txb_GiaMonAn.Text + "Đ";
            // phần ghi món ăn vào DataGridView
            bool kq = false;
            food f_f = new food(list, id, name, price);
            foreach (var item in f)
            {
                if (id == item.F_id)
                {
                    kq = true;
                    MessageBox.Show("Mã Món Ăn Bị Trùng!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            if (!kq) f.Add(f_f);
            LoadFoodList(dgv_MonAn, f);
        }
        private void btnSuaMonAn_Click_1(object sender, EventArgs e)
        {
            if (pt == -1) MessageBox.Show("Hãy chọn 1 đối tượng", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                string list = cb_DanhMucMonAn.Text;
                string id = txb_IDMonAn.Text;
                string name = txb_TenMonAn.Text;
                string price = txb_GiaMonAn.Text;
                food f_f = new food(list, id, name, price);
                f[pt] = f_f;
                LoadFoodList(dgv_MonAn, f);
                pt = -1;
            }
        }
        private void btnXoaMonAn_Click_1(object sender, EventArgs e)
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
        private void btnXemMonAn_Click(object sender, EventArgs e)
        {
            LoadFoodList(dgv_MonAn, f);
            LoadFoodListFromFile("DanhSachMonAn.dat");
        }
        private void btnTimMonAn_Click_1(object sender, EventArgs e)
        {
            List<food> srearch = new List<food>();
            foreach (var item in f)
            {
                if (item.F_id.Contains(txbTimMonAn.Text))
                {
                    srearch.Add(item);
                }
            }
            LoadFoodList(dgv_MonAn, srearch);
        }
        #endregion

        // ===================================================================================

        #region THÔNG TIN TÀI KHOẢN

        private void LoadAccountList(DataGridView dgv_AccountList, List<ThongTinTK_MK> tttkmk)
        {
            dgv_AccountList.DataSource = null;
            dgv_AccountList.DataSource = f_tttkmk.ToList();
        }
        private void dgv_AccountList_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            pt = e.RowIndex;
            txb_TenTK.Text = f_tttkmk[pt].TaiKhoan;
            txb_MK.Text = f_tttkmk[pt].MatKhau;
            txb_FullName.Text = f_tttkmk[pt].FullName;
            cbb_LoaiTK.Text = f_tttkmk[pt].Status;
        }
        private void btnThemTaiKhoan_Click(object sender, EventArgs e)
        {
            string tk = txb_TenTK.Text;
            string mk = txb_MK.Text;
            string fn = txb_FullName.Text;
            string loai = cbb_LoaiTK.SelectedItem.ToString();

            bool kqtk = false;
            ThongTinTK_MK thongtintkmk = new ThongTinTK_MK(tk, mk, fn, loai);
            foreach (var item in f_tttkmk)
            {
                if (tk == item.TaiKhoan)
                {
                    kqtk = true;
                    MessageBox.Show("Tên Tài Khoản Đã Tồn Tại!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            if (!kqtk) f_tttkmk.Add(thongtintkmk);
            LoadAccountList(dgv_AccountList, f_tttkmk);
        }
        private void btnXoaTaiKhoan_Click(object sender, EventArgs e)
        {
            if (pt == -1) MessageBox.Show("Hãy chọn 1 đối tượng", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                DialogResult kqtk = MessageBox.Show("Bạn chắc chắn muốn thay đổi!", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (kqtk == DialogResult.Yes)
                {
                    f_tttkmk.RemoveAt(pt);
                    LoadAccountList(dgv_AccountList, f_tttkmk);
                }
                pt = -1;
            }
        }

        private void btnSuaTaiKhoan_Click(object sender, EventArgs e)
        {
            if (pt == -1) MessageBox.Show("Hãy chọn 1 đối tượng", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                string tk = txb_TenTK.Text;
                string fn = txb_FullName.Text;
                string mk = txb_MK.Text;
                string loai = cbb_LoaiTK.Text;
                ThongTinTK_MK newTK = new ThongTinTK_MK(tk, mk, fn, loai);
                f_tttkmk[pt] = newTK;
                LoadAccountList(dgv_AccountList, f_tttkmk);
                pt = -1;
            }
        }
        #endregion

        // ===================================================================================
        









        #region
        //================ Hàm fix bug save food =================/
        [Serializable]
        public class food
        {
            public string F_list { get; set; }
            public string F_id { get; set; }
            public string F_name { get; set; }
            public string F_price { get; set; }

            public food(string list, string id, string name, string price)
            {
                F_list = list;
                F_id = id;
                F_name = name;
                F_price = price;
            }
        }









        #endregion

        
    }
}
