using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
[Serializable]

    public class tk_mk
    {
        private string m_taikhoan;
        private string m_matkhau;
        //private string m_fullname;

        //public string FullName
        //{
        //get { return m_fullname; }
        //set { m_fullname = value; }
        //}

        public string TaiKhoan
        {
            get { return m_taikhoan; }
            set { m_taikhoan = value; }
        }
        public string MatKhau
        {
            get { return m_matkhau; }
            set { m_matkhau = value; }
        }
        
        public tk_mk()
        {
            m_taikhoan = string.Empty;
            m_matkhau = string.Empty;
          //  m_fullname = string.Empty;
        }

        public tk_mk(string tk, string mk)
        {
            m_taikhoan = tk;
            m_matkhau = mk;
         //   m_fullname = fn;
        }
    }

