using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;

namespace WatchShop.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            ViewBag.listPromotionProductTop = new PromotionDAO().getTopById(1);
            var model = new ProductDAO().getAll();
            return View(model);
        }

        public ActionResult DetailProduct(long ID_Product)
        {
            var model = new ProductDAO().getDetailProduct(ID_Product);
            ViewBag.listProductByTrademark = new ProductDAO().getListProductByTrademark(2, 6);
            return View(model);
        }
    }
}