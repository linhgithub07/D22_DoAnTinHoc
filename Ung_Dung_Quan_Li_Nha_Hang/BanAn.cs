using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ung_Dung_Quan_Li_Nha_Hang
{
    [Serializable]
    public class BanAn
    {
        private string m_id_ban;
        private string m_tenban;
        private string m_trangthai;
        public string ID
        {
            get { return m_id_ban; }
            set { m_id_ban = value;}
        }
        public string Tenban 
        {
            get {  return m_tenban; }
            set {  m_tenban = value;}
        }
        public string TrangThai
        {
            get { return m_trangthai; }
            set { m_trangthai = value;}
        }
        public BanAn() 
        {
            m_id_ban=string.Empty;
            m_tenban=string.Empty;
            m_trangthai = "Trống";
        }
        public BanAn(string id_ban, string tenban, string trangthai)
        {
            m_id_ban = id_ban;
            Tenban = tenban;
            m_trangthai = trangthai;
        }
    }
}
