using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace TestApp.Model
{
    public class Region
    {
        [JsonProperty(PropertyName = "ArabicName")]
        public string ArabicName { get; set; }

        [JsonProperty(PropertyName = "EnglishName")]
        public string EnglishName { get; set; }
    }
}
