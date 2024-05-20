﻿using ServerLib.Events;
using ServerLib.Handlers;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace ServerLib.Sockets
{
    public class Server : ServerBase
    {
        private readonly TcpListener _listener;

        public override event EventHandler<ServerEventArgs> Connected;
        public override event EventHandler<ServerEventArgs> Disconnected;
        public override event EventHandler<ServerEventArgs> Received;
        public override event EventHandler<ServerEventArgs> Setting;
        public bool isStart = false;
        public Server(IPAddress iPAddress, int port) : base(iPAddress, port)
        {
            _listener = new TcpListener(iPAddress, port);
        }

        public async Task StartAsync()
        {
            if (IsRunning)
                return;

            try
            {
                _listener.Start();
                IsRunning = true;
                Debug.Print("서버 시작");
                while (true)
                {
                    TcpClient client = await _listener.AcceptTcpClientAsync();
                    Debug.Print($"클라이언트 연결 수락: {client.Client.Handle}");
                    ClientHandler clientHandler = new ClientHandler(client);
                    clientHandler.Connected += Connected;
                    clientHandler.Disconnected += Disconnected;
                    clientHandler.Received += Received;
                    clientHandler.Setting += Setting;

                    _ = clientHandler.HandleClientAsync();
                }
            }
            catch (Exception ex)
            {
                Debug.Print($"서버 시작 중 오류 발생: {ex.Message}");
                IsRunning = false;
            }
        }

        public void Stop()
        {
            IsRunning = false;
            _listener.Stop();
            Debug.Print("서버 정지");
        }
    }
}
