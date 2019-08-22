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
using System.Text;

namespace WebApi.Controllers
{
    ///<summary>
    ///Controlador de Compras
    ///</summary>
    public class PurchaseController : ApiController
    {
        readonly string url = @"https://firebasestorage.googleapis.com/v0/b/l3mwebapidatabase.appspot.com/o/DataBase.json?alt=media&token=0b842b13-c1ac-4e2b-bf5d-b084c306fc7b";

        ///<summary>
        ///Permite consultar la lista de compras
        ///</summary>
        [HttpGet]
        public List<Purchase> Get()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())

            using (StreamReader jsonStream = new StreamReader(stream))
            {
                var json = jsonStream.ReadToEnd();
                DataBaseStruct list = JsonConvert.DeserializeObject<DataBaseStruct>(json);
                return list.Purchases;
            }
        }
        ///<summary>
        ///Permite consultar una compra especifica
        ///</summary>
        ///<param name="id"> Identificador de la compra </param>
        [HttpGet]
        public Purchase Get(string id)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())

            using (StreamReader jsonStream = new StreamReader(stream))
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
        ///<summary>
        ///Permite agregar compras a la lista
        ///</summary>
        ///<param name="description"> Descripcion de la compra </param>
        ///<param name="realDate"> Fecha real en que se realizo la compra </param>
        ///<param name="registrationDate"> Fecha de registro de la compra</param>
        ///<param name="supplier"> Proveedor de la compra</param>
        ///<param name="image"> Enlace de la imagen de la compra </param>
        ///<param name="branchOffice"> Sucursal en la que se realizo la compra </param>
        [HttpPost]
        public void Post(string description, string realDate, string registrationDate, string supplier, string image, string branchOffice)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())

            using (StreamReader jsonStream = new StreamReader(stream))
            {
                Random rnd = new Random();
                Purchase purchase = new Purchase
                {

                    ID = rnd.Next(0, 9999).ToString(),
                    Description = description,
                    RealDate = realDate,
                    RegistrationDate = registrationDate,
                    Supplier = supplier,
                    Image = image,
                    BranchOffice = branchOffice
                };

                var jsonOld = jsonStream.ReadToEnd();
                DataBaseStruct list = JsonConvert.DeserializeObject<DataBaseStruct>(jsonOld);
                list.Purchases.Add(purchase);

                //Serializar el json
                var request2 = (HttpWebRequest)WebRequest.Create(url);
                request2.Method = "POST";
                request2.ContentType = "application/json";
                request2.Timeout = 30000;

                string jsonNew = JsonConvert.SerializeObject(list);
                byte[] byteArray = Encoding.UTF8.GetBytes(jsonNew);
                request2.ContentLength = byteArray.Length;

                using (var dataStream = request2.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                }

                using (HttpWebResponse response3 = (HttpWebResponse)request2.GetResponse())
                {
                    using (Stream stream2 = response3.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(stream2))
                        {
                            string responseFromServer = reader.ReadToEnd();
                        }
                    }
                }
            }
        }
        ///<summary>
        ///Permite modificar compras de la lista
        ///</summary>
        ///<param name="id"> Identificador de la compra </param>
        ///<param name="description"> Descripcion de la compra </param>
        ///<param name="realDate"> Fecha real en que se realizo la compra </param>
        ///<param name="registrationDate"> Fecha de registro de la compra</param>
        ///<param name="supplier"> Proveedor de la compra</param>
        ///<param name="image"> Enlace de la imagen de la compra </param>
        ///<param name="branchOffice"> Sucursal en la que se realizo la compra </param>
        [HttpPut]
        public void Put(string id, string description, string realDate, string registrationDate, string supplier, string image, string branchOffice)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())

            using (StreamReader jsonStream = new StreamReader(stream))
            {
                var json = jsonStream.ReadToEnd();
                DataBaseStruct list = JsonConvert.DeserializeObject<DataBaseStruct>(json);
                int x = 0;
                while (x < list.Purchases.Count)
                {
                    if (string.Equals(list.Purchases[x].ID, id))
                    {
                        list.Purchases[x].Description = description;
                        list.Purchases[x].RealDate = realDate;
                        list.Purchases[x].RegistrationDate = registrationDate;
                        list.Purchases[x].Supplier = supplier;
                        list.Purchases[x].Image = image;
                        list.Purchases[x].BranchOffice = branchOffice;
                    }
                    x++;
                }

                //Serializar el json
                var request2 = (HttpWebRequest)WebRequest.Create(url);
                request2.Method = "POST";
                request2.ContentType = "application/json";
                request2.Timeout = 30000;

                string jsonNew = JsonConvert.SerializeObject(list);
                byte[] byteArray = Encoding.UTF8.GetBytes(jsonNew);
                request2.ContentLength = byteArray.Length;

                using (var dataStream = request2.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                }

                using (HttpWebResponse response3 = (HttpWebResponse)request2.GetResponse())
                {
                    using (Stream stream2 = response3.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(stream2))
                        {
                            string responseFromServer = reader.ReadToEnd();
                        }
                    }
                }
            }
        }
        ///<summary>
        ///Permite eliminar compras de la lista
        ///</summary>
        ///<param name="id"> Identificador de la compra </param>
        [HttpDelete]
        public void Delete(string id)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())

            using (StreamReader jsonStream = new StreamReader(stream))
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

                //Serializar el json
                var request2 = (HttpWebRequest)WebRequest.Create(url);
                request2.Method = "POST";
                request2.ContentType = "application/json";
                request2.Timeout = 30000;

                string jsonNew = JsonConvert.SerializeObject(list);
                byte[] byteArray = Encoding.UTF8.GetBytes(jsonNew);
                request2.ContentLength = byteArray.Length;

                using (var dataStream = request2.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                }

                using (HttpWebResponse response3 = (HttpWebResponse)request2.GetResponse())
                {
                    using (Stream stream2 = response3.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(stream2))
                        {
                            string responseFromServer = reader.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}
