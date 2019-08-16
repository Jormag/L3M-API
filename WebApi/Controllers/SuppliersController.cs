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
    public class SuppliersController : ApiController
    {
        readonly string url = "D:/Cristian/Documents/Proyectos Visual Studio/WebApi/WebApi/Data/DataBase.json";

        [HttpGet]
        public List<Suppliers> Get()
        {
            using (StreamReader jsonStream = File.OpenText(url))
            {
                var json = jsonStream.ReadToEnd();
                DataBaseStruct list = JsonConvert.DeserializeObject<DataBaseStruct>(json);
                return list.Suppliers;
            }
        }

        [HttpGet]
        public Suppliers Get(string id)
        {
            using (StreamReader jsonStream = File.OpenText(url))
            {
                var json = jsonStream.ReadToEnd();
                DataBaseStruct list = JsonConvert.DeserializeObject<DataBaseStruct>(json);
                int x = 0;
                Suppliers Suppliers = new Suppliers();
                while (x < list.Suppliers.Count)
                {
                    if (string.Equals(list.Suppliers[x].ID, id))
                    {
                        Suppliers = list.Suppliers[x];
                    }
                    x++;
                }

                return Suppliers;
            }
        }

        [HttpPost]
        public void Post(string supplier, string identificationCard)
        {
            using (StreamReader jsonStream = File.OpenText(url))
            {
                Suppliers Suppliers = new Suppliers();
                Random rnd = new Random();
                Suppliers.ID = rnd.Next(0, 9999).ToString();
                Suppliers.Supplier = supplier;
                Suppliers.IdentificationCard = identificationCard;


                var jsonOld = jsonStream.ReadToEnd();
                DataBaseStruct list = JsonConvert.DeserializeObject<DataBaseStruct>(jsonOld);
                list.Suppliers.Add(Suppliers);
                string jsonNew = JsonConvert.SerializeObject(list);
                jsonStream.Close();
                System.IO.File.WriteAllText(url, jsonNew);
            }
        }

        [HttpPut]
        public void Put(string id, string supplier, string identificationCard)
        {
            using (StreamReader jsonStream = File.OpenText(url))
            {
                var json = jsonStream.ReadToEnd();
                DataBaseStruct list = JsonConvert.DeserializeObject<DataBaseStruct>(json);
                int x = 0;
                while (x < list.Suppliers.Count)
                {
                    if (string.Equals(list.Suppliers[x].ID, id))
                    {
                        list.Suppliers[x].Supplier = supplier;
                        list.Suppliers[x].IdentificationCard = identificationCard;

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
                while (x < list.Suppliers.Count)
                {
                    if (string.Equals(list.Suppliers[x].ID, id))
                    {
                        list.Suppliers.RemoveAt(x);
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
