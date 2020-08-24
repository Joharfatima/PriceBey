using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PriceBey.Models
{
    public class ProductBooking
    {
        [Key]
        public int ID { get; set; }
        public string UserID { get; set; }
        public int ProductPriceId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; }
        public string Comments { get; set; }
        public DateTime CreatedDate { get; set; }

        [ForeignKey("ProductPriceId")]
        public ProductPrice ProductPrice { get; set; }

        [ForeignKey("UserID")]
        public ApplicationUser User { get; set; }
    }
}