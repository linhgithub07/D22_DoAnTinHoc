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
using Ung_Dung_Quan_Li_Nha_Hang;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;


namespace Ung_Dung_Quan_Li_Nha_Hang
{
    
    public partial class formAdmin : Form

    {

        private List<food> f = new List<food>();
        private List<tk_mk> f_tkmk = new List<tk_mk>(); // ll = load list
        private int pt = -1;
        // private List<BanAn> DanhSachBanAn = new List<BanAn>();
        private List<BanAn> DanhSachBanAn;
        public delegate void ButtonAddedEventHandler(BanAn newTable);
        public event ButtonAddedEventHandler ButtonAdded;
        public formAdmin(List<BanAn> dsBan)
        {
            InitializeComponent();
            if (dsBan == null)
            {
                MessageBox.Show("Danh sách bàn không hợp lệ!");
                return;
            }
            DanhSachBanAn = new List<BanAn>(dsBan);
            hienthi();
        }

        #region PHẦN MÓN ĂN.
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

        private void btn_SaveFood_Click(object sender, EventArgs e)
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
            txt_ListFood.Text = f[pt].F_list;
            txt_FoodID.Text = f[pt].F_id;
            txt_FoodName.Text = f[pt].F_name;
            txt_FoodPrice.Text = f[pt].F_price;
        }// chức năng của hàm: khi click vao bất cứ vị trí trên dong nào thì data của dòng đó được hiển thị.
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
            LoadFoodListFromFile("DanhSachMonAn.dat");
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

        private void formAdmin_Load(object sender, EventArgs e)
        {

            //DanhSachBanAn = new List<BanAn>();
            dsHoaDon = new List<Bill>();
            LoadFile();
            hienthi();
        }
        private void hienthi()
        {
            dgv_Ban.DataSource = DanhSachBanAn.ToList();
        }

        private BanAn timBan(string ma)
        {
            foreach(BanAn x in DanhSachBanAn)
                if (x.ID == ma) return x;
            return null;
        }
        private void btnThemBan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txbID_Ban.Text))
            {
                MessageBox.Show("ID không được để trống!");
                return;
            }
            BanAn banAn = new BanAn();
            banAn.ID = txbID_Ban.Text;
            banAn.Tenban = txbTen_Ban.Text;
            banAn.TrangThai = txbTrangThai.Text;
            if(timBan(banAn.ID)==null)
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

        private void btnXoaBan_Click(object sender, EventArgs e)
        {
            string ma=txbID_Ban.Text;
            if(timBan(ma)!=null)
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
        private void btnSuaBan_Click(object sender, EventArgs e)
        {
            string ma = txbID_Ban.Text;
            BanAn banAn=timBan(ma);
            if (banAn != null)
            {
                banAn.Tenban = txbTen_Ban.Text;
                banAn.TrangThai= txbTrangThai.Text;
                ButtonAdded?.Invoke(null);
                hienthi();
                MessageBox.Show("Cập nhật bàn thành công!");
            }
            else 
            {
                MessageBox.Show("Không tìm thấy bàn để sửa!");
            }
        }

        private void dgv_Ban_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            txbID_Ban.Text = dgv_Ban.Rows[e.RowIndex].Cells[0].Value.ToString();
            txbTen_Ban.Text = dgv_Ban.Rows[e.RowIndex].Cells[1].Value.ToString();
            txbTrangThai.Text = dgv_Ban.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void btnGhiBan_Click(object sender, EventArgs e)
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
            string strFileLocation = "dsBanAn.bin";
            if (File.Exists(strFileLocation))
            {
                using (FileStream readerFileStream = new FileStream(strFileLocation, FileMode.Open, System.IO.FileAccess.Read))
                {
                    DanhSachBanAn = (List<BanAn>)binaryFormatter.Deserialize(readerFileStream);
                }
            }
        }

        //
        
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

        #region Phần Thống Kê
        private List<Bill> dsHoaDon;
        public void hienthiHoaDon()
        {
            dgv_DoanhThu.DataSource = dsHoaDon;
        }
        private void butThongKe_Click(object sender, EventArgs e)
        {
            DateTime ngayBatDau = dtpNgayBD.Value;
            DateTime ngayKetThuc= dtpNgayKetThuc.Value;
            if (ngayBatDau > ngayKetThuc)
            {
                MessageBox.Show("Ngày bắt đầu không thể lớn hơn ngày kết thúc. Vui lòng chọn lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<Bill> dsHoaDonTrongThoiGianThongKe = new List<Bill>();
            foreach(Bill b in dsHoaDon) 
            {
                if(b.m_NgayTao>= ngayBatDau&&b.m_NgayTao<=ngayKetThuc)
                {
                    dsHoaDonTrongThoiGianThongKe.Add(b);
                }
            }
            if (dsHoaDonTrongThoiGianThongKe.Count == 0)
            {
                MessageBox.Show("Không có hóa đơn trong khoảng thời gian này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Hiển thị danh sách hóa đơn trong DataGridView
                dgv_DoanhThu.DataSource = dsHoaDonTrongThoiGianThongKe;
            }
        }


        #endregion

        private void dgv_DoanhThu_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}

