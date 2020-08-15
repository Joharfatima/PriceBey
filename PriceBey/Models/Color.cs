using System.ComponentModel.DataAnnotations;

namespace PriceBey.Models
{
    public class Color
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}