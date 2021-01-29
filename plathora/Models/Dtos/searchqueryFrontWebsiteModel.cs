using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace plathora.Models.Dtos
{
    public class searchqueryFrontWebsiteModel
    {

         
        public int id { get; set; }
        public string sectorname { get; set; }
        public string businessname { get; set; }
        public string productname { get; set; }
        public string businessid { get; set; }
        public string productid { get; set; }
        public string lic { get; set; }
        public string customerid { get; set; }
        public string cityid { get; set; }
        public string companyName { get; set; }
        public string ownername { get; set; }
        public string owneremail { get; set; }
        public string ownerPhoneNumber { get; set; }
        public string sliderimg1 { get; set; }
        public string rating { get; set; }
        public string review { get; set; }
        public string landmark { get; set; }
        public string businesstime { get; set; }
        public int TotalRecords { get; set; }

    }
}
