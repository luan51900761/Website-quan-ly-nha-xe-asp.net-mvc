using EF.CustomModel;
using EF.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EF.DAO
{
    public class ChuyenXeDao
    {
        private DBContextSV db;
        public ChuyenXeDao()
        {
            db = new DBContextSV();
        }
        public const string USER_SESSION = "USER_SESSION";
        public IEnumerable<ScheduleList> ListAll()
        {
            //IQueryable để truy vấn dữ liệu. Vể bản chất IQuery to hơn IEnum
            //dùng LinQ  để lấy dữ liệu nối từ khóa ngoại của 2 bảng
            IQueryable<ScheduleList> model = from c in db.chuyenxes
                                             join t in db.tuyenxes
                                             on c.matuyen equals t.matuyen
                                             select new ScheduleList()
                                             {
                                                 matuyen = c.matuyen,
                                                 tenchuyen = c.tenchuyen,
                                                 tentuyen = t.tentuyen,
                                                 giodi = c.giodi,
                                                 gioden = c.gioden,
                                                 noidi = t.diemdi,
                                                 noiden = t.diemden,
                                                 ngaydi = c.ngaydi
                                             };
            return model.OrderBy(x => x.matuyen);
        }

        public IEnumerable<chuyenxe> ListWhereBykeyword(string keyword)
        {
            //IQueryable để truy vấn dữ liệu. Vể bản chất IQuery to hơn IEnum

            IQueryable<chuyenxe> model = db.chuyenxes.Where(x => x.ngaydi.ToString().Contains(keyword));
            return model.OrderBy(x => x.machuyen);
        }

        public IEnumerable<ScheduleList> ListAll(string start, string to)
        {
            //IQueryable để truy vấn dữ liệu. Vể bản chất IQuery to hơn IEnum
            //dùng LinQ  để lấy dữ liệu nối từ khóa ngoại của 2 bảng
            IQueryable<ScheduleList> model = from c in db.chuyenxes
                                             join t in db.tuyenxes
                                             on c.matuyen equals t.matuyen
                                             where (t.diemdi.Equals(start) && t.diemden.Equals(to))
                                             select new ScheduleList()
                                             {
                                                 machuyen = c.machuyen,
                                                 matuyen = c.matuyen,
                                                 tenchuyen = c.tenchuyen,
                                                 tentuyen = t.tentuyen,
                                                 giodi = c.giodi,
                                                 gioden = c.gioden,
                                                 noidi = t.diemdi,
                                                 noiden = t.diemden,
                                                 ngaydi = c.ngaydi
                                             };
            return model.OrderBy(x => x.matuyen);
        }

        public object ListbyMatx(string matx)
        {
            IQueryable<chuyenxe> model = db.chuyenxes.Where(x => x.matx.Equals(matx));
            return model.OrderBy(x => x.machuyen);
        }

        public object ListbyManv(string manv)
        {
            IQueryable<chuyenxe> model = db.chuyenxes.Where(x=>x.manv.Equals(manv));
            return model.OrderBy(x => x.machuyen);
        }

        public IEnumerable<chuyenxe> List()
        {
            //IQueryable để truy vấn dữ liệu. Vể bản chất IQuery to hơn IEnum

            IQueryable<chuyenxe> model = db.chuyenxes;
            return model.OrderBy(x => x.machuyen);
        }

        public chuyenxe ListWhere(string machuyen)
        {
            //IQueryable để truy vấn dữ liệu. Vể bản chất IQuery to hơn IEnum

            chuyenxe model = db.chuyenxes.Where(x => x.machuyen.Equals(machuyen)).SingleOrDefault();
            return model;
        }
        public List<string> getMaChuyen()
        {
            List<string> listmachuyen = db.chuyenxes.Select(x => x.machuyen).ToList();
            return listmachuyen;
        }

        public int create(chuyenxe item)
        {
            //kiểm tra duplicate
            var result = db.chuyenxes.Where(x => x.machuyen.Equals(item.machuyen)).SingleOrDefault();
            if (result == null)
            {
                db.chuyenxes.Add(item);
                db.SaveChanges();
                return 1;
            }
            return 0;
        }

        public int Delete(string machuyen)
        {
            var result = db.chuyenxes.Find(machuyen);
            if (result == null)
            {
                return 0;
            }
            db.chuyenxes.Remove(result);
            db.SaveChanges();
            return 1;
        }
        public int Edit(chuyenxe item)
        {
            var result = db.chuyenxes.Find(item.machuyen);
            if (result != null)
            {
                //code update db

                result.machuyen = item.machuyen;
                result.tenchuyen = item.tenchuyen;
                result.matuyen = item.matuyen;
                result.giodi = item.giodi;
                result.gioden = item.gioden;
                result.manv= item.manv;
                result.maxe = item.maxe;
                result.matx = item.matx;
                result.ngaydi = item.ngaydi;

                db.SaveChanges();
                return 1;
            }
            return 0;
        }

    }
}
