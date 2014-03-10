using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineArkansas.Controllers
{
    [Table("Registration")]
    public class Comment
    {
        [Key]
        public Int64 registrationId { get; set; }
        public string courseName { get; set; }
        public string firstName { get; set; }
        public string lastName   { get; set; }
        public string organization  { get; set; }
        public string address { get; set; }
        public string address2 { get; set; } 
        public string city { get; set; }
        public string state { get; set; }
        public string zipCode  { get; set; }
        public string telephone { get; set; }
        public string fax { get; set; }
        public string email{ get; set; }
        public DateTime courseStartDate { get; set; }
        public DateTime courseEndDate { get; set; }
        public double courseFee { get; set; }
    }

    public class RegistrationContext : DbContext
    {
        public DbSet<Comment> Comment { get; set; }
    }          
}
