using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

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