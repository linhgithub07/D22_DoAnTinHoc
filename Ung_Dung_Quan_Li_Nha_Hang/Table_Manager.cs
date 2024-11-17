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
            //this.Hide();
            f_thongtin.ShowDialog();  
        }

        private void admin_Click(object sender, EventArgs e)
        {
           formAdmin formAdmin = new formAdmin();
            this.Hide();
            formAdmin.ShowDialog();
            this.Show();
        }
    }
}
