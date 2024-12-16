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
            chitietHoaDon = chitietHOADON ?? new List<ChiTietHoaDon>();
        }

        public double TongTien
        {
            get
            {
                return chitietHoaDon.Sum(ct => ct.thanhTien);
            }
        }
    }

}

