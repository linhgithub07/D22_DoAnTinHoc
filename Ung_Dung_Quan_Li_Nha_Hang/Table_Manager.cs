using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ung_Dung_Quan_Li_Nha_Hang
{

    public partial class Table_Manager : Form
    {
        private List<BanAn> dsBanAn;
        public Table_Manager()
        {
            InitializeComponent();

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
            formAdmin formAdmin = new formAdmin();
            this.Hide();
            formAdmin.Show();
            this.Show();
        }

        #region Xu Ly Them Ban ra form giao dien

        public void CapNhatDanhSachBan(List<BanAn> danhSachBan)
        {
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


        #endregion
    }
}
