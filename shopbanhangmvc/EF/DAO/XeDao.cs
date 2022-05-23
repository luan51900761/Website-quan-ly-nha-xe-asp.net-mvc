using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF.EF;

namespace EF.DAO
{
    public class XeDao
    {
            private DBContextSV db;
            public XeDao()
            {
                db = new DBContextSV();
            }
            public const string USER_SESSION = "USER_SESSION";

        public IEnumerable<xe> ListAll()
        {
            //IQueryable để truy vấn dữ liệu. Vể bản chất IQuery to hơn IEnum

            IQueryable<xe> model = db.xes;
            return model.OrderBy(x => x.maxe);
        }

        public int create(xe newtx)
        {
            //kiểm tra duplicate
            var result = db.xes.Where(x => x.maxe.Equals(newtx.maxe)).SingleOrDefault();
            if (result == null)
            {
                db.xes.Add(newtx);
                db.SaveChanges();
                return 1;
            }
            return 0;
        }

        public int Delete(string maxe)
        {
            var result = db.xes.Find(maxe);
            if (result == null)
            {
                return 0;
            }
            db.xes.Remove(result);
            db.SaveChanges();
            return 1;
        }
        public int Edit(xe newtx)
        {
            var result = db.xes.Find(newtx.maxe);
            if (result != null)
            {
                //code update db

                result.maxe = newtx.maxe;
                result.tenxe = newtx.tenxe;
                result.bienso = newtx.bienso;
                db.SaveChanges();
                return 1;
            }
            return 0;
        }

        public List<string> getMaXe()
        {
            List<string> listmachuyen = db.xes.Select(x => x.maxe).ToList();
            return listmachuyen;
        }
    }
}
