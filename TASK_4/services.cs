using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TASK_4
{
    public class services:Iservices
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
                if(float.TryParse(Console.ReadLine(), out price)&&price>0)
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
                if(int.TryParse(Console.ReadLine(), out quantity)&&quantity>0)
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
            if (!customers.Any(c => c.id == customer_id))
            {
                Console.WriteLine("customer not found");
                return;
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
            DateTime noww = DateTime.Now;
            order o = new order( idd,customer_id,status,new List<order_item>(),noww);

            orders.Add(o);

            Console.WriteLine("order created successfully");

        }
     public  void add_product_to_order()
        {
            Console.WriteLine("you are in add product to order feature");
            Console.WriteLine("enter the order id");
            int order_id;
            while (true)
            {
                if(int.TryParse(Console.ReadLine(), out order_id))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("invalid input, please enter a valid order id");
                }
            }
            int product_id;
            Console.WriteLine("enter the product id");
            while (true)
            {
                if(int.TryParse(Console.ReadLine(), out product_id))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("invalid input, please enter a valid product id");
                }
            }
            order selected = orders.FirstOrDefault(o => o.id == order_id);

            if (selected == null)
            {
                Console.WriteLine("order not found");
                return;
            }
            product added = products.FirstOrDefault(o => o.id == product_id);

            if (added == null)
            {
                Console.WriteLine("product not found");
                return;
            }
            int quant;
            Console.WriteLine("enter the quantity of product you want");
            while (true)
            {
                if(int.TryParse(Console.ReadLine(), out quant) && quant > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("invalid input, please enter a valid quantity");
                }
            }
            if (quant > added.quantity)
            {
                Console.WriteLine("not enough stock");
                return;
            }

            order_item item = new order_item(added.name, quant, added.price);
            selected.order_items.Add(item);
            added.quantity -= quant;

        }
        public void view_orders()
        {
            Console.WriteLine("here i will provide you with orders list");
            foreach(var o in orders)
            {
                Console.WriteLine(o.id + " " + o.customer_id + " " + o.status + " " + o.created_date);
            }
        }
      public  void search_orders()
        {
            Console.WriteLine("you are in search orders feature");
            Console.WriteLine("enter the order id");
            int idd;
            while (true)
            {
                
                if (int.TryParse(Console.ReadLine(),out idd ))
                {
                    Console.WriteLine("valid input");
                    break;
                }
                else
                {
                    Console.WriteLine("invalid input, please enter a valid order id");
                }
            }
            orders.Where(x=>x.id==idd).ToList().ForEach(x => Console.WriteLine(x.id + " " + x.customer_id + " " + x.status + " " + x.created_date));
            Console.WriteLine("thanks for using this feature");
        }
        public void filter_orders_by_status()
        {
            Console.WriteLine("you are in filter orders by status feature");
            Console.WriteLine("enter 1 if you want to filter completed orders");
            Console.WriteLine("enter 0 if you want to filter pending orders");
            int ch;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out ch))
                {
                    if (ch == 1)
                    {
                        orders.Where(x => x.status == true).ToList().ForEach(x => Console.WriteLine(x.id + " " + x.customer_id + " " + x.status + " " + x.created_date));
                        break;
                    }
                    else if (ch == 0)
                    {
                        orders.Where(x => x.status == false).ToList().ForEach(x => Console.WriteLine(x.id + " " + x.customer_id + " " + x.status + " " + x.created_date));
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
            Console.WriteLine("thanks for using this feature");

        }
      public  void calculate_order_total()
        {
            Console.WriteLine("you are in total ordeer feature");
            Console.WriteLine("enter the id of the order");
            int idd;
            while (true)
            {
                if(int.TryParse(Console.ReadLine(),out idd))
                {
                    Console.WriteLine("you have entered a valid order id");
                    break;
                }
                else
                {
                    Console.WriteLine("invalid input, please enter a valid order id");
                }
            }
            if(!orders.Any(o => o.id == idd))
            {
                Console.WriteLine("order not found");
                return;
            }
            else
            {
                Console.WriteLine("the total cost of the order for this id");
                Console.WriteLine(idd);
                Console.WriteLine(orders.FirstOrDefault(o => o.id == idd).order_items.Sum(x => x.unit_price * x.quantity));
            }
        }
        public float get_order_total(order selected_order)
        {
            return selected_order.order_items.Sum(item => item.unit_price * item.quantity);
        }
        public bool can_complete_order(order order)
        {
            return (order != null &&order.order_items != null &&order.order_items.Count > 0);
        }
    }
}
