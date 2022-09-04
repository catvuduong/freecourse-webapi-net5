using System;

namespace my_web_api_app.Data
{
    public class OrderDetail
    {
        public Guid GoodCode { get; set; }
        public Guid OrderCode { get; set; }
        public int Quatity { get; set; }
        public double UnitPrice { get; set; }
        public byte Discount { get; set; }
        //relationship
        public Order Order { get; set; }
        public Good Good { get; set; }
    }
}
