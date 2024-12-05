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
            if(dsBanAn==null)
            {
                MessageBox.Show("Danh sách bàn không có dữ liệu!");
                return;
            }
            dsBanAn = danhSachBan; // Cập nhật danh sách bàn từ form khác
            CapNhatDanhSachBan();  // Cập nhật giao diện với danh sách mới
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
                
                // Tự cập nhật lại màu:
                updateMauBanAn(ban, btnBan);
                // Gắn sự kiện khi nhấn vào nút
                btnBan.Click += (s, e) =>
                {
                    MessageBox.Show($"ID: {ban.ID}\nTên bàn: {ban.Tenban}\nTrạng thái: {ban.TrangThai} ", "Thông tin bàn");
                };

                // Thêm nút vào FlowLayoutPanel
                flpBan.Controls.Add(btnBan);
            }
        }

        private void updateMauBanAn(BanAn ban, Button btnBan)
        {
            if(ban.TrangThai=="Đã đặt")
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
    }
}
