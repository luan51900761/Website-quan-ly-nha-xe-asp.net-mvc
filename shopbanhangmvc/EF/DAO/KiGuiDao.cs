using EF.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.DAO
{
    public class KiGuiDao
    {
        private DBContextSV db;
        public KiGuiDao()
        {
            db = new DBContextSV();
        }
        public const string USER_SESSION = "USER_SESSION";
        public IEnumerable<kigui> ListAll()
        {
            //IQueryable để truy vấn dữ liệu. Vể bản chất IQuery to hơn IEnum

            IQueryable<kigui> model = db.kiguis;
            return model.OrderBy(x => x.makg);
        }

        public kigui ListWhere(int makg)
        {
            //IQueryable để truy vấn dữ liệu. Vể bản chất IQuery to hơn IEnum

            kigui model = db.kiguis.Where(x => x.makg == makg).SingleOrDefault();
            return model;
        }

        public int Delete(int makg)
        {
            var result = db.kiguis.Find(makg);
            if (result == null)
            {
                return 0;
            }
            db.kiguis.Remove(result);
            db.SaveChanges();
            return 1;
        }

        public int create(kigui kigui)
        {
            //kiểm tra duplicate
            var result = db.kiguis.Where(x => x.makg == kigui.makg).SingleOrDefault();
            if (result == null)
            {
                db.kiguis.Add(kigui);
                db.SaveChanges();
                return 1;
            }
            return 0;
        }

        public IEnumerable<kigui> ListWhereBySdt(string sdt)
        {
            //IQueryable để truy vấn dữ liệu. Vể bản chất IQuery to hơn IEnum

            IQueryable<kigui> model = db.kiguis.Where(x => x.sdtnguoigui.Contains(sdt));
            return model.OrderBy(x => x.makg);
        }

        public IEnumerable<kigui> ListWhereByMaChuyen(string machuyen)
        {
            IQueryable<kigui> model = db.kiguis.Where(x => x.machuyen.Equals(machuyen));
            return model.OrderBy(x => x.makg);
        }
    }
}
