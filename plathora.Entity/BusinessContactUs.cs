using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace plathora.Entity
{
  public  class BusinessContactUs
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public string Email { get; set; }
        public string Mobileno { get; set; }
        public string Message { get; set; }
        [ForeignKey("BusinessOwnerRegi")]
        public int businessid { get; set; }
        public BusinessOwnerRegi BusinessOwnerRegi { get; set; }

        public DateTime createddate { get; set; } = DateTime.Now;
    }
}
