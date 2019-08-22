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
    ///Controlador de la clase BranchOffice
    ///</summary>
    public class BranchOfficesController : ApiController
    {
        readonly string url = @"https://firebasestorage.googleapis.com/v0/b/l3mwebapidatabase.appspot.com/o/DataBase.json?alt=media&token=0b842b13-c1ac-4e2b-bf5d-b084c306fc7b";

        ///<summary>
        ///Permite mostrar el listado de Sucursales
        ///</summary>
        [HttpGet]
        public List<BranchOffice> Get()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())

            using (StreamReader jsonStream = new StreamReader(stream))
            {
                var json = jsonStream.ReadToEnd();
                DataBaseStruct list = JsonConvert.DeserializeObject<DataBaseStruct>(json);
                return list.BranchOffices;
            }
        }
        ///<summary>
        ///Permite filtrar sucursales por nombre
        ///</summary>
        ///<param name="name"> Nombre de la Sucursal </param>
        [HttpGet]
        public List<BranchOffice> Get(string name)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())

            using (StreamReader jsonStream = new StreamReader(stream))
            {
                var json = jsonStream.ReadToEnd();
                DataBaseStruct list = JsonConvert.DeserializeObject<DataBaseStruct>(json);
                int x = 0;
                List<BranchOffice> BranchOffices = new List<BranchOffice>();
                while (x < list.BranchOffices.Count)
                {
                    if (string.Equals(list.BranchOffices[x].Name, name))
                    {
                        BranchOffices.Add(list.BranchOffices[x]);
                    }
                    x++;
                }

                return BranchOffices;
            }
        }
        ///<summary>
        ///Permite agregar nuevas sucursales
        ///</summary>
        ///<param name="name"> Nombre de la Sucursal </param>
        ///<param name="address"> Direccion de la Sucursal </param>
        ///<param name="phone"> Numero telefonico de la Sucursal </param>
        ///<param name="administrator"> Nombre del administrador a cargo de la Sucursal</param>
        [HttpPost]
        public void Post(string name, string address, string phone, string administrator)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())

            using (StreamReader jsonStream = new StreamReader(stream))
            {
                BranchOffice BranchOffices = new BranchOffice
                {
                    Name = name,
                    Address = address,
                    Phone = phone,
                    Administrator = administrator
                };

                var jsonOld = jsonStream.ReadToEnd();
                DataBaseStruct list = JsonConvert.DeserializeObject<DataBaseStruct>(jsonOld);
                list.BranchOffices.Add(BranchOffices);

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
        ///Permite modificar la informacion de las sucursales
        ///</summary>
        ///<param name="name"> Nombre de la Sucursal </param>
        ///<param name="address"> Direccion de la Sucursal </param>
        ///<param name="phone"> Numero telefonico de la Sucursal </param>
        ///<param name="administrator"> Nombre del administrador a cargo de la Sucursal</param>
        [HttpPut]
        public void Put(string name, string address, string phone, string administrator)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())

            using (StreamReader jsonStream = new StreamReader(stream))
            {
                var json = jsonStream.ReadToEnd();
                DataBaseStruct list = JsonConvert.DeserializeObject<DataBaseStruct>(json);
                int x = 0;
                while (x < list.BranchOffices.Count)
                {
                    if (string.Equals(list.BranchOffices[x].Name, name))
                    {
                        list.BranchOffices[x].Name = name;
                        list.BranchOffices[x].Address = address;
                        list.BranchOffices[x].Phone = phone;
                        list.BranchOffices[x].Administrator = administrator;
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
        ///Permite eliminar sucursales
        ///</summary>
        ///<param name="name"> Nombre de la Sucursal </param>
        [HttpDelete]
        public void Delete(string name)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())

            using (StreamReader jsonStream = new StreamReader(stream))
            {
                var json = jsonStream.ReadToEnd();
                DataBaseStruct list = JsonConvert.DeserializeObject<DataBaseStruct>(json);
                int x = 0;
                while (x < list.BranchOffices.Count)
                {
                    if (string.Equals(list.BranchOffices[x].Name, name))
                    {
                        list.BranchOffices.RemoveAt(x);
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
