using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Controllers
{

    public class AssignmentWorkingHours
    {
        public Workinghours[] WorkingHours { get; set; }
    }

    public class Workinghours
    {
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string WeeklyHours { get; set; }
        public string ExtraHours { get; set; }
    }

}
