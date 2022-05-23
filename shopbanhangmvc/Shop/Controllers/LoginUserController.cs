using EF.DAO;
using EF.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class LoginUserController : Controller
    {
        // GET: Login
        [RequireHttps]
        [HttpPost]
        // CÁI VALIDATE NÀY CHỈ DÙNG ĐỂ HIỆN THỊ THÔNG BÁO THÔI
        [ValidateAntiForgeryToken]
        public ActionResult Index(account login)
        {
            if (ModelState.IsValid)
            {
                var user = new UserDao();
                var result = user.login(login.username.Trim(), UserDao.MD5Hash(login.password));
                 if (result == 1 || result == 3 || result == 2)
                {
                    Session.Add(UserDao.USER_SESSION, login.username);
                    return RedirectToAction("Index", "Start");

                }
                else 
                {
                    ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng"); 
                }
            }
            return View("Index");

        }
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult SignUp()
        {
           
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult SignUp(account acc)
        {
            if (ModelState.IsValid)
            {
                var user = new UserDao();
                acc.password = UserDao.MD5Hash(acc.password);
                acc.role = "Custommer";
                string result = user.create(acc);
                if (string.IsNullOrEmpty(result))
                {
                    ModelState.AddModelError("", "Duplicate username");
                    return View();
                }
                else
                {
                    ModelState.AddModelError("", "Tạo người dùng thành công");
                    return RedirectToAction("Index", "LoginUser");
                }
            }
            return View();
        }
    }
}