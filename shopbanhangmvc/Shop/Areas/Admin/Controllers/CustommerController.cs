using EF.DAO;
using EF.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Shop.Areas.Admin.Controllers
{
    public class CustommerController : BaseController
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
        // GET: Admin/Customer
        public ActionResult Index()
        {
            NhanVienDao nv = new NhanVienDao();
            return View(nv.ListAll());
        }

        [HttpPost]
        public ActionResult Index(string keyword)
        {
            NhanVienDao hd = new NhanVienDao();
            var result = hd.ListWhereBySdt(keyword);
            return View(result);
        }
        [HttpGet]
        public ActionResult Detail(string manv)
        {
            if(manv == null)
            {
                NhanVienDao nv = new NhanVienDao();
                var result1 = nv.ListWhereByUserName(Session[UserDao.USER_SESSION].ToString());
                return View(result1);
            }
            NhanVienDao kg = new NhanVienDao();
            var result = kg.ListWhere(manv);
            result.hinhanh = result.hinhanh.Trim();
            return View(result);
        }

       

        [HttpGet]
        public ActionResult Edit(string manv)
        {
            nhanvien nv = new nhanvien();
            nv.manv = manv;
            return View(nv);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(nhanvien editObj)
        {
            string url = "/Content/img/" + editObj.hinhanh;
            editObj.hinhanh = url;
            var nv = new NhanVienDao();
            nv.Edit(editObj);
            return RedirectToAction("Index");
 
        }

       
        [HttpGet]
        public ActionResult Delete(string manv)
        {
            var nv = new NhanVienDao();
            if (nv.Delete(manv) == 1)
            {
                SetAlert("Xoá nhân viên thành công", "success");
                return RedirectToAction("Index", "Custommer");

            }
            SetAlert("Xoá nhân viên không thành công", "error");
            return RedirectToAction("Index", "Custommer");
        }

        public ActionResult Create()
        {
            var nv = new NhanVienDao();
            ViewBag.username = nv.getUsername();
            return View();
        }

        [HttpPost]
        public ActionResult Create(nhanvien newnv)
        {
            string url = "/Content/img/" + newnv.hinhanh;
            newnv.hinhanh = url;
            var nv = new NhanVienDao();
            nv.create(newnv);
            return RedirectToAction("Index");
        }
    }
}