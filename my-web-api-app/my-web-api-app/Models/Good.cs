using System;

namespace my_web_api_app.Models
{
    public class GoodVM
    {
        public string NameOfGood { get; set; }
        public double UnitPrice
        {
            get; set;
        }
    }
    public class Good : GoodVM
    {
        public Guid GoodCode { get; set; }
    }
}
