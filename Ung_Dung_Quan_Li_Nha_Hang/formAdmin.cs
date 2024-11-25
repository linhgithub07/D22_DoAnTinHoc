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


namespace Ung_Dung_Quan_Li_Nha_Hang
{
    
    public partial class formAdmin : Form

    {
        private List<food> f = new List<food>();
        private List<tk_mk> f_tkmk = new List<tk_mk>(); // ll = load list
        private int pt = -1;
        private Table_Manager formHienThi;
        public formAdmin()
        {
            InitializeComponent();
            formHienThi = new Table_Manager();
            formHienThi.Show();
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
        private List<BanAn> dsBanAn = new List<BanAn>();


        private void formAdmin_Load(object sender, EventArgs e)
        {
            
            dsBanAn = new List<BanAn>();
            LoadFile();
            hienthi();
            formHienThi = new Table_Manager();
            formHienThi.Show();
            formHienThi.CapNhatDanhSachBan(dsBanAn);
        }
        private void hienthi()
        {
            dgv_Ban.DataSource = dsBanAn.ToList();
        }

        private BanAn timBan(string ma)
        {
            foreach(BanAn x in dsBanAn)
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
                dsBanAn.Add(banAn);
                hienthi();
                formHienThi.CapNhatDanhSachBan();
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
                dsBanAn.Remove(timBan(ma));
                hienthi();
                formHienThi.CapNhatDanhSachBan();
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
                if (ma != dgv_Ban.CurrentRow.Cells[0].Value.ToString())
                {
                    MessageBox.Show("ID bàn không được phép thay đổi!");
                    return;
                }
                banAn.Tenban = txbTen_Ban.Text;
                banAn.TrangThai= txbTrangThai.Text;
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
                    bf.Serialize(file, this.dsBanAn);
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
                    dsBanAn = (List<BanAn>)binaryFormatter.Deserialize(readerFileStream);
                }
            }
            else
            {
                dsBanAn = new List<BanAn>(); // Nếu file không tồn tại, khởi tạo danh sách rỗng
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

       

       
    }
}

