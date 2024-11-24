using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
        private List<tk_mk> dsTK;
        public Login()
        {
            InitializeComponent();
        }

        private void but_dangNhap_Click(object sender, EventArgs e)
        {
            string filePath = "DanhSachTaiKhoan.bin";
            string tenTK = txBox_dangNhap.Text.Trim();
            string matkhau = txBox_matKhau.Text.Trim();

           dsTK = DocDsTK(filePath);

            bool flag = false;
            foreach(tk_mk tk in dsTK)
            {
                if(tk.TaiKhoan==tenTK&&tk.MatKhau==matkhau)
                    flag = true;
                break;
            }
            if (flag)
            {
                MessageBox.Show("Bạn đã đăng nhập thành công.", "Chúc Mừng");
                this.Hide();
                Table_Manager form2 = new Table_Manager();
                this.Hide();
                form2.ShowDialog();
                this.Show();
                
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác.", "Thông Báo!");
            }
        }

        private void but_thoat_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có chắc là muốn thoát không?", "Thông Báo!", MessageBoxButtons.YesNo);
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
            string tenTK = txBox_dangNhap.Text.Trim();
            string matkhau = txBox_matKhau.Text.Trim();

            // Kiểm tra tài khoản và mật khẩu có để trống không
            if (string.IsNullOrWhiteSpace(tenTK) || string.IsNullOrWhiteSpace(matkhau))
            //string.IsNullOrWhiteSpace: kiểm tra xem chuỗi rỗng hoặc chỉ chứa khoảng trắng
            {
                MessageBox.Show("Tên tài khoản và mật khẩu không được để trống!", "Thông Báo");
                return; // Dừng việc tiếp tục xử lý nếu dữ liệu không hợp lệ
            }

            // Đọc danh sách tài khoản từ file
            List<tk_mk> dsTK = DocDsTK(filePath);

            // Kiểm tra tài khoản đã tồn tại hay chưa
            bool flag = false;
            foreach (tk_mk tk in dsTK)
            {
                if (tk.TaiKhoan == tenTK)
                {
                    flag = true;
                    break;
                }
            }

            // Nếu tồn tại thì thông báo, nếu không thì tiếp tục tạo tài khoản
            if (flag)
            {
                MessageBox.Show("Tài khoản đã tồn tại. Vui lòng sử dụng tên tài khoản khác!", "Thông Báo");
            }
            else
            {
                // Tạo tài khoản mới và ghi vào file
                tk_mk taikhoanMoi = new tk_mk(tenTK, matkhau);

                // Thêm tài khoản vào danh sách
                dsTK.Add(taikhoanMoi);

                // Ghi tài khoản vào file
                GhiFile(filePath, dsTK);

                // Sau khi tạo thành công thì xuất thông báo
                MessageBox.Show("Đã tạo tài khoản thành công!", "Thông Báo");

                // Xóa nội dung textbox
                txBox_dangNhap.Clear();
                txBox_matKhau.Clear();
            }
        } 
    }
}

