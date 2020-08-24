using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PriceBey.Models
{
    public class PriceClickHistory
    {
        [Key]
        public int ID { get; set; }

        public int ProductPriceId { get; set; }

        [ForeignKey("ProductPriceId")]
        public ProductPrice ProductPrice { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; }
    }
}
