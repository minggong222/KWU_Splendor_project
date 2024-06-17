using ServerLib.Models;
using System;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using GameDefine;
namespace ServerLib.Models
{

    [Serializable]
    public class Packet
    {
        public int Type;
        public int Length;
        public Packet()
        {
            Length = 0;
            Type = 0;
        }
        public static byte[] Serialize(Object o)
        {
            MemoryStream ms = new MemoryStream(1024 * 4);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms, o);
            return ms.ToArray();
        }

        public static Object Deserialize(byte[] bt)
        {
            MemoryStream ms = new MemoryStream(1024 * 4);
            foreach (byte b in bt)
            {
                ms.WriteByte(b);
            }
            ms.Position = 0;
            BinaryFormatter bf = new BinaryFormatter();
            Object obj = bf.Deserialize(ms);
            ms.Close();
            return obj;
        }
    }
    [Serializable]
    public class TurnEnd : Packet
    {
        public Player[] players = new Player[4];   // 플레이어 4명 정보
        public Board boardInfo;                    // 보드 정보
        public int winner;                     // 0 : 게임 진행 / 1 : Player1 승리 / 2 : Player2 승리 / 3 : Player3 승리 / 4 : Player4 승리
        public int turnPlayer;                 // 1 : Player1 / 2 : Player2 / 3 : Player3 / 4 : Player4
        public int round = 1;
        public TurnEnd()
        {
            boardInfo = new Board();
            players[0] = new Player();
            players[1] = new Player();
            players[2] = new Player();
            players[3] = new Player();
            winner = 1;
            turnPlayer = 1;
        }
        public TurnEnd(Packet p)
        {
            Type = p.Type;
            Length = p.Length;
            boardInfo = new Board();
        }
    }
}
