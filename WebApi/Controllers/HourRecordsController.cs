﻿using System;
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
    ///Controlador del registro de horas
    ///</summary>
    public class HourRecordsController : ApiController
    {
        readonly string url = @"https://firebasestorage.googleapis.com/v0/b/l3mwebapidatabase.appspot.com/o/DataBase.json?alt=media&token=0b842b13-c1ac-4e2b-bf5d-b084c306fc7b";

        ///<summary>
        ///Permite consultar el listado general de registros de horas
        ///</summary>
        [HttpGet]
        public List<HourRecord> Get()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())

            using (StreamReader jsonStream = new StreamReader(stream))
            {
                var json = jsonStream.ReadToEnd();
                DataBaseStruct list = JsonConvert.DeserializeObject<DataBaseStruct>(json);
                return list.HourRecords;
            }
        }
        ///<summary>
        ///Permite consultar el listado  de registros de horas para un trabajador especifico
        ///</summary>
        ///<param name="name"> Nombre del trabajador </param>
        [HttpGet]
        public List<HourRecord> Get(string name)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())

            using (StreamReader jsonStream = new StreamReader(stream))
            {
                var json = jsonStream.ReadToEnd();
                DataBaseStruct list = JsonConvert.DeserializeObject<DataBaseStruct>(json);
                int x = 0;
                List<HourRecord> hourRecords = new List<HourRecord>();
                while (x < list.HourRecords.Count)
                {
                    if (string.Equals(list.HourRecords[x].Name, name))
                    {
                        hourRecords.Add(list.HourRecords[x]);
                    }
                    x++;
                }

                return hourRecords;
            }
        }
        ///<summary>
        ///Permite agregar nuevos registros de horas
        ///</summary>
        ///<param name="name"> Nombre del trabajador</param>
        ///<param name="weekBeginning"> Fecha de Inicio de la semana</param>
        ///<param name="weekEnd"> Fecha de Finalizacion de la semana</param>
        ///<param name="workedHours"> Cantidad de horas trabajadas</param>
        [HttpPost]
        public void Post(string name, string weekBeginning, string weekEnd, int workedHours)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())

            using (StreamReader jsonStream = new StreamReader(stream))
            {
                HourRecord hourRecord = new HourRecord
                {
                    Name = name,
                    WeekBeginning = weekBeginning,
                    WeekEnd = weekEnd,
                    WorkedHours = workedHours
                };

                var jsonOld = jsonStream.ReadToEnd();
                DataBaseStruct list = JsonConvert.DeserializeObject<DataBaseStruct>(jsonOld);
                list.HourRecords.Add(hourRecord);

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
        ///Permite modificar registros de horas
        ///</summary>
        ///<param name="name"> Nombre del trabajador</param>
        ///<param name="weekBeginning"> Fecha de Inicio de la semana</param>
        ///<param name="weekEnd"> Fecha de Finalizacion de la semana</param>
        ///<param name="workedHours"> Cantidad de horas trabajadas</param>
        [HttpPut]
        public void Put(string name, string weekBeginning, string weekEnd, int workedHours)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())

            using (StreamReader jsonStream = new StreamReader(stream))
            {
                var json = jsonStream.ReadToEnd();
                DataBaseStruct list = JsonConvert.DeserializeObject<DataBaseStruct>(json);
                int x = 0;
                while (x < list.HourRecords.Count)
                {
                    if (string.Equals(list.HourRecords[x].Name, name)&& string.Equals(list.HourRecords[x].WeekBeginning, weekBeginning) && string.Equals(list.HourRecords[x].WeekEnd, weekEnd))
                    {
                        list.HourRecords[x].Name = name;
                        list.HourRecords[x].WeekBeginning = weekBeginning;
                        list.HourRecords[x].WeekEnd = weekEnd;
                        list.HourRecords[x].WorkedHours = workedHours;
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
        ///Permite eliminar registros de horas existentes
        ///</summary>
        ///<param name="name"> Nombre del trabajador</param>
        ///<param name="weekBeginning"> Fecha de Inicio de la semana</param>
        ///<param name="weekEnd"> Fecha de Finalizacion de la semana</param>
        [HttpDelete]
        public void Delete(string name, string weekBeginning, string weekEnd)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())

            using (StreamReader jsonStream = new StreamReader(stream))
            {
                var json = jsonStream.ReadToEnd();
                DataBaseStruct list = JsonConvert.DeserializeObject<DataBaseStruct>(json);
                int x = 0;
                while (x < list.HourRecords.Count)
                {
                    if (string.Equals(list.HourRecords[x].Name, name) && string.Equals(list.HourRecords[x].WeekBeginning, weekBeginning) && string.Equals(list.HourRecords[x].WeekEnd, weekEnd))
                    {
                        list.HourRecords.RemoveAt(x);
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
