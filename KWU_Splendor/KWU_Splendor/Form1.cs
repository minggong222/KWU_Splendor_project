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
//using GameRule;

namespace KWU_Splendor
{
    public partial class Form1 : Form
    {
        int[] gamCnt = new int[6];
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // 게임 보드 관리 함수
        public void InitializeGameBoard() { }//게임 보드를 초기화하는 함수
        public void UpdateGameBoard() { }//게임 보드 상태를 업데이트하는 함수
        public void RenderGameBoard() { }//게임 보드를 화면에 렌더링하는 함수
        // 플레이어 관리 함수
        public void CreatePlayer() { }//플레이어를 생성하고 초기화하는 함수
        public void UpdatePlayerInfo() { }//플레이어의 점수, 토큰 등의 정보를 업데이트하는 함수
        public void ProcessPlayerAction() { }//플레이어의 행동(토큰 획득, 카드 구매 등)을 처리하는 함수
        // 게임 로직 함수
        public void StartGame() { }// 게임을 시작하는 함수
        public void EndGame() { }// 게임을 종료하는 함수
        public void ManageTurnOrder() { }// 플레이어의 턴 순서를 관리하는 함수
        public void CheckWinCondition() { }//승리 조건을 확인하는 함수
        public void CalculateGameResult() { }//게임 결과를 계산하는 함수
        // 사용자 인터페이스 함수
        public void RenderGameScreen() { } //게임 화면을 렌더링하는 함수
        public void ProcessUserInput() { } //사용자의 입력을 처리하는 함수
        public void DisplayGameInfo() { }//게임 정보를 화면에 표시하는 함수
    }
}
