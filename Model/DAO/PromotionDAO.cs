using System.Linq;
using System.Collections.Generic;
using Model.EF;
using Model.ViewModel;
using System;
using PagedList;


namespace Model.DAO
{
    public class PromotionDAO
    {
        private WatchShopDBContext db = null;

        public PromotionDAO()
        {
            db = new WatchShopDBContext();
        }

        public List<Promotion> getNewPromotions()
        {
            return db.Promotions.Where(x => x.EndTime > DateTime.Now).OrderByDescending(x => x.StartTime).ToList();
        }

        public Promotion getPromotionById(long promotionID)
        {
            return db.Promotions.SingleOrDefault(x => x.ID_Promotion == promotionID);
        }

        public List<PromotionViewModel> getPromotionProduct(long promotionID, int top)
        {
            var model = from prom in db.Promotions
                        join prod in db.Products
                        on prom.ID_Promotion equals prod.ID_Promotion
                        where prom.ID_Promotion == promotionID
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
            if(top != 0)
            {
                return model.Take(top).ToList();
            }
            else
            {
                return model.ToList();
            }    
        }
        public IEnumerable<Promotion> ListAllPaging(int page = 1, int pageSize = 4)
        {
            return db.Promotions.OrderByDescending(x => x.Name).ToPagedList(page, pageSize);
        }

        public bool Insert(Promotion promotion)
        {
            try
            {
                db.Promotions.Add(promotion);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }



        }
    }
}
