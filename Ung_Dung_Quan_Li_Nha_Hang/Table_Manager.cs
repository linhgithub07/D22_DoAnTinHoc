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
    [Serializable]

    public partial class Table_Manager : Form
    {
        private List<BanAn> dsBanAn = new List<BanAn>();
        private List<food> dsMonAn= new List<food>();
        private List<Bill> dsHoaDon = new List<Bill>();
        public Table_Manager()
        {
            InitializeComponent();
            LoadFileBanAn();
            CapNhatDanhSachBan();
        }

        private void dangxuat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thongtincanhan_Click(object sender, EventArgs e)
        {
            formThongTinCaNhan f_thongtin = new formThongTinCaNhan();
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
            CapNhatDanhSachBan(dsBanAn);  // Cập nhật lại giao diện
        }

        #region Xu Ly Them Ban ra form giao dien
        private void FormAdmin_ButtonAdded(BanAn ban)
        {
            if (ban != null)
            {
                dsBanAn.Add(ban);
            }
            CapNhatDanhSachBan(dsBanAn);
        }
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
        public void CapNhatDanhSachBanHandler(BanAn banAn)
        {
            // Cập nhật trạng thái của bàn trong danh sách
            var ban = dsBanAn.FirstOrDefault(b => b.ID == banAn.ID);
            if (ban != null)
            {
                ban.TrangThai = banAn.TrangThai;
            }

            // Gọi phương thức cập nhật giao diện
            CapNhatDanhSachBan(dsBanAn);  // Cập nhật lại giao diện
        }
        public void CapNhatDanhSachBan()
        {
            flpBan.Controls.Clear(); // Xóa các nút cũ trong FlowLayoutPanel

            foreach (BanAn ban in dsBanAn)
            {
                // Tạo nút cho từng bàn
                Button btnBan = new Button();
                btnBan.Text = ban.Tenban;
                btnBan.Width = 100;
                btnBan.Height = 50;
                btnBan.Tag = ban;

                // Tự cập nhật lại màu:
                updateMauBanAn(ban, btnBan);
                // Gắn sự kiện khi nhấn vào nút
                btnBan.Click += (s, e) =>
                {
                    BanAn banAn = (BanAn)btnBan.Tag;

                    if (banAn == null || string.IsNullOrEmpty(banAn.ID))
                    {
                        MessageBox.Show("Bàn không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Hiển thị hộp thoại với 2 lựa chọn: Xem Hóa Đơn và OK
                    DialogResult dialogResult = MessageBox.Show("Bạn Muốn Tạo Hóa Đơn?", "Hóa Đơn", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        // Nếu người dùng chọn "Yes", mở Form Hóa Đơn
                        OpenHoaDonForm(banAn);  // Mở form hóa đơn và truyền bàn hiện tại
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        // Nếu người dùng chọn "No", hiển thị thông tin bàn
                        ShowBanInfo(banAn);  // Hiển thị thông tin về bàn
                    }
                    else
                    {
                        // Nếu người dùng chọn "Cancel" hoặc đóng hộp thoại, không làm gì
                        return;
                    }
                };

                // Thêm nút vào FlowLayoutPanel
                flpBan.Controls.Add(btnBan);
            }
        }
        private void OpenHoaDonForm(BanAn banAn)
        {
            // Tạo một form hóa đơn mới (ví dụ: FormHoaDon)
            FormHoaDon formHoaDon = new FormHoaDon(banAn);
            formHoaDon.BanUpdated += CapNhatDanhSachBanHandler;

            this.Hide();
            formHoaDon.ShowDialog();
            this.Show();
        }
        private void ShowBanInfo(BanAn banAn)
        {
            string thongTinBan = $"ID: {banAn.ID}\nTên bàn: {banAn.Tenban}\nTrạng thái: {banAn.TrangThai}";
            MessageBox.Show(thongTinBan, "Thông tin Bàn", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void LoadFileBanAn()
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
        
    }
}
