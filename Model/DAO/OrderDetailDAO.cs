using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;

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
        public IEnumerable<OrderDetail> ListAllPaging(int page = 1, int pageSize = 4)
        {
            return db.OrderDetails.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize);
        }
        public void changeStatus(long id , string status)
        {
            var model = db.OrderDetails.SingleOrDefault(x => x.ID_OrderDetail == id);
            model.Order.Status = status;
            db.SaveChanges();
        }
    }
}
