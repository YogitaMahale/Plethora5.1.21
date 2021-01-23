using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace plathora.Entity
{
  public class advertisementInfo
    {
      
        public int id { get; set; }
        [ForeignKey("BusinessOwnerRegi")]
        public int businessid { get; set; }
        public BusinessOwnerRegi BusinessOwnerRegi { get; set; }


        //[ForeignKey("ApplicationUser")]
        //public string  customerId { get; set; }
        //public ApplicationUser ApplicationUser { get; set; }


        [ForeignKey("Advertise")]
        public int? advertiseid { get; set; } = null;
        public Advertise Advertise { get; set; }

        [ForeignKey("SectorRegistration")]
        public int? sectorId { get; set; } = null;
        public SectorRegistration SectorRegistration { get; set; }


        public DateTime startdate { get; set; }
        public string title { get; set; }
       
        public string videourl { get; set; }
        public string shortdesc { get; set; }
        public string longdesc { get; set; }
        public string image1 { get; set; }
        public string image2 { get; set; }
        
      
        public string cityIds { get; set; }

        [DefaultValue("false")]
        public Boolean isdeleted { get; set; }

        //paymnet details
        public DateTime Registrationdate { get; set; } = DateTime.UtcNow;
        public DateTime Expirydate { get; set; }
        public string PaymentStatus { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal PaymentAmount { get; set; }
        public string TransactionId { get; set; }

        public string AfilateuniqueId { get; set; }
    }
}
