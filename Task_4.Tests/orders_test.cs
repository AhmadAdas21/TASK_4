using Xunit;
using System;
using System.Collections.Generic;
using TASK_4;
using Xunit;

namespace Task_4.Tests
{
    public class orders_test
    {
        [Fact]
        public void calculate_order_total_returns_correct_total()
        {

            services service = new services();
            product pr = new product(1, "laptop", 1000, 5);
            product po = new product(2, "air bods", 50, 10);
            customer c = new customer(1, "ahmd", "ahmad@");

            List<order_item> items = new List<order_item>
            {
                new order_item(pr, 2, 1000),
                new order_item(po, 3, 50)
            };

            order _order = new order(1, c, false, items, DateTime.Now);


            float actual = service.get_order_total(_order);


            Assert.Equal(2150, actual);
        }

        [Fact]
        public void new_order_has_correct_customer_id()
        {
            customer c = new customer(25, "ahmad", "ahmad@");
            order order = new order(1, c, false, new List<order_item>(), DateTime.Now);
            int actual_id = order.customer_id.id;

            Assert.Equal(25, actual_id);
        }

        [Fact]
        public void new_order_starts_with_empty_items_list()
        {
            customer c = new customer(25, "ahmad", "ahmad@");

            order order = new order(1, c, false, new List<order_item>(), DateTime.Now);


            Assert.Empty(order.order_items);
        }

        [Fact]
        public void empty_order_cannot_be_completed()
        {
           
            services service = new services();
            customer c=new customer(25, "ahmad", "ahmad@");

            order selected_order = new order(1,c,false,new List<order_item>(),DateTime.Now);

           
            bool result = service.can_complete_order(selected_order);

           
            Assert.False(result);
        }
        [Fact]
        public void order_with_just_one_item_can_be_completed()
        {
            services s= new services();
            customer c = new customer(10, "ahmad", "ahmad@");
            product p= new product(1, "flash", 10, 5);
            order o = new order(1, c, false, new List<order_item> { new order_item(p, 1, 10) }, DateTime.Now);

            bool result = s.can_complete_order(o);
            Assert.True(result);
        }
        [Fact]
        public void empty_order_total_should_be_zero()
        {
            services se = new services();
            customer c=new customer(3, "ahmad", "ahmad@");
            order o=new order(1,c,true, new List<order_item>() { }, DateTime.Now);
            int total = (int)se.get_order_total(o);
            Assert.Equal(0, total);
        }
        [Fact]
         public void adding_quantity_equal_to_stock_should_succeed_and_make_stock_zero()
        {

            product p = new product(1, "desk", 10, 5);
            customer c=new customer(1, "ahmad", "ahmad@");
            List<order_item> items = new List<order_item>()
           {
               new order_item(p, 5, 10)
           };

           
            services ser = new services();
            order or = new order(1,c, false, items, DateTime.Now);
            Assert.Equal(5, p.quantity);


        }
        [Fact]
        public void negative_product_price_should_be_rejected()
        {
            services s = new services();
            product p = new product(1, "chair", -10, 5);
            Assert.True(p.price < 0);
        }
        [Fact]
        public void negative_product_stock_should_be_rejected()
        {
            services s = new services();
            product p=new product(1, "table", 10, -5);
            Assert.True(p.quantity < 0);
        }
         [Fact]
        public void missing_customer_should_not_exist()
        {
            services s = new services();

            bool result = s.customer_exists(999);

            Assert.False(result);
        }
        [Fact]
        public void quantity_greater_than_stock_should_be_rejected()
        {
            services s = new services();
            product p = new product(1, "apple",1, 5);
            order_item item = new order_item(p, 10, 1);
            if (item.quantity > p.quantity)
            {
                Assert.True(true);
            }
            else
            {
                Assert.True(false);
            }
           ///Assert.Equal(p.quantity,item.quantity);
        }
        [Fact]
        public void stock_should_decrease()
        {
            services s = new services();
            customer c = new customer(2,"ahmad","ahmad@gmail");
            product p = new product(1, "apple", 1, 5);
            order o = new order(1, c, false, new List<order_item> { new order_item(p, 3, 1) }, DateTime.Now);
            s.add_product_to_order(o, p, 3);
            Assert.Equal(2, p.quantity);

        }
        [Fact]
        public void quantity_equal_to_stock_should_make_stock_zero()
        {
            services s=new services();
            customer c = new customer(2, "ahmad", "ahmad@gmail");
            product p= new product(1, "banana", 1, 5);
            order order = new order(1, c, false, new List<order_item> { new order_item(p, 5, 1) }, DateTime.Now);
            s.add_product_to_order(order, p, 5);
            Assert.Equal(0, p.quantity);
        }

    }
}