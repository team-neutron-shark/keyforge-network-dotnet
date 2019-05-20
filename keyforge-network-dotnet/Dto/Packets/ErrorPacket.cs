using Newtonsoft.Json;

namespace KeyforgeNetwork.Dto.Packets
{
    public class ErrorPacket : Packet
    {
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        public ErrorPacket()
        {
            Type = PacketType.Error;
        }
    }
}