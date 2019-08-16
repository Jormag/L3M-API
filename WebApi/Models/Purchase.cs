using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class Purchase
    {
        public string ID { get; set; }
        public string Description { get; set; }
        public string RealDatePurchase { get; set; }
        public string RegistrationDatePurchase { get; set; }
        public string Provider { get; set; }
        public string PurchaseImage { get; set; }
        public string PurchaseRegistrationBranch { get; set; }
    }
}

