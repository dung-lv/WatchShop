using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.DAO
{
    public class TrademarkDAO
    {
        private WatchShopDBContext db = null;

        public TrademarkDAO()
        {
            db = new WatchShopDBContext();
        }

        public List<Trademark> getAll()
        {
            return db.Trademarks.OrderBy(x => x.Name).ToList();
        }
    }
}
