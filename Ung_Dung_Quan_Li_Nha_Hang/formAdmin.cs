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
using Ung_Dung_Quan_Li_Nha_Hang;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using System.Windows.Forms.DataVisualization.Charting;


namespace Ung_Dung_Quan_Li_Nha_Hang
{
    
    public partial class formAdmin : Form

    {

        private List<food> f = new List<food>();
        private List<tk_mk> f_tkmk = new List<tk_mk>(); // ll = load list
        private int pt = -1;
        // private List<BanAn> DanhSachBanAn = new List<BanAn>();
        private List<BanAn> DanhSachBanAn;
        public delegate void ButtonAddedEventHandler(BanAn newTable);
        public event ButtonAddedEventHandler ButtonAdded;
        private List<Bill> dsHoaDon=new List<Bill>();
        public formAdmin(List<BanAn> dsBan)
        {
            InitializeComponent();
            if (dsBan == null)
            {
                MessageBox.Show("Danh sách bàn không hợp lệ!");
                return;
            }
            DanhSachBanAn = new List<BanAn>(dsBan);
            hienthi();
        }

        #region PHẦN MÓN ĂN.
        #region Phần Lưu Món Ăn
        private void SaveFoodListToFile(string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                BinaryFormatter sf = new BinaryFormatter();
                sf.Serialize(fs, f);
            }
            MessageBox.Show("Danh sách món ăn đã được lưu vào file thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_SaveFood_Click(object sender, EventArgs e)
        {
            SaveFoodListToFile("dsMonAn.bin");
        }
        private void LoadFoodListFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    f = (List<food>)formatter.Deserialize(fs);
                    LoadFoodList(dgv_MonAn, f);
                }
                MessageBox.Show("Danh sách món ăn đã được tải từ file!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("File không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void LoadFoodList(DataGridView dgv_MonAn, List<food> f)
        {
            dgv_MonAn.DataSource = f.ToList();
        }
        private void dgv_MonAn_CellClick(object sender, DataGridViewCellEventArgs e) 
        {
            pt = e.RowIndex;
            txt_ListFood.Text = f[pt].F_list;
            txt_FoodID.Text = f[pt].F_id;
            txt_FoodName.Text = f[pt].F_name;
            txt_FoodPrice.Text = f[pt].F_price.ToString();
        }// chức năng của hàm: khi click vao bất cứ vị trí trên dong nào thì data của dòng đó được hiển thị.
        private void btnThemMonAn_Click(object sender, EventArgs e)
        {
            string list = txt_ListFood.Text;
            string id = txt_FoodID.Text;
            string name = txt_FoodName.Text;
            string price = txt_FoodPrice.Text;
            if (!double.TryParse(price, out double P) || P < 0)
            {
                MessageBox.Show("Giá trị 'Giá' phải là một số hợp lệ và không được âm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;  // Không tiếp tục thêm món ăn nếu giá không hợp lệ
            }
            // phần ghi món ăn vào DataGridView
            bool kq = false;
            food f_f = new food(list, id, name, P);
            foreach ( var item in f)
            {
                if (id == item.F_id)
                {
                    kq = true;
                    MessageBox.Show("Mã Món Ăn Bị Trùng!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            if (!kq)
            {
                f.Add(f_f);
                LoadFoodList(dgv_MonAn, f);
                SaveFoodListToFile("dsMonAn.bin");
            }
            
        } // chưa có phần ghi dữ liệu vào file.
        private void btnSuaMonAn_Click(object sender, EventArgs e)
        {
            if (pt == -1) MessageBox.Show("Hãy chọn 1 đối tượng", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                string list = txt_ListFood.Text;
                string id = txt_FoodID.Text;
                string name = txt_FoodName.Text;
                string price = txt_FoodPrice.Text;
                if (double.TryParse(price, out double P))
                {
                    food f_f = new food(list, id, name, P);
                    f[pt] = f_f;  // Cập nhật món ăn trong danh sách
                    LoadFoodList(dgv_MonAn, f);  // Cập nhật DataGridView

                    pt = -1;  // Đặt lại chỉ số chọn
                    SaveFoodListToFile("dsMonAn.bin");  // Lưu danh sách món ăn vào file

                    MessageBox.Show("Thông tin món ăn đã được cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Giá tiền không hợp lệ. Vui lòng nhập một số hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnXoaMonAn_Click(object sender, EventArgs e)
        {
            if (pt == -1) MessageBox.Show("Hãy chọn 1 đối tượng", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                DialogResult kq = MessageBox.Show("Bạn chắc chắn muốn thay đổi!", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (kq == DialogResult.Yes)
                {
                    f.RemoveAt(pt);
                    LoadFoodList(dgv_MonAn, f);
                    SaveFoodListToFile("dsMonAn.bin");
                }
                pt = -1;
            }
        }
        private void btn_Xem_Click(object sender, EventArgs e)
        {
            LoadFoodList(dgv_MonAn, f);
            LoadFoodListFromFile("dsMonAn.bin");
        }
        private void btnTimMonAn_Click(object sender, EventArgs e)
        {
            List<food> srearch = new List<food>();
            foreach (var item in f)
            {
                if (item.F_id.Contains(txbTimMonAn.Text))
                {
                    srearch.Add(item);
                }    
            }
            LoadFoodList(dgv_MonAn,srearch);
        }
        #endregion


        #region PHẦN BÀN ĂN

        private void formAdmin_Load(object sender, EventArgs e)
        {

            //DanhSachBanAn = new List<BanAn>();
            dgv_Ban.RowEnter += dgv_Ban_RowEnter;
            cbbTrangThai_Ban.SelectedIndexChanged += cbbTrangThai_Ban_SelectedIndexChanged;

            LoadFile();
            hienthi();
        }
        private void CapNhatTrangThaiBan(List<BanAn> danhSachCapNhat)
        {
            DanhSachBanAn = danhSachCapNhat;
            hienthi(); // Cập nhật giao diện
        }
        private void hienthi()
        {
            // Tạo danh sách dữ liệu để gán vào DataGridView
            var danhSachBinding = DanhSachBanAn.Select(ban => new
            {
                ID = ban.ID,
                TenBan = ban.Tenban,
                TrangThai = ban.TrangThai == "Đã đặt" // Chuyển "Đã đặt" thành true, ngược lại là false
            }).ToList();

            // Gán danh sách dữ liệu vào DataGridView
            dgv_Ban.DataSource = danhSachBinding;
        }

        private BanAn timBan(string ma)
        {
            foreach(BanAn x in DanhSachBanAn)
                if (x.ID == ma) return x;
            return null;
        }
        private void btnThemBan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txbID_Ban.Text))
            {
                MessageBox.Show("ID không được để trống!");
                return;
            }
            BanAn banAn = new BanAn();
            banAn.ID = txbID_Ban.Text;
            banAn.Tenban = txbTen_Ban.Text;
            banAn.TrangThai =cbbTrangThai_Ban.Text;
            if(timBan(banAn.ID)==null)
            {
                DanhSachBanAn.Add(banAn);
                ButtonAdded?.Invoke(banAn);
                hienthi();
            }
            else
            {
                MessageBox.Show("Bàn đã tồn tại!");
            }
        }

        private void btnXoaBan_Click(object sender, EventArgs e)
        {
            string ma=txbID_Ban.Text;
            if(timBan(ma)!=null)
            {
                DanhSachBanAn.Remove(timBan(ma));
                ButtonAdded?.Invoke(null);
                hienthi();
            }
            else
            {
                MessageBox.Show("không tìm thấy bàn để xóa!");
            }
        }
        private void btnSuaBan_Click(object sender, EventArgs e)
        {
            string ma = txbID_Ban.Text;
            BanAn banAn=timBan(ma);
            if (banAn != null)
            {
                banAn.Tenban = txbTen_Ban.Text;
                banAn.TrangThai= cbbTrangThai_Ban.Text;
                ButtonAdded?.Invoke(null);
                hienthi();
                MessageBox.Show("Cập nhật bàn thành công!");
            }
            else 
            {
                MessageBox.Show("Không tìm thấy bàn để sửa!");
            }
        }

        private void dgv_Ban_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            txbID_Ban.Text = dgv_Ban.Rows[e.RowIndex].Cells[0].Value.ToString();
            txbTen_Ban.Text = dgv_Ban.Rows[e.RowIndex].Cells[1].Value.ToString();
            bool trangThai = (bool)dgv_Ban.Rows[e.RowIndex].Cells[2].Value;
            cbbTrangThai_Ban.Text = trangThai ? "Đã đặt" : "Trống";
        }

        private void cbbTrangThai_Ban_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dgv_Ban.CurrentRow != null)
            {
                // Lấy giá trị mới từ ComboBox
                string trangThai = cbbTrangThai_Ban.Text;

                // Cập nhật giá trị checkbox trong DataGridView
                dgv_Ban.CurrentRow.Cells[2].Value = trangThai == "Đã đặt";
            }
        }
        private void dgv_Ban_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu sự kiện thay đổi xảy ra tại cột "TrangThai"
            if (e.ColumnIndex == dgv_Ban.Columns["TrangThai"].Index && e.RowIndex >= 0)
            {
                // Lấy giá trị mới từ checkbox
                bool trangThaiMoi = (bool)dgv_Ban.Rows[e.RowIndex].Cells[2].Value;

                // Chuyển đổi thành chuỗi "Đã đặt" hoặc "Trống"
                string trangThaiString = trangThaiMoi ? "Đã đặt" : "Trống";

                // Lấy ID bàn từ cột ID
                string idBan = dgv_Ban.Rows[e.RowIndex].Cells[0].Value.ToString();

                // Tìm bàn trong danh sách và cập nhật trạng thái
                BanAn banAn = timBan(idBan);
                if (banAn != null)
                {
                    banAn.TrangThai = trangThaiString;
                }
            }
        }

        private void dgv_Ban_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu người dùng click vào cột trạng thái (checkbox)
            if (e.ColumnIndex == dgv_Ban.Columns["TrangThai"].Index && e.RowIndex >= 0)
            {
                // Lấy trạng thái của checkbox khi người dùng click
                bool trangThaiMoi = (bool)dgv_Ban.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                // Cập nhật ComboBox tương ứng với trạng thái
                cbbTrangThai_Ban.Text = trangThaiMoi ? "Đã đặt" : "Trống";
            }
        }
        private void btnGhiBan_Click(object sender, EventArgs e)
        {

            try
            {
                using (Stream file = File.Open("dsBanAn.bin", FileMode.Create))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(file, this.DanhSachBanAn);
                }
                MessageBox.Show("Ghi Thanh Cong.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                    DanhSachBanAn = (List<BanAn>)binaryFormatter.Deserialize(readerFileStream);
                }
            }
        }

                #endregion

                #region PHẦN THÔNG TIN TÀI KHOẢN
                private void LoadAccountList(DataGridView dgv_AccountList, List<tk_mk> tkmk) { dgv_AccountList.DataSource = tkmk.ToList(); }
        private void dgv_AccountList_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            pt = e.RowIndex;
            txb_TenTK.Text = f_tkmk[pt].TaiKhoan;
        }
        private void btnThemTaiKhoan_Click(object sender, EventArgs e)
        {
            string nameTK = txb_TenTK.Text;
            string fullName = txb_FullName.Text;
            string pass = txb_pass.Text;
            string loai = cbb_LoaiTK.Text;

            bool kqtk = false;
            tk_mk newTK = new tk_mk(nameTK, pass);
            foreach (var item in f_tkmk)
            {
                if (nameTK == item.TaiKhoan)
                {
                    kqtk = true;
                    MessageBox.Show("Tên Tài Khoản Đã Tồn Tại!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            if (!kqtk) f_tkmk.Add(newTK);
            LoadAccountList(dgv_AccountList, f_tkmk);
        }
        private void btnXoaTaiKhoan_Click(object sender, EventArgs e)
        {
            if (pt == -1) MessageBox.Show("Hãy chọn 1 đối tượng", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                DialogResult kqtk = MessageBox.Show("Bạn chắc chắn muốn thay đổi!", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (kqtk == DialogResult.Yes)
                {
                    f_tkmk.RemoveAt(pt);
                    LoadAccountList(dgv_AccountList, f_tkmk);
                }
                pt = -1;
            }
        }

        private void btnSuaTaiKhoan_Click(object sender, EventArgs e)
        {
            if (pt == -1) MessageBox.Show("Hãy chọn 1 đối tượng", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                string nameTK = txb_TenTK.Text;
                string fullName = txb_FullName.Text;
                string pass = txb_pass.Text;
                string loai = cbb_LoaiTK.Text;
                tk_mk newTK = new tk_mk(nameTK, pass);
                f_tkmk[pt] = newTK;
                LoadAccountList(dgv_AccountList, f_tkmk);
                pt = -1;
            }
        }
        #endregion

        #region Phần Thống Kê
        //goi lai dsBanAn de hien thi ra phan thong ke
        public List<BanAn> LoadDanhSachBanAn()
        {
            List<BanAn> dsBanAn = new List<BanAn>();
            if (File.Exists("dsBanAn.bin"))
            {
                using (FileStream fs = new FileStream("dsBanAn.bin", FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    dsBanAn = (List<BanAn>)formatter.Deserialize(fs);
                }
            }
            else
            {
                MessageBox.Show("File dsBanAn.bin không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dsBanAn;
        }
        public void hienthiHoaDon()
        {
            List<BanAn> dsBanAn=LoadDanhSachBanAn();
            DateTime ngayBatDau = dtpNgayBD.Value;
            DateTime ngayKetThuc = dtpNgayKetThuc.Value;
            if (ngayBatDau > ngayKetThuc)
            {
                MessageBox.Show("Ngày bắt đầu không thể lớn hơn ngày kết thúc. Vui lòng chọn lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //Tạo danh sách hóa đơn trong khoảng thời gian đã chọn
            List<Bill> dsHoaDonTrongThoiGianThongKe = new List<Bill>();
            foreach (Bill b in dsHoaDon)
            {
                if (b.m_NgayTao >= ngayBatDau && b.m_NgayTao <= ngayKetThuc)
                {
                    dsHoaDonTrongThoiGianThongKe.Add(b);
                }
            }
            // Hiển thị danh sách hóa đơn đã lọc trên DataGridView
            if (dsHoaDonTrongThoiGianThongKe.Count == 0)
            {
                MessageBox.Show("Không có hóa đơn trong khoảng thời gian này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                dgv_DoanhThu.Columns.Clear();
                dgv_DoanhThu.Columns.Add("MãHĐ", "Mã Hóa Đơn");
                dgv_DoanhThu.Columns.Add("TenBan", "Tên Bàn");
                dgv_DoanhThu.Columns.Add("NgayTao", "Ngày Tạo");
                //dgv_DoanhThu.Columns.Add("TenMon", "Tên Món");
                dgv_DoanhThu.Columns.Add("TongTien", "Tổng Tiền");

                // Thêm dữ liệu vào DataGridView
                foreach (var bill in dsHoaDonTrongThoiGianThongKe)
                {
                    foreach (var chitiet in bill.chitietHoaDon)
                    {
                        //Xử lí tìm tên bàn
                        //Cho tạm bàn mặc định là Bàn 1.
                        string tenBan = "Bàn 1";
                        var ban = dsBanAn.FirstOrDefault(b => b.ID == bill.m_id); //Lấy tên bàn theo ID bàn của hóa đơn
                        if (ban != null)
                        {
                            tenBan = ban.Tenban;
                        }

                        dgv_DoanhThu.Rows.Add(bill.m_id, tenBan, bill.m_NgayTao.ToShortDateString(), /*chitiet.monAn.F_name,*/ chitiet.thanhTien);
                    }
                }
            }
        }
        private void butThongKe_Click(object sender, EventArgs e)
        {
            

            //// Tạo danh sách món ăn mẫu
            //List<food> dsMonAn = new List<food>
            //{
            //    new food("Menu1", "F001", "Mực Rim Mắm", "50000"),
            //    new food("Menu2", "F002", "Lẩu gà", "45000"),
            //    new food("Menu3", "F003", "Cơm Chiên Dương Châu", "55000"),
            //    new food("Menu4", "F004", "Mì xào", "60000"),
            //    new food("Menu5", "F005", "Tôm hùm hấp", "70000")
            //};

            //// Tạo danh sách hóa đơn mẫu
            //dsHoaDon = new List<Bill>
            //{
            //    new Bill("HD001", new DateTime(2024, 12, 1), new List<ChiTietHoaDon>
            //    {
            //        new ChiTietHoaDon(dsMonAn[0], 2), 
            //        new ChiTietHoaDon(dsMonAn[1], 1) 
            //    }),
            //    new Bill("HD002", new DateTime(2024, 12, 5), new List<ChiTietHoaDon>
            //    {
            //        new ChiTietHoaDon(dsMonAn[2], 3),  
            //        new ChiTietHoaDon(dsMonAn[3], 1)  
            //    }),
            //    new Bill("HD003", new DateTime(2024, 12, 8), new List<ChiTietHoaDon>
            //    {
            //        new ChiTietHoaDon(dsMonAn[4], 4),  
            //        new ChiTietHoaDon(dsMonAn[1], 2)
            //    }),
            //    new Bill("HD004", new DateTime(2024, 12, 10), new List<ChiTietHoaDon>
            //    {
            //        new ChiTietHoaDon(dsMonAn[0], 1),  
            //        new ChiTietHoaDon(dsMonAn[2], 1),  
            //        new ChiTietHoaDon(dsMonAn[3], 2)   
            //    })
            //};

            hienthiHoaDon();
        }

        


        #endregion

        private void btnTaoBieuDo_Click(object sender, EventArgs e)
        {
            DateTime ngayBatDau = dtpNgayBD.Value.Date;
            DateTime ngayKetThuc = dtpNgayKetThuc.Value.Date;
            if (ngayBatDau > ngayKetThuc)
            {
                MessageBox.Show("Ngày bắt đầu không thể lớn hơn ngày kết thúc. Vui lòng chọn lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //Lọc hóa đơn
            List<Bill> dsHoaDonTrongThoiGian = new List<Bill>();
            foreach (var hoaDon in dsHoaDon)
            {
                if (hoaDon.m_NgayTao.Date >= ngayBatDau && hoaDon.m_NgayTao.Date <= ngayKetThuc)
                {
                    dsHoaDonTrongThoiGian.Add(hoaDon);
                }
            }
            //Kiểm tra có hóa đơn không
            if (dsHoaDonTrongThoiGian.Count == 0)
            {
                MessageBox.Show("Không có hóa đơn trong khoảng thời gian này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //Tính doanh thu theo ngày
            Dictionary<DateTime, double> doanhThuTheoNgay = new Dictionary<DateTime, double>();
            foreach (var hoaDon in dsHoaDonTrongThoiGian)
            {
                DateTime ngay = hoaDon.m_NgayTao.Date;
                if (!doanhThuTheoNgay.ContainsKey(ngay))
                {
                    doanhThuTheoNgay[ngay] = 0;
                }
                doanhThuTheoNgay[ngay] += hoaDon.TongTien;
            }
            //Chuyển dictionary sang List
            List<KeyValuePair<DateTime, double>> doanhThuTheoNgaySapXep = doanhThuTheoNgay.ToList();
            doanhThuTheoNgaySapXep.Sort((x, y) => x.Key.CompareTo(y.Key));
            // Cấu hình Biểu Đồ
            chart_DoanhThu.Series.Clear();
            chart_DoanhThu.ChartAreas.Clear();
            chart_DoanhThu.ChartAreas.Add(new ChartArea("DoanhThu"));
            //Thêm một series mới để vẽ biểu đồ doanh thu
            var series = new Series("Doanh Thu")
            {
                ChartType = SeriesChartType.Column,
                XValueType = ChartValueType.DateTime,
                YValueType = ChartValueType.Double
            };
            //Thêm dữ liệu vào series
            foreach (var item in doanhThuTheoNgaySapXep)
            {
                series.Points.AddXY(item.Key, item.Value);
            }
            // Thêm series vào chart
            chart_DoanhThu.Series.Add(series);
            chart_DoanhThu.Titles.Clear();//Cập nhật title
            chart_DoanhThu.Titles.Add("Biểu đồ Doanh Thu từ " + ngayBatDau.ToString("dd/MM/yyyy") + " đến " + ngayKetThuc.ToString("dd/MM/yyyy"));
            // Tùy chỉnh trục X để hiển thị ngày tháng dễ nhìn hơn
            chart_DoanhThu.ChartAreas["DoanhThu"].AxisX.LabelStyle.Format = "dd/MM/yyyy";//Kiểu
            chart_DoanhThu.ChartAreas["DoanhThu"].AxisX.IntervalType = DateTimeIntervalType.Days;//Đơn vị
            chart_DoanhThu.ChartAreas["DoanhThu"].AxisX.Interval = 1; //Khoảng cách các mốc tgian
        }
    }
}

