using Newtonsoft.Json;

namespace KeyforgeNetwork.Dto.Packets
{
    public class JoinLobbyResponsePacket : Packet
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string ID { get; set; }

        [JsonProperty(PropertyName = "success")]
        public bool Success { get; set; }

        public JoinLobbyResponsePacket()
        {
            Type = PacketType.LobbyListResponse;
        }
    }
}