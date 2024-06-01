using ServerLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib.Handlers
{
    public class ClientRoomManager
    {
        private List<ClientHandler> _roomHandlersDict = new List<ClientHandler>();

        public void Add(ClientHandler clientHandler)
        {
            _roomHandlersDict.Add(clientHandler);
        }

        public void SendToMyRoom(TurnEnd hub)
        {
            foreach(var handler in _roomHandlersDict)
            {
                handler.Send(hub);
            }
        }
        public void SendToState(TurnEnd hub)
        {
            foreach (var handler in _roomHandlersDict)
            {
                handler.Send(hub);
                hub.turnPlayer++;
            }
        }
    }
}
