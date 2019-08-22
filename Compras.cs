using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Controllers
{
    
        public class Compras
        {
            public Purchase[] Purchases { get; set; }
        }

        public class Purchase
        {
            public string Description { get; set; }
            public string RealDatePurchase { get; set; }
            public string RegistrationDatePurchase { get; set; }
            public string Provider { get; set; }
            public string PurchaseImage { get; set; }
            public string PurchaseRegistrationBranch { get; set; }
        }

    }

