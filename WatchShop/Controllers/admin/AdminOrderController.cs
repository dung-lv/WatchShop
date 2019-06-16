using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WatchShop.Controllers.admin
{
    public class AdminOrderController : BaseController
    {
        private OrderDetailDAO orderDetailDAO = null;

        public AdminOrderController()
        {
            orderDetailDAO = new OrderDetailDAO();
        }
        // GET: AdminOrder
        public ActionResult Index(String searchString, String status, int page = 1, int pageSize = 5)
        {
            var model = orderDetailDAO.ListAllPaging(searchString, status,page,pageSize);
            ViewBag.SearchString = searchString;
            ViewBag.status = status;
            return View(model);
        }
        [HttpPost]
        public JsonResult update(string status,long id)
        {
            orderDetailDAO.changeStatus(id, status);
            return Json(new
            {
                status = true
            });
        }

    }
}