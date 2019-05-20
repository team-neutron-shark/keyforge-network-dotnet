using Newtonsoft.Json;

namespace KeyforgeNetwork.Models
{
    public class PlayerListEntry
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}