using Newtonsoft.Json;

namespace KeyforgeNetwork.Dto.Packets
{
    public class LobbyChatResponsePacket : Packet
    {
		[JsonProperty(PropertyName = "message")]
		public string Message { get; set; }
        public LobbyChatResponsePacket()
        {
            Type = PacketType.LobbyChatResponse;
        }
    }
}