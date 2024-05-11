using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CardDB;
using static GameDefine.Game;
//using GameRule;

namespace KWU_Splendor
{
    public partial class Form1 : Form
    {
        int[] gemCnt = new int[6];
        Player[] Players = new Player[4];
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void InitializeGame()
        {
            // 공동 보석 토큰 준비
            InitializeGemTokens();

            // 귀족 카드 준비
            InitializeNobilityCards();

            // 개발 카드 준비
            InitializeDevelopmentCards();

            // 플레이어 생성
            CreatePlayers();
        }

        private void InitializeGemTokens()
        {
            gemCnt[0] = 7;
            gemCnt[1] = 7;
            gemCnt[2] = 7;
            gemCnt[3] = 7;
            gemCnt[4] = 7;
            gemCnt[5] = 5;
        }

        private void InitializeNobilityCards()
        {
            // 귀족 카드 초기화 로직 구현
            // 귀족 카드 정보(비용, 점수) 설정
        }

        private void InitializeDevelopmentCards()
        {
            // 개발 카드 초기화 로직 구현
            // 개발 카드 정보(비용, 점수) 설정
        }
        private void CreatePlayers()
        {
            // 플레이어 생성 로직 구현
            // 플레이어 객체 생성 및 초기화
        }
        public void TakeTurn(Player player)
        {
            // 플레이어 행동 처리
            ProcessPlayerAction(player);

            // 게임 상태 업데이트
            UpdateGameState();
        }

        private void ProcessPlayerAction(Player player)
        {
            // 플레이어 행동 처리 로직 구현
            // 보석 토큰 획득, 카드 구매 등의 처리
        }

        private void UpdateGameState()
        {
            // 게임 상태 업데이트 로직 구현
            // 점수 계산, 승리 조건 확인 등
        }
        public bool CheckWinCondition()
        {
            // 플레이어 점수 확인 로직 구현
            foreach (Player player in Players)
            {
                if (player.playerScore >= 15)
                {
                    return true; // 승리 조건 충족
                }
            }
            return false; // 승리 조건 미충족
        }

    }
}
