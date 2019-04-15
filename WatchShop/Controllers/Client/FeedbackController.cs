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

        public FeedbackController()
        {
            feedbackDAO = new FeedbackDAO();
        }
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Send(string name, string phone, string address, string email, string content)
        {
            var feedback = new Feedback();
            feedback.Name = name;
            feedback.Email = email;
            feedback.CreateDate = DateTime.Now;
            feedback.Phone = phone;
            feedback.Content = content;
            feedback.Address = address;

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