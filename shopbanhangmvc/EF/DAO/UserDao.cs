using EF.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using System.Data.Entity;

namespace EF.DAO
{
    public class UserDao
    {
        private DBContextSV db;
        public UserDao()
        {
            db = new DBContextSV();
        }
        public const string USER_SESSION = "USER_SESSION";
        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }

        public string FindCV(string username)
        {
            return db.accounts.Find(username).role;

        }

        public int login(string user, string pass)
        {
            var result = db.accounts.Where(x => x.password.Equals(pass) && x.username.Equals(user)).SingleOrDefault();
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.role.Trim() == "Employee") { return 2; }
                if (result.role.Trim() == "Custommer") { return 3; }
                return 1;
            }
        }
        public IEnumerable<account> ListAll()
        {
            //IQueryable để truy vấn dữ liệu. Vể bản chất IQuery to hơn IEnum

            IQueryable<account> model = db.accounts;
            return model.OrderBy(x => x.username);
        }

        //IEnumerable chỉ là biến generic chỉ dùng để đọc dữ liệu
        public IEnumerable<account> ListAll(int page, int pageSize)
        {
            //IQueryable để truy vấn dữ liệu. Vể bản chất IQuery to hơn IEnum

            IQueryable<account> model = db.accounts;
            return model.OrderBy(x => x.username).ToPagedList(page, pageSize);
        }
        public IEnumerable<account> ListWhere(string keyword, int page, int pageSize)
        {
            IQueryable<account> model = db.accounts;
            if (!String.IsNullOrEmpty(keyword))
            {
                return model.Where(x => x.username.Contains(keyword)).OrderBy(x=>x.username).ToPagedList(page,pageSize);
            }

            return model.OrderBy(x=>x.username).ToPagedList(page,pageSize);
        }
        public string create(account account)
        {
            //kiểm tra duplicate
            var result = db.accounts.Where(x => x.username == account.username).SingleOrDefault();
            if (result == null)
            {
                db.accounts.Add(account);
                db.SaveChanges();
                return account.username;
            }
            return null;
        }
        public int Delete(string  username)
        {
            var result = db.accounts.Find(username);
            if (result == null)
            {
                return 0;
            }
            db.accounts.Remove(result);
            db.SaveChanges();
            return 1;
        }
        public int Edit(string username, string newPassword, string newRole)
        {
            var result = db.accounts.Find(username);
            if (result != null)
            {
                //code update db
                var account = new account();
                account.username = username;
                account.password = newPassword;
                account.role = newRole;
                db.accounts.Attach(account);
                db.Entry(account).State = EntityState.Modified;
                db.SaveChanges();
                return 1;
            }
            return 0;
        }
    }
}
