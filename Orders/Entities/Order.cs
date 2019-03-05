using System;
using System.Collections.Generic;
using Orders.Entities.Enums;
using System.Text;
using System.Globalization;


namespace Orders.Entities
{
    class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderItem> Item { get; set; } = new List<OrderItem>();
        public Client Client { get; set; }

        public Order()
        {

        }

        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
            Client = client;
        }

        public void AddItem (OrderItem item)
        {
            Item.Add(item);
        }

        public void RemoveItem (OrderItem item)
        {
            Item.Remove(item);
        }

        public double Total()
        {
            double sum = 0.0;
            foreach(OrderItem item in Item)
            {
                sum += item.SubTotal();
            }
            return sum;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Order moment: " + Moment.ToString("dd/MM/yyyy HH:mm:ss"));
            sb.AppendLine("Order status: " + Status);
            sb.AppendLine("Client: " + Client);
            sb.AppendLine("Order items: ");

            foreach(OrderItem item in Item)
            {
                sb.AppendLine(item.ToString());
            }

            sb.AppendLine("Total price: $" + Total().ToString("F2", CultureInfo.InstalledUICulture));

            return sb.ToString();
        }
    }
}
