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

        public List<Product> getListProductHot(int top)
        {
            return db.Products.Where(x => x.Hot == true).OrderByDescending(x => x.CreateDate).Take(top).ToList();
        }

        public List<Product> getListProductByCategory(long CategoryID, int first, int maxResult, int priceFrom, int priceTo)
        {
            List<long> listtrademarkID = new List<long>();
            foreach (var trademark in db.Trademarks.Where(x => x.ID_Category == CategoryID).ToList())
            {
                listtrademarkID.Add(trademark.ID_Trademark);
            }
            if(maxResult == 0)
            {
                return db.Products.Where(x => listtrademarkID.Contains(x.ID_Trademark)).OrderByDescending(x => x.CreateDate).ToList();
            }
            else
            {
                if(priceTo != 0)
                {
                    return db.Products.Where(x => listtrademarkID.Contains(x.ID_Trademark) && x.Price >= priceFrom && x.Price <= priceTo).OrderByDescending(x => x.CreateDate).Skip(first).Take(maxResult).ToList();
                }
                else
                {
                    return db.Products.Where(x => listtrademarkID.Contains(x.ID_Trademark)).OrderByDescending(x => x.CreateDate).Skip(first).Take(maxResult).ToList();
                }
            }
        }

        public List<Product> getListProductByTrademark(long trademarkID, int first, int maxResult, int priceFrom, int priceTo)
        {
            if (maxResult == 0)
            {
                return db.Products.Where(x => x.ID_Trademark == trademarkID).OrderByDescending(x => x.CreateDate).ToList();
            }
            else
            {
                if (priceTo != 0)
                {
                    return db.Products.Where(x => x.ID_Trademark == trademarkID && x.Price >= priceFrom && x.Price <= priceTo).OrderByDescending(x => x.CreateDate).Skip(first).Take(maxResult).ToList();
                }
                else
                {
                    return db.Products.Where(x => x.ID_Trademark == trademarkID).OrderByDescending(x => x.CreateDate).Skip(first).Take(maxResult).ToList();
                }
            }
        }

        public Product getDetailProductById(long productID)
        {
            return db.Products.SingleOrDefault(x => x.ID_Product == productID);
        }

        public Product getDetailProductByName(string name)
        {
            return db.Products.SingleOrDefault(x => x.Name == name);
        }

        public long InsertProduct(Product pro)
        {
            db.Products.Add(pro);
            db.SaveChanges();
            return pro.ID_Product;
        }

        public void DeleteProduct(long id)
        {
            Product pro = db.Products.Find(id);
            db.Products.Remove(pro);
            db.SaveChanges();
        }

        public List<string> ListName(string keyword)
        {
            return db.Products.Where(x => x.Name.Contains(keyword)).Select(x => x.Name).ToList();
        }
    }
}
