namespace KeyforgeNetwork.Dto.Packets
{
    public class PlayerListRequestPacket : Packet
    {
        public PlayerListRequestPacket()
        {
            Type = PacketType.PlayerListRequest;
        }
    }
}