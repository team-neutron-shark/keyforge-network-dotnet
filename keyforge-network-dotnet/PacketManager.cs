using System;
using Newtonsoft.Json;
using System.Net.Sockets;
using System.Text;

namespace KeyforgeNetwork
{
    public class PacketManager
    {
        public PacketManager()
        {
        }

        public static string SerializePacket(Packet packet)
        {
            string json = "";

            try
            {
                json = JsonConvert.SerializeObject(packet);
            }
            catch(JsonSerializationException e)
            {
                Console.WriteLine("Error serializing packet: {0}", e);
                return json;
            }

            return json;
        }

        public static void WritePacket(NetworkStream stream, Packet packet)
        {
            string jsonPayload = SerializePacket(packet);
            byte[] typeField = BitConverter.GetBytes(Convert.ToUInt16(packet.Type));
            byte[] lengthField = BitConverter.GetBytes(Convert.ToUInt16(jsonPayload.Length));
            byte[] jsonField = Encoding.UTF8.GetBytes(jsonPayload);

            stream.Write(typeField, 0, typeField.Length);
            stream.Write(lengthField, 0, lengthField.Length);
            stream.Write(jsonField, 0, jsonField.Length);
        }
    }
}
