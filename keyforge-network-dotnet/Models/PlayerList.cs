using Newtonsoft.Json;

namespace KeyforgeNetwork.Models
{
    public class PlayerList
    {
        [JsonProperty(PropertyName = "count")]
        public uint Count { get; set; }

        [JsonProperty(PropertyName = "players")]
        public PlayerListEntry[] Players { get; set; }
    }
}