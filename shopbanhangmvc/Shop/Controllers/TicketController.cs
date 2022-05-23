using EF.CustomModel;
using EF.DAO;
using EF.EF;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class TicketController : BaseController
    {
        // GET: Ticket

        public ActionResult List(int mahd)
        {
            VeXeDao vx = new VeXeDao();
            var result  = vx.ListWhere(mahd);
            return View(result);
        }
       
        [HttpGet]
        public ActionResult book(string machuyen)
        {
            try
            {
                var vexe = new VeXeDao();
                var giave = vexe.getGia(machuyen);
                var result = vexe.ListAll(machuyen);
                ViewData["giave"] = giave;
                ViewData["rawdata"] = result;
                ViewData["machuyen"] = machuyen;
                return View();
            }
            catch { return RedirectToAction("Index", "Start"); }
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult book(BookTicket book) {
            book.machuyenxe = TempData["machuyen"].ToString();
            var username = TempData["Data1"];
            var hoadon = new HoaDonDao();
            book.tongtien = book.tongtien.Trim();
            book.tongtien = book.tongtien.Remove(book.tongtien.Trim().Length - 1, 1);
            book.tongtien = book.tongtien.Replace(".", "");
            book.username = username.ToString();
            hoadon.Insert(book);
            SetAlert("Đặt vé thành công", "success");
            return RedirectToAction("Index", "HoaDon");
        }


        public  void SetAlert(string message, string type)
        {
            TempData["AlertMessage"] = message;
            switch (type)
            {
                case "success":
                    TempData["AlertType"] = "alert-success"; break;
                case "warming":
                    TempData["AlertType"] = "alert-danger"; break;
                case "error":
                    TempData["AlertType"] = "alert-danger"; break;
                default:
                    TempData["AlertType"] = ""; break;
            }
        }
    }
}