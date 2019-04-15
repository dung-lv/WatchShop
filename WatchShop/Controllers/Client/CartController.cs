using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;
using WatchShop.Models;
using System.Web.Script.Serialization;
using Model.EF;
using System.Configuration;
using WatchShop.Common;

namespace WatchShop.Controllers
{
    public class CartController : Controller
    {
        private OrderDAO orderDAO = null;

        public CartController()
        {
            orderDAO = new OrderDAO();
        }
        // GET: Cart
        public ActionResult Index()
        {
            var cart = Session[ValSession.CART_SESSION];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }

        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = (List<CartItem>)Session[ValSession.CART_SESSION];

            foreach (var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.Product.ID_Product == item.Product.ID_Product);
                if (jsonItem != null)
                {
                    item.Quantity = jsonItem.Quantity;
                }
            }
            Session[ValSession.CART_SESSION] = sessionCart;
            return Json(new
            {
                status = true
            });
        }

        public JsonResult Delete(long id)
        {
            var sessionCart = (List<CartItem>)Session[ValSession.CART_SESSION];
            sessionCart.RemoveAll(x => x.Product.ID_Product == id);
            Session[ValSession.CART_SESSION] = sessionCart;
            HomeController.x--;
            Session[ValSession.COUNT_ITEM_CART] = HomeController.x;
            return Json(new
            {
                status = true
            });
        }

        [HttpPost]
        public ActionResult Payment(string name, string email, string phone, string address, string optradio, string note)
        {
            var order = new Order();
            order.CreateDate = DateTime.Now;
            order.Name = name;
            order.Email = email;
            order.Phone = phone;
            order.Address = address;
            order.Transport = optradio;
            order.Note = note;
            order.Status = Common.ValConst.COMFIRMING;
            var ID_Order = orderDAO.InsertOrder(order);
            var cart = (List<CartItem>)Session[ValSession.CART_SESSION];
            var detailOrderDao = new OrderDetailDAO();
            decimal total = 0;
            foreach (var item in cart)
            {
                var orderDetail = new OrderDetail();
                orderDetail.ID_Product = item.Product.ID_Product;
                orderDetail.ID_Order = ID_Order;
                orderDetail.Quantity = item.Quantity;
                orderDetail.TotalPrice = (item.Product.Price * item.Quantity);
                detailOrderDao.InsertOrderDetail(orderDetail);
                total += (item.Product.Price.GetValueOrDefault(0) * item.Quantity);
            }
            return Redirect("/");
        }
    }
}