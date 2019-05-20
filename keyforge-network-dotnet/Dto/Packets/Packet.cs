using Newtonsoft.Json;

namespace KeyforgeNetwork.Dto.Packets
{
    public class Packet
	{
		[JsonProperty(PropertyName = "sequence")]
		public ushort Sequence { get; set; }

		[JsonProperty(PropertyName = "type")]
		public PacketType Type { get; set; }
	}
}