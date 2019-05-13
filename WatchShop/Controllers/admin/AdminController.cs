using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.ViewModel;
using Model.EF;
using WatchShop.Common;
using System.IO;

namespace WatchShop.Controllers.admin
{
    public class AdminController : Controller
    {
        private ProductDAO productDAO = null;
        private CategoryDAO categoryDAO = null;
        private PromotionDAO promotionDAO = null;
        private TrademarkDAO trademarkDAO = null;

        public AdminController()
        {
            productDAO = new ProductDAO();
            categoryDAO = new CategoryDAO();
            promotionDAO = new PromotionDAO();
            trademarkDAO = new TrademarkDAO();
        }
        // GET: Admin
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var model = productDAO.ListAllPaging(page, pageSize);
            List<Promotion> promotions = promotionDAO.getNewPromotions();
            promotions.Insert(0, new Promotion());
            ViewBag.promotion = promotions;
            ViewBag.trademark = trademarkDAO.getAll();
            if(Session[CommonConstant.USER_SESSION] == null)
            {
                return Redirect("/");
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateOrUpdateProduct(ProductModel model)
        {
            if (model.ID_Product != 0)
            {
                if(model.ImageFile != null)
                {
                    model.Avatar = SaveFile(model);
                }
                productDAO.UpdateProduct(model);
            }
            else
            {
                Product db = new Product();
                db.Name = model.Name;
                db.Price = model.Price;
                db.Quantity = model.Quantity;
                if (model.ID_Promotion != 0)
                {
                    db.ID_Promotion = model.ID_Promotion;
                    db.Discount = model.Discount;
                }
                db.Hot = model.Hot;
                db.Metatitle = model.Metatitle;
                db.Description = model.Description;
                db.Content = model.Content;
                db.ID_Trademark = model.ID_Trademark;
                db.Avatar = SaveFile(model);
                db.CreateDate = DateTime.Now;
                productDAO.InsertProduct(db);
            }
            ModelState.Clear();
            return Redirect("/Admin/Index");
        }

        public JsonResult Delete(long id)
        {
            productDAO.DeleteProduct(id);
            return Json(new
            {
                status = true
            });
        }

        public ActionResult CategoryManager()
        {
            var model = categoryDAO.getAll();
            return View(model);
        }

        public string SaveFile(ProductModel model)
        {
            string fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
            string extension = Path.GetExtension(model.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            fileName = Path.Combine(Server.MapPath("/Assets/Client/images/"), fileName);
            model.ImageFile.SaveAs(fileName);
            return fileName;
        }
    }
}