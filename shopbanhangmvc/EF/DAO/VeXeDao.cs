using EF.CustomModel;
using EF.EF;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EF.DAO
{
    public class VeXeDao
    {
        private DBContextSV db;
        public VeXeDao()
        {
            db = new DBContextSV();
        }
        public const string USER_SESSION = "USER_SESSION";

        public double getGia(string machuyen)
        {
            IQueryable<BookTicket> model1 = from c in db.chuyenxes
                                            join t in db.tuyenxes
                                            on c.matuyen equals t.matuyen
                                            where c.machuyen.Equals(machuyen)
                                            select new BookTicket()
                                            {
                                                gia = (double)t.banggia

                                            };
            return model1.First().gia;
        }
        public IEnumerable<BookTicket> ListAll(string machuyen)
        {
            IQueryable<BookTicket> model = from h in db.hoadons
                                           join v in db.vexes
                                           on h.mahd equals v.mahd
                                           where h.machuyen.Equals(machuyen)
                                           select new BookTicket()
                                           {
                                               mave = v.mave,
                                               tenghe = v.tenghe,
                                               machuyenxe = machuyen
                                           };

            return model.OrderBy(x => x.mave);
        }

        public bool Insert(vexe ve)
        {
                ve.mave = db.vexes.Count() + 1;
                ve.tinhtrang = 0;
                db.vexes.Add(ve);
                db.SaveChanges();
               return true;
        }
        public IEnumerable<vexe> ListWhere(int mahd)
        {
            //IQueryable để truy vấn dữ liệu. Vể bản chất IQuery to hơn IEnum

            IQueryable<vexe> model = db.vexes.Where(x => x.mahd == mahd);
            return model.OrderBy(x => x.mave);
        }

        public int Confirm(int mahd)
        {

            IQueryable<vexe> model = db.vexes.Where(x => x.mahd == mahd);

            model = model.OrderBy(x => x.mave);
            if (model != null)
            {
                foreach ( var item in model) {
                    //code update db
                    vexe a = db.vexes.SingleOrDefault(x => x.mave == item.mave);
                    a.tinhtrang = 1;
                    
                }
                db.SaveChanges();
                return 1;
            }
            return 0;
        }

        public int Delete(int mahd)
        {
            var result = db.vexes.Where(x => x.mahd == mahd);
            if (result == null)
            {
                return 0;
            }
            db.vexes.RemoveRange(result);
            db.SaveChanges();
            return 1;
        }

        public IEnumerable<vexe> ListWhereByMaChuyen(string machuyen)
        {
            IQueryable<vexe> model = db.vexes.Where(x => x.hoadon.machuyen.Equals(machuyen.Trim()));
            return model.OrderBy(x => x.tenghe);
        }
    }
}
