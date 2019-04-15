using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class ContactDAO
    {
        private WatchShopDBContext db = null;

        public ContactDAO()
        {
            db = new WatchShopDBContext();
        }

        public Contact getContact()
        {
            return db.Contacts.SingleOrDefault();
        }
    }
}
