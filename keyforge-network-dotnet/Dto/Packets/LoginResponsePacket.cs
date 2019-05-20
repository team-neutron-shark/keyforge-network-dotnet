namespace KeyforgeNetwork.Dto.Packets
{
    public class LoginResponsePacket : Packet
    {
        public LoginResponsePacket()
        {
            Type = PacketType.LoginResponse;
        }
    }
}