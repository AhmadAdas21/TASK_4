using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TASK_4
{
    internal class services:Iservices
    {
        List<customer> customers = new List<customer>();
        List<order> orders = new List<order>();
        List<product> products = new List<product>();
        List<order_item> order_items = new List<order_item>();

        public   void add_customer()
        {
            Console.WriteLine("enter customer id");
            int idd;
            while (true)
            {
                if(int.TryParse(Console.ReadLine(), out idd))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("invalid input, please enter a valid customer id");
                }
            }
            Console.WriteLine("enter customer name");
            string name=Console.ReadLine();
            Console.WriteLine("enter customer email");
            string email = Console.ReadLine();
            customer c = new customer(idd, name, email);

            Console.WriteLine("the customer has been added successfully");


        }
     public   void view_customers()
        {

        }

    public    void add_product()
        {

        }
    public  void view_products()
        {

        }

      public  void create_order()
        {

        }
     public  void add_product_to_order()
        {

        }
       public void view_orders()
        {

        }
      public  void search_orders()
        {

        }
     public  void filter_orders_by_status()
        {

        }
      public  void calculate_order_total()
        {

        }
    }
}
