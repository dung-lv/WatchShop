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

        public Order getOrder(long id)
        {
            return db.Orders.SingleOrDefault(x => x.ID_Order == id);
        }

        public void UpdateOrder(Order o)
        {
            var entity = db.Orders.SingleOrDefault(x => x.ID_Order == o.ID_Order);
            entity.Name = o.Name;
            entity.Email = o.Email;
            entity.Phone = o.Phone;
            entity.Address = o.Address;
            entity.CreateDate = o.CreateDate;
            entity.Note = o.Note;
            db.SaveChanges();
        }
    }
}
