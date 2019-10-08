using Newtonsoft.Json;

namespace WebApplicationDemo.Models
{
    [JsonObject("tokenManagement")]
    public class TokenManagement
    {
        [JsonProperty("secret")]
        public string Secret { get; set; }

        [JsonProperty("issuer")]
        public string Issuer { get; set; }

        [JsonProperty("audience")]
        public string Audience { get; set; }

        [JsonProperty("expiration")]
        public double Expiration { get; set; }

        [JsonProperty("refreshExpiration")]
        public string RefreshExpiration { get; set; }
    }
}
