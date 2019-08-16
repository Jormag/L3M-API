using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class DataBaseStruct
    {
        public List<Product> Products { get; set; }
        public List<Purchase> Purchases { get; set; }
        public List<WorkRol> WorkRoles { get; set; }
        public List<WorkingHour> WorkingHours { get; set; }
        public List<BranchOffice> BranchOffices { get; set; }
        public List<Worker> Workers { get; set; }
        public List<Suppliers> Suppliers { get; set; }
        public List<ExpenseBranch> ExpenseBranches { get; set; }
        public List<ProductList> ProductLists { get; set; }
        public List<ProductsBranch> ProductBranches { get; set; }

        


    }
}