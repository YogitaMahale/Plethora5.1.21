using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace plathora.Models.Dtos
{
    public class advertisementInfoDtos
    {
        //      id, cityIds, sectorId, advertiseid, startdate, title, videourl, shortdesc, longdesc, image1, image2, isdeleted, Expirydate
        //, PaymentAmount, PaymentStatus, Registrationdate, TransactionId, AfilateuniqueId, businessid

     
        public int businessid { get; set; }

        public int sectorId { get; set; }
        public string cityIds { get; set; }
        public int advertiseid { get; set; }
        public DateTime startdate { get; set; }
        public string title { get; set; }

        public string videourl { get; set; }
        public string shortdesc { get; set; }
        public string longdesc { get; set; }
        public string image1 { get; set; }   
        
        public string PaymentStatus { get; set; }
        
        public decimal PaymentAmount { get; set; }
        public string TransactionId { get; set; }

        public string uniqueId { get; set; }

        

        //public string customerId { get; set; }

        //public int advertiseid { get; set; }
        //public DateTime startdate { get; set; }
        //public string title { get; set; }
        //public string videourl { get; set; }
        //public string shortdesc { get; set; }
        //public string longdesc { get; set; }
        //public string image1 { get; set; }
        //public string image2 { get; set; }

        //public decimal PaymentAmount { get; set; }
        //public string PaymentStatus { get; set; }
        //public string TransactionId { get; set; }

        //public string uniqueId { get; set; }

    }
}
