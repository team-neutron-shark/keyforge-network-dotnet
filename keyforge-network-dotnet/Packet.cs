using Newtonsoft.Json;

namespace KeyforgeNetwork
{
    public class LobbyListEntry
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string ID { get; set; }
    }

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
            Version = Protocol.Version;
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
        [JsonProperty(PropertyName = "players")]
        public PlayerListEntry[] Players { get; set; }

        [JsonProperty(PropertyName = "count")]
        public uint Count { get; set; }

		public PlayerListResponsePacket()
		{
			Type = PacketType.PlayerListResponse;
		}
	}

    public class CreateLobbyRequestPacket : Packet
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        public CreateLobbyRequestPacket()
        {
            Type = PacketType.CreateLobbyRequest;
        }
    }

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

    public class LobbyListRequestPacket : Packet
    {
        public LobbyListRequestPacket()
        {
            Type = PacketType.LobbyListRequest;
        }
    }

    public class LobbyListResponsePacket : Packet
    {
        [JsonProperty(PropertyName = "count")]
        public uint Count { get; set; }

        [JsonProperty(PropertyName = "lobbies")]
        public LobbyListEntry[] Lobbies { get; set; }

        public LobbyListResponsePacket()
        {
            Type = PacketType.LobbyListResponse;
        }
    }

    public class JoinLobbyRequestPacket : Packet
    {
        public JoinLobbyRequestPacket()
        {
            Type = PacketType.JoinLobbyRequest;
        }
    }

    public class JoinLobbyResponsePacket : Packet
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string ID { get; set; }

        [JsonProperty(PropertyName = "success")]
        public bool Success { get; set; }

        public JoinLobbyResponsePacket()
        {
            Type = PacketType.LobbyListResponse;
        }
    }

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

    public class LeaveLobbyResponsePacket : Packet
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string ID { get; set; }

        [JsonProperty(PropertyName = "success")]
        public bool Success { get; set; }

        public LeaveLobbyResponsePacket()
        {
            Type = PacketType.LeaveLobbyResponse;
        }
    }

    public class LobbyChatRequestPacket : Packet
    {
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        public LobbyChatRequestPacket()
        {
            Type = PacketType.LobbyChatRequest;
        }
    }

    public class LobbyChatResponsePacket : Packet
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }


        public LobbyChatResponsePacket()
        {
            Type = PacketType.LobbyChatRequest;
        }
    }

    public class LobbyKickRequestPacket : Packet
    {
        [JsonProperty(PropertyName = "target")]
        public string Target { get; set; }

        public LobbyKickRequestPacket()
        {
            Type = PacketType.KickLobbyRequest;
        }
    }

    public class LobbyKickResponsePacket : Packet
    {
        [JsonProperty(PropertyName = "target")]
        public string Target { get; set; }

        public LobbyKickResponsePacket()
        {
            Type = PacketType.KickLobbyResponse;
        }
    }
}