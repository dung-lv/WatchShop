using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.DAO
{
    public class OrderDAO
    {
        private WatchShopDBContext db = null;

        public OrderDAO()
        {
            db = new WatchShopDBContext();
        }

        public long InsertOrder(Order od)
        {
            db.Orders.Add(od);
            db.SaveChanges();
            return od.ID_Order;
        }
    }
}
