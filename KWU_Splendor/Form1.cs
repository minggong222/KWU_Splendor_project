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
            BoardSetting(GetTurn());
        }
        private void Setting(object sender, ServerLib.Events.ServerEventArgs e)
        {
            gameState = e.Hub;
            myTurn = e.Hub.turnPlayer;
            if (myTurn == 0)
                WinnerNotice();
            gameState.Type = (int)PacketType.turnEnd;
            Debug.Print("{0}", myTurn);
            BoardSetting(GetTurn());
            gameState.turnPlayer = 1;             
            turn.Text = "Player" + gameState.turnPlayer.ToString() + "차례";

        }

        public Label GetTurn()
        {
            return turn;
        }

        public void BoardSetting(Label turn)
        {
            GamSetting();
            CardSetting();
            PlayerSetting();
            //ReservedCardSetting();
        }
        public void GamSetting()
        {
            dia.Text = gameState.boardInfo.boardGems[0].ToString() + "개";
            saf.Text = gameState.boardInfo.boardGems[1].ToString() + "개";
            eme.Text = gameState.boardInfo.boardGems[2].ToString() + "개";
            rub.Text = gameState.boardInfo.boardGems[3].ToString() + "개";
            ony.Text = gameState.boardInfo.boardGems[4].ToString() + "개";
        }
        public void CardSetting()
        {
            Level1Card1.Text = gameState.boardInfo.boardCards1[0].cardScore.ToString() + "점" + Environment.NewLine + Environment.NewLine
                + "      " + gameState.boardInfo.boardCards1[0].cardCost[0].ToString() + "개" + Environment.NewLine
                + "      " + gameState.boardInfo.boardCards1[0].cardCost[1].ToString() + "개" + Environment.NewLine
                + "      " + gameState.boardInfo.boardCards1[0].cardCost[2].ToString() + "개" + Environment.NewLine
                + "      " + gameState.boardInfo.boardCards1[0].cardCost[3].ToString() + "개" + Environment.NewLine
                + "      " + gameState.boardInfo.boardCards1[0].cardCost[4].ToString() + "개" + Environment.NewLine;
            ptb_img(L1C1_ptb, gameState.boardInfo.boardCards1[0].cardGem);
            Level1Card2.Text = gameState.boardInfo.boardCards1[1].cardScore.ToString() + "점" + Environment.NewLine + Environment.NewLine
                + "      " + gameState.boardInfo.boardCards1[1].cardCost[0].ToString() + "개" + Environment.NewLine
                + "      " + gameState.boardInfo.boardCards1[1].cardCost[1].ToString() + "개" + Environment.NewLine
                + "      " + gameState.boardInfo.boardCards1[1].cardCost[2].ToString() + "개" + Environment.NewLine
                + "      " + gameState.boardInfo.boardCards1[1].cardCost[3].ToString() + "개" + Environment.NewLine
                + "      " + gameState.boardInfo.boardCards1[1].cardCost[4].ToString() + "개" + Environment.NewLine;
            ptb_img(L1C2_ptb, gameState.boardInfo.boardCards1[1].cardGem);
            Level1Card3.Text = gameState.boardInfo.boardCards1[2].cardScore.ToString() + "점" + Environment.NewLine + Environment.NewLine
                + "      " + gameState.boardInfo.boardCards1[2].cardCost[0].ToString() + "개" + Environment.NewLine
                + "      " + gameState.boardInfo.boardCards1[2].cardCost[1].ToString() + "개" + Environment.NewLine
                + "      " + gameState.boardInfo.boardCards1[2].cardCost[2].ToString() + "개" + Environment.NewLine
                + "      " + gameState.boardInfo.boardCards1[2].cardCost[3].ToString() + "개" + Environment.NewLine
                + "      " + gameState.boardInfo.boardCards1[2].cardCost[4].ToString() + "개" + Environment.NewLine;
            ptb_img(L1C3_ptb, gameState.boardInfo.boardCards1[2].cardGem);
            Level1Card4.Text = gameState.boardInfo.boardCards1[3].cardScore.ToString() + "점" + Environment.NewLine + Environment.NewLine
                + "      " + gameState.boardInfo.boardCards1[3].cardCost[0].ToString() + "개" + Environment.NewLine
                + "      " + gameState.boardInfo.boardCards1[3].cardCost[1].ToString() + "개" + Environment.NewLine
                + "      " + gameState.boardInfo.boardCards1[3].cardCost[2].ToString() + "개" + Environment.NewLine
                + "      " + gameState.boardInfo.boardCards1[3].cardCost[3].ToString() + "개" + Environment.NewLine
                + "      " + gameState.boardInfo.boardCards1[3].cardCost[4].ToString() + "개" + Environment.NewLine;
            ptb_img(L1C4_ptb, gameState.boardInfo.boardCards1[3].cardGem);

            Level2Card1.Text = gameState.boardInfo.boardCards2[0].cardScore.ToString() + "점" + Environment.NewLine + Environment.NewLine
                + "      " + gameState.boardInfo.boardCards2[0].cardCost[0].ToString() + "개" + Environment.NewLine
                + "      " + gameState.boardInfo.boardCards2[0].cardCost[1].ToString() + "개" + Environment.NewLine
                + "      " + gameState.boardInfo.boardCards2[0].cardCost[2].ToString() + "개" + Environment.NewLine
                + "      " + gameState.boardInfo.boardCards2[0].cardCost[3].ToString() + "개" + Environment.NewLine
                + "      " + gameState.boardInfo.boardCards2[0].cardCost[4].ToString() + "개" + Environment.NewLine;
            ptb_img(L2C1_ptb, gameState.boardInfo.boardCards2[0].cardGem);
            Level2Card2.Text = gameState.boardInfo.boardCards2[1].cardScore.ToString() + "점" + Environment.NewLine + Environment.NewLine
                + "      " + gameState.boardInfo.boardCards2[1].cardCost[0].ToString() + "개" + Environment.NewLine
                + "      " + gameState.boardInfo.boardCards2[1].cardCost[1].ToString() + "개" + Environment.NewLine
                + "      " + gameState.boardInfo.boardCards2[1].cardCost[2].ToString() + "개" + Environment.NewLine
                + "      " + gameState.boardInfo.boardCards2[1].cardCost[3].ToString() + "개" + Environment.NewLine
                + "      " + gameState.boardInfo.boardCards2[1].cardCost[4].ToString() + "개" + Environment.NewLine;
            ptb_img(L2C2_ptb, gameState.boardInfo.boardCards2[1].cardGem);
            Level2Card3.Text = gameState.boardInfo.boardCards2[2].cardScore.ToString() + "점" + Environment.NewLine + Environment.NewLine
                + "      " + gameState.boardInfo.boardCards2[2].cardCost[0].ToString() + "개" + Environment.NewLine
                + "      " + gameState.boardInfo.boardCards2[2].cardCost[1].ToString() + "개" + Environment.NewLine
                + "      " + gameState.boardInfo.boardCards2[2].cardCost[2].ToString() + "개" + Environment.NewLine
                + "      " + gameState.boardInfo.boardCards2[2].cardCost[3].ToString() + "개" + Environment.NewLine
                + "      " + gameState.boardInfo.boardCards2[2].cardCost[4].ToString() + "개" + Environment.NewLine;
            ptb_img(L2C3_ptb, gameState.boardInfo.boardCards2[2].cardGem);
            Level2Card4.Text = gameState.boardInfo.boardCards2[3].cardScore.ToString() + "점" + Environment.NewLine + Environment.NewLine
                + "      " + gameState.boardInfo.boardCards2[3].cardCost[0].ToString() + "개" + Environment.NewLine
                + "      " + gameState.boardInfo.boardCards2[3].cardCost[1].ToString() + "개" + Environment.NewLine
                + "      " + gameState.boardInfo.boardCards2[3].cardCost[2].ToString() + "개" + Environment.NewLine
                + "      " + gameState.boardInfo.boardCards2[3].cardCost[3].ToString() + "개" + Environment.NewLine
                + "      " + gameState.boardInfo.boardCards2[3].cardCost[4].ToString() + "개" + Environment.NewLine;
            ptb_img(L2C4_ptb, gameState.boardInfo.boardCards2[3].cardGem);

            Level3Card1.Text = gameState.boardInfo.boardCards3[0].cardScore.ToString() + "점" + Environment.NewLine + Environment.NewLine
                + "      " + gameState.boardInfo.boardCards3[0].cardCost[0].ToString() + "개" + Environment.NewLine
                + "      " + gameState.boardInfo.boardCards3[0].cardCost[1].ToString() + "개" + Environment.NewLine
                + "      " + gameState.boardInfo.boardCards3[0].cardCost[2].ToString() + "개" + Environment.NewLine
                + "      " + gameState.boardInfo.boardCards3[0].cardCost[3].ToString() + "개" + Environment.NewLine
                + "      " + gameState.boardInfo.boardCards3[0].cardCost[4].ToString() + "개" + Environment.NewLine;
            ptb_img(L3C1_ptb, gameState.boardInfo.boardCards3[0].cardGem);
            Level3Card2.Text = gameState.boardInfo.boardCards3[1].cardScore.ToString() + "점" + Environment.NewLine + Environment.NewLine
                + "      " + gameState.boardInfo.boardCards3[1].cardCost[0].ToString() + "개" + Environment.NewLine
                + "      " + gameState.boardInfo.boardCards3[1].cardCost[1].ToString() + "개" + Environment.NewLine
                + "      " + gameState.boardInfo.boardCards3[1].cardCost[2].ToString() + "개" + Environment.NewLine
                + "      " + gameState.boardInfo.boardCards3[1].cardCost[3].ToString() + "개" + Environment.NewLine
                + "      " + gameState.boardInfo.boardCards3[1].cardCost[4].ToString() + "개" + Environment.NewLine;
            ptb_img(L3C2_ptb, gameState.boardInfo.boardCards3[1].cardGem);
            Level3Card3.Text = gameState.boardInfo.boardCards3[2].cardScore.ToString() + "점" + Environment.NewLine + Environment.NewLine
                + "      " + gameState.boardInfo.boardCards3[2].cardCost[0].ToString() + "개" + Environment.NewLine
                + "      " + gameState.boardInfo.boardCards3[2].cardCost[1].ToString() + "개" + Environment.NewLine
                + "      " + gameState.boardInfo.boardCards3[2].cardCost[2].ToString() + "개" + Environment.NewLine
                + "      " + gameState.boardInfo.boardCards3[2].cardCost[3].ToString() + "개" + Environment.NewLine
                + "      " + gameState.boardInfo.boardCards3[2].cardCost[4].ToString() + "개" + Environment.NewLine;
            ptb_img(L3C3_ptb, gameState.boardInfo.boardCards3[2].cardGem);
            Level3Card4.Text = gameState.boardInfo.boardCards3[3].cardScore.ToString() + "점" + Environment.NewLine + Environment.NewLine
                + "      " + gameState.boardInfo.boardCards3[3].cardCost[0].ToString() + "개" + Environment.NewLine
                + "      " + gameState.boardInfo.boardCards3[3].cardCost[1].ToString() + "개" + Environment.NewLine
                + "      " + gameState.boardInfo.boardCards3[3].cardCost[2].ToString() + "개" + Environment.NewLine
                + "      " + gameState.boardInfo.boardCards3[3].cardCost[3].ToString() + "개" + Environment.NewLine
                + "      " + gameState.boardInfo.boardCards3[3].cardCost[4].ToString() + "개" + Environment.NewLine;
            ptb_img(L3C4_ptb, gameState.boardInfo.boardCards3[3].cardGem);

            NobleCard1.Text = "3" + "점" + Environment.NewLine + Environment.NewLine
                + "      " + gameState.boardInfo.boardNoble[0].nobleCost[0].ToString() + "개" + Environment.NewLine
                + "      " + gameState.boardInfo.boardNoble[0].nobleCost[1].ToString() + "개" + Environment.NewLine
                + "      " + gameState.boardInfo.boardNoble[0].nobleCost[2].ToString() + "개" + Environment.NewLine
                + "      " + gameState.boardInfo.boardNoble[0].nobleCost[3].ToString() + "개" + Environment.NewLine
                + "      " + gameState.boardInfo.boardNoble[0].nobleCost[4].ToString() + "개" + Environment.NewLine;
            NobleCard2.Text = "3" + "점" + Environment.NewLine + Environment.NewLine
                + "      " + gameState.boardInfo.boardNoble[1].nobleCost[0].ToString() + "개" + Environment.NewLine
                + "      " + gameState.boardInfo.boardNoble[1].nobleCost[1].ToString() + "개" + Environment.NewLine
                + "      " + gameState.boardInfo.boardNoble[1].nobleCost[2].ToString() + "개" + Environment.NewLine
                + "      " + gameState.boardInfo.boardNoble[1].nobleCost[3].ToString() + "개" + Environment.NewLine
                + "      " + gameState.boardInfo.boardNoble[1].nobleCost[4].ToString() + "개" + Environment.NewLine;
            NobleCard3.Text = "3" + "점" + Environment.NewLine + Environment.NewLine
                + "      " + gameState.boardInfo.boardNoble[2].nobleCost[0].ToString() + "개" + Environment.NewLine
                + "      " + gameState.boardInfo.boardNoble[2].nobleCost[1].ToString() + "개" + Environment.NewLine
                + "      " + gameState.boardInfo.boardNoble[2].nobleCost[2].ToString() + "개" + Environment.NewLine
                + "      " + gameState.boardInfo.boardNoble[2].nobleCost[3].ToString() + "개" + Environment.NewLine
                + "      " + gameState.boardInfo.boardNoble[2].nobleCost[4].ToString() + "개" + Environment.NewLine;
            NobleCard4.Text = "3" + "점" + Environment.NewLine + Environment.NewLine
                + "      " + gameState.boardInfo.boardNoble[3].nobleCost[0].ToString() + "개" + Environment.NewLine
                + "      " + gameState.boardInfo.boardNoble[3].nobleCost[1].ToString() + "개" + Environment.NewLine
                + "      " + gameState.boardInfo.boardNoble[3].nobleCost[2].ToString() + "개" + Environment.NewLine
                + "      " + gameState.boardInfo.boardNoble[3].nobleCost[3].ToString() + "개" + Environment.NewLine
                + "      " + gameState.boardInfo.boardNoble[3].nobleCost[4].ToString() + "개" + Environment.NewLine;
            NobleCard5.Text = "3" + "점" + Environment.NewLine + Environment.NewLine
                + "      " + gameState.boardInfo.boardNoble[4].nobleCost[0].ToString() + "개" + Environment.NewLine
                + "      " + gameState.boardInfo.boardNoble[4].nobleCost[1].ToString() + "개" + Environment.NewLine
                + "      " + gameState.boardInfo.boardNoble[4].nobleCost[2].ToString() + "개" + Environment.NewLine
                + "      " + gameState.boardInfo.boardNoble[4].nobleCost[3].ToString() + "개" + Environment.NewLine
                + "      " + gameState.boardInfo.boardNoble[4].nobleCost[4].ToString() + "개" + Environment.NewLine;

            Level1Card_Count.Text = Environment.NewLine + Environment.NewLine + "남은 갯수" + Environment.NewLine + Environment.NewLine + gameState.boardInfo.deckCards1.Count;
            Level2Card_Count.Text = Environment.NewLine + Environment.NewLine + "남은 갯수" + Environment.NewLine + Environment.NewLine + gameState.boardInfo.deckCards2.Count;
            Level3Card_Count.Text = Environment.NewLine + Environment.NewLine + "남은 갯수" + Environment.NewLine + Environment.NewLine + gameState.boardInfo.deckCards3.Count;
        }
        public void PlayerSetting()
        {
            int idx = myTurn - 1;
            P1_dia.Text = gameState.players[idx].playerGems[0].ToString() + "개";
            P1_saf.Text = gameState.players[idx].playerGems[1].ToString() + "개";
            P1_eme.Text = gameState.players[idx].playerGems[2].ToString() + "개";
            P1_rub.Text = gameState.players[idx].playerGems[3].ToString() + "개";
            P1_ony.Text = gameState.players[idx].playerGems[4].ToString() + "개";
            P1_gol.Text = gameState.players[idx].playerGems[5].ToString() + "개";
            P1_diaCard.Text = "+" + gameState.players[idx].gemSale[0].ToString();
            P1_safCard.Text = "+" + gameState.players[idx].gemSale[1].ToString();
            P1_emeCard.Text = "+" + gameState.players[idx].gemSale[2].ToString();
            P1_rubCard.Text = "+" + gameState.players[idx].gemSale[3].ToString();
            P1_onyCard.Text = "+" + gameState.players[idx].gemSale[4].ToString();
            P1_GB.Text = "Player" + (idx + 1);
            P1_score.Text = gameState.players[idx].totalScore.ToString();
            hideReserved();

            if (gameState.players[idx].reservedCards.Count == 1)
            {
                P1_reserved1.Visible = true;
                P1R1_ptb.Visible = true;
                P1_r1g1.Visible = true;
                P1_r1g2.Visible = true;
                P1_r1g3.Visible = true;
                P1_r1g4.Visible = true;
                P1_r1g5.Visible = true;
                P1_reserved1.Text = gameState.players[idx].reservedCards[0].cardScore.ToString() + "점" + Environment.NewLine + Environment.NewLine
                    + "      " + gameState.players[idx].reservedCards[0].cardCost[0].ToString() + "개" + Environment.NewLine
                    + "      " + gameState.players[idx].reservedCards[0].cardCost[1].ToString() + "개" + Environment.NewLine
                    + "      " + gameState.players[idx].reservedCards[0].cardCost[2].ToString() + "개" + Environment.NewLine
                    + "      " + gameState.players[idx].reservedCards[0].cardCost[3].ToString() + "개" + Environment.NewLine
                    + "      " + gameState.players[idx].reservedCards[0].cardCost[4].ToString() + "개" + Environment.NewLine;
                ptb_img(P1R1_ptb, gameState.players[idx].reservedCards[0].cardGem);
            }
            else if (gameState.players[idx].reservedCards.Count == 2)
            {
                P1_reserved2.Visible = true;
                P1R2_ptb.Visible = true;
                P1_r2g1.Visible = true;
                P1_r2g2.Visible = true;
                P1_r2g3.Visible = true;
                P1_r2g4.Visible = true;
                P1_r2g5.Visible = true;
                P1_reserved2.Text = gameState.players[idx].reservedCards[1].cardScore.ToString() + "점" + Environment.NewLine + Environment.NewLine
                    + "      " + gameState.players[idx].reservedCards[1].cardCost[0].ToString() + "개" + Environment.NewLine
                    + "      " + gameState.players[idx].reservedCards[1].cardCost[1].ToString() + "개" + Environment.NewLine
                    + "      " + gameState.players[idx].reservedCards[1].cardCost[2].ToString() + "개" + Environment.NewLine
                    + "      " + gameState.players[idx].reservedCards[1].cardCost[3].ToString() + "개" + Environment.NewLine
                    + "      " + gameState.players[idx].reservedCards[1].cardCost[4].ToString() + "개" + Environment.NewLine;
                ptb_img(P1R2_ptb, gameState.players[idx].reservedCards[1].cardGem);
            }
            else if (gameState.players[idx].reservedCards.Count == 3)
            {
                P1_reserved3.Visible = true;
                P1R3_ptb.Visible = true;
                P1_r3g1.Visible = true;
                P1_r3g2.Visible = true;
                P1_r3g3.Visible = true;
                P1_r3g4.Visible = true;
                P1_r3g5.Visible = true;
                P1_reserved3.Text = gameState.players[idx].reservedCards[2].cardScore.ToString() + "점" + Environment.NewLine + Environment.NewLine
                     + "      " + gameState.players[idx].reservedCards[2].cardCost[0].ToString() + "개" + Environment.NewLine
                     + "      " + gameState.players[idx].reservedCards[2].cardCost[1].ToString() + "개" + Environment.NewLine
                     + "      " + gameState.players[idx].reservedCards[2].cardCost[2].ToString() + "개" + Environment.NewLine
                     + "      " + gameState.players[idx].reservedCards[2].cardCost[3].ToString() + "개" + Environment.NewLine
                     + "      " + gameState.players[idx].reservedCards[2].cardCost[4].ToString() + "개" + Environment.NewLine;
                ptb_img(P1R3_ptb, gameState.players[idx].reservedCards[2].cardGem);
            }
            idx = (idx + 1) % 4;
            P2_dia.Text = gameState.players[idx].playerGems[0].ToString() + "개";
            P2_saf.Text = gameState.players[idx].playerGems[1].ToString() + "개";
            P2_eme.Text = gameState.players[idx].playerGems[2].ToString() + "개";
            P2_rub.Text = gameState.players[idx].playerGems[3].ToString() + "개";
            P2_ony.Text = gameState.players[idx].playerGems[4].ToString() + "개";
            P2_gol.Text = gameState.players[idx].playerGems[5].ToString() + "개";
            P2_diaCard.Text = "+" + gameState.players[idx].gemSale[0].ToString();
            P2_safCard.Text = "+" + gameState.players[idx].gemSale[1].ToString();
            P2_emeCard.Text = "+" + gameState.players[idx].gemSale[2].ToString();
            P2_rubCard.Text = "+" + gameState.players[idx].gemSale[3].ToString();
            P2_onyCard.Text = "+" + gameState.players[idx].gemSale[4].ToString();
            P2_GB.Text = "Player" + (idx + 1);
            P2_score.Text = gameState.players[idx].totalScore.ToString();
            if (gameState.players[idx].reservedCards.Count == 1)
            {
                P2_reserved1.Visible = true;
                P2R1_ptb.Visible = true;
                P2_r1g1.Visible = true;
                P2_r1g2.Visible = true;
                P2_r1g3.Visible = true;
                P2_r1g4.Visible = true;
                P2_r1g5.Visible = true;
                P2_reserved1.Text = gameState.players[idx].reservedCards[0].cardScore.ToString() + "점" + Environment.NewLine + Environment.NewLine
                    + "      " + gameState.players[idx].reservedCards[0].cardCost[0].ToString() + "개" + Environment.NewLine
                    + "      " + gameState.players[idx].reservedCards[0].cardCost[1].ToString() + "개" + Environment.NewLine
                    + "      " + gameState.players[idx].reservedCards[0].cardCost[2].ToString() + "개" + Environment.NewLine
                    + "      " + gameState.players[idx].reservedCards[0].cardCost[3].ToString() + "개" + Environment.NewLine
                    + "      " + gameState.players[idx].reservedCards[0].cardCost[4].ToString() + "개" + Environment.NewLine;
                ptb_img(P2R1_ptb, gameState.players[idx].reservedCards[0].cardGem);
            }
            else if (gameState.players[idx].reservedCards.Count == 2)
            {
                P2_reserved2.Visible = true;
                P2R2_ptb.Visible = true;
                P2_r2g1.Visible = true;
                P2_r2g2.Visible = true;
                P2_r2g3.Visible = true;
                P2_r2g4.Visible = true;
                P2_r2g5.Visible = true;
                P2_reserved2.Text = gameState.players[idx].reservedCards[1].cardScore.ToString() + "점" + Environment.NewLine + Environment.NewLine
                    + "      " + gameState.players[idx].reservedCards[1].cardCost[0].ToString() + "개" + Environment.NewLine
                    + "      " + gameState.players[idx].reservedCards[1].cardCost[1].ToString() + "개" + Environment.NewLine
                    + "      " + gameState.players[idx].reservedCards[1].cardCost[2].ToString() + "개" + Environment.NewLine
                    + "      " + gameState.players[idx].reservedCards[1].cardCost[3].ToString() + "개" + Environment.NewLine
                    + "      " + gameState.players[idx].reservedCards[1].cardCost[4].ToString() + "개" + Environment.NewLine;
                ptb_img(P2R2_ptb, gameState.players[idx].reservedCards[1].cardGem);
            }
            else if (gameState.players[idx].reservedCards.Count == 3)
            {
                P2_reserved3.Visible = true;
                P2R3_ptb.Visible = true;
                P2_r3g1.Visible = true;
                P2_r3g2.Visible = true;
                P2_r3g3.Visible = true;
                P2_r3g4.Visible = true;
                P2_r3g5.Visible = true;
                P2_reserved3.Text = gameState.players[idx].reservedCards[2].cardScore.ToString() + "점" + Environment.NewLine + Environment.NewLine
                     + "      " + gameState.players[idx].reservedCards[2].cardCost[0].ToString() + "개" + Environment.NewLine
                     + "      " + gameState.players[idx].reservedCards[2].cardCost[1].ToString() + "개" + Environment.NewLine
                     + "      " + gameState.players[idx].reservedCards[2].cardCost[2].ToString() + "개" + Environment.NewLine
                     + "      " + gameState.players[idx].reservedCards[2].cardCost[3].ToString() + "개" + Environment.NewLine
                     + "      " + gameState.players[idx].reservedCards[2].cardCost[4].ToString() + "개" + Environment.NewLine;
                ptb_img(P2R3_ptb, gameState.players[idx].reservedCards[2].cardGem);
            }
            idx = (idx + 1) % 4;
            P3_dia.Text = gameState.players[idx].playerGems[0].ToString() + "개";
            P3_saf.Text = gameState.players[idx].playerGems[1].ToString() + "개";
            P3_eme.Text = gameState.players[idx].playerGems[2].ToString() + "개";
            P3_rub.Text = gameState.players[idx].playerGems[3].ToString() + "개";
            P3_ony.Text = gameState.players[idx].playerGems[4].ToString() + "개";
            P3_gol.Text = gameState.players[idx].playerGems[5].ToString() + "개";
            P3_diaCard.Text = "+" + gameState.players[idx].gemSale[0].ToString();
            P3_safCard.Text = "+" + gameState.players[idx].gemSale[1].ToString();
            P3_emeCard.Text = "+" + gameState.players[idx].gemSale[2].ToString();
            P3_rubCard.Text = "+" + gameState.players[idx].gemSale[3].ToString();
            P3_onyCard.Text = "+" + gameState.players[idx].gemSale[4].ToString();
            P3_GB.Text = "Player" + (idx + 1);
            P3_score.Text = gameState.players[idx].totalScore.ToString();
            if (gameState.players[idx].reservedCards.Count == 1)
            {
                P3_reserved1.Visible = true;
                P3R1_ptb.Visible = true;
                P3_r1g1.Visible = true;
                P3_r1g2.Visible = true;
                P3_r1g3.Visible = true;
                P3_r1g4.Visible = true;
                P3_r1g5.Visible = true;
                P3_reserved1.Text = gameState.players[idx].reservedCards[0].cardScore.ToString() + "점" + Environment.NewLine + Environment.NewLine
                    + "      " + gameState.players[idx].reservedCards[0].cardCost[0].ToString() + "개" + Environment.NewLine
                    + "      " + gameState.players[idx].reservedCards[0].cardCost[1].ToString() + "개" + Environment.NewLine
                    + "      " + gameState.players[idx].reservedCards[0].cardCost[2].ToString() + "개" + Environment.NewLine
                    + "      " + gameState.players[idx].reservedCards[0].cardCost[3].ToString() + "개" + Environment.NewLine
                    + "      " + gameState.players[idx].reservedCards[0].cardCost[4].ToString() + "개" + Environment.NewLine;
                ptb_img(P3R1_ptb, gameState.players[idx].reservedCards[0].cardGem);
            }
            else if (gameState.players[idx].reservedCards.Count == 2)
            {
                P3_reserved2.Visible = true;
                P3R2_ptb.Visible = true;
                P3_r2g1.Visible = true;
                P3_r2g2.Visible = true;
                P3_r2g3.Visible = true;
                P3_r2g4.Visible = true;
                P3_r2g5.Visible = true;
                P3_reserved2.Text = gameState.players[idx].reservedCards[1].cardScore.ToString() + "점" + Environment.NewLine + Environment.NewLine
                    + "      " + gameState.players[idx].reservedCards[1].cardCost[0].ToString() + "개" + Environment.NewLine
                    + "      " + gameState.players[idx].reservedCards[1].cardCost[1].ToString() + "개" + Environment.NewLine
                    + "      " + gameState.players[idx].reservedCards[1].cardCost[2].ToString() + "개" + Environment.NewLine
                    + "      " + gameState.players[idx].reservedCards[1].cardCost[3].ToString() + "개" + Environment.NewLine
                    + "      " + gameState.players[idx].reservedCards[1].cardCost[4].ToString() + "개" + Environment.NewLine;
                ptb_img(P3R2_ptb, gameState.players[idx].reservedCards[1].cardGem);
            }
            else if (gameState.players[idx].reservedCards.Count == 3)
            {
                P3_reserved3.Visible = true;
                P3R3_ptb.Visible = true;
                P3_r3g1.Visible = true;
                P3_r3g2.Visible = true;
                P3_r3g3.Visible = true;
                P3_r3g4.Visible = true;
                P3_r3g5.Visible = true;
                P3_reserved3.Text = gameState.players[idx].reservedCards[2].cardScore.ToString() + "점" + Environment.NewLine + Environment.NewLine
                     + "      " + gameState.players[idx].reservedCards[2].cardCost[0].ToString() + "개" + Environment.NewLine
                     + "      " + gameState.players[idx].reservedCards[2].cardCost[1].ToString() + "개" + Environment.NewLine
                     + "      " + gameState.players[idx].reservedCards[2].cardCost[2].ToString() + "개" + Environment.NewLine
                     + "      " + gameState.players[idx].reservedCards[2].cardCost[3].ToString() + "개" + Environment.NewLine
                     + "      " + gameState.players[idx].reservedCards[2].cardCost[4].ToString() + "개" + Environment.NewLine;
                ptb_img(P3R3_ptb, gameState.players[idx].reservedCards[2].cardGem);
            }
            idx = (idx + 1) % 4;
            P4_dia.Text = gameState.players[idx].playerGems[0].ToString() + "개";
            P4_saf.Text = gameState.players[idx].playerGems[1].ToString() + "개";
            P4_eme.Text = gameState.players[idx].playerGems[2].ToString() + "개";
            P4_rub.Text = gameState.players[idx].playerGems[3].ToString() + "개";
            P4_ony.Text = gameState.players[idx].playerGems[4].ToString() + "개";
            P4_gol.Text = gameState.players[idx].playerGems[5].ToString() + "개";
            P4_diaCard.Text = "+" + gameState.players[idx].gemSale[0].ToString();
            P4_safCard.Text = "+" + gameState.players[idx].gemSale[1].ToString();
            P4_emeCard.Text = "+" + gameState.players[idx].gemSale[2].ToString();
            P4_rubCard.Text = "+" + gameState.players[idx].gemSale[3].ToString();
            P4_onyCard.Text = "+" + gameState.players[idx].gemSale[4].ToString();
            P4_GB.Text = "Player" + (idx + 1);
            P4_score.Text = gameState.players[idx].totalScore.ToString();
            round.Text = "Round" + gameState.round;
            if (gameState.players[idx].reservedCards.Count == 1)
            {
                P4_reserved1.Visible = true;
                P4R1_ptb.Visible = true;
                P4_r1g1.Visible = true;
                P4_r1g2.Visible = true;
                P4_r1g3.Visible = true;
                P4_r1g4.Visible = true;
                P4_r1g5.Visible = true;
                P4_reserved1.Text = gameState.players[idx].reservedCards[0].cardScore.ToString() + "점" + Environment.NewLine + Environment.NewLine
                    + "      " + gameState.players[idx].reservedCards[0].cardCost[0].ToString() + "개" + Environment.NewLine
                    + "      " + gameState.players[idx].reservedCards[0].cardCost[1].ToString() + "개" + Environment.NewLine
                    + "      " + gameState.players[idx].reservedCards[0].cardCost[2].ToString() + "개" + Environment.NewLine
                    + "      " + gameState.players[idx].reservedCards[0].cardCost[3].ToString() + "개" + Environment.NewLine
                    + "      " + gameState.players[idx].reservedCards[0].cardCost[4].ToString() + "개" + Environment.NewLine;
                ptb_img(P4R1_ptb, gameState.players[idx].reservedCards[0].cardGem);
            }
            else if (gameState.players[idx].reservedCards.Count == 2)
            {
                P4_reserved2.Visible = true;
                P4R2_ptb.Visible = true;
                P4_r2g1.Visible = true;
                P4_r2g2.Visible = true;
                P4_r2g3.Visible = true;
                P4_r2g4.Visible = true;
                P4_r2g5.Visible = true;
                P4_reserved2.Text = gameState.players[idx].reservedCards[1].cardScore.ToString() + "점" + Environment.NewLine + Environment.NewLine
                    + "      " + gameState.players[idx].reservedCards[1].cardCost[0].ToString() + "개" + Environment.NewLine
                    + "      " + gameState.players[idx].reservedCards[1].cardCost[1].ToString() + "개" + Environment.NewLine
                    + "      " + gameState.players[idx].reservedCards[1].cardCost[2].ToString() + "개" + Environment.NewLine
                    + "      " + gameState.players[idx].reservedCards[1].cardCost[3].ToString() + "개" + Environment.NewLine
                    + "      " + gameState.players[idx].reservedCards[1].cardCost[4].ToString() + "개" + Environment.NewLine;
                ptb_img(P4R2_ptb, gameState.players[idx].reservedCards[1].cardGem);
            }
            else if (gameState.players[idx].reservedCards.Count == 3)
            {
                P4_reserved3.Visible = true;
                P4R3_ptb.Visible = true;
                P4_r3g1.Visible = true;
                P4_r3g2.Visible = true;
                P4_r3g3.Visible = true;
                P4_r3g4.Visible = true;
                P4_r3g5.Visible = true;
                P4_reserved3.Text = gameState.players[idx].reservedCards[2].cardScore.ToString() + "점" + Environment.NewLine + Environment.NewLine
                     + "      " + gameState.players[idx].reservedCards[2].cardCost[0].ToString() + "개" + Environment.NewLine
                     + "      " + gameState.players[idx].reservedCards[2].cardCost[1].ToString() + "개" + Environment.NewLine
                     + "      " + gameState.players[idx].reservedCards[2].cardCost[2].ToString() + "개" + Environment.NewLine
                     + "      " + gameState.players[idx].reservedCards[2].cardCost[3].ToString() + "개" + Environment.NewLine
                     + "      " + gameState.players[idx].reservedCards[2].cardCost[4].ToString() + "개" + Environment.NewLine;
                ptb_img(P4R3_ptb, gameState.players[idx].reservedCards[2].cardGem);
            }
            turn.Text = "Player" + gameState.turnPlayer.ToString() + "차례";
        }
       public void hideReserved()
        {
            P1_reserved1.Visible = false;
            P1_reserved2.Visible = false;
            P1_reserved3.Visible = false;
            P1R1_ptb.Visible = false;
            P1R2_ptb.Visible = false;
            P1R3_ptb.Visible = false;
            P1_r1g1.Visible = false;
            P1_r1g2.Visible = false;
            P1_r1g3.Visible = false;
            P1_r1g4.Visible = false;
            P1_r1g5.Visible = false;
            P1_r2g1.Visible = false;
            P1_r2g2.Visible = false;
            P1_r2g3.Visible = false;
            P1_r2g4.Visible = false;
            P1_r2g5.Visible = false;
            P1_r3g1.Visible = false;
            P1_r3g2.Visible = false;
            P1_r3g3.Visible = false;
            P1_r3g4.Visible = false;
            P1_r3g5.Visible = false;

            P3_reserved1.Visible = false;
            P3_reserved2.Visible = false;
            P3_reserved3.Visible = false;
            P3R1_ptb.Visible = false;
            P3R2_ptb.Visible = false;
            P3R3_ptb.Visible = false;
            P2_r1g1.Visible = false;
            P2_r1g2.Visible = false;
            P2_r1g3.Visible = false;
            P2_r1g4.Visible = false;
            P2_r1g5.Visible = false;
            P2_r2g1.Visible = false;
            P2_r2g2.Visible = false;
            P2_r2g3.Visible = false;
            P2_r2g4.Visible = false;
            P2_r2g5.Visible = false;
            P2_r3g1.Visible = false;
            P2_r3g2.Visible = false;
            P2_r3g3.Visible = false;
            P2_r3g4.Visible = false;
            P2_r3g5.Visible = false;

            P2_reserved1.Visible = false;
            P2_reserved2.Visible = false;
            P2_reserved3.Visible = false;
            P2R1_ptb.Visible = false;
            P2R2_ptb.Visible = false;
            P2R3_ptb.Visible = false;
            P3_r1g1.Visible = false;
            P3_r1g2.Visible = false;
            P3_r1g3.Visible = false;
            P3_r1g4.Visible = false;
            P3_r1g5.Visible = false;
            P3_r2g1.Visible = false;
            P3_r2g2.Visible = false;
            P3_r2g3.Visible = false;
            P3_r2g4.Visible = false;
            P3_r2g5.Visible = false;
            P3_r3g1.Visible = false;
            P3_r3g2.Visible = false;
            P3_r3g3.Visible = false;
            P3_r3g4.Visible = false;
            P3_r3g5.Visible = false;

            P4_reserved1.Visible = false;
            P4_reserved2.Visible = false;
            P4_reserved3.Visible = false;
            P4R1_ptb.Visible = false;
            P4R2_ptb.Visible = false;
            P4R3_ptb.Visible = false;
            P4_r1g1.Visible = false;
            P4_r1g2.Visible = false;
            P4_r1g3.Visible = false;
            P4_r1g4.Visible = false;
            P4_r1g5.Visible = false;
            P4_r2g1.Visible = false;
            P4_r2g2.Visible = false;
            P4_r2g3.Visible = false;
            P4_r2g4.Visible = false;
            P4_r2g5.Visible = false;
            P4_r3g1.Visible = false;
            P4_r3g2.Visible = false;
            P4_r3g3.Visible = false;
            P4_r3g4.Visible = false;
            P4_r3g5.Visible = false;
        }

        /*
     * 0 : 다이아(흰)dia
     * 1 : 사파이어(파) saf
     * 2 : 에메랄드(초) eme
     * 3 : 루비(빨) rub
     * 4 : 오닉스(검) ony
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
        
        private void ptb_img(PictureBox ptb, int GemNumber)
        {
            if (GemNumber == 0) ptb.Load("Image\\dia.png");
            if (GemNumber == 1) ptb.Load("Image\\sapphire.png");
            if (GemNumber == 2) ptb.Load("Image\\emerald.png");
            if (GemNumber == 3) ptb.Load("Image\\ruby.png");
            if (GemNumber == 4) ptb.Load("Image\\onyx.png");
            ptb.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void btn_coin_Click(object sender, EventArgs e)
        {
            //string 배열에 label 데이터 저장 
            string[] labelsData = { dia.Text, saf.Text, eme.Text, rub.Text, ony.Text };

            if (gameState.turnPlayer == myTurn)
            {
                Form2 form2 = new Form2(labelsData, true);
                form2.DataUpdated += Form2_DataUpdated;
                form2.DataUpdated2 += Form2_DataUpdated2;
                form2.Show();
            }
            else
            {
                MessageBox.Show("나의 턴이 아닙니다.");
            }
        }
        private void Form2_DataUpdated(object sender, string[] newData)
        {
            //보석 가져오기
            //form2에서 update된 값 label에 할당
            gameState.players[myTurn - 1].playerGems[0] += (Int32.Parse(dia.Text.Substring(0, 1)) - Int32.Parse(newData[0].Substring(0, 1)));
            gameState.players[myTurn - 1].playerGems[1] += (Int32.Parse(saf.Text.Substring(0, 1)) - Int32.Parse(newData[1].Substring(0, 1)));
            gameState.players[myTurn - 1].playerGems[2] += (Int32.Parse(eme.Text.Substring(0, 1)) - Int32.Parse(newData[2].Substring(0, 1)));
            gameState.players[myTurn - 1].playerGems[3] += (Int32.Parse(rub.Text.Substring(0, 1)) - Int32.Parse(newData[3].Substring(0, 1)));
            gameState.players[myTurn - 1].playerGems[4] += (Int32.Parse(ony.Text.Substring(0, 1)) - Int32.Parse(newData[4].Substring(0, 1)));
            gameState.boardInfo.boardGems[0] = Int32.Parse(newData[0].Substring(0, 1));
            gameState.boardInfo.boardGems[1] = Int32.Parse(newData[1].Substring(0, 1));
            gameState.boardInfo.boardGems[2] = Int32.Parse(newData[2].Substring(0, 1));
            gameState.boardInfo.boardGems[3] = Int32.Parse(newData[3].Substring(0, 1));
            gameState.boardInfo.boardGems[4] = Int32.Parse(newData[4].Substring(0, 1));


            //플레이어의 보석이 10개 이상일시
            int total_gem = gameState.players[myTurn - 1].playerGems[0] + gameState.players[myTurn - 1].playerGems[1] +
                gameState.players[myTurn - 1].playerGems[2] + gameState.players[myTurn - 1].playerGems[3]
                + gameState.players[myTurn - 1].playerGems[4] + gameState.players[myTurn - 1].playerGems[5];
            if (total_gem > 10)
            {
                MessageBox.Show("플레이어는 보석을 최대 10개까지 소지 할 수 있습니다!");
                string[] labelsData = { gameState.players[myTurn - 1].playerGems[0].ToString() + "개",
                    gameState.players[myTurn - 1].playerGems[1].ToString() + "개", 
                    gameState.players[myTurn - 1].playerGems[2].ToString() + "개", 
                    gameState.players[myTurn - 1].playerGems[3].ToString() + "개", 
                    gameState.players[myTurn - 1].playerGems[4].ToString() + "개" };

                Form2 form2 = new Form2(labelsData, false);
                form2.DataUpdated += Form2_DataUpdated;
                form2.DataUpdated2 += Form2_DataUpdated2;
                form2.Show();
            }
            else
            {
                _clientHandler.Send(gameState);
            }

            
            //_clientHandler.Send(gameState);

        }

        private void Form2_DataUpdated2(object sender, string[] newData)
        {
            //보석 버리기
            //form2에서 update된 값 label에 할당
            gameState.players[myTurn - 1].playerGems[0] -= Int32.Parse(newData[0].Substring(0, 1));
            gameState.players[myTurn - 1].playerGems[1] -= Int32.Parse(newData[1].Substring(0, 1));
            gameState.players[myTurn - 1].playerGems[2] -= Int32.Parse(newData[2].Substring(0, 1));
            gameState.players[myTurn - 1].playerGems[3] -= Int32.Parse(newData[3].Substring(0, 1));
            gameState.players[myTurn - 1].playerGems[4] -= Int32.Parse(newData[4].Substring(0, 1));
            gameState.boardInfo.boardGems[0] += Int32.Parse(newData[0].Substring(0, 1));
            gameState.boardInfo.boardGems[1] += Int32.Parse(newData[1].Substring(0, 1));
            gameState.boardInfo.boardGems[2] += Int32.Parse(newData[2].Substring(0, 1));
            gameState.boardInfo.boardGems[3] += Int32.Parse(newData[3].Substring(0, 1));
            gameState.boardInfo.boardGems[4] += Int32.Parse(newData[4].Substring(0, 1));

            _clientHandler.Send(gameState);
        }
        private void btn_card_Click(object sender, EventArgs e)
        {
            if (gameState.turnPlayer == myTurn)
            {
                List<Card> level1cards = gameState.boardInfo.boardCards1;
                List<Card> level2cards = gameState.boardInfo.boardCards2;
                List<Card> level3cards = gameState.boardInfo.boardCards3;
                List<Noble> noblecards = gameState.boardInfo.boardNoble;
                List<Card> Rcards = gameState.players[myTurn - 1].reservedCards;
                Form3 form3 = new Form3(level1cards, level2cards, level3cards, noblecards, Rcards);
                form3.CardBuy += Form3_CardBuy;
                form3.NobleBuy += Form3_NobleBuy;
                form3.Reserved += Form3_Reserved;
                form3.Show();
            }
            else
            {
                MessageBox.Show("나의 턴이 아닙니다.");
            }
        }
        private void Form3_CardBuy(object sender, Card card)
        {
            if (card.cardCost[0] <= gameState.players[myTurn - 1].playerGems[0] + gameState.players[myTurn - 1].gemSale[0] &&
                card.cardCost[1] <= gameState.players[myTurn - 1].playerGems[1] + gameState.players[myTurn - 1].gemSale[1] &&
                card.cardCost[2] <= gameState.players[myTurn - 1].playerGems[2] + gameState.players[myTurn - 1].gemSale[2] &&
                card.cardCost[3] <= gameState.players[myTurn - 1].playerGems[3] + gameState.players[myTurn - 1].gemSale[3] &&
                card.cardCost[4] <= gameState.players[myTurn - 1].playerGems[4] + gameState.players[myTurn - 1].gemSale[4])
            {
                Random rnd = new Random();
                int cost;
                cost = card.cardCost[0] - gameState.players[myTurn - 1].gemSale[0];
                if (cost > 0)
                {
                    gameState.boardInfo.boardGems[0] += cost;
                    gameState.players[myTurn - 1].playerGems[0] -= cost;
                }
                cost = card.cardCost[1] - gameState.players[myTurn - 1].gemSale[1];
                if (cost > 0)
                {
                    gameState.boardInfo.boardGems[1] += cost;
                    gameState.players[myTurn - 1].playerGems[1] -= cost;
                }
                cost = card.cardCost[2] - gameState.players[myTurn - 1].gemSale[2];
                if (cost > 0)
                {
                    gameState.boardInfo.boardGems[2] += cost;
                    gameState.players[myTurn - 1].playerGems[2] -= cost;
                }
                cost = card.cardCost[3] - gameState.players[myTurn - 1].gemSale[3];
                if (cost > 0)
                {
                    gameState.boardInfo.boardGems[3] += cost;
                    gameState.players[myTurn - 1].playerGems[3] -= cost;
                }
                cost = card.cardCost[4] - gameState.players[myTurn - 1].gemSale[4];
                if (cost > 0)
                {
                    gameState.boardInfo.boardGems[4] += cost;
                    gameState.players[myTurn - 1].playerGems[4] -= cost;
                }

                gameState.players[myTurn - 1].totalScore += card.cardScore;
                gameState.players[myTurn - 1].gemSale[card.cardGem]++;
                gameState.players[myTurn - 1].playerCards.Add(card);
                int num;
                if(card.cardID <= 40)
                {
                    num = rnd.Next(gameState.boardInfo.deckCards1.Count);
                    gameState.boardInfo.boardCards1.Remove(card);
                    gameState.boardInfo.boardCards1.Add(gameState.boardInfo.deckCards1[num]);
                    gameState.boardInfo.deckCards1.Remove(gameState.boardInfo.deckCards1[num]);

                }
                else if(card.cardID <= 70)
                {
                    num = rnd.Next(gameState.boardInfo.deckCards1.Count);
                    gameState.boardInfo.boardCards2.Remove(card);
                    gameState.boardInfo.boardCards2.Add(gameState.boardInfo.deckCards2[num]);
                    gameState.boardInfo.deckCards2.Remove(gameState.boardInfo.deckCards2[num]);

                }
                else
                {
                    num = rnd.Next(gameState.boardInfo.deckCards1.Count);
                    gameState.boardInfo.boardCards3.Remove(card);
                    gameState.boardInfo.boardCards3.Add(gameState.boardInfo.deckCards3[num]);
                    gameState.boardInfo.deckCards3.Remove(gameState.boardInfo.deckCards3[num]);

                }
                if (gameState.players[myTurn - 1].totalScore > 14)
                {
                    gameState.winner = myTurn;
                }
                _clientHandler.Send(gameState);
            }
            else
            {
                MessageBox.Show("보석이 부족합니다.");
                Debug.Print(gameState.players[myTurn - 1].playerGems[0].ToString());
            }
            
        }
        private void Form3_NobleBuy(object sender, Noble noble)
        {
            if (noble.nobleCost[0] <= gameState.players[myTurn - 1].gemSale[0] &&
                noble.nobleCost[1] <= gameState.players[myTurn - 1].gemSale[1] &&
                noble.nobleCost[2] <= gameState.players[myTurn - 1].gemSale[2] &&
                noble.nobleCost[3] <= gameState.players[myTurn - 1].gemSale[3] &&
                noble.nobleCost[4] <= gameState.players[myTurn - 1].gemSale[4])
            {
                gameState.players[myTurn - 1].totalScore += 3;
                gameState.players[myTurn - 1].playerNoble.Add(noble);
                if (gameState.players[myTurn - 1].totalScore > 14)
                {
                    gameState.winner = myTurn;
                }
                _clientHandler.Send(gameState);
            }
            else
            {
                MessageBox.Show("보석이 부족합니다.");
            }
        }
        private void Form3_Reserved(object sender, Card card)
        {
            // 예약된 카드가 3장 이내 라면 조건
            if (gameState.players[myTurn - 1].reservedCards.Count < 3)
            {
                gameState.players[myTurn - 1].playerGems[5] += 1;
                gameState.players[myTurn - 1].reservedCards.Add(card);

                Random rnd = new Random();
                int num;
                if (card.cardID <= 40)
                {
                    num = rnd.Next(gameState.boardInfo.deckCards1.Count);
                    gameState.boardInfo.boardCards1.Remove(card);
                    gameState.boardInfo.boardCards1.Add(gameState.boardInfo.deckCards1[num]);
                    gameState.boardInfo.deckCards1.Remove(gameState.boardInfo.deckCards1[num]);

                }
                else if (card.cardID <= 70)
                {
                    num = rnd.Next(gameState.boardInfo.deckCards1.Count);
                    gameState.boardInfo.boardCards2.Remove(card);
                    gameState.boardInfo.boardCards2.Add(gameState.boardInfo.deckCards2[num]);
                    gameState.boardInfo.deckCards2.Remove(gameState.boardInfo.deckCards2[num]);

                }
                else
                {
                    num = rnd.Next(gameState.boardInfo.deckCards1.Count);
                    gameState.boardInfo.boardCards3.Remove(card);
                    gameState.boardInfo.boardCards3.Add(gameState.boardInfo.deckCards3[num]);
                    gameState.boardInfo.deckCards3.Remove(gameState.boardInfo.deckCards3[num]);

                }
                _clientHandler.Send(gameState);
            }
            else
            {
                MessageBox.Show("예약된 카드의 최대 갯수는 3장입니다.");
            }
        }
        private async void btnConnect_Click(object sender, EventArgs e)
        {
            await _client.ConnectAsync();
        }
        private void btn_sendRes_Click(object sender, EventArgs e)
        {
            if(gameState.turnPlayer != myTurn)
            {
                MessageBox.Show("나의 턴이 아닙니다.");
            }
            _clientHandler.Send(gameState);
        }


        public void WinnerNotice()
        {
            for (int i = 0; i < gameState.players.Length; i++)
            {
                int max = 14;
                if (gameState.players[i].totalScore > max)
                {
                    max = gameState.players[i].totalScore;
                    gameState.winner = i + 1;
                }
                //점수 동일한 경우
                else if (gameState.players[i].totalScore == max)
                {
                    //카드 개수 비교
                    if (gameState.players[i].playerCards.Count + gameState.players[i].playerNoble.Count < gameState.players[gameState.winner - 1].playerCards.Count + gameState.players[gameState.winner - 1].playerNoble.Count)
                    {
                        gameState.winner = i + 1;
                    }
                }
            }
            //결과 출력
            MessageBox.Show("Player{0}가 승리하였습니다!", gameState.winner.ToString());
            this.Close();
        }

    }
}
