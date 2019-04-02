using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.ViewModel
{
    public class CategoryTrademarkViewModel
    {
        public List<Category> listCategory { get; set; }
        public List<Trademark> listTrademark { get; set; }
    }
}
