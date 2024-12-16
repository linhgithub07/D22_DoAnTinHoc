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
    public partial class FormHoaDon : Form
    {
        private BanAn _banAn;
        private List<BanAn> dsBanAn = new List<BanAn>();
        private List<food> dsMonAn = new List<food>();
        private List<Bill> dsHoaDon = new List<Bill>();
        private static int soHoaDon;
        public event Action<BanAn> BanUpdated;
        public FormHoaDon()
        {
            InitializeComponent();
        }
        public FormHoaDon(BanAn banAn)
        {
            InitializeComponent();
            _banAn = banAn;
        }

        private void FormHoaDon_Load(object sender, EventArgs e)
        {
            // Hiển thị tên bàn hiện tại nếu có
            if (_banAn != null)
            {
                lblTenBan.Text = _banAn.Tenban; // Giả sử bạn có một Label để hiển thị tên bàn
            }

            //LoadBanVaoComboBox();
            LoadMonAnVaoComboBox();
            LoadHoaDon();
            taoCotChoDataGridView();
        }
        private void LoadMonAnVaoComboBox()
        {
            dsMonAn = new List<food>();

            // Kiểm tra file có tồn tại không
            if (File.Exists("dsMonAn.bin"))
            {
                try
                {
                    // Đọc dữ liệu từ file nhị phân
                    using (FileStream fs = new FileStream("dsMonAn.bin", FileMode.Open, FileAccess.Read))
                    {
                        BinaryFormatter formatter = new BinaryFormatter();
                        dsMonAn = (List<food>)formatter.Deserialize(fs);
                    }

                    // Thêm tên món ăn vào ComboBox
                    comboBoxTenMonAn.Items.Clear(); // Xóa dữ liệu cũ trong ComboBox
                    foreach (var monAn in dsMonAn)
                    {
                        comboBoxTenMonAn.Items.Add(monAn.F_name); // Thêm tên món ăn vào ComboBox
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi đọc file: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("File dsMonAn.bin không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void LoadBanVaoComboBox()
        //{
        //    // Kiểm tra xem file dsBanAn.bin có tồn tại không
        //    if (File.Exists("dsBanAn.bin"))
        //    {
        //        try
        //        {
        //            // Đọc dữ liệu từ file nhị phân
        //            using (FileStream fs = new FileStream("dsBanAn.bin", FileMode.Open, FileAccess.Read))
        //            {
        //                BinaryFormatter formatter = new BinaryFormatter();
        //                dsBanAn = (List<BanAn>)formatter.Deserialize(fs);
        //            }

        //            // Thiết lập DisplayMember và ValueMember
        //            comboBoxTenBan.DisplayMember = "Tenban";  // Chỉ hiển thị tên bàn
        //            comboBoxTenBan.ValueMember = "ID";        // Lưu ID bàn trong giá trị của ComboBox

        //            // Thêm đối tượng BanAn vào ComboBox
        //            comboBoxTenBan.Items.Clear();
        //            foreach (BanAn ban in dsBanAn)
        //            {
        //                comboBoxTenBan.Items.Add(ban); // Thêm đối tượng BanAn
        //            }

        //            // Nếu có bàn, tự động chọn bàn đầu tiên
        //            if (comboBoxTenBan.Items.Count > 0)
        //            {
        //                comboBoxTenBan.SelectedIndex = 0;
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show($"Lỗi khi đọc file: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("File dsBanAn.bin không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void taoCotChoDataGridView()
        {
            dgvHoaDon.Columns.Clear();
            dgvHoaDon.Columns.Add("MaHoaDon", "Mã Hóa Đơn");
            dgvHoaDon.Columns.Add("TenBan", "Tên Bàn");
            dgvHoaDon.Columns.Add("TenMonAn", "Tên Món Ăn");
            dgvHoaDon.Columns.Add("SoLuong", "Số Lượng");
            dgvHoaDon.Columns.Add("NgayTao", "Ngày Tạo");
            dgvHoaDon.Columns.Add("ThanhTien", "Thành Tiền");

            // Định dạng cột tiền
            dgvHoaDon.Columns["ThanhTien"].DefaultCellStyle.Format = "C";
        }

        public void luuHoaDon(string fileName, List<Bill> dsHoaDon)
        {
            try
            {
                // Tạo một đối tượng BinaryFormatter
                BinaryFormatter formatter = new BinaryFormatter();

                // Mở hoặc tạo file lưu trữ danh sách hóa đơn
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    // Tiến hành lưu danh sách dsHoaDon vào file
                    formatter.Serialize(fs, dsHoaDon);
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                MessageBox.Show($"Lỗi khi lưu hóa đơn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadHoaDon(string tenBan)
        {
            // Đọc danh sách hóa đơn từ file
            List<Bill> dsHoaDon = docHoaDon("dsHoaDon.bin");
            string ten= lblTenBan.Text;
            tenBan= ten.Trim();

            // Tìm hóa đơn tương ứng với bàn
            foreach (var hoaDon in dsHoaDon)
            {
                // Kiểm tra nếu hóa đơn thuộc bàn hiện tại
                if (hoaDon.chitietHoaDon.Any(ct => ct.monAn.F_list == tenBan))
                {
                    // Hiển thị hóa đơn trong DataGridView
                    foreach (var item in hoaDon.chitietHoaDon)
                    {
                        // Thêm thông tin món ăn từ chi tiết hóa đơn vào DataGridView
                        dgvHoaDon.Rows.Add(hoaDon.m_id, tenBan, item.monAn.F_name, item.soLuong, hoaDon.m_NgayTao, item.thanhTien);
                    }

                    break;  // Dừng tìm kiếm sau khi tìm được hóa đơn cho bàn
                }
            }

            // Đọc danh sách bàn và cập nhật trạng thái bàn
            List<BanAn> dsBanAn = docBanAn("dsBanAn.bin");
            foreach (var banAn in dsBanAn)
            {
                if (banAn.Tenban == tenBan)
                {
                    // Cập nhật trạng thái bàn trong giao diện
                    banAn.TrangThai="Đã đặt";
                    break;
                }
            }
        }
        private List<Bill> docHoaDon(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return new List<Bill>();
            }

            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                return (List<Bill>)formatter.Deserialize(fs);
            }
        }

        private List<BanAn> docBanAn(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return new List<BanAn>();
            }

            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                return (List<BanAn>)formatter.Deserialize(fs);
            }
        }
        private void btnThemMonAn_Click_1(object sender, EventArgs e)
        {
            if (_banAn == null || string.IsNullOrEmpty(_banAn.ID))
            {
                MessageBox.Show("Bàn không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Lấy thông tin từ ComboBox và NumericUpDown
            string tenBan = lblTenBan.Text;
            string tenMonAn = comboBoxTenMonAn.Text;
            int soLuong = (int)numUD_SLMonAn.Value;
            DateTime ngayTao = DateTime.Now;

            if (string.IsNullOrEmpty(tenMonAn))
            {
                MessageBox.Show("Vui lòng chọn món ăn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tìm món ăn trong danh sách dsMonAn
            food monAn = null;
            foreach (var item in dsMonAn)
            {
                if (item.F_name == tenMonAn)
                {
                    monAn = item;
                    break;
                }
            }

            if (monAn == null)
            {
                MessageBox.Show("Không tìm thấy món ăn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Tính Thành Tiền
            double thanhTien = soLuong * monAn.F_price;

            // Tạo mã hóa đơn với số tăng dần(mã hóa đơn dạng HD001, HD002, ...)
            string maHoaDon = "HD" + soHoaDon.ToString("D3");
            soHoaDon++;

            // Thêm dòng vào DataGridView
            dgvHoaDon.Rows.Add(maHoaDon,tenBan, tenMonAn, soLuong, DateTime.Now, thanhTien);

            // Cập nhật trạng thái bàn
            foreach (var banAn in dsBanAn)
            {
                if (banAn.Tenban == tenBan)
                {
                    banAn.TrangThai = "Đã đặt";
                    break;
                }
            }

            // Cập nhật Tổng Tiền
            UpdateTongTien();
        }
        private void UpdateTongTien()
        {
            double tongTien = 0;

            foreach (DataGridViewRow row in dgvHoaDon.Rows)
            {
                if (row.Cells["ThanhTien"].Value != null)
                {
                    tongTien += Convert.ToDouble(row.Cells["ThanhTien"].Value);
                }
            }

            txbTongTien.Text = tongTien.ToString();
        }
       

        private void butThanhToan_Click_1(object sender, EventArgs e)
        {
            if (_banAn == null || string.IsNullOrEmpty(_banAn.Tenban))
            {
                MessageBox.Show("Bàn không hợp lệ hoặc chưa chọn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string tenBan = _banAn.Tenban;
            DateTime ngayTao = DateTime.Now;

            // Kiểm tra nếu DataGridView có dữ liệu hợp lệ
            if (dgvHoaDon.Rows.Count == 0)
            {
                MessageBox.Show("Không có món ăn nào trong hóa đơn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Tạo danh sách chi tiết hóa đơn
            List<ChiTietHoaDon> chiTietHoaDon = new List<ChiTietHoaDon>();
            foreach (DataGridViewRow row in dgvHoaDon.Rows)
            {
                if (row.Cells["TenMonAn"].Value != null && row.Cells["SoLuong"].Value != null)
                {
                    string tenMonAn = row.Cells["TenMonAn"].Value.ToString();
                    int soLuong;
                    if (!int.TryParse(row.Cells["SoLuong"].Value.ToString(), out soLuong) || soLuong <= 0)
                    {
                        MessageBox.Show("Số lượng không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Tìm món ăn trong danh sách
                    food monAn = dsMonAn.FirstOrDefault(f => f.F_name == tenMonAn);
                    if (monAn == null)
                    {
                        MessageBox.Show($"Món ăn '{tenMonAn}' không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Thêm vào danh sách chi tiết hóa đơn
                    chiTietHoaDon.Add(new ChiTietHoaDon(monAn, soLuong));
                }
            }

            // Kiểm tra nếu danh sách chi tiết hóa đơn trống
            if (chiTietHoaDon.Count == 0)
            {
                MessageBox.Show("Không có món ăn nào trong hóa đơn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Tạo hóa đơn và thêm vào danh sách
            Bill hoaDon = new Bill(Guid.NewGuid().ToString(), ngayTao, chiTietHoaDon);
            dsHoaDon.Add(hoaDon);

            // Lưu hóa đơn vào file
            try
            {
                luuHoaDon("dsHoaDon.bin", dsHoaDon);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu hóa đơn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Hiển thị thông báo thành công
            MessageBox.Show("Hóa đơn đã được thanh toán thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Xóa dữ liệu hiện tại trong DataGridView và tổng tiền
            dgvHoaDon.Rows.Clear();
            txbTongTien.Clear();

            // Cập nhật trạng thái bàn
            //foreach (var banAn in dsBanAn)
            //{
            //    if (banAn.Tenban == tenBan)
            //    {
            //        banAn.TrangThai = "Trống";
            //        break;
            //    }
            //}
            if (_banAn != null)
            {
                _banAn.TrangThai = "Đã đặt";  // Hoặc trạng thái bạn muốn
                BanUpdated?.Invoke(_banAn);  // Gửi thông báo cho FormTableManager
                
            }
            this.Close();
        }
        private void LuuDanhSachBan()
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            string strFileLocation = "dsBanAn.bin";

            using (FileStream writerFileStream = new FileStream(strFileLocation, FileMode.Create, FileAccess.Write))
            {
                binaryFormatter.Serialize(writerFileStream, dsBanAn);  // Lưu danh sách bàn vào file
            }
        }

    }
}
