using System.ComponentModel.DataAnnotations;

namespace PriceBey.Models
{
    public class Store
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Logo { get; set; }
    }
}