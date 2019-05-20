using Newtonsoft.Json;

namespace KeyforgeNetwork.Dto.Packets
{
    public class CreateLobbyResponsePacket : Packet
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string ID { get; set; }

        public CreateLobbyResponsePacket()
        {
            Type = PacketType.CreateLobbyResponse;
        }
    }
}