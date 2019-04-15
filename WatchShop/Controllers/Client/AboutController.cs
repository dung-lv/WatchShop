using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WatchShop.Controllers.Client
{
    public class AboutController : Controller
    {
        private AboutDAO aboutDAO = null;

        public AboutController()
        {
            aboutDAO = new AboutDAO();
        }
        // GET: Guarantee
        public ActionResult Index()
        {
            var model = aboutDAO.getAbout();
            return View(model);
        }
    }
}