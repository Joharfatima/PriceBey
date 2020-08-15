using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PriceBey.Models
{
    public class ProductPrice
    {
        [Key]
        public int ID { get; set; }
        public decimal Price { get; set; }
        public string Url { get; set; }
        public int ProductId { get; set; }
        public bool IsActive { get; set; }
        public int StoreId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        [ForeignKey("StoreId")]
        public Store Store { get; set; }

    }
}