using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Controllers
{

    public class Dealer
    {
        public List<SupplierA> Suppliers { get; set; }
    }

    public class SupplierA
    {
        public string Number { get; set; }
        public string Supplier { get; set; }
        public string IdentificationCard { get; set; }
    }

}
