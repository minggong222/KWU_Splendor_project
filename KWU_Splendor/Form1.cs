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

        public Board card_board = new Board(); //데이터 수정시 삭제

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
            BoardSetting(GetTurn());
            turn.Text = "Player" + 1 + "차례";
        }

        public Label GetTurn()
        {
            return turn;
        }

        public void BoardSetting(Label turn)
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
     * 0 : 오닉스(검) ony
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
            
            Level1Card1.Text = card_board.boardCards1[0].cardScore.ToString() + "점" + Environment.NewLine + Environment.NewLine
                + "      " + card_board.boardCards1[0].cardCost[0].ToString() + "개" + Environment.NewLine
                + "      " + card_board.boardCards1[0].cardCost[1].ToString() + "개" + Environment.NewLine
                + "      " + card_board.boardCards1[0].cardCost[2].ToString() + "개" + Environment.NewLine
                + "      " + card_board.boardCards1[0].cardCost[3].ToString() + "개" + Environment.NewLine
                + "      " + card_board.boardCards1[0].cardCost[4].ToString() + "개" + Environment.NewLine;
            ptb_img(L1C1_ptb, card_board.boardCards1[0].cardGem);
            Level1Card2.Text = card_board.boardCards1[1].cardScore.ToString() + "점" + Environment.NewLine + Environment.NewLine
                + "      " + card_board.boardCards1[1].cardCost[0].ToString() + "개" + Environment.NewLine
                + "      " + card_board.boardCards1[1].cardCost[1].ToString() + "개" + Environment.NewLine
                + "      " + card_board.boardCards1[1].cardCost[2].ToString() + "개" + Environment.NewLine
                + "      " + card_board.boardCards1[1].cardCost[3].ToString() + "개" + Environment.NewLine
                + "      " + card_board.boardCards1[1].cardCost[4].ToString() + "개" + Environment.NewLine;
            ptb_img(L1C2_ptb, card_board.boardCards1[1].cardGem);
            Level1Card3.Text = card_board.boardCards1[2].cardScore.ToString() + "점" + Environment.NewLine + Environment.NewLine
                + "      " + card_board.boardCards1[2].cardCost[0].ToString() + "개" + Environment.NewLine
                + "      " + card_board.boardCards1[2].cardCost[1].ToString() + "개" + Environment.NewLine
                + "      " + card_board.boardCards1[2].cardCost[2].ToString() + "개" + Environment.NewLine
                + "      " + card_board.boardCards1[2].cardCost[3].ToString() + "개" + Environment.NewLine
                + "      " + card_board.boardCards1[2].cardCost[4].ToString() + "개" + Environment.NewLine;
            ptb_img(L1C3_ptb, card_board.boardCards1[2].cardGem);
            Level1Card4.Text = card_board.boardCards1[3].cardScore.ToString() + "점" + Environment.NewLine + Environment.NewLine
                + "      " + card_board.boardCards1[3].cardCost[0].ToString() + "개" + Environment.NewLine
                + "      " + card_board.boardCards1[3].cardCost[1].ToString() + "개" + Environment.NewLine
                + "      " + card_board.boardCards1[3].cardCost[2].ToString() + "개" + Environment.NewLine
                + "      " + card_board.boardCards1[3].cardCost[3].ToString() + "개" + Environment.NewLine
                + "      " + card_board.boardCards1[3].cardCost[4].ToString() + "개" + Environment.NewLine;
            ptb_img(L1C4_ptb, card_board.boardCards1[3].cardGem);

            Level2Card1.Text = card_board.boardCards2[0].cardScore.ToString() + "점" + Environment.NewLine + Environment.NewLine
                + "      " + card_board.boardCards2[0].cardCost[0].ToString() + "개" + Environment.NewLine
                + "      " + card_board.boardCards2[0].cardCost[1].ToString() + "개" + Environment.NewLine
                + "      " + card_board.boardCards2[0].cardCost[2].ToString() + "개" + Environment.NewLine
                + "      " + card_board.boardCards2[0].cardCost[3].ToString() + "개" + Environment.NewLine
                + "      " + card_board.boardCards2[0].cardCost[4].ToString() + "개" + Environment.NewLine;
            ptb_img(L2C1_ptb, card_board.boardCards2[0].cardGem);
            Level2Card2.Text = card_board.boardCards2[1].cardScore.ToString() + "점" + Environment.NewLine + Environment.NewLine
                + "      " + card_board.boardCards2[1].cardCost[0].ToString() + "개" + Environment.NewLine
                + "      " + card_board.boardCards2[1].cardCost[1].ToString() + "개" + Environment.NewLine
                + "      " + card_board.boardCards2[1].cardCost[2].ToString() + "개" + Environment.NewLine
                + "      " + card_board.boardCards2[1].cardCost[3].ToString() + "개" + Environment.NewLine
                + "      " + card_board.boardCards2[1].cardCost[4].ToString() + "개" + Environment.NewLine;
            ptb_img(L2C2_ptb, card_board.boardCards2[1].cardGem);
            Level2Card3.Text = card_board.boardCards2[2].cardScore.ToString() + "점" + Environment.NewLine + Environment.NewLine
                + "      " + card_board.boardCards2[2].cardCost[0].ToString() + "개" + Environment.NewLine
                + "      " + card_board.boardCards2[2].cardCost[1].ToString() + "개" + Environment.NewLine
                + "      " + card_board.boardCards2[2].cardCost[2].ToString() + "개" + Environment.NewLine
                + "      " + card_board.boardCards2[2].cardCost[3].ToString() + "개" + Environment.NewLine
                + "      " + card_board.boardCards2[2].cardCost[4].ToString() + "개" + Environment.NewLine;
            ptb_img(L2C3_ptb, card_board.boardCards2[2].cardGem);
            Level2Card4.Text = card_board.boardCards2[3].cardScore.ToString() + "점" + Environment.NewLine + Environment.NewLine
                + "      " + card_board.boardCards2[3].cardCost[0].ToString() + "개" + Environment.NewLine
                + "      " + card_board.boardCards2[3].cardCost[1].ToString() + "개" + Environment.NewLine
                + "      " + card_board.boardCards2[3].cardCost[2].ToString() + "개" + Environment.NewLine
                + "      " + card_board.boardCards2[3].cardCost[3].ToString() + "개" + Environment.NewLine
                + "      " + card_board.boardCards2[3].cardCost[4].ToString() + "개" + Environment.NewLine;
            ptb_img(L2C4_ptb, card_board.boardCards2[3].cardGem);

            Level3Card1.Text = card_board.boardCards3[0].cardScore.ToString() + "점" + Environment.NewLine + Environment.NewLine
                + "      " + card_board.boardCards3[0].cardCost[0].ToString() + "개" + Environment.NewLine
                + "      " + card_board.boardCards3[0].cardCost[1].ToString() + "개" + Environment.NewLine
                + "      " + card_board.boardCards3[0].cardCost[2].ToString() + "개" + Environment.NewLine
                + "      " + card_board.boardCards3[0].cardCost[3].ToString() + "개" + Environment.NewLine
                + "      " + card_board.boardCards3[0].cardCost[4].ToString() + "개" + Environment.NewLine;
            ptb_img(L3C1_ptb, card_board.boardCards3[0].cardGem);
            Level3Card2.Text = card_board.boardCards3[1].cardScore.ToString() + "점" + Environment.NewLine + Environment.NewLine
                + "      " + card_board.boardCards3[1].cardCost[0].ToString() + "개" + Environment.NewLine
                + "      " + card_board.boardCards3[1].cardCost[1].ToString() + "개" + Environment.NewLine
                + "      " + card_board.boardCards3[1].cardCost[2].ToString() + "개" + Environment.NewLine
                + "      " + card_board.boardCards3[1].cardCost[3].ToString() + "개" + Environment.NewLine
                + "      " + card_board.boardCards3[1].cardCost[4].ToString() + "개" + Environment.NewLine;
            ptb_img(L3C2_ptb, card_board.boardCards3[1].cardGem);
            Level3Card3.Text = card_board.boardCards3[2].cardScore.ToString() + "점" + Environment.NewLine + Environment.NewLine
                + "      " + card_board.boardCards3[2].cardCost[0].ToString() + "개" + Environment.NewLine
                + "      " + card_board.boardCards3[2].cardCost[1].ToString() + "개" + Environment.NewLine
                + "      " + card_board.boardCards3[2].cardCost[2].ToString() + "개" + Environment.NewLine
                + "      " + card_board.boardCards3[2].cardCost[3].ToString() + "개" + Environment.NewLine
                + "      " + card_board.boardCards3[2].cardCost[4].ToString() + "개" + Environment.NewLine;
            ptb_img(L3C3_ptb, card_board.boardCards3[2].cardGem);
            Level3Card4.Text = card_board.boardCards3[3].cardScore.ToString() + "점" + Environment.NewLine + Environment.NewLine
                + "      " + card_board.boardCards3[3].cardCost[0].ToString() + "개" + Environment.NewLine
                + "      " + card_board.boardCards3[3].cardCost[1].ToString() + "개" + Environment.NewLine
                + "      " + card_board.boardCards3[3].cardCost[2].ToString() + "개" + Environment.NewLine
                + "      " + card_board.boardCards3[3].cardCost[3].ToString() + "개" + Environment.NewLine
                + "      " + card_board.boardCards3[3].cardCost[4].ToString() + "개" + Environment.NewLine;
            ptb_img(L3C4_ptb, card_board.boardCards3[3].cardGem);

            NobleCard1.Text = "3" + "점" + Environment.NewLine + Environment.NewLine
                + "      " + card_board.boardNoble[0].nobleCost[0].ToString() + "개" + Environment.NewLine
                + "      " + card_board.boardNoble[0].nobleCost[1].ToString() + "개" + Environment.NewLine
                + "      " + card_board.boardNoble[0].nobleCost[2].ToString() + "개" + Environment.NewLine
                + "      " + card_board.boardNoble[0].nobleCost[3].ToString() + "개" + Environment.NewLine
                + "      " + card_board.boardNoble[0].nobleCost[4].ToString() + "개" + Environment.NewLine;
            NobleCard2.Text = "3" + "점" + Environment.NewLine + Environment.NewLine
                + "      " + card_board.boardNoble[1].nobleCost[0].ToString() + "개" + Environment.NewLine
                + "      " + card_board.boardNoble[1].nobleCost[1].ToString() + "개" + Environment.NewLine
                + "      " + card_board.boardNoble[1].nobleCost[2].ToString() + "개" + Environment.NewLine
                + "      " + card_board.boardNoble[1].nobleCost[3].ToString() + "개" + Environment.NewLine
                + "      " + card_board.boardNoble[1].nobleCost[4].ToString() + "개" + Environment.NewLine;
            NobleCard3.Text = "3" + "점" + Environment.NewLine + Environment.NewLine
                + "      " + card_board.boardNoble[2].nobleCost[0].ToString() + "개" + Environment.NewLine
                + "      " + card_board.boardNoble[2].nobleCost[1].ToString() + "개" + Environment.NewLine
                + "      " + card_board.boardNoble[2].nobleCost[2].ToString() + "개" + Environment.NewLine
                + "      " + card_board.boardNoble[2].nobleCost[3].ToString() + "개" + Environment.NewLine
                + "      " + card_board.boardNoble[2].nobleCost[4].ToString() + "개" + Environment.NewLine;
            NobleCard4.Text = "3" + "점" + Environment.NewLine + Environment.NewLine
                + "      " + card_board.boardNoble[3].nobleCost[0].ToString() + "개" + Environment.NewLine
                + "      " + card_board.boardNoble[3].nobleCost[1].ToString() + "개" + Environment.NewLine
                + "      " + card_board.boardNoble[3].nobleCost[2].ToString() + "개" + Environment.NewLine
                + "      " + card_board.boardNoble[3].nobleCost[3].ToString() + "개" + Environment.NewLine
                + "      " + card_board.boardNoble[3].nobleCost[4].ToString() + "개" + Environment.NewLine;
            NobleCard5.Text = "3" + "점" + Environment.NewLine + Environment.NewLine
                + "      " + card_board.boardNoble[4].nobleCost[0].ToString() + "개" + Environment.NewLine
                + "      " + card_board.boardNoble[4].nobleCost[1].ToString() + "개" + Environment.NewLine
                + "      " + card_board.boardNoble[4].nobleCost[2].ToString() + "개" + Environment.NewLine
                + "      " + card_board.boardNoble[4].nobleCost[3].ToString() + "개" + Environment.NewLine
                + "      " + card_board.boardNoble[4].nobleCost[4].ToString() + "개" + Environment.NewLine;

            Level1Card_Count.Text = Environment.NewLine + Environment.NewLine + "남은 갯수" + Environment.NewLine + Environment.NewLine + card_board.deckCards1.Count;
            Level2Card_Count.Text = Environment.NewLine + Environment.NewLine + "남은 갯수" + Environment.NewLine + Environment.NewLine + card_board.deckCards2.Count;
            Level3Card_Count.Text = Environment.NewLine + Environment.NewLine + "남은 갯수" + Environment.NewLine + Environment.NewLine + card_board.deckCards3.Count;
        }
        
        private void ptb_img(PictureBox ptb, int GemNumber)
        {
            if (GemNumber == 0) ptb.Load("Image\\onyx.png");
            if (GemNumber == 1) ptb.Load("Image\\sapphire.png");
            if (GemNumber == 2) ptb.Load("Image\\emerald.png");
            if (GemNumber == 3) ptb.Load("Image\\ruby.png");
            if (GemNumber == 4) ptb.Load("Image\\dia.png");
            ptb.SizeMode = PictureBoxSizeMode.StretchImage;
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
            List<Card> level1cards = card_board.boardCards1;
            List<Card> level2cards = card_board.boardCards2;
            List<Card> level3cards = card_board.boardCards3;
            List<Noble> noblecards = card_board.boardNoble;
            Form3 form3 = new Form3(level1cards, level2cards, level3cards , noblecards);
            //dataupdate() 함수 호출
            form3.Show();
        }

        private async void btnConnect_Click(object sender, EventArgs e)
        {
            await _client.ConnectAsync();
        }

        private void btn_reservation_Click(object sender, EventArgs e)
        {
            //drawcard 실행 테스트
            card_board.DrawCard(1);
            Level1Card_Count.Text = Environment.NewLine + Environment.NewLine + "남은 갯수" + Environment.NewLine + Environment.NewLine + card_board.deckCards1.Count;
        }
    }
}
