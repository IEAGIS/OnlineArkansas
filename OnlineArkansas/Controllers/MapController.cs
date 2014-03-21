using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineArkansas.Controllers
{
    public class MapController : Controller
    {
        //
        // GET: /Map/

        public ActionResult Index()
        {
            return View();
        }

        [AllowCrossSiteJson]
        public ActionResult SchoolDist()
        {
            ViewBag.Template = "GIS";
            return View();
        }

        public ActionResult CampusMap()
        {
            ViewBag.Template = "CampusMap";
            return View();
        }

    }
}
