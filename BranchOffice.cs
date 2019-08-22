using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Controllers
{

    public class Branch
    {
        public List<Branchoffice> BranchOffices { get; set; }
    }

    public class Branchoffice
    {
        public string Number { get; set; }
        public string Branch { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Administrator { get; set; }
    }

}
