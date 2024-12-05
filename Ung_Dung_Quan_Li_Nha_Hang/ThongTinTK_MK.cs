using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ung_Dung_Quan_Li_Nha_Hang
{
    internal class ThongTinTK_MK
    {
        protected string m_taikhoan;
        protected string m_matkhau;
        protected string m_fullname;
        protected string m_status;
        public ThongTinTK_MK()
        {
            this.m_taikhoan = null;
            this.m_matkhau = null;
            this.m_fullname = null;
            this.m_status = null;
        }
        public ThongTinTK_MK(string tk, string mk, string fn, string tt)
        {
            this.m_taikhoan = tk;
            this.m_matkhau = mk;
            this.m_fullname = fn;
            this.m_status = tt;
        }
        public string TaiKhoan { get { return this.m_taikhoan; } set { this.m_taikhoan = value; } }
        public string MatKhau { get { return this.m_matkhau; } set { this.m_matkhau = value; } }
        public string FullName { get { return this.m_fullname; } set { this.m_fullname = value; } }
        public string Status { get { return this.m_status; } set { this.m_status = value; } }
    }

}
