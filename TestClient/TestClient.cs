using System;
using System.Collections.Generic;
using System.Text;
using KeyforgeNetwork;
using KeyforgeNetwork.Dto.Packets;
using Microsoft.Extensions.Logging;

namespace TestClient
{
    public class TestClient : ITestClient
    {
        private readonly ILogger<TestClient> _logger;

        public TestClient(ILogger<TestClient> logger)
        {
            _logger = logger;
        }

        public void TestVersion()
        {
            _logger.LogInformation("Test Version");

            Client client = new Client();
            client.Connect("127.0.0.1", 8888);

            VersionPacket packet = new VersionPacket();
            packet.Version = 0.01f;

            _logger.LogInformation("Writing Packet Version {packetVersion}", packet.Version);
            PacketManager.WritePacket(client.GetStream(), packet);

            _logger.LogInformation("Reading Packet back");
            var packet2 = PacketManager.ReadPacket(client.GetStream());

            _logger.LogInformation("Read Packet: {packetType}", packet2.Type);
            Console.WriteLine(packet2);
        }
    }
}
