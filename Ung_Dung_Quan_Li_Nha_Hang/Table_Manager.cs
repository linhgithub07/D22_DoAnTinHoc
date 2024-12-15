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
            LoadDataToDataGridView();
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

        //===================================================================

        #region xử lý hiển thị danh sách món ăn
        private void LoadDataToDataGridView()
        {
            string filePath = "DanhSachMonAn.dat"; // Đường dẫn tới tệp nhị phân
            List<food> people = ReadBinaryFile(filePath);

            // Gắn dữ liệu vào DataGridView
            dgv_ShowFood.DataSource = people;
        }

        private List<food> ReadBinaryFile(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("Tệp không tồn tại!");

            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                return (List<food>)formatter.Deserialize(fs);
            }
        }
        // Phương thức hiển thị danh sách lên DataGridView
        private void DisplayFoodListInDataGridView(List<food> foodList)
        {
            // Gán danh sách làm nguồn dữ liệu cho DataGridView
            dgv_ShowFood.DataSource = null; // Xóa dữ liệu cũ (nếu có)
            dgv_ShowFood.DataSource = foodList; // Gán danh sách mới
        }

        private void cbb_ShowLoaiMonAn_SelectedIndexChanged_1(object sender, EventArgs e)
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
            List<food> foodList;
            try
            {
                foodList = ReadBinaryFile("DanhSachMonAn.dat");
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Lọc danh sách theo loại được chọn
            List<food> filteredFoodList;
            switch (selectedCategory)
            {
                case "Danh sách món ăn":
                    // Hiển thị toàn bộ danh sách
                    DisplayFoodListInDataGridView(foodList);
                    break;

                case "Nước":
                case "Gỏi":
                case "Rau Củ":
                case "Mì":
                case "Cơm":
                case "Mực":
                case "Gà":
                    filteredFoodList = foodList.Where(foodItem => foodItem.F_list == selectedCategory).ToList();
                    DisplayFoodListInDataGridView(filteredFoodList);
                    break;

                default:
                    // Xử lý các trường hợp khác
                    MessageBox.Show("Danh mục không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }
        #endregion
        private void btnThemMonAn_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_XemBill_Click(object sender, EventArgs e)
        {

        }
    }
}