using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class Worker
    {
        public string ID { get; set; }
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