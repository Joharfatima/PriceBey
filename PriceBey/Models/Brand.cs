using System.ComponentModel.DataAnnotations;

namespace PriceBey.Models
{
    public class Brand
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }

    }
}