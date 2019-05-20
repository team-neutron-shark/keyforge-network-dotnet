namespace KeyforgeNetwork.Dto.Packets
{
    public class LobbyListRequestPacket : Packet
    {
        public LobbyListRequestPacket()
        {
            Type = PacketType.LobbyListRequest;
        }
    }
}