using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//using CardDB;
using GameDefine;

namespace KWU_Splendor
{
    public partial class Form1 : Form
    {
        Player[] players = new Player[4];
        Board board = null;
        ActiveCard activeCard;
        public int turn = 1;
        public bool gameEnd = false;
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void GameSetting()
        {
            board = new Board();
            players[0] = new Player();
            players[1] = new Player();
            players[2] = new Player();
            players[3] = new Player();
            activeCard = new ActiveCard();
        }

        
    }
}
