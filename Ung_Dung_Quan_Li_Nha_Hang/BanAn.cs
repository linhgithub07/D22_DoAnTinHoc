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
        public string ID{ get; set; }
        public string TenBan{ get; set; }
        public string TrangThai{ get; set; }
        public BanAn()
        {
            m_id_ban = string.Empty;
            m_tenban = string.Empty;
            m_trangthai = "trong";
        }
        public BanAn(string id_ban, string tenban, string trangthai)
        {
            m_id_ban = id_ban;
            TenBan = tenban;
            m_trangthai = trangthai;
        }
    }
}
