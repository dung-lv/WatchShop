using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class CategoryDAO
    {
        private WatchShopDBContext db = null;

        public CategoryDAO()
        {
            db = new WatchShopDBContext();
        }

        public List<Category> getAll()
        {
            return db.Categories.OrderBy(x => x.Name).ToList();
        }

        public Category getDetailCategory(long id)
        {
            return db.Categories.SingleOrDefault(x => x.ID_Category == id);
        }

        public Category getDetailCategoryByMetaTitle(string metatitle)
        {
            return db.Categories.SingleOrDefault(x => x.Metatitle == metatitle);
        }

        public Category getDetailCategoryByTrademark(long id)
        {
            Trademark trademark = db.Trademarks.SingleOrDefault(x => x.ID_Trademark == id);
            return db.Categories.SingleOrDefault(x => x.ID_Category == trademark.ID_Category);
        }
    }
}
