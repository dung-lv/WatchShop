using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
    public class PromotionViewModel
    {
        public long ID_Promotion { get; set; }

        public long ID_Product { get; set; }

        public string NamePromotion { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public string Description { get; set; }

        public decimal? Price { get; set; }

        public decimal? Discount { get; set; }

        public string Avatar { get; set; }

        public string NameProduct { get; set; }

        public string Metatitle { get; set; }
    }
}