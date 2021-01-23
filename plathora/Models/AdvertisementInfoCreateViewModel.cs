﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace plathora.Models
{
    public class AdvertisementInfoCreateViewModel
    {
        public int id { get; set; }
        [Display(Name = "City")]
        public string cityIds { get; set; }
        [Display(Name = "Sector")]
        public int? sectorId { get; set; } = null;

        [Display(Name = "Select Package")]
        public int? advertiseid { get; set; } = null;
        [Display(Name = "Select Company")]
        public int businessid { get; set; }



        [Display(Name = "Register by Unique ID")]
        public string AfilateuniqueId { get; set; }

      
      

        [Display(Name = "Start Date")]
        public DateTime startdate { get; set; }
        [Display(Name = "Title")]
        public string title { get; set; }
        [Display(Name = "Website Link")]
        public string videourl { get; set; }
        [Display(Name = "Short Description")]
        public string shortdesc { get; set; }
        [Display(Name = "Long Description")]
        public string longdesc { get; set; }
        [Display(Name = "Photo")]
        public IFormFile image1 { get; set; }
        //public string image2 { get; set; }

   

       

        //paymnet details
        public DateTime Registrationdate { get; set; } = DateTime.UtcNow;
        public DateTime Expirydate { get; set; }
        public string PaymentStatus { get; set; }
        
        public decimal PaymentAmount { get; set; }
        public string TransactionId { get; set; }

      
    }
}