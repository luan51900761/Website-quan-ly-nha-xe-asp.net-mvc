using EF.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.DAO
{
    public class TuyenXeDao
    {
        private DBContextSV db;
        public TuyenXeDao()
        {
            db = new DBContextSV();
        }
        public const string USER_SESSION = "USER_SESSION";
        public IEnumerable<tuyenxe> ListAll()
        {
            //IQueryable để truy vấn dữ liệu. Vể bản chất IQuery to hơn IEnum

            IQueryable<tuyenxe> model = db.tuyenxes;
            return model.OrderBy(x => x.matuyen);
        }

        public object ListWhereBykeyword(string keyword)
        {
            IQueryable<tuyenxe> model = db.tuyenxes.Where(x => x.diemdi.Contains(keyword));
            return model.OrderBy(x => x.matuyen);
        }


        public IEnumerable<tuyenxe> ListAll(int page, int pageSize)
        {
            //IQueryable để truy vấn dữ liệu. Vể bản chất IQuery to hơn IEnum

            IQueryable<tuyenxe> model = db.tuyenxes;
            return model.OrderBy(x => x.matuyen).ToPagedList(page, pageSize);
        }

        public int create(tuyenxe newtx)
        {
            //kiểm tra duplicate
            var result = db.tuyenxes.Where(x => x.matuyen.Equals(newtx.matuyen)).SingleOrDefault();
            if (result == null)
            {
                db.tuyenxes.Add(newtx);
                db.SaveChanges();
                return 1;
            }
            return 0;
        }

        public int Delete(string matuyen)
        {
            var result = db.tuyenxes.Find(matuyen);
            if (result == null)
            {
                return 0;
            }
            db.tuyenxes.Remove(result);
            db.SaveChanges();
            return 1;
        }
        public int Edit(tuyenxe newtx)
        {
            var result = db.tuyenxes.Find(newtx.matuyen);
            if (result != null)
            {
                //code update db

                result.matuyen = newtx.matuyen;
                result.tentuyen = newtx.tentuyen;
                result.diemdi = newtx.diemdi;
                result.diemden = newtx.diemden;
                result.banggia = newtx.banggia;
                result.image = newtx.image;
                result.thoigian = newtx.thoigian;
                db.SaveChanges();
                return 1;
            }
            return 0;
        }

        public List<string> getMaTuyen()
        {
            List<string> listmachuyen = db.tuyenxes.Select(x => x.matuyen).ToList();
            return listmachuyen;
        }
        

        public tuyenxe ListWhere(string matuyen)
        {
            //IQueryable để truy vấn dữ liệu. Vể bản chất IQuery to hơn IEnum

            tuyenxe model = db.tuyenxes.Where(x => x.matuyen.Equals(matuyen)).SingleOrDefault();
            return model;
        }
    }
}
