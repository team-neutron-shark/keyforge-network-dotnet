using Newtonsoft.Json;

namespace KeyforgeNetwork.Dto.Packets
{
    public class CreateLobbyRequestPacket : Packet
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        public CreateLobbyRequestPacket()
        {
            Type = PacketType.CreateLobbyRequest;
        }
    }
}