using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;
using WatchShop.Common;
using Model.EF;
using System.Text.RegularExpressions;
using System.Globalization;
using WatchShop.Models;

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
        public ActionResult Index(string name = "codien", int page = 1, int prf = 0, int prt = 0, string co = "", long td = 0, long ct = 0)
        {
            var maxResult = 8;
            var first = (maxResult * page) - maxResult;
            var model = new List<Product>();
            if (prf == 0)
            {
                if (name.Equals("codien") || name.Equals("hiendai"))
                {
                    Category db = categoryDAO.getDetailCategoryByMetaTitle(name);
                    model = productDAO.getListProductByCategory(db.ID_Category, first, maxResult, priceFrom, priceTo);
                    //ViewBag.listPromotionProductTop = promotionDAO.getPromotionProduct(1, 3);
                    Trademark trademark = new Trademark();
                    trademark.Name = "All";
                    trademark.ID_Trademark = 0;
                    List<Trademark> lstTrademark = trademarkDAO.getListTrademarkByCategory(db.ID_Category);
                    lstTrademark.Insert(0, trademark);
                    ViewBag.listTrademark = lstTrademark;
                    var count = productDAO.getListProductByCategory(db.ID_Category, 1, 0, 0, 0).Count();
                    ViewBag.totalPage = ((count - 1) / maxResult) + 1;
                    //ViewBag.category = categoryDAO.getDetailCategory(id);
                    ViewBag.category = db;
                }
                else
                {
                    Trademark db = trademarkDAO.getDetailTrademarkByMetatitle(name);
                    model = productDAO.getListProductByTrademark(db.ID_Trademark, first, maxResult, priceFrom, priceTo);
                    List<Trademark> lstTrademark = new List<Trademark>();
                    lstTrademark.Add(trademarkDAO.getDetailTrademark(db.ID_Trademark));
                    ViewBag.listTrademark = lstTrademark;
                    //ViewBag.listPromotionProductTop = promotionDAO.getPromotionProduct(1, 3);
                    var count = productDAO.getListProductByTrademark(db.ID_Trademark, 1, 0, 0, 0).Count();
                    ViewBag.totalPage = ((count - 1) / maxResult) + 1;
                    ViewBag.category = categoryDAO.getDetailCategoryByTrademark(db.ID_Trademark);
                    //ViewBag.trademark = trademarkDAO.getDetailTrademark(id);
                    ViewBag.trademark = db;
                }
                ColorModel.colors.Sort(new SC());
                ViewBag.colors = ColorModel.colors;
                ViewBag.page = page;
                ViewBag.prf = 0;
                ViewBag.prt = 0;
                ViewBag.co = "";
                ViewBag.td = 0;
                ViewBag.ct = 0;
            }
            else
            {
                model = productDAO.FillData(maxResult, first, prf, prt, co, td, ct, false);
                var count = productDAO.FillData(maxResult, first, prf, prt, co, td, ct, true).Count();
                List<Trademark> lstTrademark = trademarkDAO.getListTrademarkByCategory(ct);
                ViewBag.totalPage = ((count - 1) / maxResult) + 1;
                ViewBag.category = categoryDAO.getDetailCategory(ct);
                if (td != 0)
                {
                    Trademark entity = trademarkDAO.getDetailTrademark(td);
                    lstTrademark.Remove(entity);
                    lstTrademark.Insert(0, entity);
                    ViewBag.trademark = entity;

                    Trademark trademark = new Trademark();
                    trademark.Name = "All";
                    trademark.ID_Trademark = 0;
                    lstTrademark.Add(trademark);
                }
                else
                {
                    Trademark trademark = new Trademark();
                    trademark.Name = "All";
                    trademark.ID_Trademark = 0;
                    lstTrademark.Insert(0, trademark);
                    ViewBag.trademark = null;
                }
                ViewBag.listTrademark = lstTrademark;

                ColorModel.colors.Sort(new SC());
                List<string> colors = ColorModel.colors;
                if (co != "All")
                {
                    colors.Remove(co);
                    colors.Insert(0, co);
                    ViewBag.colors = colors;
                }
                else
                {
                    ViewBag.colors = colors;
                }
                ViewBag.page = page;
                ViewBag.prf = prf;
                ViewBag.prt = prt;
                ViewBag.co = co;
                ViewBag.td = td;
                ViewBag.ct = ct;
            }
            return View(model);
        }

        //public ActionResult ProductByTrademark(string name = "citizen", int page = 1)
        //{
        //    var maxResult = 8;
        //    var first = (maxResult * page) - maxResult;
        //    Trademark db = trademarkDAO.getDetailTrademarkByMetatitle(name);
        //    var model = productDAO.getListProductByTrademark(db.ID_Trademark, first, maxResult, priceFrom, priceTo);
        //    List<Trademark> lstTrademark = new List<Trademark>();
        //    lstTrademark.Add(trademarkDAO.getDetailTrademark(db.ID_Trademark));
        //    ViewBag.listTrademark = lstTrademark;
        //    ViewBag.listPromotionProductTop = promotionDAO.getPromotionProduct(1, 3);
        //    ViewBag.totalPage = (double)(productDAO.getListProductByTrademark(db.ID_Trademark, 1, 0, 0, 0).Count() / maxResult) + 1;
        //    ViewBag.category = categoryDAO.getDetailCategoryByTrademark(db.ID_Trademark);
        //    ViewBag.trademark = db;
        //    ViewBag.colors = ColorModel.colors;
        //    return View("index", model);
        //}

        public ActionResult ProductDetailByMetaTitle(string name)
        {
            var model = productDAO.getDetailProductByMetaTitle(name);
            ViewBag.listProductByTrademark = productDAO.getListProductByTrademark(model.ID_Trademark, 0, 8, 0, 0);
            //ViewBag.listProductByTrademark = productDAO.getListProductByTrademark(1, 0, 8, 0, 0);
            return View(model);
        }

        public ActionResult ProductDetailByName(string name)
        {
            var model = productDAO.getDetailProductByName(name);
            ViewBag.listProductByTrademark = productDAO.getListProductByTrademark(model.ID_Trademark, 0, 8, 0, 0);
            //ViewBag.listProductByTrademark = productDAO.getListProductByTrademark(1, 0, 8, 0, 0);
            return View("ProductDetailByMetaTitle", model);
        }

        public JsonResult ListName(string q)
        {
            var data = productDAO.ListName(q);
            return Json(new
            {
                data = data,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }
    }

    class SC : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            return x.CompareTo(y);
        }
    }
}