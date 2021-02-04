using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace plathora.Models
{
    public class NewBusinessCreateViewModel
    {
        public int id { get; set; } = 0;
         
        [DisplayName("Register by Affilate ID")]        
        public string UniqueId { get; set; }
        public string customerid { get; set; }

       
        
         
        [DisplayName("Description")]
        public string description { get; set; }
        
        [DisplayName("Regcertificate")]
        public string Regcertificate { get; set; }

         
        [DisplayName("Business")]
        public string businessid { get; set; }
        public string multipleBusinessid { get; set; }
        // public string productid { get; set; }
        [DisplayName("Product")]
        public string productid { get; set; }
        public string multipleProductid { get; set; }
        public string lic { get; set; }

         
        [DisplayName("")]
        public string MondayOpen { get; set; }
        [DisplayName("")]
        public string MondayClose { get; set; }
        [DisplayName("")]

        public string TuesdayOpen { get; set; }
        [DisplayName("")]
        public string TuesdayClose { get; set; }

        [DisplayName("")]
        public string WednesdayOpen { get; set; }
        [DisplayName("")]
        public string WednesdayClose { get; set; }
        [DisplayName("")]

        public string ThursdayOpen { get; set; }
        [DisplayName("")]
        public string ThursdayClose { get; set; }
        [DisplayName("")]
        public string FridayOpen { get; set; }
        [DisplayName("")]
        public string FridayClose { get; set; }
        [DisplayName("")]
        public string SaturdayOpen { get; set; }
        [DisplayName("")]
        public string SaturdayClose { get; set; }
        [DisplayName("")]
        public string SundayOpen { get; set; }
        [DisplayName("")]
        public string SundayClose { get; set; }
        [DisplayName("")]

        public int CallCount { get; set; } = 0;
        public int SMSCount { get; set; } = 0;
        public int WhatssappCount { get; set; } = 0;
        public int ShareCount { get; set; } = 0;

        [DisplayName("Image 1")]
        public IFormFile sliderimg1 { get; set; }
        [DisplayName("Image 2")]
        public IFormFile sliderimg2 { get; set; }
        [DisplayName("Image 3")]
        public IFormFile sliderimg3 { get; set; }
        [DisplayName("Image 4")]
        public IFormFile sliderimg4 { get; set; }
        [DisplayName("Image 5")]
        public IFormFile sliderimg5 { get; set; }

        [DisplayName("Facebook URL")]
        public string facebookLink { get; set; }
        [DisplayName("Twitter URL")]
        public string twitterLink { get; set; }
        [DisplayName("Youtube URL")]
        public string youtubeLink { get; set; }
        [DisplayName("Linkedin URL 5")]
        public string linkedinLink { get; set; }
        [DisplayName("Googleplus URL")]
        public string googleplusLink { get; set; }
        [DisplayName("Instagram URL")]
        public string instagramLink { get; set; }





        //paymnet details

        public string PaymentStatus { get; set; }

        public decimal PaymentAmount { get; set; }
        public string TransactionId { get; set; }
        [Required]
        [DisplayName("Package")]
        //public int? MembershipId { get; set; } = null;
        public int? BusinessPackageId { get; set; } = null;

        [DisplayName("House")]
        public string house { get; set; }
        [DisplayName("Landmark")]
        public string landmark { get; set; }
        [DisplayName("Street")]
        public string street { get; set; }


         


        [Required]
        [Display(Name = "Select Country")]
        public int countryid { get; set; }

        [Required]
        [Display(Name = "Select State")]
        public int stateid { get; set; }


        [Required]
        [Display(Name = "Select City")]
        public int cityid { get; set; }

        [DisplayName("Zipcode")]
        public string zipcode { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }

        //--------company info---
        [Required]
        [DisplayName("Company Name")]
        public string companyName { get; set; }
        [DisplayName("GST No")]
        public string gstno { get; set; }
        [DisplayName("Website")]
        public string Website { get; set; }

        [Required]
        [DisplayName("Type of Business")]
        public string businessOperation { get; set; }
        [Required]
        [DisplayName("Type of Company")]
        public string businessType { get; set; }
        public string organization { get; set; }





       
       
        

    }
}
