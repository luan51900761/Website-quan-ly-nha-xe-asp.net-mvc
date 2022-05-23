using Shop.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EF.DAO;
using System.Configuration;

namespace Shop.Areas.Admin.Controllers
{
    public class LoginController : Controller  //Don't check session here. Because login page don't need session
    {
        // GET: Admin/Login
        [RequireHttps]
        public ActionResult Index()
        {
            return View();
        }
        //kHI BÊN HTML DÙNG PHƯƠNG THỨC POST THÌ SẼ CHẠY HÀM KIỂM TRA NÀY
        [HttpPost]
        // CÁI VALIDATE NÀY CHỈ DÙNG ĐỂ HIỆN THỊ THÔNG BÁO THÔI
        [ValidateAntiForgeryToken]
        public ActionResult Index(account login)
        {
            if (ModelState.IsValid)
            {
                var user = new UserDao();
                var result = user.login(login.username.Trim(),UserDao.MD5Hash(login.password));
                if(result == 3)
                {
                    ModelState.AddModelError("", "Bạn không có quyền truy cập vào trang này");
                }
                else if(result == 1||result == 2)
                {
                    //ModelState.AddModelError("","đăng nhập thành công");
                    Session.Add(UserDao.USER_SESSION, login.username);
                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    ModelState.AddModelError("", "đăng nhập thất bại");
                }
            }
            return View("Index");


        }

}
}