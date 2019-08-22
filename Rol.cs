using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Controllers
{

    public class Rol
    {
        public WorkRol[] Roles { get; set; }
    }

    public class WorkRol
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Rol { get; set; }
    }

}
