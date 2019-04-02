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
    }
}
