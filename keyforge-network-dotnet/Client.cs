using System;
using System.Net.Sockets;
using KeyforgeNetwork.Exceptions;

namespace KeyforgeNetwork
{
    public class Client
    {
        private readonly TcpClient _client = new TcpClient();

        private readonly string _address;
        private readonly int _port;

        public Client(string address, int port)
        {
	        _address = address;
	        _port = port;

			Connect();
        }

        public NetworkStream NetworkStream => _client.GetStream();

        public void Connect()
        {
	        try
	        {
		        _client.Connect(_address, _port);
	        }
	        catch (SocketException e)
	        {
		        var message = $"Connect error accessing socket on {_address}:{_port} {e.Message}";
		        throw new KeyforgeNetworkException(message, e);
	        }
	        catch (Exception e)
	        {
		        var message = $"Unknown error connecting to {_address}:{_port} {e.Message}";
		        throw new KeyforgeNetworkException(message, e);
			}
        }
    }
}
