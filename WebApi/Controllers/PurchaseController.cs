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
    public class PurchaseController : ApiController
    {
        readonly string url = "D:/Cristian/Documents/Proyectos Visual Studio/WebApi/WebApi/Data/DataBase.json";

        [HttpGet]
        public List<Purchase> Get()
        {
            using (StreamReader jsonStream = File.OpenText(url))
            {
                var json = jsonStream.ReadToEnd();
                DataBaseStruct list = JsonConvert.DeserializeObject<DataBaseStruct>(json);
                return list.Purchases;
            }
        }

        [HttpGet]
        public Purchase Get(string id)
        {
            using (StreamReader jsonStream = File.OpenText(url))
            {
                var json = jsonStream.ReadToEnd();
                DataBaseStruct list = JsonConvert.DeserializeObject<DataBaseStruct>(json);
                int x = 0;
                Purchase purchase = new Purchase();
                while (x < list.Purchases.Count)
                {
                    if (string.Equals(list.Purchases[x].ID, id))
                    {
                        purchase = list.Purchases[x];
                    }
                    x++;
                }
                return purchase;
            }
        }

        [HttpPost]
        public void Post(string description, string realDatePurchase, string registrationDatePurchase, string provider, string image, string purchaseRegistrationBranch)
        {
            using (StreamReader jsonStream = File.OpenText(url))
            {
                Purchase purchase = new Purchase();
                Random rnd = new Random();
                purchase.ID = rnd.Next(0, 9999).ToString();
                purchase.Description = description;
                purchase.RealDatePurchase = realDatePurchase;
                purchase.RegistrationDatePurchase = registrationDatePurchase;
                purchase.Provider = provider;
                purchase.PurchaseImage = image;
                purchase.PurchaseRegistrationBranch = purchaseRegistrationBranch;

                var jsonOld = jsonStream.ReadToEnd();
                DataBaseStruct list = JsonConvert.DeserializeObject<DataBaseStruct>(jsonOld);
                list.Purchases.Add(purchase);
                string jsonNew = JsonConvert.SerializeObject(list);
                jsonStream.Close();
                System.IO.File.WriteAllText(url, jsonNew);
            }
        }

        [HttpPut]
        public void Put(string id, string description, string realDatePurchase, string registrationDatePurchase, string provider, string image, string purchaseRegistrationBranch)
        {
            using (StreamReader jsonStream = File.OpenText(url))
            {
                var json = jsonStream.ReadToEnd();
                DataBaseStruct list = JsonConvert.DeserializeObject<DataBaseStruct>(json);
                int x = 0;
                while (x < list.Purchases.Count)
                {
                    if (string.Equals(list.Purchases[x].ID, id))
                    {
                        list.Purchases[x].Description = description;
                        list.Purchases[x].RealDatePurchase = realDatePurchase;
                        list.Purchases[x].RegistrationDatePurchase = registrationDatePurchase;
                        list.Purchases[x].Provider = provider;
                        list.Purchases[x].PurchaseImage = image;
                        list.Purchases[x].PurchaseRegistrationBranch = purchaseRegistrationBranch;
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
                while (x < list.Purchases.Count)
                {
                    if (string.Equals(list.Purchases[x].ID, id))
                    {
                        list.Purchases.RemoveAt(x);
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
