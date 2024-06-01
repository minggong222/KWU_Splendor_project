using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib.Models
{
    public enum PacketType
    {
        init = 0,
        gem,
        card,
        turnEnd,
        restart,
        end,
        setting
    }
}
