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
    }
}
