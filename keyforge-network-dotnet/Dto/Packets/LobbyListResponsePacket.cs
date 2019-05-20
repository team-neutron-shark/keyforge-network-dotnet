using KeyforgeNetwork.Models;
using Newtonsoft.Json;

namespace KeyforgeNetwork.Dto.Packets
{
    public class LobbyListResponsePacket : Packet
    {
        [JsonProperty(PropertyName = "count")]
        public uint Count { get; set; }

        [JsonProperty(PropertyName = "lobbies")]
        public LobbyListEntry[] Lobbies { get; set; }

        public LobbyListResponsePacket()
        {
            Type = PacketType.LobbyListResponse;
        }
    }
}