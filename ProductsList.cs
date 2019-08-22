using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Controllers
{

    public class ProductLists
    {
        public List<Productlist> ProductList { get; set; }
    }

    public class Productlist
    {
        public string Product { get; set; }
        public string CostProduct { get; set; }
        public string Existence { get; set; }
    }

}
