using Newtonsoft.Json;
using System;

namespace MiniURL.Models
{
    public class Item
    {
        [JsonProperty(PropertyName = "longurl")]
        public string LongURL { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string ShortURL { get; set; }

        [JsonProperty(PropertyName = "expirationdate")]
        public DateTime ExpirationDate { get; set; }
    }
}
