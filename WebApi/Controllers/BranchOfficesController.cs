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
    public class BranchOfficesController : ApiController
    {
        readonly string url = "D:/Cristian/Documents/Proyectos Visual Studio/WebApi/WebApi/Data/DataBase.json";

        [HttpGet]
        public List<BranchOffice> Get()
        {
            using (StreamReader jsonStream = File.OpenText(url))
            {
                var json = jsonStream.ReadToEnd();
                DataBaseStruct list = JsonConvert.DeserializeObject<DataBaseStruct>(json);
                return list.BranchOffices;
            }
        }

        [HttpGet]
        public BranchOffice Get(string id)
        {
            using (StreamReader jsonStream = File.OpenText(url))
            {
                var json = jsonStream.ReadToEnd();
                DataBaseStruct list = JsonConvert.DeserializeObject<DataBaseStruct>(json);
                int x = 0;
                BranchOffice BranchOffices = new BranchOffice();
                while (x < list.BranchOffices.Count)
                {
                    if (string.Equals(list.BranchOffices[x].ID, id))
                    {
                        BranchOffices = list.BranchOffices[x];
                    }
                    x++;
                }

                return BranchOffices;
            }
        }

        [HttpPost]
        public void Post(string branch, string address, string phone, string administrator)
        {
            using (StreamReader jsonStream = File.OpenText(url))
            {
                BranchOffice BranchOffices = new BranchOffice();
                Random rnd = new Random();
                BranchOffices.ID = rnd.Next(0, 9999).ToString();
                BranchOffices.Branch = branch;
                BranchOffices.Address = address;
                BranchOffices.Phone = phone;
                BranchOffices.Administrator = administrator;

                var jsonOld = jsonStream.ReadToEnd();
                DataBaseStruct list = JsonConvert.DeserializeObject<DataBaseStruct>(jsonOld);
                list.BranchOffices.Add(BranchOffices);
                string jsonNew = JsonConvert.SerializeObject(list);
                jsonStream.Close();
                System.IO.File.WriteAllText(url, jsonNew);
            }
        }

        [HttpPut]
        public void Put(string id, string branch, string address, string phone, string administrator)
        {
            using (StreamReader jsonStream = File.OpenText(url))
            {
                var json = jsonStream.ReadToEnd();
                DataBaseStruct list = JsonConvert.DeserializeObject<DataBaseStruct>(json);
                int x = 0;
                while (x < list.BranchOffices.Count)
                {
                    if (string.Equals(list.BranchOffices[x].ID, id))
                    {
                        list.BranchOffices[x].Branch = branch;
                        list.BranchOffices[x].Address = address;
                        list.BranchOffices[x].Phone = phone;
                        list.BranchOffices[x].Administrator = administrator;
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
                while (x < list.BranchOffices.Count)
                {
                    if (string.Equals(list.BranchOffices[x].ID, id))
                    {
                        list.BranchOffices.RemoveAt(x);
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
