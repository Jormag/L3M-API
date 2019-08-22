using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Controllers
{


        public class AssignmentWorkingHours
        {
            public List<Workinghour> WorkingHours { get; set; }
        }

        public class Workinghour
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public string SecondSurname { get; set; }
            public string WeeklyHours { get; set; }
            public string ExtraHours { get; set; }
            public string Secondsurname { get; set; }
        }

    }




