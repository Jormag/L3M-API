using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Controllers
{

    public class ExpenseBranchOffice
    {
        public List<Expensebranch> ExpenseBranch { get; set; }
    }

    public class Expensebranch
    {
        public string Date { get; set; }
        public string Suppliers { get; set; }
        public string Description { get; set; }
        public string Payment { get; set; }
    }

}
