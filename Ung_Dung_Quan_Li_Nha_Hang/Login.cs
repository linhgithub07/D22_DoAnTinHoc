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
    public partial class Login : Form
    {
        private List<tk_mk> dsTKMK;
        public Login()
        {
            InitializeComponent();
        }
        private void but_dangNhap_Click(object sender, EventArgs e)
        {
            string filePath = "DanhSachTaiKhoan.bin";
            string tenTK = txBox_dangNhap.Text.Trim();
            string matkhau = txBox_matKhau.Text.Trim();

            List<tk_mk> dsTK = DocDsTK(filePath);

            bool flag = false;
            for (int i = 0; i < dsTK.Count; i++)
            {
                if (dsTK[i].TaiKhoan == tenTK && dsTK[i].MatKhau == matkhau)
                {
                    flag = true;
                    break;
                }
            }
            if (flag)
            {
                MessageBox.Show("Ban da dang nhap thanh cong", "Chuc Mung");
                Table_Manager form2 = new Table_Manager();
                this.Hide();
                form2.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Tai khoan chua duoc tao", "Thong bao");
            }
        }

        private void but_thoat_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Ban co chac la muon thoat khong?", "Thong Bao!", MessageBoxButtons.YesNo);
            if (kq == DialogResult.Yes) this.Close();
        }

        //TaoTK va luu vao file nhi phan
        private List<tk_mk> DocDsTK(string filePath)
        {
            List<tk_mk> dsTK = new List<tk_mk>();
            if (File.Exists(filePath))
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    dsTK = (List<tk_mk>)bf.Deserialize(fs);
                }
            }
            return dsTK;
        }

        private void GhiFile(string filePath, List<tk_mk> dsTK)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, dsTK);
            }
        }
        private void butTaoTK_Click(object sender, EventArgs e)
        {
            string filePath = "DanhSachTaiKhoan.bin";
            string tenTK = txBox_dangNhap.Text.Trim();//  .trim: loai bo khoang trang dau cuoi
            string matkhau = txBox_matKhau.Text.Trim();
            //kiem tra tk mk co de trong khong?
            if (tenTK == null || matkhau == null)
            {
                MessageBox.Show("Ten tai khoan va mat khau khong duoc de trong!", "Thong Bao");
            }
            //Doc danh sach tai khoan tu file
            List<tk_mk> dsTK = DocDsTK(filePath);

            //kiem tra dstk ton tai hay chua
            bool flag = false;
            for (int i = 0; i < dsTK.Count; i++)
            {
                if (dsTK[i].TaiKhoan == tenTK)
                {
                    flag = true;
                    break;
                }
            }
            //neu ton tai thi xuat ra thong bao da ton tai, vui long su dung tai khoan khac. Neu khong thi tiep tuc tao tai khoan
            if (flag)
            {
                MessageBox.Show("Tai khoan da ton tai. Vui long su dung ten tai khoan khac!", "Thong bao");
            }

            //Tao tai khoan moi va ghi vao file
            tk_mk taikhoanMoi = new tk_mk(tenTK, matkhau);
            //them tk vao dsach
            dsTK.Add(taikhoanMoi);
            //ghi tkmk vao file 
            GhiFile(filePath, dsTK);

            txBox_dangNhap.Clear();
            txBox_matKhau.Clear();
            //Sau khi tao thanh cong thi xuat thong bao da tao thanh cong
            //MessageBox.Show("Da tao thanh cong", "Thong Bao");
        }
    }
}

