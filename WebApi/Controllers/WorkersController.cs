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
    ///Controlador de los trabajadores
    ///</summary>
    public class WorkersController : ApiController
    {
        readonly string url = @"https://firebasestorage.googleapis.com/v0/b/l3mwebapidatabase.appspot.com/o/DataBase.json?alt=media&token=0b842b13-c1ac-4e2b-bf5d-b084c306fc7b";
        ///<summary>
        ///Permite consultar la lista de trabajadores
        ///</summary>
        [HttpGet]
        public List<Worker> Get()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())

            using (StreamReader jsonStream = new StreamReader(stream))
            {
                var json = jsonStream.ReadToEnd();
                DataBaseStruct list = JsonConvert.DeserializeObject<DataBaseStruct>(json);
                return list.Workers;
            }
        }
        ///<summary>
        ///Permite consultar trabajadores por numero de cedula
        ///</summary>
        ///<param name="identificationCard"> Numero de cedula del trabajador</param>
        [HttpGet]
        public Worker Get(string identificationCard)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())

            using (StreamReader jsonStream = new StreamReader(stream))
            {
                var json = jsonStream.ReadToEnd();
                DataBaseStruct list = JsonConvert.DeserializeObject<DataBaseStruct>(json);
                int x = 0;
                Worker worker = new Worker();
                while (x < list.Workers.Count)
                {
                    if (string.Equals(list.Workers[x].IdentificationCard, identificationCard))
                    {
                        worker = list.Workers[x];
                    }
                    x++;
                }

                return worker;
            }
        }
        ///<summary>
        ///Permite agregar nuevos trabajadores a la lista
        ///</summary>
        ///<param name="identificationCard"> Numero de cedula del trabajador</param>
        ///<param name="name"> Nombre del trabajador</param>
        ///<param name="birthDate"> Fecha de nacimiento del trabajador</param>
        ///<param name="admissionDate"> Fecha de ingreso </param>
        ///<param name="branchOffice"> Sucursar en la que trabaja</param>
        ///<param name="hourlyWage"> Salario por hora del trabajador</param>
        ///<param name="rol"> Rol del trabajador</param>
        [HttpPost]
        public void Post(string identificationCard, string name,  string birthDate, string admissionDate, string branchOffice, int hourlyWage, string rol)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())

            using (StreamReader jsonStream = new StreamReader(stream))
            {
                Worker worker = new Worker
                {
                    IdentificationCard = identificationCard,
                    Name = name,
                    BirthDate = birthDate,
                    AdmissionDate = admissionDate,
                    BranchOffice = branchOffice,
                    HourlyWage = hourlyWage,
                    Rol = rol
                };

                var jsonOld = jsonStream.ReadToEnd();
                DataBaseStruct list = JsonConvert.DeserializeObject<DataBaseStruct>(jsonOld);
                list.Workers.Add(worker);

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
        ///Permite modificar trabajadores de la lista
        ///</summary>
        ///<param name="identificationCard"> Numero de cedula del trabajador</param>
        ///<param name="name"> Nombre del trabajador</param>
        ///<param name="birthDate"> Fecha de nacimiento del trabajador</param>
        ///<param name="admissionDate"> Fecha de ingreso </param>
        ///<param name="branchOffice"> Sucursar en la que trabaja</param>
        ///<param name="hourlyWage"> Salario por hora del trabajador</param>
        ///<param name="rol"> Rol del trabajador</param>
        [HttpPut]
        public void Put(string identificationCard, string name, string birthDate, string admissionDate, string branchOffice, int hourlyWage, string rol)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())

            using (StreamReader jsonStream = new StreamReader(stream))
            {
                var json = jsonStream.ReadToEnd();
                DataBaseStruct list = JsonConvert.DeserializeObject<DataBaseStruct>(json);
                int x = 0;
                while (x < list.Workers.Count)
                {
                    if (string.Equals(list.Workers[x].IdentificationCard, identificationCard))
                    {
                        list.Workers[x].IdentificationCard = identificationCard;
                        list.Workers[x].Name = name;
                        list.Workers[x].BirthDate = birthDate;
                        list.Workers[x].AdmissionDate = admissionDate;
                        list.Workers[x].BranchOffice = branchOffice;
                        list.Workers[x].HourlyWage = hourlyWage;
                        list.Workers[x].Rol = rol;
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
        ///Permite eliminar trabajadores de la lista
        ///</summary>
        ///<param name="identificationCard"> Numero de cedula del trabajador</param>
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
                while (x < list.Workers.Count)
                {
                    if (string.Equals(list.Workers[x].IdentificationCard, identificationCard))
                    {
                        list.Workers.RemoveAt(x);
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
