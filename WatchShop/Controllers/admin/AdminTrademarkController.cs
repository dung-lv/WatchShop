using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WatchShop.Controllers.admin
{
    public class AdminTrademarkController : Controller
    {
        private ProductDAO productDAO = null;
        private CategoryDAO categoryDAO = null;
        private PromotionDAO promotionDAO = null;
        private TrademarkDAO trademarkDAO = null;

        public AdminTrademarkController()
        {
            productDAO = new ProductDAO();
            categoryDAO = new CategoryDAO();
            promotionDAO = new PromotionDAO();
            trademarkDAO = new TrademarkDAO();
        }
        // GET: AdminPromotion
        public ActionResult Index(int page = 1, int pageSize = 5)
        {
            var model = trademarkDAO.ListAllPaging(page, pageSize);

            return View(model);
        }
    }
}