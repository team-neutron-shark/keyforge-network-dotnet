using System;
using Newtonsoft.Json;
using System.Net.Sockets;
using System.Text;
using KeyforgeNetwork.Dto.Packets;

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

        public static Packet ReadPacket(NetworkStream stream)
        {
            Console.WriteLine("reading packet");
            byte[] typeBuffer = new byte[2];
            byte[] lengthBuffer = new byte[2];
             
            stream.Read(typeBuffer, 0, 2);
            stream.Read(lengthBuffer, 0, 2);

            ushort typeField = BitConverter.ToUInt16(typeBuffer, 0);
            ushort lengthField = BitConverter.ToUInt16(lengthBuffer, 0);

            Console.WriteLine("type: {0}", typeField);
            Console.WriteLine("length: {0}", lengthField);

            byte[] payloadBuffer = new byte[lengthField];

            stream.Read(payloadBuffer, 0, payloadBuffer.Length);
            string jsonPayload = Encoding.UTF8.GetString(payloadBuffer);

            return RenderPacket((PacketType)typeField, jsonPayload);
        }

        public static Packet RenderPacket(PacketType type, string payload)
        {
            switch(type)
            {
                case PacketType.Exit:
                    {
                        ExitPacket p = JsonConvert.DeserializeObject<ExitPacket>(payload);
                        return p;
                    }
                case PacketType.Error:
                    {
                        ErrorPacket p = JsonConvert.DeserializeObject<ErrorPacket>(payload);
                        return p;
                    }
                case PacketType.VersionRequest:
                    {
                        VersionPacket p = JsonConvert.DeserializeObject<VersionPacket>(payload);
                        return p;
                    }
                case PacketType.VersionResponse:
                    {
                        VersionPacket p = JsonConvert.DeserializeObject<VersionPacket>(payload);
                        return p;
                    }
                case PacketType.LoginRequest:
                    {
                        LoginRequestPacket p = JsonConvert.DeserializeObject<LoginRequestPacket>(payload);
                        return p;
                    }
                case PacketType.LoginResponse:
                    {
                        LoginResponsePacket p = JsonConvert.DeserializeObject<LoginResponsePacket>(payload);
                        return p;
                    }
                case PacketType.PlayerListRequest:
                    {
                        PlayerListRequestPacket p = JsonConvert.DeserializeObject<PlayerListRequestPacket>(payload);
                        return p;
                    }
                case PacketType.PlayerListResponse:
                    {
                        LoginResponsePacket p = JsonConvert.DeserializeObject<LoginResponsePacket>(payload);
                        return p;
                    }
                case PacketType.CreateLobbyRequest:
                    {
                        CreateLobbyRequestPacket p = JsonConvert.DeserializeObject<CreateLobbyRequestPacket>(payload);
                        return p;
                    }
                case PacketType.CreateLobbyResponse:
                    {
                        CreateLobbyResponsePacket p = JsonConvert.DeserializeObject<CreateLobbyResponsePacket>(payload);
                        return p;
                    }
                default:
                    Console.WriteLine("packet type not found.");
                    return new Packet();
            }

        }

        private static ushort SwapBytes16(ushort number)
        {
            return (ushort)((number & 0xFF00) >> 8 | (number & 0x00FF) << 8); 
        }
    }
}
