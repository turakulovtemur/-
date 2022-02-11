using ExchangeRates.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ExchangeRates.Services
{
    public class RatesService : IRatesService
    {
        string URL = "https://openexchangerates.org/api/historical/{0}.json?app_id=ef9bd5f8a2824d24a6efbfb699ee1cf7&symbols={1}";

        public double GetRateByDate(DateTime date, string currencyCode)
        {
            currencyCode = currencyCode.ToUpper();
            string changedUrl = string.Format(URL, date.ToString("yyyy-MM-dd"), currencyCode);
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(changedUrl);
            // https://openexchangerates.org/api/latest.json?app_id=ef9bd5f8a2824d24a6efbfb699ee1cf7&symbols=RUB

            httpWebRequest.ContentType = "text/json";

            httpWebRequest.Method = "GET";//Можно GET
            httpWebRequest.Accept = "application/json";
            httpWebRequest.ContentType = "application/x-www-form-urlencoded";
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                //ответ от сервера
                var result = streamReader.ReadToEnd();

                //Десериализация
                RateModel rateModel = JsonConvert.DeserializeObject<RateModel>(result);

                var currencyRate = rateModel.rates.ContainsKey(currencyCode)
                    ? rateModel.rates[currencyCode]
                    : "0";

                return Convert.ToDouble(currencyRate, CultureInfo.InvariantCulture);
            }
        }
    }
}
