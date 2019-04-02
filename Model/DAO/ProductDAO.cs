using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.DAO
{
    public class ProductDAO
    {
        private WatchShopDBContext db = null;

        public ProductDAO()
        {
            db = new WatchShopDBContext();
        }
        
        public List<Product> getAll()
        {
            return db.Products.ToList();
        }

        public List<Product> getListProductByHot(int top)
        {
            return db.Products.Where(x => x.Hot == true).OrderByDescending(x => x.CreateDate).Take(top).ToList();
        }

        public List<Product> getListProductByTrademark(int trademarkID, int top)
        {
            return db.Products.Where(x => x.ID_Trademark == trademarkID).OrderByDescending(x => x.CreateDate).Take(top).ToList();
        }

        public Product getDetailProduct(int productID)
        {
            return db.Products.Where(x => x.ID_Product == productID).Single();
        }
    }
}
