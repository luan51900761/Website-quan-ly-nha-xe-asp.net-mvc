using EF.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class KiGuiUserController : Controller
    {
        // GET: KiGui
        public ActionResult Search()
        {
            
            return View();
        }

        public void SetAlert(string message, string type)
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

        [HttpPost]
        public ActionResult Detail(string code)
        {

            KiGuiDao kg = new KiGuiDao();
            code = code.Trim().Replace(code.Substring(0, 9),"");
            string derypt = Crypt.DecodeServerName(code);
            if (derypt != null)
            {
                int ma = Int32.Parse(derypt);
                var result = kg.ListWhere(ma);
                if (result == null)
                {
                    SetAlert("Mã hóa đơn không hợp lệ", "error");
                    return View("Search");
                }
                return View(result);
            }
            SetAlert("Mã hóa đơn không hợp lệ", "error");
            return View("Search");
        }
    }
}