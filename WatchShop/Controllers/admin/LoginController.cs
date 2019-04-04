using System;
using Model.DAO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WatchShop.Models;
using WatchShop.Common;
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
            var dao = new UserDao();
            var result = dao.Login(model.UserName, model.Password);
            if (ModelState.IsValid)
            {
                if (result)
                {
                    var login = dao.GetUserByID(model.UserName);
                    var userSession = new UserLogin();
                    userSession.userName = login.Username;
                    userSession.UserID = login.ID_Login;
                    Session.Add(CommonConstant.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Home");
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