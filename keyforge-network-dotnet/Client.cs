using System;
using System.Net.Sockets;

namespace KeyforgeNetwork
{
    public class Client
    {
        private TcpClient client;

        public Client()
        {
            client = new TcpClient();
        }

        public void Log(string message)
        {
            Console.WriteLine("[LOG] {0}", message);
        }

        public NetworkStream GetStream()
        {
            return client.GetStream();
        }

        public void Connect(string address, int port)
        {
            try 
            {
                client.Connect(address, port);
            }
            catch (SocketException e)
            {
                string message = string.Format("Connect error accessing socket: {0}", e);
                Log(message);
                return;
            }
        }

        public void SendVersionRequest()
        {
            VersionPacket packet = new VersionPacket();
            PacketManager.WritePacket(client.GetStream(), packet);
        }

        public void SendLoginRequest(string username, string password)
        {
            Vault vault = new Vault();
            VaultUser user = vault.Login(username, password);

            if(user.Token.Length <= 0)
            {
                return;
            }

            if(user.ID.Length <= 0)
            {
                return;
            }

            LoginRequestPacket packet = new LoginRequestPacket();
            packet.Name = username;
            packet.Token = user.Token;
            packet.ID = user.ID;

            PacketManager.WritePacket(client.GetStream(), packet);
        }

        public void SendPlayerListRequest()
        {
            PlayerListRequestPacket packet = new PlayerListRequestPacket();
            PacketManager.WritePacket(client.GetStream(), packet);
        }

        public void CreateLobbyRequest(string name)
        {
            CreateLobbyRequestPacket packet = new CreateLobbyRequestPacket();
            packet.Name = name;
            PacketManager.WritePacket(client.GetStream(), packet);
        }
    }
}
