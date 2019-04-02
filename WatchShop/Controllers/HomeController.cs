using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.ViewModel;

namespace WatchShop.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.listPromotionProductTop = new PromotionDAO().getTopById(1);
            ViewBag.listPromotionProduct = new PromotionDAO().getAllById(1);
            ViewBag.listHotProduct = new ProductDAO().getListProductByHot(10);
            return View();
        }

        [ChildActionOnly]
        public PartialViewResult Category()
        {
            CategoryTrademarkViewModel ctViewModel = new CategoryTrademarkViewModel();
            ctViewModel.listCategory = new CategoryDAO().getAll();
            ctViewModel.listTrademark = new TrademarkDAO().getAll();
            var model = ctViewModel;

            return PartialView(model);
        }
    }
}