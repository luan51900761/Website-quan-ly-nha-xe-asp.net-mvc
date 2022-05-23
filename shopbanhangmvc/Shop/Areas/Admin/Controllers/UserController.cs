using EF.DAO;
using EF.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Web.Routing;

namespace Shop.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {

        protected override void OnActionExecuted(ActionExecutedContext filecontext)
        {
            var session = Session[UserDao.USER_SESSION];
            if (session == null)
            {
                Response.Redirect("~/Admin/Login/Index");
            }
            NhanVienDao nv = new NhanVienDao();
            string chucvu = Crypt.convertToUnSign3(nv.getCVbyusername(session.ToString()).Trim());

            if (!chucvu.Equals(Crypt.convertToUnSign3("Quản Lý")))
            {
                SetAlert("bạn không có quyền truy cập vào trang này", "error");
                filecontext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "Index", ares = "Admin " }));
            }
            base.OnActionExecuted(filecontext);
        }
        // GET: Admin/User
        //Mặc định trang create sẽ là trang 1 và số phần tử là 4
        public ActionResult Index(int page =1 , int pageSize = 6)
        {
            var user = new UserDao();
            var userList = user.ListAll(page, pageSize);
            return View(userList);

        }
        //Phân Trang bằng PageList
        //Tempdata để set keyword, 
        [HttpPost]
        public ActionResult Index(string keyword, int page = 1, int pageSize = 6)
        {
            var user = new UserDao();
            ViewBag.Searchkey = keyword;
            IEnumerable<account> userx;
            if (keyword != "")
            {
                userx = user.ListWhere(keyword, page, pageSize=10);
                return View(userx);
            }
            userx = user.ListWhere(keyword, page, pageSize);
            return View(userx);

        }
        public ActionResult Create()
        {
                
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(account acc)
        {
            if (ModelState.IsValid)
            {
                var user = new UserDao();
                acc.password = UserDao.MD5Hash(acc.password);
                string result = user.create(acc);
                if(string.IsNullOrEmpty(result))
                {
                    //ModelState.AddModelError("", "Duplicate username");
                    SetAlert("Tên người dùng đã tồn tại","warming");
                    return View();
                }
                else
                {
                    SetAlert("Thêm người dùng thành công", "success");
                    return RedirectToAction("Index", "User");
                }
            }
            SetAlert("Thêm người dùng không thành công", "error");
            return View();
    
        }
        [HttpGet]
        public ActionResult Delete(string username)
        {
            var userDao = new UserDao();
            if (userDao.Delete(username) == 1)
            {
                SetAlert("Xoá người dùng thành công", "success");
                return RedirectToAction("Index", "User");

            }
            SetAlert("Xoá người dùng không thành công", "error");
            return RedirectToAction("Index", "User");
        }
        public ActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(account editObj)
        {
            //LẤY DỮ LIẸU TRONG URL BẰNG ROUTEDATA
            if (ModelState.IsValid)
            {
                editObj.username = RouteData.Values["key"].ToString();
                var userDao = new UserDao();
                var result = userDao.Edit(editObj.username, UserDao.MD5Hash(editObj.password), editObj.role);
                if (result == 1)
                {
                    SetAlert("Cập nhập thành công", "success");
                    return RedirectToAction("Index", "User");
                }
                SetAlert("Cập nhập không thành công", "danger");
                return View();
            }
            return View();
        }

    }
    
}   