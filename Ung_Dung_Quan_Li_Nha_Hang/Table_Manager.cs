using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Ung_Dung_Quan_Li_Nha_Hang
{
    public partial class Table_Manager : Form
    {

        public Table_Manager()
        {
            InitializeComponent();
            formAdmin adminForm = new formAdmin();
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
        private Dictionary<string, Button> buttonBanAn = new Dictionary<string, Button>();
        public void ThemBan(BanAn ban)
        {
            Button btnBan = new Button
            {
                //Thiet ke kich thuoc cua ban khi an tao ban.
                Text = ban.TenBan,
                Width = 100,
                Height = 50,
                Margin = new Padding(5)
            };
        
            buttonBanAn.Add(ban.TenBan, btnBan);
            flowLayoutPanel.Controls.Add(btnBan);
        }

        public void XoaBan(BanAn ban)
        {
            foreach (var x in buttonBanAn.ToList())
            {
                if (x.Key == ban.TenBan)
                {
                    flowLayoutPanel.Controls.Remove(x.Value);
                    buttonBanAn.Remove(x.Key);
                    break;
                }
            }


        }


        #endregion

       
    }
}
