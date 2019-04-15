using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;
using WatchShop.Common;
using Model.EF;
using System.Text.RegularExpressions;

namespace WatchShop.Controllers
{
    public class ProductController : Controller
    {
        private ProductDAO productDAO = null;
        private PromotionDAO promotionDAO = null;
        private CategoryDAO categoryDAO = null;
        private TrademarkDAO trademarkDAO = null;
        private int priceFrom = 0;
        private int priceTo = 0;

        public ProductController()
        {
            productDAO = new ProductDAO();
            promotionDAO = new PromotionDAO();
            categoryDAO = new CategoryDAO();
            trademarkDAO = new TrademarkDAO();
        }
        // GET: Product
        public ActionResult Index(long id, int page = 1, string price = "")
        {
            var maxResult = 4;
            var x = price;
            var first = (maxResult * page + 1 + 1) - maxResult;
            if (price != "")
            {
                price = Regex.Replace(price, @"[\s+]", "");
                price = price.Replace("$", "");
                string[] priceArr = price.Split('-');
                priceFrom = Convert.ToInt32(priceArr[0]);
                priceTo = Convert.ToInt32(priceArr[1]);
            } 
            var model = productDAO.getListProductByCategory(id, first, maxResult, priceFrom, priceTo);
            ViewBag.listPromotionProductTop = promotionDAO.getPromotionProduct(1, 3);
            ViewBag.totalPage = (productDAO.getListProductByCategory(id,1,0,0,0).Count() / maxResult) + 1;
            ViewBag.category = categoryDAO.getDetailCategory(id);
            return View(model);
        }

        public ActionResult ProductByTrademark(long id, int page = 1, string price = "")
        {
            var maxResult = 4;
            var first = (maxResult * page) - maxResult;
            if (price != "")
            {
                price = Regex.Replace(price, @"[\s+]", "");
                price = price.Replace("$", "");
                string[] priceArr = price.Split('-');
                priceFrom = Convert.ToInt32(priceArr[0]);
                priceTo = Convert.ToInt32(priceArr[1]);
            }
            var model = productDAO.getListProductByTrademark(id, first, maxResult, priceFrom, priceTo);
            ViewBag.listPromotionProductTop = promotionDAO.getPromotionProduct(1, 3);
            ViewBag.totalPage = (double)(productDAO.getListProductByTrademark(id, 1, 0, 0, 0).Count() / maxResult) + 1;
            ViewBag.category = categoryDAO.getDetailCategoryByTrademark(id);
            ViewBag.trademark = trademarkDAO.getDetailTrademark(id);
            return View("index", model);
        }

        public ActionResult DetailProductById(long id)
        {
            var model = productDAO.getDetailProductById(id);
            //ViewBag.listProductByTrademark = productDAO.getListProductByTrademark(model.ID_Trademark, 0, 8, 0, 0);
            ViewBag.listProductByTrademark = productDAO.getListProductByTrademark(1, 0, 8, 0, 0);
            return View(model);
        }

        [HttpPost]
        public ActionResult DetailProductByName(string name)
        {
            var model = productDAO.getDetailProductByName(name);
            //ViewBag.listProductByTrademark = productDAO.getListProductByTrademark(model.ID_Trademark, 0, 8, 0, 0);
            ViewBag.listProductByTrademark = productDAO.getListProductByTrademark(1, 0, 8, 0, 0);
            return View("DetailProductById", model);
        }
    }
}