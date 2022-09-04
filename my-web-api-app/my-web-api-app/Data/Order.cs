using System;
using System.Collections.Generic;

namespace my_web_api_app.Data
{
    public enum OrderStatus
    {
        New = 0, Mayment = 1, Complete = 1, COmplete = 2, Cancel = -1
    }
    public class Order

    {
        public Guid OrderCode { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DateTime { get; set; }
        public int OrderStatus { get; set; }
        public string Receiver { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }
    }
}
