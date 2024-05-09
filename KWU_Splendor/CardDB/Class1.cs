using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardDB
{
    public class Card
    {
        public int cardID;
        public int cardScore;
        public int[] cardCost = new int[5];
        public int cardLevel;
        public int cardGem;
        public Card(int ID, int score, int cost0, int cost1, int cost2, int cost3, int cost4, int level, int gem)
        {
            cardID = ID;
            cardScore = score;
            cardCost[0] = cost0;
            cardCost[1] = cost1;
            cardCost[2] = cost2;
            cardCost[3] = cost3;
            cardCost[4] = cost4;
            cardLevel = level;
            cardGem = gem;
        }
    }

    public class Noble
    {
        public int nobleID;
        public int nobleScore;
        public int[] nobleCost = new int[5];          // 카드 보석(비용)

        public Noble(int ID, int Score, int cost0, int cost1, int cost2, int cost3, int cost4)
        {
            nobleID = ID;
            nobleScore = Score;
            nobleCost[0] = cost0;
            nobleCost[1] = cost1;
            nobleCost[2] = cost2;
            nobleCost[3] = cost3;
            nobleCost[4] = cost4;
        }
    }

    public class Board
    {
        public List<Card> cardsLevel1List = new List<Card>();       // 레벨1 카드 (40개)
        public List<Card> cardLevel2List = new List<Card>();        // 레벨2 카드 (30개)
        public List<Card> cardLevel3List = new List<Card>();        // 레벨3 카드 (20개)
        public List<Noble> nobleList = new List<Noble>();           // 귀족 카드 (10개)
        public int[] boardGems = new int[5];                        // 보석의 종류 (5개)

        public int[] Randomtest;
        //0: 다이아
        //1: 사파이어
        //2: 에메랄드
        //3: 루비
        //4: 줄마노

        public Board()
        {
            boardGems[0] = boardGems[1] = boardGems[2] = boardGems[3] = boardGems[4] = 7;   // 보석 초기화
            CardInit();
        }
        public void CardInit()
        {
            int[] RandomArray = RandomID(40);
            int i = 0;
            //ID score cost0 cost1 cost2 cost3 cost4 level gem
            cardsLevel1List.Add(new Card(RandomArray[i++], 0, 0, 0, 0, 2, 1, 1, 0));
            cardsLevel1List.Add(new Card(RandomArray[i++], 0, 0, 3, 0, 0, 0, 1, 0));
            cardsLevel1List.Add(new Card(RandomArray[i++], 0, 0, 1, 1, 1, 1, 1, 0));
            cardsLevel1List.Add(new Card(RandomArray[i++], 0, 0, 2, 0, 0, 2, 1, 0));
            cardsLevel1List.Add(new Card(RandomArray[i++], 0, 0, 1, 2, 1, 1, 1, 0));
            cardsLevel1List.Add(new Card(RandomArray[i++], 0, 0, 2, 2, 0, 1, 1, 0));
            cardsLevel1List.Add(new Card(RandomArray[i++], 0, 3, 1, 0, 0, 1, 1, 0));
            cardsLevel1List.Add(new Card(RandomArray[i++], 1, 0, 0, 4, 0, 0, 1, 0));

            cardsLevel1List.Add(new Card(RandomArray[i++], 0, 1, 0, 0, 0, 2, 1, 1));
            cardsLevel1List.Add(new Card(RandomArray[i++], 0, 0, 0, 0, 0, 3, 1, 1));
            cardsLevel1List.Add(new Card(RandomArray[i++], 0, 1, 0, 1, 1, 1, 1, 1));
            cardsLevel1List.Add(new Card(RandomArray[i++], 0, 0, 0, 2, 0, 2, 1, 1));
            cardsLevel1List.Add(new Card(RandomArray[i++], 0, 1, 0, 1, 2, 1, 1, 1));
            cardsLevel1List.Add(new Card(RandomArray[i++], 0, 1, 0, 1, 2, 0, 1, 1));
            cardsLevel1List.Add(new Card(RandomArray[i++], 0, 0, 1, 3, 1, 0, 1, 1));
            cardsLevel1List.Add(new Card(RandomArray[i++], 1, 0, 0, 0, 4, 0, 1, 1));

            cardsLevel1List.Add(new Card(RandomArray[i++], 0, 2, 1, 0, 0, 0, 1, 2));
            cardsLevel1List.Add(new Card(RandomArray[i++], 0, 0, 0, 0, 3, 0, 1, 2));
            cardsLevel1List.Add(new Card(RandomArray[i++], 0, 1, 1, 0, 1, 1, 1, 2));
            cardsLevel1List.Add(new Card(RandomArray[i++], 0, 0, 2, 0, 2, 0, 1, 2));
            cardsLevel1List.Add(new Card(RandomArray[i++], 0, 1, 1, 0, 1, 2, 1, 2));
            cardsLevel1List.Add(new Card(RandomArray[i++], 0, 0, 1, 0, 2, 2, 1, 2));
            cardsLevel1List.Add(new Card(RandomArray[i++], 0, 1, 3, 1, 0, 0, 1, 2));
            cardsLevel1List.Add(new Card(RandomArray[i++], 1, 0, 0, 0, 0, 4, 1, 2));

            cardsLevel1List.Add(new Card(RandomArray[i++], 0, 0, 2, 1, 0, 0, 1, 3));
            cardsLevel1List.Add(new Card(RandomArray[i++], 0, 3, 0, 0, 0, 0, 1, 3));
            cardsLevel1List.Add(new Card(RandomArray[i++], 0, 1, 1, 1, 0, 1, 1, 3));
            cardsLevel1List.Add(new Card(RandomArray[i++], 0, 2, 0, 0, 2, 0, 1, 3));
            cardsLevel1List.Add(new Card(RandomArray[i++], 0, 2, 1, 1, 0, 1, 1, 3));
            cardsLevel1List.Add(new Card(RandomArray[i++], 0, 2, 0, 1, 0, 2, 1, 3));
            cardsLevel1List.Add(new Card(RandomArray[i++], 0, 1, 0, 0, 1, 3, 1, 3));
            cardsLevel1List.Add(new Card(RandomArray[i++], 1, 4, 0, 0, 0, 0, 1, 3));

            cardsLevel1List.Add(new Card(RandomArray[i++], 0, 0, 0, 2, 1, 0, 1, 4));
            cardsLevel1List.Add(new Card(RandomArray[i++], 0, 0, 0, 3, 0, 0, 1, 4));
            cardsLevel1List.Add(new Card(RandomArray[i++], 0, 1, 1, 1, 1, 0, 1, 4));
            cardsLevel1List.Add(new Card(RandomArray[i++], 0, 2, 0, 2, 0, 0, 1, 4));
            cardsLevel1List.Add(new Card(RandomArray[i++], 0, 1, 2, 1, 1, 0, 1, 4));
            cardsLevel1List.Add(new Card(RandomArray[i++], 0, 2, 2, 0, 1, 0, 1, 4));
            cardsLevel1List.Add(new Card(RandomArray[i++], 0, 0, 0, 1, 3, 1, 1, 4));
            cardsLevel1List.Add(new Card(RandomArray[i++], 1, 0, 4, 0, 0, 0, 1, 4));

            int[] RandomArray2 = RandomID(30);
            int i2 = 0;

            cardLevel2List.Add(new Card(RandomArray2[i2++], 1, 0, 0, 3, 2, 2, 2, 0));
            cardLevel2List.Add(new Card(RandomArray2[i2++], 1, 2, 3, 0, 3, 0, 2, 0));
            cardLevel2List.Add(new Card(RandomArray2[i2++], 2, 0, 0, 0, 5, 0, 2, 0));
            cardLevel2List.Add(new Card(RandomArray2[i2++], 2, 0, 0, 1, 4, 2, 2, 0));
            cardLevel2List.Add(new Card(RandomArray2[i2++], 2, 0, 0, 0, 5, 3, 2, 0));
            cardLevel2List.Add(new Card(RandomArray2[i2++], 3, 6, 0, 0, 0, 0, 2, 0));

            cardLevel2List.Add(new Card(RandomArray2[i2++], 1, 0, 2, 2, 3, 0, 2, 1));
            cardLevel2List.Add(new Card(RandomArray2[i2++], 1, 0, 2, 3, 0, 3, 2, 1));
            cardLevel2List.Add(new Card(RandomArray2[i2++], 2, 0, 5, 0, 0, 0, 2, 1));
            cardLevel2List.Add(new Card(RandomArray2[i2++], 2, 2, 0, 0, 1, 4, 2, 1));
            cardLevel2List.Add(new Card(RandomArray2[i2++], 2, 5, 3, 0, 0, 0, 2, 1));
            cardLevel2List.Add(new Card(RandomArray2[i2++], 3, 0, 6, 0, 0, 0, 2, 1));

            cardLevel2List.Add(new Card(RandomArray2[i2++], 1, 2, 3, 0, 0, 2, 2, 2));
            cardLevel2List.Add(new Card(RandomArray2[i2++], 1, 3, 0, 2, 3, 0, 2, 2));
            cardLevel2List.Add(new Card(RandomArray2[i2++], 2, 0, 0, 5, 0, 0, 2, 2));
            cardLevel2List.Add(new Card(RandomArray2[i2++], 2, 4, 2, 0, 0, 1, 2, 2));
            cardLevel2List.Add(new Card(RandomArray2[i2++], 2, 0, 5, 3, 0, 0, 2, 2));
            cardLevel2List.Add(new Card(RandomArray2[i2++], 3, 0, 0, 6, 0, 0, 2, 2));

            cardLevel2List.Add(new Card(RandomArray2[i2++], 1, 2, 0, 0, 2, 3, 2, 3));
            cardLevel2List.Add(new Card(RandomArray2[i2++], 1, 0, 3, 0, 2, 3, 2, 3));
            cardLevel2List.Add(new Card(RandomArray2[i2++], 2, 0, 0, 0, 0, 5, 2, 3));
            cardLevel2List.Add(new Card(RandomArray2[i2++], 2, 1, 4, 2, 0, 0, 2, 3));
            cardLevel2List.Add(new Card(RandomArray2[i2++], 2, 3, 0, 0, 0, 5, 2, 3));
            cardLevel2List.Add(new Card(RandomArray2[i2++], 3, 0, 0, 0, 6, 0, 2, 3));

            cardLevel2List.Add(new Card(RandomArray2[i2++], 1, 3, 2, 2, 0, 0, 2, 4));
            cardLevel2List.Add(new Card(RandomArray2[i2++], 1, 3, 0, 3, 0, 2, 2, 4));
            cardLevel2List.Add(new Card(RandomArray2[i2++], 2, 5, 0, 0, 0, 0, 2, 4));
            cardLevel2List.Add(new Card(RandomArray2[i2++], 2, 0, 1, 4, 2, 0, 2, 4));
            cardLevel2List.Add(new Card(RandomArray2[i2++], 2, 0, 0, 5, 3, 0, 2, 4));
            cardLevel2List.Add(new Card(RandomArray2[i2++], 3, 0, 0, 0, 0, 6, 2, 4));

            int[] RandomArray3 = RandomID(20);
            int i3 = 0;

            cardLevel3List.Add(new Card(RandomArray3[i3++], 3, 0, 3, 3, 5, 3, 3, 0));
            cardLevel3List.Add(new Card(RandomArray3[i3++], 4, 0, 0, 0, 0, 7, 3, 0));
            cardLevel3List.Add(new Card(RandomArray3[i3++], 4, 3, 0, 0, 3, 6, 3, 0));
            cardLevel3List.Add(new Card(RandomArray3[i3++], 5, 3, 0, 0, 0, 7, 3, 0));

            cardLevel3List.Add(new Card(RandomArray3[i3++], 3, 3, 0, 3, 3, 5, 3, 1));
            cardLevel3List.Add(new Card(RandomArray3[i3++], 4, 7, 0, 0, 0, 0, 3, 1));
            cardLevel3List.Add(new Card(RandomArray3[i3++], 4, 6, 3, 0, 0, 3, 3, 1));
            cardLevel3List.Add(new Card(RandomArray3[i3++], 5, 7, 3, 0, 0, 0, 3, 1));

            cardLevel3List.Add(new Card(RandomArray3[i3++], 3, 5, 3, 0, 3, 3, 3, 2));
            cardLevel3List.Add(new Card(RandomArray3[i3++], 4, 0, 7, 0, 0, 0, 3, 2));
            cardLevel3List.Add(new Card(RandomArray3[i3++], 4, 3, 6, 3, 0, 0, 3, 2));
            cardLevel3List.Add(new Card(RandomArray3[i3++], 5, 0, 7, 3, 0, 0, 3, 2));

            cardLevel3List.Add(new Card(RandomArray3[i3++], 3, 3, 5, 3, 0, 3, 3, 3));
            cardLevel3List.Add(new Card(RandomArray3[i3++], 4, 0, 0, 7, 0, 0, 3, 3));
            cardLevel3List.Add(new Card(RandomArray3[i3++], 4, 0, 3, 6, 3, 0, 3, 3));
            cardLevel3List.Add(new Card(RandomArray3[i3++], 5, 0, 0, 7, 3, 0, 3, 3));

            cardLevel3List.Add(new Card(RandomArray3[i3++], 3, 3, 3, 5, 3, 0, 3, 4));
            cardLevel3List.Add(new Card(RandomArray3[i3++], 4, 0, 0, 0, 7, 0, 3, 4));
            cardLevel3List.Add(new Card(RandomArray3[i3++], 4, 0, 0, 3, 6, 3, 3, 4));
            cardLevel3List.Add(new Card(RandomArray3[i3++], 5, 0, 0, 0, 7, 3, 3, 4));

            //ID Score cost0 cost1 cost2 cost3 cost4
            int[] RandomArray4 = RandomID(10);
            int i4 = 0;
            //0: 다이아
            //1: 사파이어
            //2: 에메랄드
            //3: 루비
            //4: 줄마노
            nobleList.Add(new Noble(RandomArray4[i4++], 3, 0, 0, 4, 4, 0));     //메리여왕
            nobleList.Add(new Noble(RandomArray4[i4++], 3, 3, 0, 0, 3, 3));     //카를 5세
            nobleList.Add(new Noble(RandomArray4[i4++], 3, 4, 4, 0, 0, 0));     //마키아벨리
            nobleList.Add(new Noble(RandomArray4[i4++], 3, 4, 0, 0, 0, 4));     //이사벨 1세
            nobleList.Add(new Noble(RandomArray4[i4++], 3, 0, 4, 4, 0, 0));     //쉴레이만 1세
            nobleList.Add(new Noble(RandomArray4[i4++], 3, 0, 3, 3, 3, 0));     //카트린 드 메디시스
            nobleList.Add(new Noble(RandomArray4[i4++], 3, 3, 3, 3, 0, 0));     //브르타뉴의 앤
            nobleList.Add(new Noble(RandomArray4[i4++], 3, 0, 0, 0, 4, 4));     //헨리 8세
            nobleList.Add(new Noble(RandomArray4[i4++], 3, 3, 3, 0, 0, 3));     //오스트리아의 엘리자베트
            nobleList.Add(new Noble(RandomArray4[i4++], 3, 0, 0, 3, 3, 3));     //프랑수아 1세
        }

        public int[] RandomID(int count)
        {
            int[] intArray = new int[count];
            Random rand = new Random();

            for(int loop = 0; loop < count; loop++)
            {
                int randNumber = rand.Next(0, count);

                if (intArray.Contains(randNumber))
                {
                    loop--;
                } 
                else
                {
                    intArray[loop] = randNumber;
                }
            }
            return intArray;
        }
    }

}
