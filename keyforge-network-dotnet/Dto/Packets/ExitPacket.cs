namespace KeyforgeNetwork.Dto.Packets
{
    public class ExitPacket : Packet
    {
        public ExitPacket()
        {
            Type = PacketType.Exit;
        }
    }
}