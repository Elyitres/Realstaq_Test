using Newtonsoft.Json;

namespace Realstaq.Models
{
    public class Hero
    {
        [JsonProperty("small")]
        public string Small { get; set; }

        [JsonProperty("medium")]
        public string Medium { get; set; }
    }
}