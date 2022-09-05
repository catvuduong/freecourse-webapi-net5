using System.ComponentModel.DataAnnotations;

namespace my_web_api_app.Models
{
    public class TypeVM
    {
        public int TypeCode { get; set; }
        [Required]
        [MaxLength(50)]
        public string TypeName { get; set; }
    }
}
