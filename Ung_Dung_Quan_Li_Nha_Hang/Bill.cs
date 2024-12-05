using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ung_Dung_Quan_Li_Nha_Hang
{
    internal class Bill
    {

        private string m_id;
        private string m_ten;
        private DateTime m_ngay;
        private double m_tien;

        public string ID
        {
            get { return m_id; }
            set { m_id = value; }
        }
        public string Ten
        {
            get { return m_ten; }
            set { m_ten = value; }
        }
        public double Tien
        {
            get { return m_tien; }
            set
            {
                m_tien = value;
            }

        }
        public Bill() 
        {   m_id=string.Empty;
            m_ten = string.Empty;
            m_ngay=DateTime.Now;
            m_tien = 0;
        }
        public Bill(string id, string ten, DateTime ngay, double tien)
        {
            m_id = id;
            m_ten = ten;
            m_ngay = ngay;
            m_tien = tien;
        }
    }

}

