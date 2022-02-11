using ExchangeRates.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ExchangeRates.Services
{
    public class GifsService : IGifsService
    {
        string URL = "https://api.giphy.com/v1/gifs/{0}";
        public string GetGifs(string id)
        {
            
            string changedUrl = string.Format(URL, id);
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(changedUrl);
           

            httpWebRequest.ContentType = "text/json";

            httpWebRequest.Method = "GET";//Можно GET
            httpWebRequest.Accept = "application/json";
            httpWebRequest.ContentType = "application/x-www-form-urlencoded";
            httpWebRequest.Headers.Add("api_key", "3qoY9i4HFXTbdsjOKQ9oHJ6PSWNOnSXM");
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                //ответ от сервера
                var result = streamReader.ReadToEnd();

                //Десериализация
                GiphyModel rateModel = JsonConvert.DeserializeObject<GiphyModel>(result);

                return rateModel.Data.Images.FixedHeightDownsampled.url.ToString();
            }
        }
    }
}
