using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;

namespace OnlineArkansas.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            return View();
        }
        public ActionResult About()
        {
            //ViewBag.Message = "Your app description page.";
            return View();
        }
        public ActionResult Contact()
        {
            //ViewBag.Message = "Your contact page.";
            return View();
        }
        public ActionResult Training()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegistrationForm(Registration registration)
        {
            Registration ajaxComment = new Registration();
            ajaxComment.firstName = registration.firstName;
            ajaxComment.lastName = registration.lastName;
            ajaxComment.organization = registration.organization;
            ajaxComment.address1 = registration.address1;
            ajaxComment.address2 = registration.address2;
            ajaxComment.city = registration.city;
            ajaxComment.state = registration.state;
            ajaxComment.zipCode = registration.zipCode;
            ajaxComment.phone = registration.phone;
            ajaxComment.fax = registration.fax;
            ajaxComment.emailAddress = registration.emailAddress;

            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();

            var emailId = " ";
            var password = " ";

            using (var dbConnection = new OnlineArkansasContext())
            {
                var configurations = dbConnection.Configurations.Where(row => row.keyCode == "EMID");
                foreach (Configuration configuration in configurations)
                {
                    emailId = configuration.value1;
                    password = configuration.value2;
                }

                var confEmailAddrTo = dbConnection.Configurations.Where(row => row.keyCode == "EMTO");
                foreach (Configuration configuration in confEmailAddrTo)
                {
                    msg.To.Add(configuration.value1);
                    
                }
                var confEmailAddrCc = dbConnection.Configurations.Where(row => row.keyCode == "EMCC");
                foreach (Configuration configuration in confEmailAddrCc)
                {
                    msg.CC.Add(configuration.value1);

                }
                var confEmailAddrBcc = dbConnection.Configurations.Where(row => row.keyCode == "EMBC");
                foreach (Configuration configuration in confEmailAddrBcc)
                {
                    msg.Bcc.Add(configuration.value1);

                }

                // Create and save a new Registration                
                var registrationRecord = new Registration
                {
                    firstName = registration.firstName,
                    lastName = registration.lastName,
                    organization = registration.organization,
                    address1 = registration.address1,
                    address2 = registration.address2,
                    city = registration.city,
                    state = registration.state,
                    zipCode = registration.zipCode,
                    phone = registration.phone,
                    fax = registration.fax,
                    emailAddress = registration.emailAddress,
                    courseName = registration.courseName,
                    courseStartDate = registration.courseStartDate,
                    courseEndDate = registration.courseEndDate,
                    courseFee = registration.courseFee
                };

                dbConnection.Registrations.AddObject(registrationRecord);
                dbConnection.SaveChanges();
            }
            
            var msgText = "";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Timeout = 20000,
                Credentials = new System.Net.NetworkCredential(emailId, password)
            };

            

            msg.IsBodyHtml = true;
            msg.CC.Add(registration.emailAddress);

            msg.From = new System.Net.Mail.MailAddress(registration.emailAddress);

            msg.Subject = registration.courseName + " Form from: " + registration.firstName + " " + registration.lastName;

            msgText = "<table cellpadding='5px'>";
            msgText = msgText + "<tr><td width='30%'>Name:</td><td>" + registration.firstName + " " + registration.lastName + "</td></tr>";
            msgText = msgText + "<tr><td>Organization:</td><td>" + registration.organization + "</td></tr>";
            msgText = msgText + "<tr><td>Address 1:</td><td>" + registration.address1 + "</td></tr>";
            msgText = msgText + "<tr><td>Address 2:</td><td>" + registration.address2 + "</td></tr>";
            msgText = msgText + "<tr><td>City:</td><td>" + registration.city + "</td></tr>";
            msgText = msgText + "<tr><td>State:</td><td>" + registration.state + "</td></tr>";
            msgText = msgText + "<tr><td>Zip Code:</td><td>" + registration.zipCode + "</td></tr>";
            msgText = msgText + "<tr><td>Telephone:</td><td>" + registration.phone + "</td></tr>";
            msgText = msgText + "<tr><td>Fax:</td><td>" + registration.fax + "</td></tr>";
            msgText = msgText + "<tr><td>Email:</td><td>" + registration.emailAddress + "</td></tr>";
            msgText = msgText + "<tr><td colspan='2'>Invoice and location instructions will be mailed or faxed to you prior to the class.</td></tr>";  
            msgText = msgText + "</table>";
            msg.Body = msgText;
           
            smtp.Send(msg);                         

            return Json(ajaxComment);
        }
        public ActionResult Staff()
        {
            return View();
        }
        public ActionResult Maps()
        {
            return View();
        }
        public ActionResult Resources()
        {
            return View();
        }
        public ActionResult Location()
        {
            return View();
        }
        public ActionResult Assistance()
        {
            return View();
        }
        public ActionResult GpsInfo()
        {
            return View();
        }
    }
}
