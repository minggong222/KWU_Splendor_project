using System;

namespace ServerLib.Events
{
    public abstract class ServerEventBase
    {
        public abstract event EventHandler<ServerEventArgs> Connected;
        public abstract event EventHandler<ServerEventArgs> Disconnected;
        public abstract event EventHandler<ServerEventArgs> Received;
        public abstract event EventHandler<ServerEventArgs> Setting;
    }
}
