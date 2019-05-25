using Newtonsoft.Json;

namespace KeyforgeNetwork.Dto.Packets
{
    public class LeaveLobbyRequestPacket : Packet
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string ID { get; set; }

        public LeaveLobbyRequestPacket()
        {
            Type = PacketType.LeaveLobbyRequest;
        }
    }
}