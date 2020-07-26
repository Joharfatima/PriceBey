﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

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