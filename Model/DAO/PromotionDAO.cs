using System.Linq;
using System.Collections.Generic;
using Model.EF;
using Model.ViewModel;
using System;

namespace Model.DAO
{
    public class PromotionDAO
    {
        private WatchShopDBContext db = null;

        public PromotionDAO()
        {
            db = new WatchShopDBContext();
        }

        public List<PromotionViewModel> getTopById(int id)
        {
            var model = from prom in db.Promotions
                        join prod in db.Products
                        on prom.ID_Promotion equals prod.ID_Promotion
                        where prom.ID_Promotion == id
                        select new PromotionViewModel()
                        {
                            ID_Promotion = prom.ID_Promotion,
                            ID_Product = prod.ID_Product,
                            NamePromotion = prom.Name,
                            StartTime = prom.StartTime,
                            EndTime = prom.EndTime,
                            Description = prom.Description,
                            Price = prod.Price,
                            Discount = prod.Discount,
                            Avatar = prod.Avatar,
                            NameProduct = prod.Name,
                            Metatitle = prod.Metatitle
                        };
            return model.Take(3).ToList();
        }

        public List<PromotionViewModel> getAllById(int id)
        {
            var model = from prom in db.Promotions
                        join prod in db.Products
                        on prom.ID_Promotion equals prod.ID_Promotion
                        where prom.ID_Promotion == id
                        select new PromotionViewModel()
                        {
                            ID_Promotion = prom.ID_Promotion,
                            NamePromotion = prom.Name,
                            StartTime = prom.StartTime,
                            EndTime = prom.EndTime,
                            Price = prod.Price,
                            Description = prom.Description,
                            Discount = prod.Discount,
                            Avatar = prod.Avatar,
                            NameProduct = prod.Name
                        };
            return model.ToList();
        }
    }
}
