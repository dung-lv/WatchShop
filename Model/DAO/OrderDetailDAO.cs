using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.DAO
{
    public class OrderDetailDAO
    {
        private WatchShopDBContext db = null;

        public OrderDetailDAO()
        {
            db = new WatchShopDBContext();
        }

        public void InsertOrderDetail(OrderDetail od)
        {
            db.OrderDetails.Add(od);
            db.SaveChanges();
        }
    }
}
