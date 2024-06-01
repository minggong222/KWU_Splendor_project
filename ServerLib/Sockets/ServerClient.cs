using ServerLib.Events;
using ServerLib.Handlers;
using ServerLib.Models;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace ServerLib.Sockets
{
    public class ServerClient : ServerBase
    {
        private TcpClient _client;

        private Packet ConvertChatHub()
        {
            return new Packet
            {
                Type = (int)PacketType.init,
            };
        }

        public override event EventHandler<ServerEventArgs> Connected;
        public override event EventHandler<ServerEventArgs> Disconnected;
        public override event EventHandler<ServerEventArgs> Received;
        public override event EventHandler<ServerEventArgs> Setting;

        public ServerClient(IPAddress iPAddress, int port) : base(iPAddress, port)
        {
        }

        public async Task ConnectAsync()
        {
            if (IsRunning) return;

            try
            {
                _client = new TcpClient();
                await _client.ConnectAsync(IPAddress, Port);
                IsRunning = true;

                Packet hub = ConvertChatHub();
                TurnEnd TE = new TurnEnd(hub);
                ClientHandler clientHandler = new ClientHandler(_client);
                Connected?.Invoke(this, new ServerEventArgs(clientHandler, TE));
                clientHandler.Disconnected += ClientHandler_Disconnected;
                clientHandler.Received += Received;
                clientHandler.Setting += Setting;
                TE.Type = (int)PacketType.init;
                _ = clientHandler.HandleClientAsync();
                clientHandler?.Send(TE);
            }
            catch (Exception ex)
            {
                DisposeClient();
                Debug.Print($"서버 연결 시도 중 오류 발생: {ex.Message}");
            }
        }

        private void DisposeClient()
        {
            _client?.Dispose();
            IsRunning = false;
        }

        private void ClientHandler_Disconnected(object sender, ServerEventArgs e)
        {
            DisposeClient();
            Disconnected?.Invoke(sender, e);
        }

        public void Close()
        {
            DisposeClient();
        }
    }
}
