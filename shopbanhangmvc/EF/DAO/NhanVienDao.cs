using EF.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF.CustomModel;


namespace EF.DAO
{
    public class NhanVienDao
    {
        private DBContextSV db;
        public NhanVienDao()
        {
            db = new DBContextSV();
        }
        public const string USER_SESSION = "USER_SESSION";


        public IEnumerable<nhanvien> ListAll()
        {
            //IQueryable để truy vấn dữ liệu. Vể bản chất IQuery to hơn IEnum

            IQueryable<nhanvien> model = db.nhanviens;
            return model.OrderBy(x => x.manv);
        }
        public nhanvien ListWhere(string manv)
        {
            //IQueryable để truy vấn dữ liệu. Vể bản chất IQuery to hơn IEnum

            nhanvien model = db.nhanviens.Where(x => x.manv.Equals(manv)).SingleOrDefault();
            return model;
        }
        public nhanvien ListWhereByUserName(string username)
        {
            //IQueryable để truy vấn dữ liệu. Vể bản chất IQuery to hơn IEnum

            nhanvien model = db.nhanviens.Where(x => x.username.Equals(username)).SingleOrDefault();
            return model;
        }
        
        public int Delete(string manv)
        {
            var result = db.nhanviens.Find(manv);
            if (result == null)
            {
                return 0;
            }
            db.nhanviens.Remove(result);
            db.SaveChanges();
            return 1;
        }

        
           public IEnumerable<nhanvien> ListWhereBySdt(string sdt)
            {
                //IQueryable để truy vấn dữ liệu. Vể bản chất IQuery to hơn IEnum

                IQueryable<nhanvien> model = db.nhanviens.Where(x => x.tennv.Contains(sdt));
                return model.OrderBy(x => x.manv);
            }
        

        public int Edit(nhanvien newnv)
        {
            var result = db.nhanviens.Find(newnv.manv);
            if (result != null)
            {
                //code update db

                result.manv = newnv.manv;
                result.tennv = newnv.tennv;
                result.ngaysinh = newnv.ngaysinh;
                result.username = newnv.username;
                result.maloainv = newnv.maloainv;
                result.hinhanh = newnv.hinhanh;
                result.email = newnv.email;
                result.cmnd = newnv.cmnd;
                result.diachi = newnv.diachi;
                db.SaveChanges();
                return 1;
            }
            return 0;
        }

        public List<string> getTaiXe()
        {
            List<string> listmachuyen = db.nhanviens.Where(x => x.maloainv.Equals("LNV04")).Select(x => x.manv).ToList();
            return listmachuyen;

        }

        public List<string> getLoXe()
        {
            List<string> listmachuyen = db.nhanviens.Where(x=>x.maloainv.Equals("LNV02")).Select(x=>x.manv).ToList();
            return listmachuyen;
        }

        public int create(nhanvien newnv)
        {
            //kiểm tra duplicate
            var result = db.nhanviens.Where(x => x.manv.Equals(newnv.manv)).SingleOrDefault();
            if (result == null)
            {
                db.nhanviens.Add(newnv);
                db.SaveChanges();
                return 1;
            }
            return 0;
        }


        public string getManvByUserName(string username)
        {
            return db.nhanviens.Where(x => x.username.Equals(username)).SingleOrDefault().manv;
        }

        public string getCVbyusername(string username)
        {
            return db.nhanviens.Where(x => x.username.Equals(username)).SingleOrDefault().loainv.tenloainv;
        }
        public List<string> getUsername()
        {

            List<Account> c = (from n in db.nhanviens
                              join a in db.accounts
                              on n.username equals a.username
                              select new Account
                              {
                                  username = a.username
                              }).ToList();
            List<string> list1 = c.Select(x => x.username).ToList();
            List<string> list2 = db.accounts.Select(x => x.username).ToList();
            List<string> result = db.accounts.Select(x => x.username).ToList();
            foreach (string item in list2) {
                if (list1.Contains(item))
                    result.Remove(item);
                }
            return result;
        }
    }
}
