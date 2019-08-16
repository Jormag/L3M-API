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
    public class ExpenseBranchesController : ApiController
    {
        readonly string url = "D:/Cristian/Documents/Proyectos Visual Studio/WebApi/WebApi/Data/DataBase.json";

        [HttpGet]
        public List<ExpenseBranch> Get()
        {
            using (StreamReader jsonStream = File.OpenText(url))
            {
                var json = jsonStream.ReadToEnd();
                DataBaseStruct list = JsonConvert.DeserializeObject<DataBaseStruct>(json);
                return list.ExpenseBranches;
            }
        }

        [HttpGet]
        public ExpenseBranch Get(string id)
        {
            using (StreamReader jsonStream = File.OpenText(url))
            {
                var json = jsonStream.ReadToEnd();
                DataBaseStruct list = JsonConvert.DeserializeObject<DataBaseStruct>(json);
                int x = 0;
                ExpenseBranch expenseBranch = new ExpenseBranch();
                while (x < list.ExpenseBranches.Count)
                {
                    if (string.Equals(list.ExpenseBranches[x].ID, id))
                    {
                        expenseBranch = list.ExpenseBranches[x];
                    }
                    x++;
                }
                return expenseBranch;
            }
        }

        [HttpPost]
        public void Post(string date, string suppliers, string description, string payment)
        {
            using (StreamReader jsonStream = File.OpenText(url))
            {
                ExpenseBranch expenseBranch = new ExpenseBranch();
                Random rnd = new Random();
                expenseBranch.ID = rnd.Next(0, 9999).ToString();
                expenseBranch.Date = date;
                expenseBranch.Suppliers = suppliers;
                expenseBranch.Description = description;
                expenseBranch.Payment = payment;
               
                var jsonOld = jsonStream.ReadToEnd();
                DataBaseStruct list = JsonConvert.DeserializeObject<DataBaseStruct>(jsonOld);
                list.ExpenseBranches.Add(expenseBranch);
                string jsonNew = JsonConvert.SerializeObject(list);
                jsonStream.Close();
                System.IO.File.WriteAllText(url, jsonNew);
            }
        }

        [HttpPut]
        public void Put(string id, string date, string suppliers, string description, string payment)
        {
            using (StreamReader jsonStream = File.OpenText(url))
            {
                var json = jsonStream.ReadToEnd();
                DataBaseStruct list = JsonConvert.DeserializeObject<DataBaseStruct>(json);
                int x = 0;
                while (x < list.ExpenseBranches.Count)
                {
                    if (string.Equals(list.ExpenseBranches[x].ID, id))
                    {
                        list.ExpenseBranches[x].Date = date;
                        list.ExpenseBranches[x].Suppliers = suppliers;
                        list.ExpenseBranches[x].Description = description;
                        list.ExpenseBranches[x].Payment = payment;
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
                while (x < list.ExpenseBranches.Count)
                {
                    if (string.Equals(list.ExpenseBranches[x].ID, id))
                    {
                        list.ExpenseBranches.RemoveAt(x);
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
