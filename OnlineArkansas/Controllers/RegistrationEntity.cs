using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineArkansas.Controllers
{
    
    public class RegistrationEntity
    {
        
        public List<String> courseNames { get; set; }
        public string firstName { get; set; }
        public string lastName   { get; set; }
        public string organization  { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; } 
        public string city { get; set; }
        public string state { get; set; }
        public string zipCode  { get; set; }
        public string phone { get; set; }
        public string fax { get; set; }
        public string emailAddress{ get; set; }
        public List<DateTime> courseStartDates { get; set; }
        public List<DateTime> courseEndDates { get; set; }
        public List<decimal> courseFee { get; set; }
    }
        
}
