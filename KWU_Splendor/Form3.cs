using GameDefine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KWU_Splendor
{
    public partial class Form3 : Form
    {
        List<Card> level1cards;
        List<Card> level2cards;
        List<Card> level3cards;
        List<Noble> noblecards;
        public string CheckCard;
        public string CardNumber;
        public event EventHandler<Card> CardBuy;
        public event EventHandler<Noble> NobleBuy;
        public Form3(List<Card> l1cards, List<Card> l2cards, List<Card> l3cards, List<Noble> nbcards)
        {
            InitializeComponent();
            level1cards = l1cards;
            level2cards = l2cards;
            level3cards = l3cards;
            noblecards = nbcards;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Level1Card1.Text = level1cards[0].cardScore.ToString() + "점" + Environment.NewLine + Environment.NewLine
                + "      " + level1cards[0].cardCost[0].ToString() + "개" + Environment.NewLine
                + "      " + level1cards[0].cardCost[1].ToString() + "개" + Environment.NewLine
                + "      " + level1cards[0].cardCost[2].ToString() + "개" + Environment.NewLine
                + "      " + level1cards[0].cardCost[3].ToString() + "개" + Environment.NewLine
                + "      " + level1cards[0].cardCost[4].ToString() + "개" + Environment.NewLine;
            ptb_img(L1C1_ptb, level1cards[0].cardGem);
            Level1Card2.Text = level1cards[1].cardScore.ToString() + "점" + Environment.NewLine + Environment.NewLine
                + "      " + level1cards[1].cardCost[0].ToString() + "개" + Environment.NewLine
                + "      " + level1cards[1].cardCost[1].ToString() + "개" + Environment.NewLine
                + "      " + level1cards[1].cardCost[2].ToString() + "개" + Environment.NewLine
                + "      " + level1cards[1].cardCost[3].ToString() + "개" + Environment.NewLine
                + "      " + level1cards[1].cardCost[4].ToString() + "개" + Environment.NewLine;
            ptb_img(L1C2_ptb, level1cards[1].cardGem);
            Level1Card3.Text = level1cards[2].cardScore.ToString() + "점" + Environment.NewLine + Environment.NewLine
                + "      " + level1cards[2].cardCost[0].ToString() + "개" + Environment.NewLine
                + "      " + level1cards[2].cardCost[1].ToString() + "개" + Environment.NewLine
                + "      " + level1cards[2].cardCost[2].ToString() + "개" + Environment.NewLine
                + "      " + level1cards[2].cardCost[3].ToString() + "개" + Environment.NewLine
                + "      " + level1cards[2].cardCost[4].ToString() + "개" + Environment.NewLine;
            ptb_img(L1C3_ptb, level1cards[2].cardGem);
            Level1Card4.Text = level1cards[3].cardScore.ToString() + "점" + Environment.NewLine + Environment.NewLine
                + "      " + level1cards[3].cardCost[0].ToString() + "개" + Environment.NewLine
                + "      " + level1cards[3].cardCost[1].ToString() + "개" + Environment.NewLine
                + "      " + level1cards[3].cardCost[2].ToString() + "개" + Environment.NewLine
                + "      " + level1cards[3].cardCost[3].ToString() + "개" + Environment.NewLine
                + "      " + level1cards[3].cardCost[4].ToString() + "개" + Environment.NewLine;
            ptb_img(L1C4_ptb, level1cards[3].cardGem);

            Level2Card1.Text = level2cards[0].cardScore.ToString() + "점" + Environment.NewLine + Environment.NewLine
                + "      " + level2cards[0].cardCost[0].ToString() + "개" + Environment.NewLine
                + "      " + level2cards[0].cardCost[1].ToString() + "개" + Environment.NewLine
                + "      " + level2cards[0].cardCost[2].ToString() + "개" + Environment.NewLine
                + "      " + level2cards[0].cardCost[3].ToString() + "개" + Environment.NewLine
                + "      " + level2cards[0].cardCost[4].ToString() + "개" + Environment.NewLine;
            ptb_img(L2C1_ptb, level2cards[0].cardGem);
            Level2Card2.Text = level2cards[1].cardScore.ToString() + "점" + Environment.NewLine + Environment.NewLine
                + "      " + level2cards[1].cardCost[0].ToString() + "개" + Environment.NewLine
                + "      " + level2cards[1].cardCost[1].ToString() + "개" + Environment.NewLine
                + "      " + level2cards[1].cardCost[2].ToString() + "개" + Environment.NewLine
                + "      " + level2cards[1].cardCost[3].ToString() + "개" + Environment.NewLine
                + "      " + level2cards[1].cardCost[4].ToString() + "개" + Environment.NewLine;
            ptb_img(L2C2_ptb, level2cards[1].cardGem);
            Level2Card3.Text = level2cards[2].cardScore.ToString() + "점" + Environment.NewLine + Environment.NewLine
                + "      " + level2cards[2].cardCost[0].ToString() + "개" + Environment.NewLine
                + "      " + level2cards[2].cardCost[1].ToString() + "개" + Environment.NewLine
                + "      " + level2cards[2].cardCost[2].ToString() + "개" + Environment.NewLine
                + "      " + level2cards[2].cardCost[3].ToString() + "개" + Environment.NewLine
                + "      " + level2cards[2].cardCost[4].ToString() + "개" + Environment.NewLine;
            ptb_img(L2C3_ptb, level2cards[2].cardGem);
            Level2Card4.Text = level2cards[3].cardScore.ToString() + "점" + Environment.NewLine + Environment.NewLine
                + "      " + level2cards[3].cardCost[0].ToString() + "개" + Environment.NewLine
                + "      " + level2cards[3].cardCost[1].ToString() + "개" + Environment.NewLine
                + "      " + level2cards[3].cardCost[2].ToString() + "개" + Environment.NewLine
                + "      " + level2cards[3].cardCost[3].ToString() + "개" + Environment.NewLine
                + "      " + level2cards[3].cardCost[4].ToString() + "개" + Environment.NewLine;
            ptb_img(L2C4_ptb, level2cards[3].cardGem);

            Level3Card1.Text = level3cards[0].cardScore.ToString() + "점" + Environment.NewLine + Environment.NewLine
                + "      " + level3cards[0].cardCost[0].ToString() + "개" + Environment.NewLine
                + "      " + level3cards[0].cardCost[1].ToString() + "개" + Environment.NewLine
                + "      " + level3cards[0].cardCost[2].ToString() + "개" + Environment.NewLine
                + "      " + level3cards[0].cardCost[3].ToString() + "개" + Environment.NewLine
                + "      " + level3cards[0].cardCost[4].ToString() + "개" + Environment.NewLine;
            ptb_img(L3C1_ptb, level3cards[0].cardGem);
            Level3Card2.Text = level3cards[1].cardScore.ToString() + "점" + Environment.NewLine + Environment.NewLine
                + "      " + level3cards[1].cardCost[0].ToString() + "개" + Environment.NewLine
                + "      " + level3cards[1].cardCost[1].ToString() + "개" + Environment.NewLine
                + "      " + level3cards[1].cardCost[2].ToString() + "개" + Environment.NewLine
                + "      " + level3cards[1].cardCost[3].ToString() + "개" + Environment.NewLine
                + "      " + level3cards[1].cardCost[4].ToString() + "개" + Environment.NewLine;
            ptb_img(L3C2_ptb, level3cards[1].cardGem);
            Level3Card3.Text = level3cards[2].cardScore.ToString() + "점" + Environment.NewLine + Environment.NewLine
                + "      " + level3cards[2].cardCost[0].ToString() + "개" + Environment.NewLine
                + "      " + level3cards[2].cardCost[1].ToString() + "개" + Environment.NewLine
                + "      " + level3cards[2].cardCost[2].ToString() + "개" + Environment.NewLine
                + "      " + level3cards[2].cardCost[3].ToString() + "개" + Environment.NewLine
                + "      " + level3cards[2].cardCost[4].ToString() + "개" + Environment.NewLine;
            ptb_img(L3C3_ptb, level3cards[2].cardGem);
            Level3Card4.Text = level3cards[3].cardScore.ToString() + "점" + Environment.NewLine + Environment.NewLine
                + "      " + level3cards[3].cardCost[0].ToString() + "개" + Environment.NewLine
                + "      " + level3cards[3].cardCost[1].ToString() + "개" + Environment.NewLine
                + "      " + level3cards[3].cardCost[2].ToString() + "개" + Environment.NewLine
                + "      " + level3cards[3].cardCost[3].ToString() + "개" + Environment.NewLine
                + "      " + level3cards[3].cardCost[4].ToString() + "개" + Environment.NewLine;
            ptb_img(L3C4_ptb, level3cards[3].cardGem);

            NobleCard1.Text = "3" + "점" + Environment.NewLine + Environment.NewLine
                + "      " + noblecards[0].nobleCost[0].ToString() + "개" + Environment.NewLine
                + "      " + noblecards[0].nobleCost[1].ToString() + "개" + Environment.NewLine
                + "      " + noblecards[0].nobleCost[2].ToString() + "개" + Environment.NewLine
                + "      " + noblecards[0].nobleCost[3].ToString() + "개" + Environment.NewLine
                + "      " + noblecards[0].nobleCost[4].ToString() + "개" + Environment.NewLine;
            NobleCard2.Text = "3" + "점" + Environment.NewLine + Environment.NewLine
                + "      " + noblecards[1].nobleCost[0].ToString() + "개" + Environment.NewLine
                + "      " + noblecards[1].nobleCost[1].ToString() + "개" + Environment.NewLine
                + "      " + noblecards[1].nobleCost[2].ToString() + "개" + Environment.NewLine
                + "      " + noblecards[1].nobleCost[3].ToString() + "개" + Environment.NewLine
                + "      " + noblecards[1].nobleCost[4].ToString() + "개" + Environment.NewLine;
            NobleCard3.Text = "3" + "점" + Environment.NewLine + Environment.NewLine
                + "      " + noblecards[2].nobleCost[0].ToString() + "개" + Environment.NewLine
                + "      " + noblecards[2].nobleCost[1].ToString() + "개" + Environment.NewLine
                + "      " + noblecards[2].nobleCost[2].ToString() + "개" + Environment.NewLine
                + "      " + noblecards[2].nobleCost[3].ToString() + "개" + Environment.NewLine
                + "      " + noblecards[2].nobleCost[4].ToString() + "개" + Environment.NewLine;
            NobleCard4.Text = "3" + "점" + Environment.NewLine + Environment.NewLine
                + "      " + noblecards[3].nobleCost[0].ToString() + "개" + Environment.NewLine
                + "      " + noblecards[3].nobleCost[1].ToString() + "개" + Environment.NewLine
                + "      " + noblecards[3].nobleCost[2].ToString() + "개" + Environment.NewLine
                + "      " + noblecards[3].nobleCost[3].ToString() + "개" + Environment.NewLine
                + "      " + noblecards[3].nobleCost[4].ToString() + "개" + Environment.NewLine;
            NobleCard5.Text = "3" + "점" + Environment.NewLine + Environment.NewLine
                + "      " + noblecards[4].nobleCost[0].ToString() + "개" + Environment.NewLine
                + "      " + noblecards[4].nobleCost[1].ToString() + "개" + Environment.NewLine
                + "      " + noblecards[4].nobleCost[2].ToString() + "개" + Environment.NewLine
                + "      " + noblecards[4].nobleCost[3].ToString() + "개" + Environment.NewLine
                + "      " + noblecards[4].nobleCost[4].ToString() + "개" + Environment.NewLine;
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

        private void btn_buy_Click(object sender, EventArgs e)
        {
            switch (CheckCard)
            {
                case "n":
                    switch (CardNumber)
                    {
                        case "1":
                            nobleBuy(noblecards[0]);
                            break;

                        case "2":
                            nobleBuy(noblecards[1]);
                            break;

                        case "3":
                            nobleBuy(noblecards[2]);
                            break;

                        case "4":
                            nobleBuy(noblecards[3]);
                            break;

                        case "5":
                            nobleBuy(noblecards[4]);
                            break;
                    }
                    break;

                case "l":
                    switch (CardNumber)
                    {
                        case "11":
                            cardBuy(level1cards[0]);
                            break;

                        case "12":
                            cardBuy(level1cards[1]);
                            break;

                        case "13":
                            cardBuy(level1cards[2]);
                            break;

                        case "14":
                            cardBuy(level1cards[3]);
                            break;

                        case "21":
                            cardBuy(level2cards[0]);
                            break;

                        case "22":
                            cardBuy(level2cards[1]);
                            break;

                        case "23":
                            cardBuy(level2cards[2]);
                            break;

                        case "24":
                            cardBuy(level2cards[3]);
                            break;

                        case "31":
                            cardBuy(level3cards[0]);
                            break;

                        case "32":
                            cardBuy(level3cards[1]);
                            break;

                        case "33":
                            cardBuy(level3cards[2]);
                            break;

                        case "34":
                            cardBuy(level3cards[3]);
                            break;

                    }
                    break;

                default:
                    MessageBox.Show("버튼을 클릭해주세요");
                    break;
            }
        }
        public void cardBuy(Card card)
        {
            CardBuy?.Invoke(this, card);
            this.Close();
        }
        public void nobleBuy(Noble noble)
        {
            NobleBuy?.Invoke(this, noble);
            this.Close();
        }
        private void rdo_CheckedChanged(object sender, EventArgs e)
        {
            CheckCard = ((RadioButton)sender).Name.ToString().Substring(4,1);
            CardNumber = ((RadioButton)sender).Name.ToString().Substring(5);
        }
    }
}
