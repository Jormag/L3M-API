using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class RolController : ApiController
    {
        readonly string url = "C:/Users/yenma/Downloads/II Semestre 2019/Bases de datos/WebApi/WebApi/WebApi/Data/DataBase.json";

        [HttpGet]
        public List<WorkRol> Get()
        {
            using (StreamReader jsonStream = File.OpenText(url))
            {
                var json = jsonStream.ReadToEnd();
                DataBaseStruct list = JsonConvert.DeserializeObject<DataBaseStruct>(json);
                return list.WorkRoles;
            }
        }

        [HttpGet]
        public WorkRol Get(string id)
        {
            using (StreamReader jsonStream = File.OpenText(url))
            {
                var json = jsonStream.ReadToEnd();
                DataBaseStruct list = JsonConvert.DeserializeObject<DataBaseStruct>(json);
                int x = 0;
                WorkRol workrol = new WorkRol();
                while (x < list.WorkRoles.Count)
                {
                    if (string.Equals(list.WorkRoles[x].ID, id))
                    {
                        workrol = list.WorkRoles[x];
                    }
                    x++;
                }

                return workrol;
            }
        }

        [HttpPost]
        public void Post(string name, string firstLastName, string secondLastName, string rol)
        {
            using (StreamReader jsonStream = File.OpenText(url))
            {
                WorkRol purchase = new WorkRol();
                Random rnd = new Random();
                purchase.ID = rnd.Next(0, 9999).ToString();
                purchase.Name = name;
                purchase.FirstLastName = firstLastName;
                purchase.SecondLastName = secondLastName;
                purchase.Rol = rol;

                var jsonOld = jsonStream.ReadToEnd();
                DataBaseStruct list = JsonConvert.DeserializeObject<DataBaseStruct>(jsonOld);
                list.WorkRoles.Add(purchase);
                string jsonNew = JsonConvert.SerializeObject(list);
                jsonStream.Close();
                System.IO.File.WriteAllText(url, jsonNew);
            }
        }

        [HttpPut]
        public void Put(string id, string name, string firstLastName, string secondLastName, string rol)
        {
            using (StreamReader jsonStream = File.OpenText(url))
            {
                var json = jsonStream.ReadToEnd();
                DataBaseStruct list = JsonConvert.DeserializeObject<DataBaseStruct>(json);
                int x = 0;
                while (x < list.WorkRoles.Count)
                {
                    if (string.Equals(list.WorkRoles[x].ID, id))
                    {
                        list.WorkRoles[x].Name = name;
                        list.WorkRoles[x].FirstLastName = firstLastName;
                        list.WorkRoles[x].SecondLastName = secondLastName;
                        list.WorkRoles[x].Rol = rol;
                    }
                    x++;
                }

                string jsonNew = JsonConvert.SerializeObject(list);
                jsonStream.Close();
                System.IO.File.WriteAllText(url, jsonNew);
            }
        }

        [HttpDelete]
        public void Delete(string id)
        {
            using (StreamReader jsonStream = File.OpenText(url))
            {
                var json = jsonStream.ReadToEnd();
                DataBaseStruct list = JsonConvert.DeserializeObject<DataBaseStruct>(json);
                int x = 0;
                while (x < list.WorkRoles.Count)
                {
                    if (string.Equals(list.WorkRoles[x].ID, id))
                    {
                        list.WorkRoles.RemoveAt(x);
                    }
                    x++;
                }

                string jsonNew = JsonConvert.SerializeObject(list);
                jsonStream.Close();
                System.IO.File.WriteAllText(url, jsonNew);
            }
        }
    }
}
