using EF.CustomModel;
using EF.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.DAO
{
    public class HoaDonDao
    {
        private DBContextSV db;
        public HoaDonDao()
        {
            db = new DBContextSV();
        }
        public const string USER_SESSION = "USER_SESSION";
        public IEnumerable<hoadon> ListAll()
        {
            //IQueryable để truy vấn dữ liệu. Vể bản chất IQuery to hơn IEnum

            IQueryable<hoadon> model = db.hoadons;
            return model.OrderBy(x => x.mahd);
        }
  

        public bool Insert(BookTicket book)
        {
            int id = db.hoadons.Count() + 1;

            var Hoadon = new hoadon();
            Hoadon.mahd = id;
            Hoadon.hoten = book.hoten;
            Hoadon.sdt = book.SDT;
            Hoadon.soluongve = book.soluong;
            Hoadon.tongtien = Double.Parse(book.tongtien);
            Hoadon.tinhtrang = 0;
            Hoadon.machuyen = book.machuyenxe;
            Hoadon.username = book.username;
            Hoadon.ngaydat = DateTime.Now;
            db.hoadons.Add(Hoadon);
            db.SaveChanges();

            book.gheduocchon = book.gheduocchon.Remove(book.gheduocchon.Trim().Length - 1, 1);
            //Sử lí ghế
            string[] arrayseats = book.gheduocchon.Trim().Split(',');
            foreach (string seat in arrayseats)
            {
                var vexe = new VeXeDao();
                var ve = new vexe();
                ve.mahd = Hoadon.mahd;
                ve.tenghe = seat;
                
                vexe.Insert(ve);
            }

            return true;
        }


        public IEnumerable<hoadon> ListWhere(string username)
        {
            //IQueryable để truy vấn dữ liệu. Vể bản chất IQuery to hơn IEnum

            IQueryable<hoadon> model = db.hoadons.Where(x=>x.username.Equals(username));
            return model.OrderBy(x => x.mahd);
        }
        public IEnumerable<hoadon> ListWhereBySdt(string sdt)
        {
            //IQueryable để truy vấn dữ liệu. Vể bản chất IQuery to hơn IEnum

            IQueryable<hoadon> model = db.hoadons.Where(x=>x.sdt.Contains(sdt));
            return model.OrderBy(x => x.mahd);
        }

        public hoadon ListWhereByMahd(int mahd)
        {
            //IQueryable để truy vấn dữ liệu. Vể bản chất IQuery to hơn IEnum

            IQueryable<hoadon> model = db.hoadons.Where(x => x.mahd==(mahd));
            return model.SingleOrDefault();
        }

        public int Confirm(int mahd)
        {
            var vx = new VeXeDao();
            var result = db.hoadons.Find(mahd);
            if (result != null)
            {
                //code update db
                hoadon a = db.hoadons.SingleOrDefault(x => x.mahd == mahd);
                a.tinhtrang = 1;
                db.SaveChanges();
                vx.Confirm(mahd);
                return 1;
            }
            return 0;
        }

        public int Delete(int mahd)
        {
            VeXeDao vx = new VeXeDao();
            int dvx = vx.Delete(mahd);
            if (dvx == 1)
            {
                var result = db.hoadons.Find(mahd);
                if (result == null)
                {
                    return 0;
                }
                db.hoadons.Remove(result);
                db.SaveChanges();
                return 1;
            }
            return 0;
        }
}

        
}