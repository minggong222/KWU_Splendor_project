using ServerLib.Handlers;
using ServerLib.Models;
using System;

namespace ServerLib.Events
{
    public class ServerEventArgs : EventArgs
    {
        public ServerEventArgs(ClientHandler clientHandler, TurnEnd hub)
        {
            ClientHandler = clientHandler;
            Hub = hub;
        }

        public ClientHandler ClientHandler { get; }
        public TurnEnd Hub { get; }
    }
}
