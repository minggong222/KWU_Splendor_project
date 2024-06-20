using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ServerLib.Events;
using ServerLib.Handlers;
using ServerLib.Models;
using ServerLib.Sockets;
using System.Net;
using GameDefine;
using System.Diagnostics;
namespace GameServer
{
    public partial class Form1 : Form
    {
        private Server _server;
        private ClientRoomManager _roomManager;
        public TurnEnd TE = new TurnEnd();
        public int cnt = 0;
        private Packet CreateNewStateChatHub(Packet hub, PacketType state)
        {
            return new Packet
            {
                Type = (int)state,
            };
        }
        private void Connected(object sender, ServerEventArgs e)
        {

            _roomManager.Add(e.ClientHandler);
            cnt++;
            if (cnt == 4)
            {
                TE.Type = (int)PacketType.setting;
                _roomManager.SendToState(TE);
                TE.turnPlayer = 1;
                TE.Type = (int)PacketType.turnEnd;
            }
        }
        private void Received(object sender, ServerEventArgs e)
        {
            TE = e.Hub;
            switch (TE.turnPlayer)
            {
                case 0:
                    break;
                case 1:
                case 2:
                case 3:
                    TE.turnPlayer++;
                    break;
                case 4:
                    TE.round++;
                    TE.turnPlayer = 1;
                    WinnerFind();
                    break;

            }
            Debug.Print(TE.winner.ToString());
            _roomManager.SendToMyRoom(TE);
        }

        private void RunningStateChanged(bool isRunning)
        {
            btnStart.Enabled = !isRunning;
            btnStop.Enabled = isRunning;
        }
        public Form1()
        {
            InitializeComponent();

            _roomManager = new ClientRoomManager();
            _server = new Server(IPAddress.Parse("127.0.0.1"), 8080);
            _server.Connected += Connected;
            _server.Received += Received;
            _server.RunningStateChanged += RunningStateChanged;

            btnStart.Click += btnStart_Click;
            btnStop.Click += btnStop_Click;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            _ = _server.StartAsync();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _server.Stop();
        }
        public void WinnerFind()
        {
            int cnt = 0;
            int winner = 0;
            for (int i = 0; i < 4; i++)
            {
                if (TE.players[i].totalScore >= 15)
                {
                    cnt++;
                    if(winner != 0){
                        if(TE.players[i].playerCards.Count <= TE.players[winner - 1].playerCards.Count)
                        {
                            winner = i + 1;
                        }
                    }
                    else
                    {
                        winner = i + 1;
                    }
                }
            }
            TE.winner = winner;
        }

    }
}

