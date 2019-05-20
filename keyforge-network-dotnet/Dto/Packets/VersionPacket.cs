using Newtonsoft.Json;

namespace KeyforgeNetwork.Dto.Packets
{
    public class VersionPacket : Packet
    {
        [JsonProperty(PropertyName = "version")]
        public float Version { get; set; }

        public VersionPacket()
        {
            Type = PacketType.VersionRequest;
        }
    }
}