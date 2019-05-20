using System;
using System.Collections.Generic;
using System.Text;
using KeyforgeNetwork;
using KeyforgeNetwork.Dto.Packets;

namespace TestClient
{
    public class TestClient : ITestClient
    {
        public void TestVersion()
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
