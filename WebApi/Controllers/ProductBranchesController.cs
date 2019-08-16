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
    public class ProductBranchesController : ApiController
    {
        readonly string url = "D:/Cristian/Documents/Proyectos Visual Studio/WebApi/WebApi/Data/DataBase.json";

        [HttpGet]
        public List<ProductsBranch> Get()
        {
            using (StreamReader jsonStream = File.OpenText(url))
            {
                var json = jsonStream.ReadToEnd();
                DataBaseStruct list = JsonConvert.DeserializeObject<DataBaseStruct>(json);
                return list.ProductBranches;
            }
        }

        [HttpGet]
        public ProductsBranch Get(string id)
        {
            using (StreamReader jsonStream = File.OpenText(url))
            {
                var json = jsonStream.ReadToEnd();
                DataBaseStruct list = JsonConvert.DeserializeObject<DataBaseStruct>(json);
                int x = 0;
                ProductsBranch productsBranch = new ProductsBranch();
                while (x < list.ExpenseBranches.Count)
                {
                    if (string.Equals(list.ExpenseBranches[x].ID, id))
                    {
                        productsBranch = list.ProductBranches[x];
                    }
                    x++;
                }
                return productsBranch;
            }
        }

        [HttpPost]
        public void Post(string product, string description, string costProduct, string existence)
        {
            using (StreamReader jsonStream = File.OpenText(url))
            {
                ProductsBranch productsBranch = new ProductsBranch();
                Random rnd = new Random();
                productsBranch.ID = rnd.Next(0, 9999).ToString();
                productsBranch.Product = product;
                productsBranch.Description = description;
                productsBranch.CostProduct = costProduct;
                productsBranch.Existence = existence;

                var jsonOld = jsonStream.ReadToEnd();
                DataBaseStruct list = JsonConvert.DeserializeObject<DataBaseStruct>(jsonOld);
                list.ProductBranches.Add(productsBranch);
                string jsonNew = JsonConvert.SerializeObject(list);
                jsonStream.Close();
                System.IO.File.WriteAllText(url, jsonNew);
            }
        }

        [HttpPut]
        public void Put(string id, string product, string description, string costProduct, string existence)
        {
            using (StreamReader jsonStream = File.OpenText(url))
            {
                var json = jsonStream.ReadToEnd();
                DataBaseStruct list = JsonConvert.DeserializeObject<DataBaseStruct>(json);
                int x = 0;
                while (x < list.ProductBranches.Count)
                {
                    if (string.Equals(list.ProductBranches[x].ID, id))
                    {
                        list.ProductBranches[x].Product = product;
                        list.ProductBranches[x].Description = description;
                        list.ProductBranches[x].CostProduct = costProduct;
                        list.ProductBranches[x].Existence = existence;
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
                while (x < list.ProductBranches.Count)
                {
                    if (string.Equals(list.ProductBranches[x].ID, id))
                    {
                        list.ProductBranches.RemoveAt(x);
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
