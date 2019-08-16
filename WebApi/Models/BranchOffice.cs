using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class BranchOffice
    {
        public string ID { get; set; }
        public string Branch { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Administrator { get; set; }

    }
}