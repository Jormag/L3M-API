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
    public class WorkingHoursController : ApiController
    {
        readonly string url = "D:/Cristian/Documents/Proyectos Visual Studio/WebApi/WebApi/Data/DataBase.json";

        [HttpGet]
        public List<Workinghour> Get()
        {
            using (StreamReader jsonStream = File.OpenText(url))
            {
                var json = jsonStream.ReadToEnd();
                DataBaseStruct list = JsonConvert.DeserializeObject<DataBaseStruct>(json);
                return list.WorkingHours;
            }
        }

        [HttpGet]
        public Workinghour Get(string id)
        {
            using (StreamReader jsonStream = File.OpenText(url))
            {
                var json = jsonStream.ReadToEnd();
                DataBaseStruct list = JsonConvert.DeserializeObject<DataBaseStruct>(json);
                int x = 0;
                Workinghour workinghours = new Workinghour();
                while (x < list.WorkingHours.Count)
                {
                    if (string.Equals(list.WorkingHours[x].ID, id))
                    {
                        workinghours = list.WorkingHours[x];
                    }
                    x++;
                }

                return workinghours;
            }
        }

        [HttpPost]
        public void Post(string name, string firstLastName, string secondLastName, string weeklyHours, string extraHours)
        {
            using (StreamReader jsonStream = File.OpenText(url))
            {
                Workinghour workinghours = new Workinghour();
                Random rnd = new Random();
                workinghours.ID = rnd.Next(0, 9999).ToString();
                workinghours.Name = name;
                workinghours.FirstLastName = firstLastName;
                workinghours.SecondLastName = secondLastName;
                workinghours.WeeklyHours = weeklyHours;
                workinghours.ExtraHours = extraHours;

                var jsonOld = jsonStream.ReadToEnd();
                DataBaseStruct list = JsonConvert.DeserializeObject<DataBaseStruct>(jsonOld);
                list.WorkingHours.Add(workinghours);
                string jsonNew = JsonConvert.SerializeObject(list);
                jsonStream.Close();
                System.IO.File.WriteAllText(url, jsonNew);
            }
        }

        [HttpPut]
        public void Put(string id, string name, string firstLastName, string secondLastName, string weeklyHours, string extraHours)
        {
            using (StreamReader jsonStream = File.OpenText(url))
            {
                var json = jsonStream.ReadToEnd();
                DataBaseStruct list = JsonConvert.DeserializeObject<DataBaseStruct>(json);
                int x = 0;
                while (x < list.WorkingHours.Count)
                {
                    if (string.Equals(list.WorkingHours[x].ID, id))
                    {
                        list.WorkingHours[x].Name = name;
                        list.WorkingHours[x].FirstLastName = firstLastName;
                        list.WorkingHours[x].SecondLastName = secondLastName;
                        list.WorkingHours[x].WeeklyHours = weeklyHours;
                        list.WorkingHours[x].ExtraHours = extraHours;
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
                while (x < list.WorkingHours.Count)
                {
                    if (string.Equals(list.WorkingHours[x].ID, id))
                    {
                        list.WorkingHours.RemoveAt(x);
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
