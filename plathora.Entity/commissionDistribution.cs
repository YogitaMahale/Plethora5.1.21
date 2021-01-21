using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace plathora.Entity
{
  public class commissionDistribution
    {
        public int id { get; set; }
        public string commissiontype { get; set; }
        public string registrationtype { get; set; }
        [ForeignKey("ApplicationUser1")]
        public string  affilateId { get; set; }
        public ApplicationUser ApplicationUser1 { get; set; }

        [ForeignKey("ApplicationUser2")]
        public string fromAffilateId { get; set; }
        public ApplicationUser ApplicationUser2 { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 3)")]
        public decimal commissionamount { get; set; }       

        public DateTime createddate { get; set; } = DateTime.Now; 

        [DefaultValue("false")]
        public Boolean isdeleted { get; set; }
       
    }
}
