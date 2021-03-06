﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace plathora.Models
{
    public class taxEditViewmodel
    {
        public int id { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string name { get; set; }
        [Required]
        [RegularExpression(@"((\d+)((\.\d{1,2})?))$"), Display(Name = "Amount")]
        public decimal percentage { get; set; }


    }
}
