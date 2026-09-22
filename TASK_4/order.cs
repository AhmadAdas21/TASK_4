using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TASK_4
{
    public class order
    {
        public int id { get; set; }
        public customer customer_id { get; set; }
        public bool status { get; set; }
        public List<order_item> order_items { get; set; }
        public DateTime created_date { get; set; }

        public order(int id,customer iddd,bool stauts, List<order_item> order_items, DateTime created_date)
        {
            this.id = id;
            this.customer_id = iddd;
            this.status = stauts;
            this.order_items = order_items;
            this.created_date = created_date;
        }
    }
}
