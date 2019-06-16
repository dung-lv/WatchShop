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
        private OrderDetailDAO orderDetailDAO = null;
        private ProductDAO productDAO = null;

        public CartController()
        {
            orderDAO = new OrderDAO();
            orderDetailDAO = new OrderDetailDAO();
            productDAO = new ProductDAO();
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
            decimal? totalAll = 0;
            foreach (CartItem c in list)
            {
                if(c.Product.Discount != null)
                {
                    totalAll += (c.Product.Discount * c.Quantity);
                }
                else
                {
                    totalAll += (c.Product.Price * c.Quantity);
                }
            }
            ViewBag.totalAll = totalAll;
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
            HomeController.count--;
            Session[ValSession.COUNT_ITEM_CART_SESSION] = HomeController.count;
            return Json(new
            {
                status = true
            });
        }

        [HttpPost]
        public ActionResult Payment(string name, string email, string phone, string address, string note, string id)
        {
            if (id == "0")
            {
                var order = new Order();
                order.CreateDate = DateTime.Now;
                order.Name = name;
                order.Email = email;
                order.Phone = phone;
                order.Address = address;
                order.Note = note;
                order.Status = Common.ValConst.COMFIRMING;
                var ID_Order = orderDAO.InsertOrder(order);
                var cart = (List<CartItem>)Session[ValSession.CART_SESSION];
                foreach (var item in cart)
                {
                    var orderDetail = new OrderDetail();
                    orderDetail.ID_Product = item.Product.ID_Product;
                    orderDetail.ID_Order = ID_Order;
                    orderDetail.Quantity = item.Quantity;
                    orderDetail.TotalPrice = (item.Product.Price * item.Quantity);
                    orderDetail.CreateDate = DateTime.Now;
                    orderDetailDAO.InsertOrderDetail(orderDetail);
                    productDAO.updateProductForPayment(item.Product.ID_Product, item.Quantity);
                }
                Session[ValSession.PAY_SESSION] = ID_Order;
            }
            else
            {
                var order = new Order();
                order.CreateDate = DateTime.Now;
                order.Name = name;
                order.Email = email;
                order.Phone = phone;
                order.Address = address;
                order.Note = note;
                order.ID_Order = Convert.ToInt64(id);
                orderDAO.UpdateOrder(order);
            }
            Session[ValSession.CART_SESSION] = null;
            HomeController.count = 0;
            Session[ValSession.COUNT_ITEM_CART_SESSION] = HomeController.count;
            return Redirect(Request.UrlReferrer.ToString());
        }

        // GET: Infor
        public ActionResult Infor()
        {
            var lstOrderDetail = orderDetailDAO.getOrderDetail((long)Session[ValSession.PAY_SESSION]);
            var order = orderDAO.getOrder((long)Session[ValSession.PAY_SESSION]);
            ViewBag.order = order;
            ViewBag.lstOrderDetail = lstOrderDetail;
            ViewBag.phone = Convert.ToInt32(order.Phone);
            decimal? totalAll = 0;
            foreach (OrderDetail o in lstOrderDetail)
            {
                totalAll += (o.Product.Price * o.Quantity);
            }
            ViewBag.totalAll = totalAll;
            return View();
        }
    }
}