using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ung_Dung_Quan_Li_Nha_Hang
{
    [Serializable]
    public class Bill
    {

        public string m_id { get; set; }
        public DateTime m_NgayTao { get; set; }
        public List<ChiTietHoaDon> chitietHoaDon { get; set; }
        public Bill(string maHoaDon, DateTime ngayTao, List<ChiTietHoaDon> chitietHOADON)
        {
            m_id = maHoaDon;
            m_NgayTao = ngayTao;
            chitietHoaDon = chitietHoaDon;
        }

        public decimal TongTien
        {
            get
            {
                decimal tong = 0;
                foreach (ChiTietHoaDon chitiet in chitietHoaDon)
                {
                    tong += chitiet.thanhTien;
                }
                return tong;
            }
        }


    }

}

