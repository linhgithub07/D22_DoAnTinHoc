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
        private string m_tenBan;
        //private string m_tongtien;
        public string ID_Ban
        { get { return m_id_ban; } set { m_id_ban = value; } }
        public string TenBan
        { get { return m_tenBan; } set { m_tenBan = value;} }
        //public string TongTien
        //{  get { return m_tongtien;}}
    }
}
