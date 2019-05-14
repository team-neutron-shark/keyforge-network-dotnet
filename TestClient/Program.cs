using System;
using System.Net.Sockets;
using KeyforgeNetwork;

namespace TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();
            client.Connect("127.0.0.1", 8888);

            
            VersionPacket packet = new VersionPacket();
            packet.Version = 0.01f;

            PacketManager.WritePacket(client.GetStream(), packet);

            var packet2 = PacketManager.ReadPacket(client.GetStream());
            Console.WriteLine(packet2);
        }
    }
}
