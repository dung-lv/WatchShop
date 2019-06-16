using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using Model.ViewModel;
using System.IO;
using PagedList;

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
            return db.Products.OrderByDescending(x => x.CreateDate).Take(top).ToList();
        }

        public List<Product> getListProductByCategory(long CategoryID, int first, int maxResult, int priceFrom, int priceTo)
        {
            List<long> listtrademarkID = new List<long>();
            foreach (var trademark in db.Trademarks.Where(x => x.ID_Category == CategoryID).ToList())
            {
                listtrademarkID.Add(trademark.ID_Trademark);
            }
            if (maxResult == 0)
            {
                return db.Products.Where(x => listtrademarkID.Contains(x.ID_Trademark)).OrderByDescending(x => x.CreateDate).ToList();
            }
            else
            {
                if (priceTo != 0)
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

        public Product getDetailProductByMetaTitle(string metatitle)
        {
            return db.Products.SingleOrDefault(x => x.Metatitle == metatitle);
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

        public void UpdateProduct(ProductModel pro)
        {
            var entity = db.Products.Find(pro.ID_Product);
            entity.Name = pro.Name;
            entity.Price = pro.Price;
            entity.Quantity = pro.Quantity;
            //entity.Hot = pro.Hot;
            entity.Metatitle = pro.Metatitle;
            entity.Description = pro.Description;
            entity.Content = pro.Content;
            entity.ID_Trademark = pro.ID_Trademark;
            if (pro.ID_Promotion != 0)
            {
                entity.ID_Promotion = pro.ID_Promotion;
                entity.Discount = pro.Discount;
            }
            if (pro.Avatar != null)
            {
                entity.Avatar = pro.Avatar;
            }
            db.SaveChanges();
        }

        public List<string> ListName(string keyword)
        {
            return db.Products.Where(x => x.Name.Contains(keyword)).Select(x => x.Name).ToList();
        }

        public List<Product> FillData(int maxResult, int first, int priceFrom, int priceTo, string color, long id_trademark, long id_category, Boolean count)
        {
            //var query = db.Products.Where(x => x.Price > priceFrom);
            //if (priceTo > priceFrom)
            //{
            //    query = query.Where(x => x.Price < priceTo);
            //}
            //if (color != "All")
            //{
            //    query = query.Where(x => x.Color == color);
            //}
            //if (id_trademark != 1000)
            //{
            //    query = query.Where(x => x.ID_Trademark == id_trademark);
            //}
            //else
            //{
            //    List<long> listtrademarkID = new List<long>();
            //    foreach (var trademark in db.Trademarks.Where(x => x.ID_Category == id_category).ToList())
            //    {
            //        listtrademarkID.Add(trademark.ID_Trademark);
            //    }
            //    query = query.Where(x => listtrademarkID.Contains(x.ID_Trademark)).OrderByDescending(x => x.CreateDate).Skip(0);
            //}
            //return query.ToList();
            string sqlString = "SELECT * FROM Product AS p WHERE p.Price >= " + priceFrom;
            if (priceTo > priceFrom)
            {
                sqlString = sqlString + " and p.Price <= " + priceTo;
            }
            if (color != "All")
            {
                sqlString = sqlString + " and p.Color = N'" + color + "'";
            }
            if (id_trademark != 0)
            {
                sqlString = sqlString + " and p.ID_Trademark = " + id_trademark;
            }
            else
            {
                sqlString = sqlString + " and p.ID_Trademark in (SELECT ID_Trademark FROM Trademark AS t WHERE t.ID_Category = " + id_category + ")";
            }
            if (!count)
            {
                return db.Products.SqlQuery(sqlString).ToList<Product>().OrderByDescending(x => x.CreateDate).Skip(first).Take(maxResult).ToList();
            }
            else
            {
                return db.Products.SqlQuery(sqlString).ToList<Product>().OrderByDescending(x => x.CreateDate).ToList();
            }
        }

        public void updateProductForPayment(long id, int quantity)
        {
            var product = db.Products.SingleOrDefault(x => x.ID_Product == id);
            product.Quantity = product.Quantity - quantity;
            db.SaveChanges();
        }

        public IEnumerable<Product> ListAllPaging(string searchString, int page = 1, int pageSize = 4)
        {
            IQueryable<Product> model = db.Products;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString) || x.Name.Contains(searchString));
            }

            return model.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize);
            
        }
    }
}
