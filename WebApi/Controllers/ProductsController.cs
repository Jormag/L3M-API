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
    ///Controlador de los productos
    ///</summary>
    public class ProductsController : ApiController
    {

        readonly string url = @"https://firebasestorage.googleapis.com/v0/b/l3mwebapidatabase.appspot.com/o/DataBase.json?alt=media&token=0b842b13-c1ac-4e2b-bf5d-b084c306fc7b";

        ///<summary>
        ///Permite consultar un listado de productos existentes
        ///</summary>
        [HttpGet]
        public List<Product> Get()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())

            using (StreamReader jsonStream = new StreamReader(stream))
            {
                var json = jsonStream.ReadToEnd();
                DataBaseStruct list = JsonConvert.DeserializeObject<DataBaseStruct>(json);
                return list.Products;
            }
        }
        ///<summary>
        ///Permite consultar un listado de productos existentes a partir del nombre
        ///</summary>
        ///<param name="name"> Nombre del producto </param>
        [HttpGet]
        public List<Product> Get(string name)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())

            using (StreamReader jsonStream = new StreamReader(stream))
            {
                var json = jsonStream.ReadToEnd();
                DataBaseStruct list = JsonConvert.DeserializeObject<DataBaseStruct>(json);
                int x = 0;
                List<Product> products = new List<Product>();
                while (x < list.Products.Count)
                {
                    if (string.Equals(list.Products[x].Name, name)) 
                    {
                        products.Add(list.Products[x]);
                    }
                    x++;
                }
                
                return products;
            }
        }
        ///<summary>
        ///Permite agregar productos al listado
        ///</summary>
        ///<param name="barcode"> Codigo de barras del producto </param>
        ///<param name="name"> Nombre del producto </param>
        ///<param name="price"> Precio del producto </param>
        ///<param name="description"> Descripcion del producto </param>
        ///<param name="provider"> Proveedor del producto </param>
        ///<param name="tax"> Indica si el producto posee impuesto o no </param>
        ///<param name="discount"> Indica si el producto posee descuento o no </param>
        [HttpPost]
        public void Post(string barcode, string name, int price, string description, string provider, int tax, int discount)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())

            using (StreamReader jsonStream = new StreamReader(stream))
            {
                Product product = new Product
                {
                    Barcode = barcode,
                    Name = name,
                    Price = price,
                    Description = description,
                    Supplier = provider,
                    Tax = tax,
                    Discount = discount
                };

                var json = jsonStream.ReadToEnd();
                DataBaseStruct list = JsonConvert.DeserializeObject<DataBaseStruct>(json);
                list.Products.Add(product);

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
        ///Permite modificar productos del listado
        ///</summary>
        ///<param name="barcode"> Codigo de barras del producto </param>
        ///<param name="name"> Nombre del producto </param>
        ///<param name="price"> Precio del producto </param>
        ///<param name="description"> Descripcion del producto </param>
        ///<param name="provider"> Proveedor del producto </param>
        ///<param name="tax"> Indica si el producto posee impuesto o no </param>
        ///<param name="discount"> Indica si el producto posee descuento o no </param>
        [HttpPut]
        public void Put(string barcode, string name, int price, string description, string provider, int tax, int discount)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())

            using (StreamReader jsonStream = new StreamReader(stream))
            {
                var json = jsonStream.ReadToEnd();
                DataBaseStruct list = JsonConvert.DeserializeObject<DataBaseStruct>(json);
                int x = 0;
                while (x < list.Products.Count)
                {
                    if (string.Equals(list.Products[x].Barcode, barcode)&& string.Equals(list.Products[x].Name,name))
                    {
                        list.Products[x].Barcode = barcode;
                        list.Products[x].Name = name;
                        list.Products[x].Price = price;
                        list.Products[x].Description = description;
                        list.Products[x].Supplier = provider;
                        list.Products[x].Tax = tax;
                        list.Products[x].Discount = discount;
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
        ///Permite eliminar productos del listado
        ///</summary>
        ///<param name="barcode"> Codigo de barras del producto </param>
        ///<param name="name"> Nombre del producto </param>
        [HttpDelete]
        public void Delete(string barcode, string name)
        {
            using (StreamReader jsonStream = File.OpenText(url))
            {
                var json = jsonStream.ReadToEnd();
                DataBaseStruct list = JsonConvert.DeserializeObject<DataBaseStruct>(json);
                int x = 0;
                while (x < list.Products.Count)
                {
                    if (string.Equals(list.Products[x].Barcode, barcode) && string.Equals(list.Products[x].Name, name))
                    {
                        list.Products.RemoveAt(x);
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



