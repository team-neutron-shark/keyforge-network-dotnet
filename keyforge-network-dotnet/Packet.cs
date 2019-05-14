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

	class Packet
	{
		[JsonProperty(PropertyName = "sequence")]
		public ushort Sequence { get; set; }

		[JsonProperty(PropertyName = "type")]
		public PacketType Type { get; set; }
	}

	class ExitPacket : Packet
	{
		public ExitPacket()
		{
			Type = PacketType.Exit;
		}
	}

	class VersionPacket : Packet
	{
		[JsonProperty(PropertyName = "version")]
		public float Version { get; set; }

		public VersionPacket()
		{
			Type = PacketType.VersionRequest;
		}
	}

	class ErrorPacket : Packet
	{
		[JsonProperty(PropertyName = "message")]
		public string Message { get; set; }

		public ErrorPacket()
		{
			Type = PacketType.Error;
		}
	}

	class LoginRequestPacket : Packet
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

	class LoginResponsePacket : Packet
	{
		public LoginResponsePacket()
		{
			Type = PacketType.LoginResponse;
		}
	}

	class PlayerListRequestPacket : Packet
	{
		public PlayerListRequestPacket()
		{
			Type = PacketType.PlayerListRequest;
		}
	}

	class PlayerListResponsePacket : Packet
	{
		public PlayerList Players { get; set; }

		public PlayerListResponsePacket()
		{
			Type = PacketType.PlayerListResponse;
		}
	}
}