using ServerLib.Models;
using ServerLib.Events;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using GameDefine;
namespace ServerLib.Handlers
{
    public class ClientHandler : ServerEventBase
    {
        private readonly TcpClient _client;
        private readonly NetworkStream _stream;

        public override event EventHandler<ServerEventArgs> Connected;
        public override event EventHandler<ServerEventArgs> Disconnected;
        public override event EventHandler<ServerEventArgs> Received;
        public override event EventHandler<ServerEventArgs> Setting;

        public ClientHandler(TcpClient client)
        {
            _client = client;
            _stream = client.GetStream();
        }

        public TurnEnd InitialData { get; private set; }

        public async Task HandleClientAsync()
        {
            byte[] sizeBuffer = new byte[4];
            int read;
            try
            {
                while (true)
                {

                    byte[] buffer = new byte[1024 * 16];

                    read = await _stream.ReadAsync(buffer, 0, buffer.Length);
                    if (read == 0)
                        break;

                    TurnEnd hub = (TurnEnd)TurnEnd.Deserialize(buffer);
                    if (hub.Type == (int)PacketType.init)
                    {
                        InitialData = hub;
                        Debug.Print("클라이언트 연결 이벤트 발생");
                        Connected?.Invoke(this, new ServerEventArgs(this, hub));
                    }
                    else if(hub.Type == (int)PacketType.setting)
                    {
                        Debug.Print("세팅");
                        Setting?.Invoke(this, new ServerEventArgs(this, hub));
                    }
                    else
                    {
                        Debug.Print("클라이언트 데이터 수신 이벤트 발생");
                        Received?.Invoke(this, new ServerEventArgs(this, hub));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"클라이언트 요청 처리 중 오류 발생: {ex.Message}");
            }
            finally
            {
                _client.Close();
                Disconnected?.Invoke(this, new ServerEventArgs(this, InitialData));
            }
        }

        public void Send(TurnEnd TE)
        {
            try
            {
                byte[] buffer = new byte[1024 * 16];
                Packet.Serialize(TE).CopyTo(buffer, 0);
                _stream.Write(buffer, 0, buffer.Length);
                Debug.Print("발송 성공");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"클라이언트로 메세지 전송 중 오류 발생: {ex.Message}");
            }
        }
    }
}
