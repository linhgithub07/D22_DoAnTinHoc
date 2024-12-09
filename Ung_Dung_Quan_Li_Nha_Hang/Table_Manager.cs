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

namespace Ung_Dung_Quan_Li_Nha_Hang
{
    public partial class Table_Manager : Form
    {
        private List<BanAn> dsBanAn = new List<BanAn>();
        private List<food> fo = new List<food>();
        public Table_Manager()
        {
            InitializeComponent();
            LoadFile();
            CapNhatDanhSachBan();
        }

        private void dangxuat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thongtincanhan_Click(object sender, EventArgs e)
        {
            formThongTinCaNhan f_thongtin= new formThongTinCaNhan();
            this.Hide();
            f_thongtin.ShowDialog();  
            this.Show();
        }

        private void admin_Click(object sender, EventArgs e)
        {
            formAdmin formAdmin = new formAdmin(dsBanAn);
            formAdmin.ButtonAdded += FormAdmin_ButtonAdded;
            this.Hide();
            formAdmin.ShowDialog();
            this.Show();
            CapNhatDanhSachBan(dsBanAn);
        }
        private void FormAdmin_ButtonAdded(BanAn ban)
        {
            if (ban != null)
            {
                dsBanAn.Add(ban);
            }
            CapNhatDanhSachBan(dsBanAn);
        }
        #region Xu Ly Them Ban ra form giao dien
        public void CapNhatDanhSachBan(List<BanAn> danhSachBan)
        {
            if (dsBanAn == null)
            {
                MessageBox.Show("Danh sách bàn không có dữ liệu!");
                return;
            }
            dsBanAn = danhSachBan; // Cập nhật danh sách bàn từ form khác
            CapNhatDanhSachBan();  // Cập nhật giao diện với danh sách mới
        }
        public void CapNhatDanhSachBan()
        { 
            flp_Ban.Controls.Clear(); // Xóa các nút cũ trong FlowLayoutPanel               

            foreach (BanAn ban in dsBanAn)
            {
                // Tạo nút cho từng bàn
                Button btnBan = new Button();
                btnBan.Text = ban.TenBan;
                btnBan.Width = 100;
                btnBan.Height = 50;

                // Tự cập nhật lại màu:
                updateMauBanAn(ban, btnBan);
                // Gắn sự kiện khi nhấn vào nút
                btnBan.Click += (s, e) =>
                {
                    MessageBox.Show($"ID: {ban.ID}\nTên bàn: {ban.TenBan}\nTrạng thái: {ban.TrangThai} ", "Thông tin bàn");
                };

                // Thêm nút vào FlowLayoutPanel
                flp_Ban.Controls.Add(btnBan);                 
            }
        }

        private void updateMauBanAn(BanAn ban, Button btnBan)
        {
            if (ban.TrangThai == "Đã đặt")
            {
                btnBan.BackColor = Color.Red;
                btnBan.ForeColor = Color.White;
            }
            else
            {
                btnBan.BackColor = Color.Green;
                btnBan.ForeColor = Color.White;
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
        }

        #endregion

        #region Thêm Món Ăn Vào Hóa Đơn
        #region
        //======= Hàm fix bug save food ========/
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
        private List<food> LoadFoodListFromFile(string filePath)
        {
            List<food> foodList = new List<food>();

            if (File.Exists(filePath))
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    foodList = (List<food>)formatter.Deserialize(fs);
                    DisplayFoodListInListView(foodList);
                }
            }
            else
            {
                MessageBox.Show("File không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return foodList;
        }
        private void DisplayFoodListInListView(List<food> foodList)
        {
            // Xóa dữ liệu hiện tại trong ListView
            listView1.Items.Clear();

            // Lặp qua danh sách món ăn và thêm vào ListView
            foreach (food f in foodList)
            {
                // Tạo ListViewItem cho mỗi món ăn
                ListViewItem item = new ListViewItem(f.F_name);
                item.SubItems.Add(f.F_id);
                item.SubItems.Add(f.F_price);

                // Thêm item vào ListView
                listView1.Items.Add(item);
            }
        }
        private void LoadAndDisplayFoodList(string filePath)
        {
            // Đọc danh sách món ăn từ file nhị phân
            List<food> foodList = LoadFoodListFromFile(filePath);

            // Hiển thị danh sách món ăn vào ListView
            DisplayFoodListInListView(foodList);
        }

        #endregion

        private void cbb_ShowLoaiMonAn_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lấy giá trị được chọn trong ComboBox
            string selectedCategory = cbb_ShowLoaiMonAn.SelectedItem.ToString();

            // Kiểm tra nếu giá trị được chọn là "Danh sách món ăn" (hoặc bất kỳ điều kiện nào bạn muốn)
            if (selectedCategory == "Danh sách món ăn")
            {
                // Gọi hàm để tải và hiển thị dữ liệu từ file nhị phân vào ListView
                LoadAndDisplayFoodList("DanhSachMonAn.dat");
            }
            else
            {
                // Xử lý các trường hợp khác nếu có
                MessageBox.Show("Chưa chọn danh mục hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
/*
 // Đảm bảo f là biến toàn cục
private List<food> f = new List<food>();

#region Thêm Món Ăn Vào Hóa Đơn

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

// Xử lý data từ file
private void dgv_ShowDanhSachMonAn_CellClick(object sender, DataGridViewCellEventArgs e)
{
    pt = e.RowIndex;
}

// Cập nhật phương thức LoadFoodList để truyền trực tiếp danh sách
private void LoadFoodList(DataGridView dgv_ShowDanhSachMonAn, List<food> f)
{
    dgv_ShowDanhSachMonAn.DataSource = f;  // Không cần chuyển đổi thành mảng
}

// Nạp danh sách món ăn từ file
private void LoadFoodListFromFile(string filePath)
{
    if (File.Exists(filePath))
    {
        using (FileStream fs = new FileStream(filePath, FileMode.Open))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            f = (List<food>)formatter.Deserialize(fs);  // Đảm bảo f là biến toàn cục
            LoadFoodList(dgv_ShowDanhSachMonAn, f);    // Hiển thị lên DataGridView
        }
        MessageBox.Show("Danh sách món ăn đã được tải từ file!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
    else
    {
        MessageBox.Show("File không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}

// Khi thay đổi loại món ăn, tải lại danh sách
private void cbb_ShowLoaiMonAn_SelectedIndexChanged(object sender, EventArgs e)
{
    LoadFoodList(dgv_ShowDanhSachMonAn, f);  // Hiển thị danh sách đã nạp
    LoadFoodListFromFile("DanhSachMonAn.dat");  // Nạp lại danh sách từ file
}

 */