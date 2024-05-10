using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDefine
{
    public class Game
    {
        public class Gem
        {
            public string gemType;
            public int gemCount;
            public int gemValue;
        }
        public class Nobility {
            public string cardType;
            public int[] cardCost;
            public int cardScore;
        }
        public class Development {
            public string cardType;
            public int[] cardCost;
            public int cardScore;
        }
        public class Player {
            public string playerName;
            public int[] playerGem;
            public Nobility[] playerNobility;
            public Development[] playerDevelopment;
            public int playerScore;
            public bool playerTurn;
        }
    }
}
