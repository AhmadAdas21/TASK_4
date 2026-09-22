using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TASK_4
{
    public class product
    {
        public int id { get; set; }
        public string name { get; set; }
        public float price { get; set; }
        public int quantity { get; set; }


        public product(int id,string name,float price,int quantity)
        {
            this.id = id;
            this.name = name;
            if (price > 0)
            {
                this.price = price;
            }
            else
            {
                throw new ArgumentException("Price must be greater than 0");
            }
            if (quantity >= 0)
            {
                this.quantity = quantity;
            }
            else
            {
                throw new ArgumentException("quantiy must be 0 or greater");
            }
        }
    }
}
