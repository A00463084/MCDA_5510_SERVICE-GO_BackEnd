using Newtonsoft.Json;

namespace ServiceGo.Models
{
    public class Signup
    {
        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("password")]
        public string password { get; set; }

        [JsonProperty("email_address")]
        public string email { get; set; }

        [JsonProperty("address")]
        public string address { get; set; }

        [JsonProperty("city")]
        public string city { get; set; }

        [JsonProperty("province")]
        public string province { get; set; }

        [JsonProperty("country")]
        public string country { get; set; }

        [JsonProperty("postal_code")]
        public string postal_code { get; set; }

        [JsonProperty("mobile_number")]
        public string phone { get; set; }
    }
}
