using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ung_Dung_Quan_Li_Nha_Hang
{
    [Serializable]
    public class ChiTietHoaDon
    {
        public food monAn { get; set; }
        public int soLuong { get; set; }
        public ChiTietHoaDon(food MonAn, int SoLuong)
        {
            monAn = MonAn;
            soLuong = SoLuong;
        }

        public decimal thanhTien
        {
            get { return soLuong*(decimal.Parse(monAn.F_price)); }
        }


    }
}
