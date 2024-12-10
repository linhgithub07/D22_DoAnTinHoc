using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
[Serializable]
    public class food
    {
        private string list;
        private string id;
        private string name;
        private string price;

        public string F_list { get; set; }
        public string F_id { get; set; }
        public string F_name { get; set; }
        public string F_price { get; set; }
        public food(string list, string id, string name, string price)
        {
            F_list = list;
            F_id = id;
            F_name = name;
            F_price = price;
        }
    }


