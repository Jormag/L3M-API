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
    ///Controlador de proveedores
    ///</summary>
    public class SuppliersController : ApiController
    {
        readonly string url = @"https://firebasestorage.googleapis.com/v0/b/l3mwebapidatabase.appspot.com/o/DataBase.json?alt=media&token=0b842b13-c1ac-4e2b-bf5d-b084c306fc7b";

        ///<summary>
        ///Permite consultar la lista de proveedores
        ///</summary>
        [HttpGet]
        public List<Supplier> Get()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())

            using (StreamReader jsonStream = new StreamReader(stream))
            {
                var json = jsonStream.ReadToEnd();
                DataBaseStruct list = JsonConvert.DeserializeObject<DataBaseStruct>(json);
                return list.Suppliers;
            }
        }
        ///<summary>
        ///Permite consultar un proveedor especifico de la lista
        ///</summary>
        ///<param name="identificationCard"> Numero de cedula del proveedor</param>
        [HttpGet]
        public Supplier Get(string identificationCard)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())

            using (StreamReader jsonStream = new StreamReader(stream))
            {
                var json = jsonStream.ReadToEnd();
                DataBaseStruct list = JsonConvert.DeserializeObject<DataBaseStruct>(json);
                int x = 0;
                Supplier Suppliers = new Supplier();
                while (x < list.Suppliers.Count)
                {
                    if (string.Equals(list.Suppliers[x].IdentificationCard, identificationCard))
                    {
                        Suppliers = list.Suppliers[x];
                    }
                    x++;
                }

                return Suppliers;
            }
        }
        ///<summary>
        ///Permite agregar un proveedor nuevo a la lista
        ///</summary>
        ///<param name="identificationCard"> Numero de cedula del proveedor</param>
        ///<param name="name"> Nombre del proveedor </param>
        [HttpPost]
        public void Post(string identificationCard, string name)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())

            using (StreamReader jsonStream = new StreamReader(stream))
            {
                Supplier Suppliers = new Supplier
                {
                    IdentificationCard = identificationCard,
                    Name = name
                };


                var jsonOld = jsonStream.ReadToEnd();
                DataBaseStruct list = JsonConvert.DeserializeObject<DataBaseStruct>(jsonOld);
                list.Suppliers.Add(Suppliers);

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
        ///Permite modificar la informacion de un proveedor de la lista
        ///</summary>
        ///<param name="identificationCard"> Numero de cedula del proveedor</param>
        ///<param name="name"> Nombre del proveedor </param>
        [HttpPut]
        public void Put(string identificationCard, string name)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())

            using (StreamReader jsonStream = new StreamReader(stream))
            {
                var json = jsonStream.ReadToEnd();
                DataBaseStruct list = JsonConvert.DeserializeObject<DataBaseStruct>(json);
                int x = 0;
                while (x < list.Suppliers.Count)
                {
                    if (string.Equals(list.Suppliers[x].IdentificationCard, identificationCard))
                    {
                        list.Suppliers[x].IdentificationCard = identificationCard;
                        list.Suppliers[x].Name = name;
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
        ///Permite eliminar un proveedor de la lista
        ///</summary>
        ///<param name="identificationCard"> Numero de cedula del proveedor</param>
        [HttpDelete]
        public void Delete(string identificationCard)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())

            using (StreamReader jsonStream = new StreamReader(stream))
            {
                var json = jsonStream.ReadToEnd();
                DataBaseStruct list = JsonConvert.DeserializeObject<DataBaseStruct>(json);
                int x = 0;
                while (x < list.Suppliers.Count)
                {
                    if (string.Equals(list.Suppliers[x].IdentificationCard, identificationCard))
                    {
                        list.Suppliers.RemoveAt(x);
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
