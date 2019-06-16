using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WatchShop.Controllers.Client
{
    public class FeedbackController : Controller
    {
        private FeedbackDAO feedbackDAO = null;
        private ContactDAO contactDAO = null;

        public FeedbackController()
        {
            feedbackDAO = new FeedbackDAO();
            contactDAO = new ContactDAO();
        }
        // GET: Contact
        public ActionResult Index()
        {
            var model = contactDAO.getContact();
            return View(model);
        }

        [HttpPost]
        public JsonResult Send(string email, string content)
        {
            var feedback = new Feedback();
            feedback.Email = email;
            feedback.CreateDate = DateTime.Now;
            feedback.Content = content;

            var id = feedbackDAO.InsertFeedback(feedback);
            if (id > 0)
            {
                return Json(new
                {
                    status = true
                });
            }

            else
                return Json(new
                {
                    status = false
                });
        }
    }
}