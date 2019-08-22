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
    public class ProductListController : ApiController
    {
        readonly string url = "C:/Users/yenma/Downloads/II Semestre 2019/Bases de datos/WebApi/WebApi/WebApi/Data/DataBase.json";

        [HttpGet]
        public List<ProductList> Get()
        {
            using (StreamReader jsonStream = File.OpenText(url))
            {
                var json = jsonStream.ReadToEnd();
                DataBaseStruct list = JsonConvert.DeserializeObject<DataBaseStruct>(json);
                return list.ProductLists;
            }
        }

        [HttpGet]
        public ProductList Get(string id)
        {
            using (StreamReader jsonStream = File.OpenText(url))
            {
                var json = jsonStream.ReadToEnd();
                DataBaseStruct list = JsonConvert.DeserializeObject<DataBaseStruct>(json);
                int x = 0;
                ProductList ProductLists = new ProductList();
                while (x < list.ProductLists.Count)
                {
                    if (string.Equals(list.ProductLists[x].ID, id))
                    {
                        ProductLists = list.ProductLists[x];
                    }
                    x++;
                }

                return ProductLists;
            }
        }

        [HttpPost]
        public void Post(string product, string costProduct, string existence)
        {
            using (StreamReader jsonStream = File.OpenText(url))
            {
                ProductList ProductLists = new ProductList();
                Random rnd = new Random();
                ProductLists.ID = rnd.Next(0, 9999).ToString();
                ProductLists.Product = product;
                ProductLists.CostProduct = costProduct;
                ProductLists.Existence = existence;
                

                var jsonOld = jsonStream.ReadToEnd();
                DataBaseStruct list = JsonConvert.DeserializeObject<DataBaseStruct>(jsonOld);
                list.ProductLists.Add(ProductLists);
                string jsonNew = JsonConvert.SerializeObject(list);
                jsonStream.Close();
                System.IO.File.WriteAllText(url, jsonNew);
            }
        }

        [HttpPut]
        public void Put(string id, string product, string costProduct, string existence)
        {
            using (StreamReader jsonStream = File.OpenText(url))
            {
                var json = jsonStream.ReadToEnd();
                DataBaseStruct list = JsonConvert.DeserializeObject<DataBaseStruct>(json);
                int x = 0;
                while (x < list.ProductLists.Count)
                {
                    if (string.Equals(list.ProductLists[x].ID, id))
                    {
                        list.ProductLists[x].Product = product;
                        list.ProductLists[x].CostProduct = costProduct;
                        list.ProductLists[x].Existence = existence;
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
                while (x < list.ProductLists.Count)
                {
                    if (string.Equals(list.ProductLists[x].ID, id))
                    {
                        list.ProductLists.RemoveAt(x);
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
