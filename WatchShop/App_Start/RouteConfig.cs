using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WatchShop
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Product by Category",
                url: "danhmuc",
                defaults: new { controller = "Product", action = "Index", name = UrlParameter.Optional },
                namespaces: new[] { "WatchShop.Controllers" }
            );

            routes.MapRoute(
                name: "Add Cart",
                url: "themgiohang",
                defaults: new { controller = "Home", action = "AddItem", id = UrlParameter.Optional },
                namespaces: new[] { "WatchShop.Controllers" }
            );

            routes.MapRoute(
                name: "Cart",
                url: "giohang",
                defaults: new { controller = "Cart", action = "Index" },
                namespaces: new[] { "WatchShop.Controllers" }
            );

            routes.MapRoute(
                name: "Payment",
                url: "thanhtoan",
                defaults: new { controller = "Cart", action = "Payment" },
                namespaces: new[] { "WatchShop.Controllers" }
            );

            routes.MapRoute(
                name: "Infor",
                url: "thongtindonhang",
                defaults: new { controller = "Cart", action = "Infor" },
                namespaces: new[] { "WatchShop.Controllers" }
            );

            routes.MapRoute(
                name: "Detail Product",
                url: "chitietsanpham",
                defaults: new { controller = "Product", action = "ProductDetailByMetaTitle", name = UrlParameter.Optional },
                namespaces: new[] { "WatchShop.Controllers" }
            );

            routes.MapRoute(
                name: "Search Product",
                url: "timkiem",
                defaults: new { controller = "Product", action = "ProductDetailByName", id = UrlParameter.Optional },
                namespaces: new[] { "WatchShop.Controllers" }
            );


            routes.MapRoute(
                name: "About",
                url: "gioithieu",
                defaults: new { controller = "About", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "WatchShop.Controllers" }
            );

            routes.MapRoute(
                name: "Feedback",
                url: "lienhe",
                defaults: new { controller = "Feedback", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "WatchShop.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "WatchShop.Controllers" }
            );
        }
    }
}
