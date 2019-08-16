using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{

    public class WorkingHour
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string FirstLastName { get; set; }
        public string SecondLastName { get; set; }
        public string WeeklyHours { get; set; }
        public string ExtraHours { get; set; }
    }

}
