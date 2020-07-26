﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PriceBey.Models
{
    public class Brand
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }

    }
}