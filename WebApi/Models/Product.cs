using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class Product
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string Provider { get; set; }
        public int Tax { get; set; }
        public int Discount { get; set; }
    }

}
