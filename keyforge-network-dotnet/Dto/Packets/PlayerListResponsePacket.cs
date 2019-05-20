using KeyforgeNetwork.Models;
using Newtonsoft.Json;

namespace KeyforgeNetwork.Dto.Packets
{
    public class PlayerListResponsePacket : Packet
    {
        [JsonProperty(PropertyName = "players")]
        public PlayerListEntry[] Players { get; set; }

        [JsonProperty(PropertyName = "count")]
        public uint Count { get; set; }

        public PlayerListResponsePacket()
        {
            Type = PacketType.PlayerListResponse;
        }
    }
}