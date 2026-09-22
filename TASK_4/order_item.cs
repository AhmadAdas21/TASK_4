using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TASK_4
{
    internal class order_item
    {
        public string product { get; set; }

        public int quantity { get; set; }
        public float unit_price { get; set; }
        public order_item(string product, int quantity, float unit_price)
        {
            this.product = product;
            this.quantity = quantity;
            this.unit_price = unit_price;
        }
    }
}
