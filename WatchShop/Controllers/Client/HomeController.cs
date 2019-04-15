using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.ViewModel;
using WatchShop.Models;
using Model.EF;
using WatchShop.Common;

namespace WatchShop.Controllers
{
    public class HomeController : Controller
    {
        public static int x = 0;
        private ProductDAO productDAO = null;
        private PromotionDAO promotionDAO = null;
        private CategoryDAO categoryDAO = null;
        private TrademarkDAO trademarkDAO = null;
        private ContactDAO contactDAO = null;

        public HomeController()
        {
            productDAO = new ProductDAO();
            promotionDAO = new PromotionDAO();
            categoryDAO = new CategoryDAO();
            trademarkDAO = new TrademarkDAO();
            contactDAO = new ContactDAO();
        }

        // GET: Home
        public ActionResult Index()
        {
            Session[ValSession.COUNT_ITEM_CART] = x;
            ViewBag.listPromotionProductTop = promotionDAO.getPromotionProduct(1,3);
            ViewBag.listPromotionProduct = promotionDAO.getPromotionProduct(1, 0);
            ViewBag.listHotProduct = productDAO.getListProductHot(10);
            return View();
        }

        public ActionResult AddItem(long id, int quantity)
        {
            var product = productDAO.getDetailProductById(id);
            var cart = Session[ValSession.CART_SESSION];
            if (cart != null)
            {
                var list = (List<CartItem>)cart;
                if (list.Exists(x => x.Product.ID_Product == id))
                {
                    foreach (var item in list)
                    {
                        if (item.Product.ID_Product == id)
                        {
                            item.Quantity += quantity;
                        }
                    }
                }
                else
                {
                    var item = new CartItem();
                    item.Product = product;
                    item.Quantity = quantity;
                    list.Add(item);
                    x++;
                }
                Session[ValSession.CART_SESSION] = list;
            }
            else
            {
                var item = new CartItem();
                item.Product = product;
                item.Quantity = quantity;
                var list = new List<CartItem>();
                list.Add(item);
                Session[ValSession.CART_SESSION] = list;
                x++;
            }
            Session[ValSession.COUNT_ITEM_CART] = x;
            return RedirectToAction("Index");
        }

        [ChildActionOnly]
        public PartialViewResult Category()
        {
            var cart = Session[ValSession.CART_SESSION];
            var list = new List<CartItem>();
            if(cart != null)
            {
                list = (List<CartItem>)cart;
            }
            ViewBag.carts = list;
            CategoryTrademarkViewModel ctViewModel = new CategoryTrademarkViewModel();
            ctViewModel.listCategory = categoryDAO.getAll();
            ctViewModel.listTrademark = trademarkDAO.getAll();
            var model = ctViewModel;
            return PartialView(model);
        }

        [ChildActionOnly]
        public PartialViewResult Footer()
        {
            var model = contactDAO.getContact();
            return PartialView(model);
        }
    }
}