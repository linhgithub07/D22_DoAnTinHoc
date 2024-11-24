using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ung_Dung_Quan_Li_Nha_Hang
{
    internal class food
    {
        private string f_list;
        private string f_id;
        private string f_name;
        private string f_price;

        //public food()
        //{
        //    f_list = null;
        //    f_id = null;
        //    f_name = null;
        //    f_price = null;
        //}
        public food(string f_list, string f_id, string f_name, string f_price)
        {
            this.F_list = f_list;
            this.F_id = f_id;
            this.F_name = f_name;
            this.F_price = f_price;
        } 
        public string F_list{ get { return f_list; } set { f_list = value; } }
        public string F_id { get { return f_id; } set { f_id = value; } }
        public string F_name { get { return f_name; } set { f_name = value; } }
        public string F_price { get { return f_price; } set { f_price = value; } }
    }
}
