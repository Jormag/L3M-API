using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Controllers
{

    public class ProductsBranchOffice
    {
        public List<Productsbranch> ProductsBranch { get; set; }
    }

    public class Productsbranch
    {
        public string Product { get; set; }
        public string Description { get; set; }
        public string CostProduct { get; set; }
        public string Existence { get; set; }
    }

}
