using System;
using System.Collections.Generic;
using System.Globalization;
using Orders.Entities;
using Orders.Entities.Enums;

namespace Orders
{
    class Program
    {
        static void Main(string[] args)
        {

            //client data
            Console.WriteLine("Enter client data:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth date (DD/MM/YYYY): ");
            DateTime birthdate = DateTime.Parse(Console.ReadLine());

            //instantiation Client
            Client client = new Client(name, email,birthdate);

            //order data
            Console.WriteLine("Enter order data:");
            Console.Write("Status: ");
            string sta = Console.ReadLine();
            OrderStatus status = (OrderStatus)Enum.Parse(typeof(OrderStatus), sta, true);

            //instantiation Order
            Order order = new Order(DateTime.Now, status, client);

            Console.Write("How many items to this order? ");
            int x = int.Parse(Console.ReadLine());

            for (int i = 1; i <= x; i++)
            {
                Console.WriteLine($"Enter #{i} item data:");
                Console.Write("Product name: ");
                string productName = Console.ReadLine();
                Console.Write("Product price: ");
                double productPrice = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                //instantiation Product
                Product product = new Product(productName, productPrice);

                Console.Write("Quantity: ");
                int productQuantity = int.Parse(Console.ReadLine());

                //instantiation OrderItem
                OrderItem orderItem = new OrderItem(productQuantity, productPrice,product);

                //adding the product
                order.AddItem(orderItem);
            }

            Console.WriteLine();
            Console.WriteLine("ORDER SUMMARY:");
            Console.WriteLine(order);

            Console.ReadLine();
        }
    }
}
