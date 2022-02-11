using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeRates.Models
{
    public class RateModel
    {
        public string disclaimer { get; set; }

        public string license { get; set; }

        public string timestamp { get; set; }

        [JsonProperty("base")]
        public string baseRate { get; set; }
        
        public Dictionary<string, string> rates { get; set; }
    }
}
