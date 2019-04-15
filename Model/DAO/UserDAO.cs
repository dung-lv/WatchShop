using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
namespace Model.DAO
{
    public class UserDAO
    {
        private WatchShopDBContext db = null;

        public UserDAO()
        {
            db = new WatchShopDBContext();
        }

        public long Insert(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.ID_Login;

        }

        public User GetUserById(Login login)
        {
            return db.Users.SingleOrDefault(x => x.ID_Login == login.ID_Login);
        }

        public Login Login(string username, string password)
        {
            return db.Logins.SingleOrDefault(x => x.Username == username && x.Password == password); ;
        }
    }
}
