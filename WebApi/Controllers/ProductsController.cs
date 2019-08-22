using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class ProductsController : ApiController
    {

        readonly string url = "D:/Cristian/Documents/Proyectos Visual Studio/WebApi/WebApi/Data/DataBase.json";

        [HttpGet]
        public List<Product> Get()
        {
            using (StreamReader jsonStream = File.OpenText(url))
            {
                var json = jsonStream.ReadToEnd();
                DataBaseStruct list = JsonConvert.DeserializeObject<DataBaseStruct>(json);
                return list.Products;
            }
        }
        
        [HttpGet]
        public Product Get(string name)
        {
            using (StreamReader jsonStream = File.OpenText(url))
            {
                var json = jsonStream.ReadToEnd();
                DataBaseStruct list = JsonConvert.DeserializeObject<DataBaseStruct>(json);
                int x = 0;
                Product product = new Product();
                while (x < list.Products.Count)
                {
                    if (string.Equals(list.Products[x].Name, name)) 
                    {
                        product = list.Products[x];
                    }
                    x++;
                }
                
                return product;
            }
        }

        [HttpPost]
        public void Post(string name, int price, string description, string provider, int tax, int discount)
        {
            using (StreamReader jsonStream = File.OpenText(url))
            {
                Product product = new Product();
                Random rnd = new Random();
                product.ID = rnd.Next(0, 9999).ToString();
                product.Name = name;
                product.Price = price;
                product.Description = description;
                product.Provider = provider;
                product.Tax = tax;
                product.Discount = discount;

                var jsonOld = jsonStream.ReadToEnd();
                DataBaseStruct list = JsonConvert.DeserializeObject<DataBaseStruct>(jsonOld);
                list.Products.Add(product);
                string jsonNew = JsonConvert.SerializeObject(list);
                jsonStream.Close();
                System.IO.File.WriteAllText(url, jsonNew);
            }
        }

        [HttpPut]
        public void Put(string id, string name, int price, string description, string provider, int tax, int discount)
        {
            using (StreamReader jsonStream = File.OpenText(url))
            {
                var json = jsonStream.ReadToEnd();
                DataBaseStruct list = JsonConvert.DeserializeObject<DataBaseStruct>(json);
                int x = 0;
                while (x < list.Products.Count)
                {
                    if (string.Equals(list.Products[x].ID, id))
                    {
                        list.Products[x].Name = name;
                        list.Products[x].Price = price;
                        list.Products[x].Description = description;
                        list.Products[x].Provider = provider;
                        list.Products[x].Tax = tax;
                        list.Products[x].Discount = discount;
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
                while (x < list.Products.Count)
                {
                    if (string.Equals(list.Products[x].ID, id))
                    {
                        list.Products.RemoveAt(x);
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



