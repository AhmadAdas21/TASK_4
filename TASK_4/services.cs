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
            customers.Add(c);


        }
     public   void view_customers()
        {
            Console.WriteLine("i will provide you with customers list");
            foreach(var i in customers)
            {
                Console.WriteLine(i.id + " " + i.name + " " + i.email);
            }
            Console.WriteLine("the list is done");


        }

    public    void add_product()
        {
            int idd;
            Console.WriteLine("you are in add product feature");
            Console.WriteLine("enter the product id");
            while (true)
            {
                if(int.TryParse(Console.ReadLine(), out idd))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("invalid input, please enter a valid product id");
                }

            }
            string name;
            Console.WriteLine("enter the product name");
            name =Console.ReadLine();
            Console.WriteLine("enter the product price");
            float price;
            while (true)
            {
                if(float.TryParse(Console.ReadLine(), out price))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("invalid input, please enter a valid product price");
                }
            }
            Console.WriteLine("enter the product quantinty in the stock");
            int quantity;
            while (true)
            {
                if(int.TryParse(Console.ReadLine(), out quantity))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("invalid input, please enter a valid product quantity");
                }
            }
            product p=new product(idd,name,price,quantity);
            products.Add(p);

        }
    public  void view_products()
        {
            Console.WriteLine("here i will provide you with products list");
            foreach(var p in products)
            {
                Console.WriteLine(p.id+"       "+p.name+"        "+p.price+"   "+p.quantity);
            }
            Console.WriteLine("i have already provided you with the products list, thank you for using this feature");

        }

      public  void create_order()
        {
            Console.WriteLine("you are in create order feature");
            int idd;
            while (true)
            {
                Console.WriteLine("enter the order id");
                if (int.TryParse(Console.ReadLine(), out idd))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("invalid input, please enter a valid order id");
                }
            }

            int customer_id;
            while ((true))
            {
                Console.WriteLine("enter the customer id");
                if (int.TryParse(Console.ReadLine(), out customer_id))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("invalid input, please enter a valid customer id");
                }
            }
            bool status;
            int st;
            Console.WriteLine("enter the status of order");
            Console.WriteLine("enter 1 if the status is completed");
            Console.WriteLine("enter 0 if the status is still pending");
            while (true)
            {
                if(int.TryParse(Console.ReadLine(), out st))
                {
                    if (st == 1)
                    {
                        status = true;
                        break;
                    }
                    else if (st == 0)
                    {
                        status = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("invalid input, please enter 1 or 0");
                    }
                }
                else
                {
                    Console.WriteLine("invalid input, please enter a valid status");
                }
            }


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
