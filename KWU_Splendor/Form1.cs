using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using GameDefine;
using ServerLib.Events;
using ServerLib.Handlers;
using ServerLib.Models;
using ServerLib.Sockets;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
namespace KWU_Splendor
{
    public partial class Form1 : Form
    {
        private ServerClient _client;
        private ClientHandler _clientHandler;
        public TurnEnd gameState;
        int myTurn;

        private void RunningStateChanged(bool isRunning)
        {
            BtnConnect.Enabled = !isRunning;
        }

        private void Connected(object sender, ServerLib.Events.ServerEventArgs e)
        {
            _clientHandler = e.ClientHandler;
        }

        private void Disconnected(object sender, ServerLib.Events.ServerEventArgs e)
        {
            _clientHandler = null;
        }

        private void Received(object sender, ServerLib.Events.ServerEventArgs e)
        {
            gameState = e.Hub;
        }
        private void Setting(object sender, ServerLib.Events.ServerEventArgs e)
        {
            gameState = e.Hub;
            myTurn = e.Hub.turnPlayer;
            gameState.Type = (int)PacketType.turnEnd;
            Debug.Print("{0}", myTurn);
            BoardSetting();
            turn.Text = "Player" + 1 + "차례";
        }
        public void BoardSetting()
        {
            ony.Text = gameState.boardInfo.boardGems[0].ToString() + "개";
            saf.Text = gameState.boardInfo.boardGems[1].ToString() + "개";
            eme.Text = gameState.boardInfo.boardGems[2].ToString() + "개";
            rub.Text = gameState.boardInfo.boardGems[3].ToString() + "개";
            dia.Text = gameState.boardInfo.boardGems[4].ToString() + "개";
            PlayerSetting();
            turn.Text = "Player" + gameState.turnPlayer.ToString() + "차례";
        }
        public void PlayerSetting()
        {
            int idx = myTurn - 1;
            P1_ony.Text = gameState.players[idx].playerGems[0].ToString() + "개";
            P1_saf.Text = gameState.players[idx].playerGems[1].ToString() + "개";
            P1_eme.Text = gameState.players[idx].playerGems[2].ToString() + "개";
            P1_rub.Text = gameState.players[idx].playerGems[3].ToString() + "개";
            P1_dia.Text = gameState.players[idx].playerGems[4].ToString() + "개";
            P1_GB.Text = "Player" + (idx + 1);
            P1_score.Text = gameState.players[idx].totalScore.ToString();
            idx = (idx + 1) % 4;
            P2_ony.Text = gameState.players[idx].playerGems[0].ToString() + "개";
            P2_saf.Text = gameState.players[idx].playerGems[1].ToString() + "개";
            P2_eme.Text = gameState.players[idx].playerGems[2].ToString() + "개";
            P2_rub.Text = gameState.players[idx].playerGems[3].ToString() + "개";
            P2_dia.Text = gameState.players[idx].playerGems[4].ToString() + "개";
            P2_GB.Text = "Player" + (idx + 1);
            P2_score.Text = gameState.players[idx].totalScore.ToString();
            idx = (idx + 1) % 4;
            P3_ony.Text = gameState.players[idx].playerGems[0].ToString() + "개";
            P3_saf.Text = gameState.players[idx].playerGems[1].ToString() + "개";
            P3_eme.Text = gameState.players[idx].playerGems[2].ToString() + "개";
            P3_rub.Text = gameState.players[idx].playerGems[3].ToString() + "개";
            P3_dia.Text = gameState.players[idx].playerGems[4].ToString() + "개";
            P3_GB.Text = "Player" + (idx + 1);
            P3_score.Text = gameState.players[idx].totalScore.ToString();
            idx = (idx + 1) % 4;
            P4_ony.Text = gameState.players[idx].playerGems[0].ToString() + "개";
            P4_saf.Text = gameState.players[idx].playerGems[1].ToString() + "개";
            P4_eme.Text = gameState.players[idx].playerGems[2].ToString() + "개";
            P4_rub.Text = gameState.players[idx].playerGems[3].ToString() + "개";
            P4_dia.Text = gameState.players[idx].playerGems[4].ToString() + "개";
            P4_GB.Text = "Player" + (idx + 1);
            P4_score.Text = gameState.players[idx].totalScore.ToString();
            idx = (idx + 1) % 4;
        }
        /*
     * 0 : 초콜렛(검) ony
     * 1 : 사파이어(파) saf
     * 2 : 에메랄드(초) eme
     * 3 : 루비(빨) rub
     * 4 : 다이아(흰)dia
    */
        public Form1()
        {
            InitializeComponent();
            _client = new ServerClient(IPAddress.Parse("127.0.0.1"), 8080);
            _client.Connected += Connected;
            _client.Disconnected += Disconnected;
            _client.Received += Received;
            _client.Setting += Setting;
            _client.RunningStateChanged += RunningStateChanged;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_coin_Click(object sender, EventArgs e)
        {
            //string 배열에 label 데이터 저장 
            string[] labelsData = { dia.Text, saf.Text, eme.Text, rub.Text, ony.Text };

            Form2 form2 = new Form2(labelsData);
            form2.DataUpdated += Form2_DataUpdated;
            form2.Show();
        }
        private void Form2_DataUpdated(object sender, string[] newData)
        {
            //form2에서 update된 값 label에 할당
            dia.Text = newData[0];
            saf.Text = newData[1];
            eme.Text = newData[2];
            rub.Text = newData[3];
            ony.Text = newData[4];
            Debug.Print("현재 턴{0}", gameState.turnPlayer);
            _clientHandler.Send(gameState);
        }

        private void btn_card_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }

        private async void btnConnect_Click(object sender, EventArgs e)
        {
            await _client.ConnectAsync();
        }
    }
}
