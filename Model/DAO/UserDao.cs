using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
namespace Model.DAO
{
    public class UserDao
    {
        WatchShopDBContext db = null;
        public UserDao()
        {
            db = new WatchShopDBContext();
        }
        public long Insert(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.ID_Login;

        }
        public Login GetUserByID(string userName)
        {
            return db.Logins.SingleOrDefault(x => x.Username == userName);
        }
        public bool Login(string username, string password)
        {
            var result = db.Logins.Count(x => x.Username == username && x.Password == password);
            if (result > 0)
            {
                return true;
            }
            return false;
        }
    }
}
