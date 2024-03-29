﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;
namespace Model.DAO
{
    public class TrademarkDAO
    {
        private WatchShopDBContext db = null;

        public TrademarkDAO()
        {
            db = new WatchShopDBContext();
        }

        public List<Trademark> getAll()
        {
            return db.Trademarks.OrderBy(x => x.Name).ToList();
        }

        public List<Trademark> getListTrademarkByCategory(long id)
        {
            return db.Trademarks.Where(x => x.ID_Category == id).ToList();
        }

        public Trademark getDetailTrademark(long id)
        {
            return db.Trademarks.SingleOrDefault(x => x.ID_Trademark == id);
        }

        public Trademark getDetailTrademarkByMetatitle(string metatitle)
        {
            return db.Trademarks.SingleOrDefault(x => x.Metatitle == metatitle);
        }

        public IEnumerable<Trademark> ListAllPaging(int page = 1, int pageSize = 4)
        {
            return db.Trademarks.OrderByDescending(x => x.Name).ToPagedList(page, pageSize);
        }
    }
}
