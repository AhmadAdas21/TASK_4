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

            List<order_item> items = new List<order_item>
            {
                new order_item("Laptop", 2, 1000),
                new order_item("Mouse", 3, 50)
            };

            order selected_order = new order(1,10,false,items,DateTime.Now);

            
            float result = service.get_order_total(selected_order);

            
            Assert.Equal(2150, result);
        }

        [Fact]
        public void new_order_has_correct_customer_id()
        {
            
            order selected_order = new order(1,25,false,new List<order_item>(), DateTime.Now );

            
            Assert.Equal(25, selected_order.customer_id);
        }

        [Fact]
        public void new_order_starts_with_empty_items_list()
        {
           
            order selected_order = new order(1, 25,false,new List<order_item>(),DateTime.Now);

            
            Assert.Empty(selected_order.order_items);
        }
    }
}