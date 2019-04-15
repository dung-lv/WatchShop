using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;
using WatchShop.Common;
using WatchShop.Models;

namespace WatchShop.Controllers.Admin
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(LoginModel model)
        {
            var userDAO = new UserDAO();
            var result = userDAO.Login(model.UserName, model.Password);
            if (ModelState.IsValid)
            {
                if (result != null)
                {
                    //var user = userDAO.GetUserById(result);
                    Session[CommonConstant.USER_SESSION] = result;
                    if(result.Role.Name == "admin")
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập không thành công");
                }
            }
            return View("Index");
        }
    }
}