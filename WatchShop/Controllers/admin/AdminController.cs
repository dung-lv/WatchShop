using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using WatchShop.Common;

namespace WatchShop.Controllers.admin
{
    public class AdminController : Controller
    {
        private ProductDAO productDAO = null;
        private PromotionDAO promotionDAO = null;
        private TrademarkDAO trademarkDAO = null;

        public AdminController()
        {
            productDAO = new ProductDAO();
            promotionDAO = new PromotionDAO();
            trademarkDAO = new TrademarkDAO();
        }
        // GET: Admin
        public ActionResult Index()
        {
            var model = productDAO.getAll();
            ViewBag.promotion = promotionDAO.getNewPromotions();
            ViewBag.trademark = trademarkDAO.getAll();
            if(Session[CommonConstant.USER_SESSION] == null)
            {
                return Redirect("/");
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateOrProduct(string name, string price, string quantity, string avatar, string promotion, string discount, string metatitle, string trademark, string description)
        {
            Product db = new Product();
            db.Name = name;
            db.Price = Decimal.Parse(price);
            db.Quantity = Int32.Parse(quantity);
            db.Avatar = avatar;
            //Promotion pro = promotionDAO.getPromotionById(Int32.Parse(promotion));
            db.Discount = Decimal.Parse(discount);
            db.Metatitle = metatitle;
            //Trademark tra = trademarkDAO.getDetailTrademark(Int32.Parse(trademark));
            db.Description = description;
            productDAO.InsertProduct(db);
            return Redirect("/");
        }

        public JsonResult Delete(long id)
        {
            productDAO.DeleteProduct(id);
            return Json(new
            {
                status = true
            });
        }
    }
}