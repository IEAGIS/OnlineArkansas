using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using BotDetect.Web.UI.Mvc;
using System.Web.UI;

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
            return View("Training","_TrainingLayout");
        }

        //
        // GET: CheckCaptcha/
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public JsonResult CheckCaptcha(string captchaId, string instanceId,
          string userInput)
        {
            bool ajaxValidationResult =
              MvcCaptcha.Validate(captchaId, userInput, instanceId);

            return Json(ajaxValidationResult, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult RegistrationForm(RegistrationEntity registrationEntity)
        {
            RegistrationEntity ajaxComment = new RegistrationEntity();
            ajaxComment.firstName = registrationEntity.firstName;
            ajaxComment.lastName = registrationEntity.lastName;
            ajaxComment.organization = registrationEntity.organization;
            ajaxComment.address1 = registrationEntity.address1;
            ajaxComment.address2 = registrationEntity.address2;
            ajaxComment.city = registrationEntity.city;
            ajaxComment.state = registrationEntity.state;
            ajaxComment.zipCode = registrationEntity.zipCode;
            ajaxComment.phone = registrationEntity.phone;
            ajaxComment.fax = registrationEntity.fax;
            ajaxComment.emailAddress = registrationEntity.emailAddress;

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

                for (var i = 0; i <= registrationEntity.courseNames.Count - 1; i++)
                {
                    // Create and save a new Registration                
                    var registrationRecord = new Registration
                    {
                        firstName = registrationEntity.firstName,
                        lastName = registrationEntity.lastName,
                        organization = registrationEntity.organization,
                        address1 = registrationEntity.address1,
                        address2 = registrationEntity.address2,
                        city = registrationEntity.city,
                        state = registrationEntity.state,
                        zipCode = registrationEntity.zipCode,
                        phone = registrationEntity.phone,
                        fax = registrationEntity.fax,
                        emailAddress = registrationEntity.emailAddress,
                        courseName = registrationEntity.courseNames[i],
                        courseStartDate = registrationEntity.courseStartDates[i],
                        courseEndDate = registrationEntity.courseEndDates[i],
                        courseFee = registrationEntity.courseFee[i]
                    };

                    dbConnection.Registrations.AddObject(registrationRecord);
                }

                
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
            msg.CC.Add(registrationEntity.emailAddress);

            msg.From = new System.Net.Mail.MailAddress(registrationEntity.emailAddress);

            msg.Subject = "Course Registration Form from: " + registrationEntity.firstName + " " + registrationEntity.lastName;

            msgText = "<table cellpadding='5px'>";
            msgText = msgText + "<tr><td width='30%'>Name:</td><td>" + registrationEntity.firstName + " " + registrationEntity.lastName + "</td></tr>";
            msgText = msgText + "<tr><td>Organization:</td><td>" + registrationEntity.organization + "</td></tr>";
            msgText = msgText + "<tr><td>Address 1:</td><td>" + registrationEntity.address1 + "</td></tr>";
            msgText = msgText + "<tr><td>Address 2:</td><td>" + registrationEntity.address2 + "</td></tr>";
            msgText = msgText + "<tr><td>City:</td><td>" + registrationEntity.city + "</td></tr>";
            msgText = msgText + "<tr><td>State:</td><td>" + registrationEntity.state + "</td></tr>";
            msgText = msgText + "<tr><td>Zip Code:</td><td>" + registrationEntity.zipCode + "</td></tr>";
            msgText = msgText + "<tr><td>Telephone:</td><td>" + registrationEntity.phone + "</td></tr>";
            msgText = msgText + "<tr><td>Fax:</td><td>" + registrationEntity.fax + "</td></tr>";
            msgText = msgText + "<tr><td>Email:</td><td>" + registrationEntity.emailAddress + "</td></tr>";
            msgText = msgText + "<tr><td colspan='2'>Courses Registered:</td></tr>";

            for (var i = 0; i <= registrationEntity.courseNames.Count - 1; i++)
            {
                msgText = msgText + "<tr><td>Course " + (i+1) + "</td><td>" + registrationEntity.courseNames[i] + "</td></tr>";
                msgText = msgText + "<tr><td>Start Date" + "</td><td>" + registrationEntity.courseStartDates[i].ToShortDateString() + "</td></tr>";
                msgText = msgText + "<tr><td>End Date" + "</td><td>" + registrationEntity.courseEndDates[i].ToShortDateString() + "</td></tr>";
                msgText = msgText + "<tr><td>Fee" + "</td><td>$ " + registrationEntity.courseFee[i] + "</td></tr>";
            }

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
        public ActionResult Facilities()
        {
            return View();
        }
    }
}
