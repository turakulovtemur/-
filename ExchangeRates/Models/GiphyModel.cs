using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeRates.Models
{
    
    public class GiphyModel
    {
        public Data Data { get; set; }


    }
    public class Images
    {
        [JsonProperty("fixed_height_downsampled")]
        public FixedHeightDownsampled FixedHeightDownsampled { get; set; }
    }


    public class FixedHeightDownsampled
    {
        public string height { get; set; }

        public string size { get; set; }

        public string url { get; set; }

        public string webp { get; set; }

        public string webp_size { get; set; }

        public string width { get; set; }
    }
    public class Data
    {

        public string type { get; set; }

        public string id { get; set; }

        public string url { get; set; }

        public string slug { get; set; }

        public string bitly_gif_url { get; set; }

        public string bitly_url { get; set; }

        public string embed_url { get; set; }

        public string username { get; set; }

        public string source { get; set; }

        public string title { get; set; }

        public string rating { get; set; }

        public string import_datetime { get; set; }

        public Images Images { get; set; }

    }
}
