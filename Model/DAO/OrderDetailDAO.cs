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

        public List<OrderDetail> getOrderDetail(long id)
        {
            return db.OrderDetails.Where(x => x.ID_Order == id).ToList();
        }

        public IEnumerable<OrderDetail> ListAllPaging(String searchString, String status ,int page = 1, int pageSize = 4)
        {

            IQueryable<OrderDetail> model = db.OrderDetails;
            if (!string.IsNullOrEmpty(status) &&status !="AL")
            {
                model = model.Where(x => x.Order.Status == status);
            }
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Order.Name.Contains(searchString) || x.Order.Phone.Contains(searchString));
            }

            return model.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize);
        }

        public void changeStatus(long id , string status)
        {
            var model = db.OrderDetails.SingleOrDefault(x => x.ID_OrderDetail == id);
            model.Order.Status = status;
            db.SaveChanges();
        }
    }
}
