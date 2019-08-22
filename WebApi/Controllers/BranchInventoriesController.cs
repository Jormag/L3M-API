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
    ///Controlador de la clase BranchInventory
    ///</summary>
    public class BranchInventoriesController : ApiController
    {
        readonly string url = @"https://firebasestorage.googleapis.com/v0/b/l3mwebapidatabase.appspot.com/o/DataBase.json?alt=media&token=0b842b13-c1ac-4e2b-bf5d-b084c306fc7b";


        ///<summary>
        ///Muestra el listado completo del inventario para todas las sucursales
        ///</summary>
        [HttpGet]
        public List<BranchInventory> Get()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())

            using (StreamReader jsonStream = new StreamReader(stream))
            {
                var json = jsonStream.ReadToEnd();
                DataBaseStruct list = JsonConvert.DeserializeObject<DataBaseStruct>(json);
                return list.BranchInventories;
            }
        }

        ///<summary>
        ///Muestra el listado de productos para una Sucursal especifica
        ///</summary>
        ///<param name="branchOffice"> Nombre de la Sucursal </param>
        [HttpGet]
        public List<BranchInventory> Get(string branchOffice)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())

            using (StreamReader jsonStream = new StreamReader(stream))
            {
                var json = jsonStream.ReadToEnd();
                DataBaseStruct list = JsonConvert.DeserializeObject<DataBaseStruct>(json);
                int x = 0;
                List<BranchInventory> branchInventories = new List<BranchInventory>();
                while (x < list.BranchInventories.Count)
                {
                    if (string.Equals(list.BranchInventories[x].BranchOffice, branchOffice))
                    {
                        branchInventories.Add(list.BranchInventories[x]);
                    }
                    x++;
                }

                return branchInventories;
            }
        }
        ///<summary>
        ///Permite Agregar nuevos productos a una sucursal
        ///</summary>
        ///<param name="barcode"> Codigo de barras del producto </param>
        ///<param name="name"> Nombre del producto </param>
        ///<param name="description"> Descripcion del producto</param>
        ///<param name="branchPrice"> Precio en la Sucursal </param>
        ///<param name="stock"> Existencias </param>
        ///<param name="branchOffice"> Nombre de la Sucursal </param>
        [HttpPost]
        public void Post(string barcode, string name, string description, int branchPrice, int stock, string branchOffice)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())

            using (StreamReader jsonStream = new StreamReader(stream))
            {
                BranchInventory branchInventory = new BranchInventory
                {
                    Barcode = barcode,
                    Name = name,
                    Description = description,
                    BranchPrice = branchPrice,
                    Stock = stock,
                    BranchOffice = branchOffice
                };


                var jsonOld = jsonStream.ReadToEnd();
                DataBaseStruct list = JsonConvert.DeserializeObject<DataBaseStruct>(jsonOld);
                list.BranchInventories.Add(branchInventory);

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
        ///Permite modificar la informacion de los productos de una sucursal
        ///</summary>
        ///<param name="barcode"> Codigo de barras del producto </param>
        ///<param name="name"> Nombre del producto </param>
        ///<param name="description"> Descripcion del producto</param>
        ///<param name="branchPrice"> Precio en la Sucursal </param>
        ///<param name="stock"> Existencias </param>
        ///<param name="branchOffice"> Nombre de la Sucursal </param>
        [HttpPut]
        public void Put(string barcode, string name, string description, int branchPrice, int stock, string branchOffice)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())

            using (StreamReader jsonStream = new StreamReader(stream))
            {
                var json = jsonStream.ReadToEnd();
                DataBaseStruct list = JsonConvert.DeserializeObject<DataBaseStruct>(json);
                int x = 0;
                while (x < list.BranchInventories.Count)
                {
                    if (string.Equals(list.BranchInventories[x].BranchOffice, branchOffice) && string.Equals(list.BranchInventories[x].Barcode, barcode) && string.Equals(list.BranchInventories[x].Name, name))
                    {
                        list.BranchInventories[x].Barcode = barcode;
                        list.BranchInventories[x].Name = name;
                        list.BranchInventories[x].Description = description;
                        list.BranchInventories[x].BranchPrice = branchPrice;
                        list.BranchInventories[x].Stock = stock;
                        list.BranchInventories[x].BranchOffice = branchOffice;
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
        ///Permite eliminar productis de una sucursal
        ///</summary>
        ///<param name="barcode"> Codigo de barras del producto </param>
        ///<param name="name"> Nombre del producto </param>
        ///<param name="branchOffice"> Nombre de la Sucursal </param>
        [HttpDelete]
        public void Delete(string barcode, string name, string branchOffice)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())

            using (StreamReader jsonStream = new StreamReader(stream))
            {
                var json = jsonStream.ReadToEnd();
                DataBaseStruct list = JsonConvert.DeserializeObject<DataBaseStruct>(json);
                int x = 0;
                while (x < list.BranchInventories.Count)
                {
                    if (string.Equals(list.BranchInventories[x].BranchOffice, branchOffice) && string.Equals(list.BranchInventories[x].Barcode, barcode) && string.Equals(list.BranchInventories[x].Name, name))
                    {
                        list.BranchInventories.RemoveAt(x);
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
