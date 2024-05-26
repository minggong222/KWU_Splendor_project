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
            Level1Card1.Text = "Score: " + level1cards[0].cardScore.ToString() + "점" + Environment.NewLine
                + "Ony: " + level1cards[0].cardCost[0].ToString() + "개" + Environment.NewLine
                + "Saf: " + level1cards[0].cardCost[1].ToString() + "개" + Environment.NewLine
                + "Eme: " + level1cards[0].cardCost[2].ToString() + "개" + Environment.NewLine
                + "Ruby: " + level1cards[0].cardCost[3].ToString() + "개" + Environment.NewLine
                + "Dia: " + level1cards[0].cardCost[4].ToString() + "개" + Environment.NewLine;
            ptb_img(L1C1_ptb, level1cards[0].cardGem);
            Level1Card2.Text = "Score: " + level1cards[1].cardScore.ToString() + "점" + Environment.NewLine
                + "Ony: " + level1cards[1].cardCost[0].ToString() + "개" + Environment.NewLine
                + "Saf: " + level1cards[1].cardCost[1].ToString() + "개" + Environment.NewLine
                + "Eme: " + level1cards[1].cardCost[2].ToString() + "개" + Environment.NewLine
                + "Ruby: " + level1cards[1].cardCost[3].ToString() + "개" + Environment.NewLine
                + "Dia: " + level1cards[1].cardCost[4].ToString() + "개" + Environment.NewLine;
            ptb_img(L1C2_ptb, level1cards[1].cardGem);
            Level1Card3.Text = "Score: " + level1cards[2].cardScore.ToString() + "점" + Environment.NewLine
                + "Ony: " + level1cards[2].cardCost[0].ToString() + "개" + Environment.NewLine
                + "Saf: " + level1cards[2].cardCost[1].ToString() + "개" + Environment.NewLine
                + "Eme: " + level1cards[2].cardCost[2].ToString() + "개" + Environment.NewLine
                + "Ruby: " + level1cards[2].cardCost[3].ToString() + "개" + Environment.NewLine
                + "Dia: " + level1cards[2].cardCost[4].ToString() + "개" + Environment.NewLine;
            ptb_img(L1C3_ptb, level1cards[2].cardGem);
            Level1Card4.Text = "Score: " + level1cards[3].cardScore.ToString() + "점" + Environment.NewLine
                + "Ony: " + level1cards[3].cardCost[0].ToString() + "개" + Environment.NewLine
                + "Saf: " + level1cards[3].cardCost[1].ToString() + "개" + Environment.NewLine
                + "Eme: " + level1cards[3].cardCost[2].ToString() + "개" + Environment.NewLine
                + "Ruby: " + level1cards[3].cardCost[3].ToString() + "개" + Environment.NewLine
                + "Dia: " + level1cards[3].cardCost[4].ToString() + "개" + Environment.NewLine;
            ptb_img(L1C4_ptb, level1cards[3].cardGem);

            Level2Card1.Text = "Score: " + level2cards[0].cardScore.ToString() + "점" + Environment.NewLine
                + "Ony: " + level2cards[0].cardCost[0].ToString() + "개" + Environment.NewLine
                + "Saf: " + level2cards[0].cardCost[1].ToString() + "개" + Environment.NewLine
                + "Eme: " + level2cards[0].cardCost[2].ToString() + "개" + Environment.NewLine
                + "Ruby: " + level2cards[0].cardCost[3].ToString() + "개" + Environment.NewLine
                + "Dia: " + level2cards[0].cardCost[4].ToString() + "개" + Environment.NewLine;
            ptb_img(L2C1_ptb, level2cards[0].cardGem);
            Level2Card2.Text = "Score: " + level2cards[1].cardScore.ToString() + "점" + Environment.NewLine
                + "Ony: " + level2cards[1].cardCost[0].ToString() + "개" + Environment.NewLine
                + "Saf: " + level2cards[1].cardCost[1].ToString() + "개" + Environment.NewLine
                + "Eme: " + level2cards[1].cardCost[2].ToString() + "개" + Environment.NewLine
                + "Ruby: " + level2cards[1].cardCost[3].ToString() + "개" + Environment.NewLine
                + "Dia: " + level2cards[1].cardCost[4].ToString() + "개" + Environment.NewLine;
            ptb_img(L2C2_ptb, level2cards[1].cardGem);
            Level2Card3.Text = "Score: " + level2cards[2].cardScore.ToString() + "점" + Environment.NewLine
                + "Ony: " + level2cards[2].cardCost[0].ToString() + "개" + Environment.NewLine
                + "Saf: " + level2cards[2].cardCost[1].ToString() + "개" + Environment.NewLine
                + "Eme: " + level2cards[2].cardCost[2].ToString() + "개" + Environment.NewLine
                + "Ruby: " + level2cards[2].cardCost[3].ToString() + "개" + Environment.NewLine
                + "Dia: " + level2cards[2].cardCost[4].ToString() + "개" + Environment.NewLine;
            ptb_img(L2C3_ptb, level2cards[2].cardGem);
            Level2Card4.Text = "Score: " + level2cards[3].cardScore.ToString() + "점" + Environment.NewLine
                + "Ony: " + level2cards[3].cardCost[0].ToString() + "개" + Environment.NewLine
                + "Saf: " + level2cards[3].cardCost[1].ToString() + "개" + Environment.NewLine
                + "Eme: " + level2cards[3].cardCost[2].ToString() + "개" + Environment.NewLine
                + "Ruby: " + level2cards[3].cardCost[3].ToString() + "개" + Environment.NewLine
                + "Dia: " + level2cards[3].cardCost[4].ToString() + "개" + Environment.NewLine;
            ptb_img(L2C4_ptb, level2cards[3].cardGem);

            Level3Card1.Text = "Score: " + level3cards[0].cardScore.ToString() + "점" + Environment.NewLine
                + "Ony: " + level3cards[0].cardCost[0].ToString() + "개" + Environment.NewLine
                + "Saf: " + level3cards[0].cardCost[1].ToString() + "개" + Environment.NewLine
                + "Eme: " + level3cards[0].cardCost[2].ToString() + "개" + Environment.NewLine
                + "Ruby: " + level3cards[0].cardCost[3].ToString() + "개" + Environment.NewLine
                + "Dia: " + level3cards[0].cardCost[4].ToString() + "개" + Environment.NewLine;
            ptb_img(L3C1_ptb, level3cards[0].cardGem);
            Level3Card2.Text = "Score: " + level3cards[1].cardScore.ToString() + "점" + Environment.NewLine
                + "Ony: " + level3cards[1].cardCost[0].ToString() + "개" + Environment.NewLine
                + "Saf: " + level3cards[1].cardCost[1].ToString() + "개" + Environment.NewLine
                + "Eme: " + level3cards[1].cardCost[2].ToString() + "개" + Environment.NewLine
                + "Ruby: " + level3cards[1].cardCost[3].ToString() + "개" + Environment.NewLine
                + "Dia: " + level3cards[1].cardCost[4].ToString() + "개" + Environment.NewLine;
            ptb_img(L3C2_ptb, level3cards[1].cardGem);
            Level3Card3.Text = "Score: " + level3cards[2].cardScore.ToString() + "점" + Environment.NewLine
                + "Ony: " + level3cards[2].cardCost[0].ToString() + "개" + Environment.NewLine
                + "Saf: " + level3cards[2].cardCost[1].ToString() + "개" + Environment.NewLine
                + "Eme: " + level3cards[2].cardCost[2].ToString() + "개" + Environment.NewLine
                + "Ruby: " + level3cards[2].cardCost[3].ToString() + "개" + Environment.NewLine
                + "Dia: " + level3cards[2].cardCost[4].ToString() + "개" + Environment.NewLine;
            ptb_img(L3C3_ptb, level3cards[2].cardGem);
            Level3Card4.Text = "Score: " + level3cards[3].cardScore.ToString() + "점" + Environment.NewLine
                + "Ony: " + level3cards[3].cardCost[0].ToString() + "개" + Environment.NewLine
                + "Saf: " + level3cards[3].cardCost[1].ToString() + "개" + Environment.NewLine
                + "Eme: " + level3cards[3].cardCost[2].ToString() + "개" + Environment.NewLine
                + "Ruby: " + level3cards[3].cardCost[3].ToString() + "개" + Environment.NewLine
                + "Dia: " + level3cards[3].cardCost[4].ToString() + "개" + Environment.NewLine;
            ptb_img(L3C4_ptb, level3cards[3].cardGem);

            NobleCard1.Text = "Score: " + "3" + "점" + Environment.NewLine
                + "Ony: " + noblecards[0].nobleCost[0].ToString() + "개" + Environment.NewLine
                + "Saf: " + noblecards[0].nobleCost[1].ToString() + "개" + Environment.NewLine
                + "Eme: " + noblecards[0].nobleCost[2].ToString() + "개" + Environment.NewLine
                + "Ruby: " + noblecards[0].nobleCost[3].ToString() + "개" + Environment.NewLine
                + "Dia: " + noblecards[0].nobleCost[4].ToString() + "개" + Environment.NewLine;
            NobleCard2.Text = "Score: " + "3" + "점" + Environment.NewLine
                + "Ony: " + noblecards[1].nobleCost[0].ToString() + "개" + Environment.NewLine
                + "Saf: " + noblecards[1].nobleCost[1].ToString() + "개" + Environment.NewLine
                + "Eme: " + noblecards[1].nobleCost[2].ToString() + "개" + Environment.NewLine
                + "Ruby: " + noblecards[1].nobleCost[3].ToString() + "개" + Environment.NewLine
                + "Dia: " + noblecards[1].nobleCost[4].ToString() + "개" + Environment.NewLine;
            NobleCard3.Text = "Score: " + "3" + "점" + Environment.NewLine
                + "Ony: " + noblecards[2].nobleCost[0].ToString() + "개" + Environment.NewLine
                + "Saf: " + noblecards[2].nobleCost[1].ToString() + "개" + Environment.NewLine
                + "Eme: " + noblecards[2].nobleCost[2].ToString() + "개" + Environment.NewLine
                + "Ruby: " + noblecards[2].nobleCost[3].ToString() + "개" + Environment.NewLine
                + "Dia: " + noblecards[2].nobleCost[4].ToString() + "개" + Environment.NewLine;
            NobleCard4.Text = "Score: " + "3" + "점" + Environment.NewLine
                + "Ony: " + noblecards[3].nobleCost[0].ToString() + "개" + Environment.NewLine
                + "Saf: " + noblecards[3].nobleCost[1].ToString() + "개" + Environment.NewLine
                + "Eme: " + noblecards[3].nobleCost[2].ToString() + "개" + Environment.NewLine
                + "Ruby: " + noblecards[3].nobleCost[3].ToString() + "개" + Environment.NewLine
                + "Dia: " + noblecards[3].nobleCost[4].ToString() + "개" + Environment.NewLine;
            NobleCard5.Text = "Score: " + "3" + "점" + Environment.NewLine
                + "Ony: " + noblecards[4].nobleCost[0].ToString() + "개" + Environment.NewLine
                + "Saf: " + noblecards[4].nobleCost[1].ToString() + "개" + Environment.NewLine
                + "Eme: " + noblecards[4].nobleCost[2].ToString() + "개" + Environment.NewLine
                + "Ruby: " + noblecards[4].nobleCost[3].ToString() + "개" + Environment.NewLine
                + "Dia: " + noblecards[4].nobleCost[4].ToString() + "개" + Environment.NewLine;
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
                            MessageBox.Show(NobleCard1.Text);
                            break;

                        case "2":
                            MessageBox.Show(NobleCard2.Text);
                            break;

                        case "3":
                            MessageBox.Show(NobleCard3.Text);
                            break;

                        case "4":
                            MessageBox.Show(NobleCard4.Text);
                            break;

                        case "5":
                            MessageBox.Show(NobleCard5.Text);
                            break;
                    }
                    break;

                case "l":
                    switch (CardNumber)
                    {
                        case "11":
                            MessageBox.Show(Level1Card1.Text);
                            break;

                        case "12":
                            MessageBox.Show(Level1Card2.Text);
                            break;

                        case "13":
                            MessageBox.Show(Level1Card3.Text);
                            break;

                        case "14":
                            MessageBox.Show(Level1Card4.Text);
                            break;

                        case "21":
                            MessageBox.Show(Level2Card1.Text);
                            break;

                        case "22":
                            MessageBox.Show(Level2Card2.Text);
                            break;

                        case "23":
                            MessageBox.Show(Level2Card3.Text);
                            break;

                        case "24":
                            MessageBox.Show(Level2Card4.Text);
                            break;

                        case "31":
                            MessageBox.Show(Level3Card1.Text);
                            break;

                        case "32":
                            MessageBox.Show(Level3Card2.Text);
                            break;

                        case "33":
                            MessageBox.Show(Level3Card3.Text);
                            break;

                        case "34":
                            MessageBox.Show(Level3Card4.Text);
                            break;

                    }
                    break;

                default:
                    MessageBox.Show("버튼을 클릭해주세요");
                    break;
            }
        }

        private void rdo_CheckedChanged(object sender, EventArgs e)
        {
            CheckCard = ((RadioButton)sender).Name.ToString().Substring(4,1);
            CardNumber = ((RadioButton)sender).Name.ToString().Substring(5);
        }
    }
}
