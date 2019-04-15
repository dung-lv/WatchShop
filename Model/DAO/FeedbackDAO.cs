using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class FeedbackDAO
    {
        private WatchShopDBContext db = null;
        public FeedbackDAO()
        {
            db = new WatchShopDBContext();
        }

        public long InsertFeedback(Feedback fd)
        {
            db.Feedbacks.Add(fd);
            db.SaveChanges();
            return fd.ID_Feedback;
        }
    }
}
