using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace my_web_api_app.Data
{
    [Table("Good")]
    public class Good
    {
        [Key]
        public Guid GoodCode { get; set; }
        [Required]
        [MaxLength(100)]
        public string GoodName { get; set; }
        public string Description { get; set; }
        [Range(0, double.MaxValue)]
        public double UnitPrice { get; set; }
        public byte Discount { get; set; }
        public int? TypeCode { get; set; }
        [ForeignKey("TypeCode")]
        public Type Type { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public Good()
        {
            OrderDetails = new List<OrderDetail>();
        }
    }
}
