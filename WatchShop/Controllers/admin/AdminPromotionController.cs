using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.DAO;
namespace WatchShop.Controllers.admin
{
    public class AdminPromotionController : Controller
    {
        private ProductDAO productDAO = null;
        private CategoryDAO categoryDAO = null;
        private PromotionDAO promotionDAO = null;
        private TrademarkDAO trademarkDAO = null;

        public AdminPromotionController()
        {
            productDAO = new ProductDAO();
            categoryDAO = new CategoryDAO();
            promotionDAO = new PromotionDAO();
            trademarkDAO = new TrademarkDAO();
        }
        // GET: AdminPromotion
        public ActionResult Index(int page = 1, int pageSize = 5)
        {
            var model = promotionDAO.ListAllPaging(page, pageSize);

            return View(model);
        }
        [HttpPost]
        public ActionResult Create(Promotion promotion)
        {
            if (ModelState.IsValid)
            {

                promotionDAO.Insert(promotion);
            }
            else
            {
                ModelState.AddModelError("", " không thành công");

            }

            return Redirect("/Admin/Index");
        }
        public JsonResult Delete(long id)
        {
            promotionDAO.DeletePromotion(id);
            return Json(new
            {
                status = true
            });
        }
    }
}