using Newtonsoft.Json;

namespace KeyforgeNetwork.Dto.Packets
{
    public class LobbyChatRequestPacket : Packet
    {
		[JsonProperty(PropertyName = "message")]
		public string Message { get; set; }
        public LobbyChatRequestPacket()
        {
            Type = PacketType.LobbyChatRequest;
        }
    }
}