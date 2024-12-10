using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ung_Dung_Quan_Li_Nha_Hang
{
    public partial class Table_Manager : Form
    {
        private List<BanAn> dsBanAn = new List<BanAn>();
        private List<food> f = new List<food>();
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
            this.Hide();
            formAdmin formAdmin = new formAdmin(dsBanAn);
            formAdmin.ButtonAdded += FormAdmin_ButtonAdded;
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
                try
                {
                    using (FileStream readerFileStream = new FileStream(strFileLocation, FileMode.Open, FileAccess.Read))
                    {
                        dsBanAn = (List<BanAn>)binaryFormatter.Deserialize(readerFileStream);
                    }
                }
                catch (SerializationException)
                {
                    MessageBox.Show("File không hợp lệ hoặc cấu trúc dữ liệu đã thay đổi. Vui lòng xóa file cũ và thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dsBanAn = new List<BanAn>(); // Khởi tạo danh sách trống
                }
            }
            else
            {
                dsBanAn = new List<BanAn>(); // Khởi tạo danh sách trống nếu file không tồn tại
            }
        }

        #endregion

        #region Thêm Món Ăn Vào Hóa Đơn
        //============== xử lý load file nhị phân lên datagirdview ========= 
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
        //======= Lọc danh sách từ file nhị phân theo loại món ăn
        private void cbb_ShowLoaiMonAn_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lấy giá trị được chọn trong ComboBox
            string selectedCategory = cbb_ShowLoaiMonAn.SelectedItem?.ToString();

            // Kiểm tra nếu chưa chọn giá trị
            if (string.IsNullOrEmpty(selectedCategory))
            {
                MessageBox.Show("Chưa chọn danh mục hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tải danh sách món ăn từ file
            List<food> foodList = LoadFoodListFromFile("DanhSachMonAn.dat");

            // Lọc danh sách theo loại được chọn
            List<food> filteredFoodList;
            switch (selectedCategory)
            {
                case "Danh sách món ăn":
                    // Hiển thị toàn bộ danh sách
                    DisplayFoodListInListView(foodList);
                    break;

                case "Nước":
                    filteredFoodList = foodList.Where(foodItem => foodItem.F_list == "Nước").ToList();
                    DisplayFoodListInListView(filteredFoodList);
                    break;

                case "Gỏi":
                    filteredFoodList = foodList.Where(foodItem => foodItem.F_list == "Gỏi").ToList();
                    DisplayFoodListInListView(filteredFoodList);
                    break;

                case "Rau Củ":
                    filteredFoodList = foodList.Where(foodItem => foodItem.F_list == "Rau Củ").ToList();
                    DisplayFoodListInListView(filteredFoodList);
                    break;

                case "Mì":
                    filteredFoodList = foodList.Where(foodItem => foodItem.F_list == "Mì").ToList();
                    DisplayFoodListInListView(filteredFoodList);
                    break;

                case "Cơm":
                    filteredFoodList = foodList.Where(foodItem => foodItem.F_list == "Cơm").ToList();
                    DisplayFoodListInListView(filteredFoodList);
                    break;

                case "Mực":
                    filteredFoodList = foodList.Where(foodItem => foodItem.F_list == "Mực").ToList();
                    DisplayFoodListInListView(filteredFoodList);
                    break;

                case "Gà":
                    filteredFoodList = foodList.Where(foodItem => foodItem.F_list == "Gà").ToList();
                    DisplayFoodListInListView(filteredFoodList);
                    break;

                default:
                    // Xử lý các trường hợp khác
                    MessageBox.Show("Danh mục không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }
        //======= Thêm món ăn vào bàn =============
        private void btnThemMonAn_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                string foodName = selectedItem.SubItems[0].Text;
                string foodId = selectedItem.SubItems[1].Text;
                string foodPrice = selectedItem.SubItems[2].Text;
                string foodCategory = "Loại món ăn";

                food newFood = new food(foodName, foodId, foodPrice, foodCategory);

                BanAn currentBan = dsBanAn.FirstOrDefault(ban => ban.TenBan == "Tên bàn hiện tại");
                if (currentBan != null)
                {
                    currentBan.MonAn.Add(newFood);
                    MessageBox.Show($"Đã thêm món ăn '{foodName}' vào bàn '{currentBan.TenBan}'.", "Thông báo");
                }
                else
                {
                    MessageBox.Show("Không tìm thấy bàn hiện tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một món ăn để thêm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion
    }
}