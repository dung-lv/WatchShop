using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Model.ViewModel
{
    public class ProductModel
    {
        public long ID_Product { get; set; }

        public string Name { get; set; }

        public decimal? Price { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        public string Avatar { get; set; }

        public int Quantity { get; set; }

        public bool Hot { get; set; }

        public decimal? Discount { get; set; }

        public string Metatitle { get; set; }

        public DateTime? CreateDate { get; set; }

        public long ID_Trademark { get; set; }

        public long ID_Promotion { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }
    }
}
