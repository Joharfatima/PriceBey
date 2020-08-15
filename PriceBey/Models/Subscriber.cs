using System.ComponentModel.DataAnnotations;

namespace PriceBey.Models
{
    public class Subscriber
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public bool isActive { get; set; }
    }
}