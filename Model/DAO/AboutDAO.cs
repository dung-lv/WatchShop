using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class AboutDAO
    {
        private WatchShopDBContext db = null;

        public AboutDAO()
        {
            db = new WatchShopDBContext();
        }

        public About getAbout()
        {
            return db.Abouts.SingleOrDefault();
        }
    }
}
