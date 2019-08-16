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
    public class WorkersController : ApiController
    {
        readonly string url = "D:/Cristian/Documents/Proyectos Visual Studio/WebApi/WebApi/Data/DataBase.json";

        [HttpGet]
        public List<Worker> Get()
        {
            using (StreamReader jsonStream = File.OpenText(url))
            {
                var json = jsonStream.ReadToEnd();
                DataBaseStruct list = JsonConvert.DeserializeObject<DataBaseStruct>(json);
                return list.Workers;
            }
        }

        [HttpGet]
        public Worker Get(string id)
        {
            using (StreamReader jsonStream = File.OpenText(url))
            {
                var json = jsonStream.ReadToEnd();
                DataBaseStruct list = JsonConvert.DeserializeObject<DataBaseStruct>(json);
                int x = 0;
                Worker workers = new Worker();
                while (x < list.Workers.Count)
                {
                    if (string.Equals(list.Workers[x].ID, id))
                    {
                        workers = list.Workers[x];
                    }
                    x++;
                }

                return workers;
            }
        }

        [HttpPost]
        public void Post(string name, string surname, string secondSurname, string identifactionCard, string birthDate, string admissionDate, string branchOffice, string hourlyWage)
        {
            using (StreamReader jsonStream = File.OpenText(url))
            {
                Worker workers = new Worker();
                Random rnd = new Random();
                workers.ID = rnd.Next(0, 9999).ToString();
                workers.Name = name;
                workers.Surname = surname;
                workers.SecondSurname = secondSurname;
                workers.IdentifactionCard = identifactionCard;
                workers.BirthDate = birthDate;
                workers.AdmissionDate = admissionDate;
                workers.BranchOffice = branchOffice;
                workers.HourlyWage = hourlyWage;

                var jsonOld = jsonStream.ReadToEnd();
                DataBaseStruct list = JsonConvert.DeserializeObject<DataBaseStruct>(jsonOld);
                list.Workers.Add(workers);
                string jsonNew = JsonConvert.SerializeObject(list);
                jsonStream.Close();
                System.IO.File.WriteAllText(url, jsonNew);
            }
        }

        [HttpPut]
        public void Put(string id, string name, string surname, string secondSurname, string identifactionCard, string birthDate, string admissionDate, string branchOffice, string hourlyWage)
        {
            using (StreamReader jsonStream = File.OpenText(url))
            {
                var json = jsonStream.ReadToEnd();
                DataBaseStruct list = JsonConvert.DeserializeObject<DataBaseStruct>(json);
                int x = 0;
                while (x < list.Workers.Count)
                {
                    if (string.Equals(list.Workers[x].ID, id))
                    {
                        list.Workers[x].Name = name;
                        list.Workers[x].Surname = surname;
                        list.Workers[x].SecondSurname = secondSurname;
                        list.Workers[x].IdentifactionCard = identifactionCard;
                        list.Workers[x].BirthDate = birthDate;
                        list.Workers[x].AdmissionDate = admissionDate;
                        list.Workers[x].BranchOffice = branchOffice;
                        list.Workers[x].HourlyWage = hourlyWage;

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
                while (x < list.Workers.Count)
                {
                    if (string.Equals(list.Workers[x].ID, id))
                    {
                        list.Workers.RemoveAt(x);
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
