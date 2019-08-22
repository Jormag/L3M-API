using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Controllers
{

    public class WorkersOffice
    {
        public Worker[] Workers { get; set; }
    }

    public class Worker
    {
        public string Number { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string SecondSurname { get; set; }
        public string IdentifactionCard { get; set; }
        public string BirthDate { get; set; }
        public string AdmissionDate { get; set; }
        public string BranchOffice { get; set; }
        public string HourlyWage { get; set; }
    }


}
