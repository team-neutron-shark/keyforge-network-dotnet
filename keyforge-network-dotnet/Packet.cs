using Newtonsoft.Json;

namespace KeyforgeNetwork
{
	public class PlayerListEntry
	{
		[JsonProperty(PropertyName = "id")]
		public string ID { get; set; }

		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }
	}

	public class PlayerList
	{
		[JsonProperty(PropertyName = "count")]
		public uint Count { get; set; }

		[JsonProperty(PropertyName = "players")]
		public PlayerListEntry[] Players { get; set; }

	}

	public class Packet
	{
		[JsonProperty(PropertyName = "sequence")]
		public ushort Sequence { get; set; }

		[JsonProperty(PropertyName = "type")]
		public PacketType Type { get; set; }
	}

	public class ExitPacket : Packet
	{
		public ExitPacket()
		{
			Type = PacketType.Exit;
		}
	}

	public class VersionPacket : Packet
	{
		[JsonProperty(PropertyName = "version")]
		public float Version { get; set; }

		public VersionPacket()
		{
			Type = PacketType.VersionRequest;
		}
	}

	public class ErrorPacket : Packet
	{
		[JsonProperty(PropertyName = "message")]
		public string Message { get; set; }

		public ErrorPacket()
		{
			Type = PacketType.Error;
		}
	}

	public class LoginRequestPacket : Packet
	{
		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		[JsonProperty(PropertyName = "id")]
		public string ID { get; set; }

		[JsonProperty(PropertyName = "token")]
		public string Token { get; set; }

		public LoginRequestPacket()
		{
			Type = PacketType.LoginRequest;
		}
	}

	public class LoginResponsePacket : Packet
	{
		public LoginResponsePacket()
		{
			Type = PacketType.LoginResponse;
		}
	}

	public class PlayerListRequestPacket : Packet
	{
		public PlayerListRequestPacket()
		{
			Type = PacketType.PlayerListRequest;
		}
	}

	public class PlayerListResponsePacket : Packet
	{
        public PlayerListEntry[] Players { get; set; }
        public uint Count { get; set; }

		public PlayerListResponsePacket()
		{
			Type = PacketType.PlayerListResponse;
		}
	}
}