using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TASK_4
{
    internal class Program
    {
        /*    customer customer = new customer();
            product product = new product();
            order order = new order();
        */
     
        static void Main(string[] args)
        {
            int d;
            services services = new services();
            bool ok = true;
            while (ok)
            {
                Console.WriteLine("*******************");
                Console.WriteLine("welcome to the order management system");
                Console.WriteLine("select one of the features below");
                Console.WriteLine("1 add customers");
                Console.WriteLine("2 view all customers");
                Console.WriteLine("3 add product");
                Console.WriteLine("4 view producrs");
                Console.WriteLine("5 create order");

                Console.WriteLine("6 add product to order");
                Console.WriteLine("7 view order");
                Console.WriteLine("8 search orders");
                Console.WriteLine("9 filter orders by status");
                Console.WriteLine("10 calculate order total");
                Console.WriteLine("11 exit");
                if (int.TryParse(Console.ReadLine(), out d))
                {
                    Console.WriteLine("valid value");
                }
                else
                {
                    Console.WriteLine("enter valid value between 1 and 11");
                }
                switch (d)
                {
                    case 1:
                        services.add_customer();
                        break;
                    case 2:
                        services.view_customers();
                        break;
                    case 3:
                        services.add_product();
                        break;
                    case 4:
                        services.view_products();
                        break;
                    case 5:
                        services.create_order();
                        break;
                    case 6:
                        services.add_product_to_order();
                        break;
                    case 7:
                        services.view_orders();
                        break;
                    case 8:
                        services.search_orders();
                        break;
                    case 9:
                        services.filter_orders_by_status();
                        break;
                    case 10:
                        services.calculate_order_total();
                        break;
                    case 11:
                        ok = false;
                        Console.WriteLine("exiting the program");
                        break;
                }



            }

        }
    }
}
