using Newtonsoft.Json;
using System;

namespace SandboxWebApi.Models
{
    public class AgoraOrder
    {
        [JsonProperty(PropertyName = "orderId")]
        public string OrderId { get; set; }

        [JsonProperty(PropertyName = "symbol")]
        public string Symbol { get; set; }

        [JsonProperty(PropertyName = "side")]
        public string Side { get; set; }

        [JsonProperty(PropertyName = "client")]
        public string Client { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        [JsonProperty(PropertyName = "crated")]
        public DateTime Created { get; set; }

        [JsonProperty(PropertyName = "isActive")]
        public Boolean IsActive { get; set; }
    }
}
