using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TASK_4
{
   public interface Iservices
    {
      void add_customer();
        void view_customers();

        void add_product();
        void view_products();

        void create_order();
        void add_product_to_order();
        void view_orders();
        void search_orders();
        void filter_orders_by_status();
        void calculate_order_total();
    }
}
