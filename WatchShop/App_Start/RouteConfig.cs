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
                url: "danhmuc/{category}",
                defaults: new { controller = "Product", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "WatchShop.Controllers" }
            );

            routes.MapRoute(
                name: "Product by Trademark",
                url: "thuonghieu/{trademark}",
                defaults: new { controller = "Product", action = "ProductByTrademark", id = UrlParameter.Optional },
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
                name: "Detail Product",
                url: "chitietsanpham/{product}",
                defaults: new { controller = "Product", action = "DetailProductById", id = UrlParameter.Optional },
                namespaces: new[] { "WatchShop.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] {"WatchShop.Controllers"}
            );
        }
    }
}
