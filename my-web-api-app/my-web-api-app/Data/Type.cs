using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace my_web_api_app.Data
{
    [Table("Type")]
    public class Type
    {
        [Key]
        public int TypeCode { get; set; }
        [Required]
        [MaxLength(50)]
        public string TypeName { get; set; }

        public virtual ICollection<Good> Goods { get; set; }
    }
}
