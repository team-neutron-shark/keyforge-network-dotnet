namespace KeyforgeNetwork.Dto.Packets
{
    public class JoinLobbyRequestPacket : Packet
    {
        public JoinLobbyRequestPacket()
        {
            Type = PacketType.JoinLobbyRequest;
        }
    }
}