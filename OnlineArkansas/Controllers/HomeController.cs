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
        public ActionResult RegistrationForm(Registration comment)
        {
            Registration ajaxComment = new Registration();
            ajaxComment.firstName = comment.firstName;
            ajaxComment.lastName = comment.lastName;
            ajaxComment.organization = comment.organization;
            ajaxComment.address1 = comment.address1;
            ajaxComment.address2 = comment.address2;
            ajaxComment.city = comment.city;
            ajaxComment.state = comment.state;
            ajaxComment.zipCode = comment.zipCode;
            ajaxComment.phone = comment.phone;
            ajaxComment.fax = comment.fax;
            ajaxComment.emailAddress = comment.emailAddress;

            //mRep.Add(ajaxComment);
            //uow.Save();
            
            var msgText = "";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Timeout = 20000,
                Credentials = new System.Net.NetworkCredential("aecamrg@gmail.com", "123aecamrg")
            };

            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();

            msg.IsBodyHtml = true;
            //msg.To.Add("ilfarmahan@ualr.edu");
            msg.To.Add("jojoseph@ualr.edu");
            msg.Bcc.Add("mxlnu1@ualr.edu");
            msg.CC.Add(comment.emailAddress);

            msg.From = new System.Net.Mail.MailAddress(comment.emailAddress);

            msg.Subject = comment.courseName + " Form from: " + comment.firstName + " " + comment.lastName;

            msgText = "<table cellpadding='5px'>";
            msgText = msgText + "<tr><td width='30%'>Name:</td><td>" + comment.firstName + " " + comment.lastName + "</td></tr>";
            msgText = msgText + "<tr><td>Organization:</td><td>" + comment.organization + "</td></tr>";
            msgText = msgText + "<tr><td>Address 1:</td><td>" + comment.address1 + "</td></tr>";
            msgText = msgText + "<tr><td>Address 2:</td><td>" + comment.address2 + "</td></tr>";
            msgText = msgText + "<tr><td>City:</td><td>" + comment.city + "</td></tr>";
            msgText = msgText + "<tr><td>State:</td><td>" + comment.state + "</td></tr>";
            msgText = msgText + "<tr><td>Zip Code:</td><td>" + comment.zipCode + "</td></tr>";
            msgText = msgText + "<tr><td>Telephone:</td><td>" + comment.phone + "</td></tr>";
            msgText = msgText + "<tr><td>Fax:</td><td>" + comment.fax + "</td></tr>";
            msgText = msgText + "<tr><td>Email:</td><td>" + comment.emailAddress + "</td></tr>";
            msgText = msgText + "<tr><td colspan='2'>Invoice and location instructions will be mailed or faxed to you prior to the class.</td></tr>";  
            msgText = msgText + "</table>";
            msg.Body = msgText;
           
            smtp.Send(msg);

            using (var db = new OnlineArkansasContext())
            {
                // Create and save a new Registration                

                var registration = new Registration
                {                    
                    firstName = comment.firstName,
                    lastName = comment.lastName,
                    organization = comment.organization,
                    address1 = comment.address1,
                    address2 = comment.address2,
                    city = comment.city,
                    state = comment.state,
                    zipCode = comment.zipCode,
                    phone = comment.phone,
                    fax = comment.fax,
                    emailAddress = comment.emailAddress,
                    courseName = comment.courseName,
                    courseStartDate = comment.courseStartDate,
                    courseEndDate = comment.courseEndDate,
                    courseFee = comment.courseFee
                };

                db.Registrations.AddObject(registration);
                db.SaveChanges();
            }                             

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
