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
        public ActionResult CommentForm(Comment comment)
        {
            Comment ajaxComment = new Comment();
            ajaxComment.FirstName = comment.FirstName;
            ajaxComment.LastName = comment.LastName;
            ajaxComment.Organization = comment.Organization;
            ajaxComment.Address = comment.Address;
            ajaxComment.Address2 = comment.Address2;
            ajaxComment.City = comment.City;
            ajaxComment.State = comment.State;
            ajaxComment.ZipCode = comment.ZipCode;
            ajaxComment.Telephone = comment.Telephone;
            ajaxComment.Fax = comment.Fax;
            ajaxComment.Email = comment.Email;

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
            msg.To.Add("ilfarmahan@ualr.edu");
            msg.CC.Add("jojoseph@ualr.edu");
            msg.Bcc.Add("mxlnu1@ualr.edu");
            msg.CC.Add(comment.Email);

            msg.From = new System.Net.Mail.MailAddress(comment.Email);

            msg.Subject = comment.CourseName + " Form from: " + comment.FirstName + " " + comment.LastName;

            msgText = "<table cellpadding='5px'>";
            msgText = msgText + "<tr><td width='30%'>Name:</td><td>" + comment.FirstName + " " + comment.LastName + "</td></tr>";
            msgText = msgText + "<tr><td>Organization:</td><td>" + comment.Organization + "</td></tr>";
            msgText = msgText + "<tr><td>Address 1:</td><td>" + comment.Address + "</td></tr>";
            msgText = msgText + "<tr><td>Address 2:</td><td>" + comment.Address2 + "</td></tr>";
            msgText = msgText + "<tr><td>City:</td><td>" + comment.City + "</td></tr>";
            msgText = msgText + "<tr><td>State:</td><td>" + comment.State + "</td></tr>";
            msgText = msgText + "<tr><td>Zip Code:</td><td>" + comment.ZipCode + "</td></tr>";
            msgText = msgText + "<tr><td>Telephone:</td><td>" + comment.Telephone + "</td></tr>";
            msgText = msgText + "<tr><td>Fax:</td><td>" + comment.Fax + "</td></tr>";
            msgText = msgText + "<tr><td>Email:</td><td>" + comment.Email + "</td></tr>";
            msgText = msgText + "<tr><td colspan='2'>Invoice and location instructions will be mailed or faxed to you prior to the class.</td></tr>";  
            msgText = msgText + "</table>";
            msg.Body = msgText;
           
            smtp.Send(msg);

            //Response.Redirect("../Home/Training.cshtml");                                   

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
