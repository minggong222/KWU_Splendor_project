using ServerLib.Events;
using System;
using System.Net;

namespace ServerLib.Sockets
{
    public abstract class ServerBase : ServerEventBase
    {
        private bool _isRunning;

        protected readonly IPAddress IPAddress;
        protected readonly int Port;

        public event Action<bool> RunningStateChanged;

        public ServerBase(IPAddress iPAddress, int port)
        {
            IPAddress = iPAddress;
            Port = port;
        }

        public bool IsRunning
        {
            get => _isRunning;
            set
            {
                if (_isRunning != value)
                {
                    _isRunning = value;
                    RunningStateChanged?.Invoke(_isRunning);
                }
            }
        }
    }
}
