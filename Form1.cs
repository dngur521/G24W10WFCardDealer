using System.Security.Policy;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace G24W10WFCardDealer
{
    // ChatGPT 참고해서 만든 Class
    public class CardComparer : IComparer<string>
    {
        private readonly Dictionary<string, int> _cardOrder;

        public CardComparer(IEnumerable<string> customOrder)
        {
            // 카드 값을 순서대로 매핑
            _cardOrder = [];
            int index  = 0;
            foreach (var card in customOrder)
            {
                _cardOrder[card] = index++;
            }
        }

        public int Compare(string x, string y)
        {
            // 각 카드 값을 순서에 따라 비교
            return _cardOrder[x].CompareTo(_cardOrder[y]);
        }
    }

    public partial class Form1 : Form
    {
        private const int CardCount = 5;

        // 배열에 쓰일 상수
        private const int value = 0;
        private const int suit = 1;

        public Form1()
        {
            InitializeComponent();
        }

        // 랜덤한 Value 값 뽑아내는 함수
        public static string GenerateValue()
        {
            string[] values = ["ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", 
                               "jack", "queen", "king"];

            Random random = new();
            int index = random.Next(0, values.Length);

            return values[index];
        }

        // 랜덤한 Suit 값 뽑아내는 함수
        public static string GenerateSuit()
        {
            string[] suits = ["spades", "diamonds", "hearts", "clubs"];

            Random random = new();
            int index = random.Next(0, suits.Length);

            return suits[index];
        }

        // 뭐뭐뭐_of_뭐뭐뭐를 "_of_"를 중심으로 내용만 뽑아내는 함수
        public static string[] GetSplit(string[] cardList, int index)
        {
            string[] temp = cardList[index].Split(new string[] { "_of_" }, StringSplitOptions.None);
            string[] spilitstr = [$"{temp[value]}", $"{temp[suit]}"];

            return spilitstr;
        }

        private void OnDeal(object sender, EventArgs e)
        {

            // 정렬 순서 정해주기
            var customOrder = new List<string> { 
                    "ace_of_spades",    "ace_of_diamonds",    "ace_of_hearts",    "ace_of_clubs",
                    "2_of_spades",      "2_of_diamonds",      "2_of_hearts",      "2_of_clubs",
                    "3_of_spades",      "3_of_diamonds",      "3_of_hearts",      "3_of_clubs",
                    "4_of_spades",      "4_of_diamonds",      "4_of_hearts",      "4_of_clubs",
                    "5_of_spades",      "5_of_diamonds",      "5_of_hearts",      "5_of_clubs",
                    "6_of_spades",      "6_of_diamonds",      "6_of_hearts",      "6_of_clubs",
                    "7_of_spades",      "7_of_diamonds",      "7_of_hearts",      "7_of_clubs",
                    "8_of_spades",      "8_of_diamonds",      "8_of_hearts",      "8_of_clubs",
                    "9_of_spades",      "9_of_diamonds",      "9_of_hearts",      "9_of_clubs",
                    "10_of_spades",     "10_of_diamonds",     "10_of_hearts",     "10_of_clubs",
                    "jack_of_spades2",  "jack_of_diamonds2",  "jack_of_hearts2",  "jack_of_clubs2",
                    "queen_of_spades2", "queen_of_diamonds2", "queen_of_hearts2", "queen_of_clubs2",
                    "king_of_spades2",  "king_of_diamonds2",  "king_of_hearts2",  "king_of_clubs2" };

            var comparer = new CardComparer(customOrder);
            var cardSet = new SortedSet<string>(comparer);

            // 중복 없이 카드 만들기
            while (cardSet.Count < CardCount)
            {
                string value = GenerateValue();
                string suit  = GenerateSuit();

                if (value is "jack" or "queen" or "king")
                    suit += "2";

                cardSet.Add($"{value}_of_{suit}");
            }

            string[] cardList = [.. cardSet];

            // 각 string에 맞는 이미지 지정
            int index = 0;

            Card1.Image = Properties.Resources.ResourceManager.
                          GetObject($"{cardList[index]}") as Image;
            string[] card1arr = GetSplit(cardList, index);
            index++;
            Card2.Image = Properties.Resources.ResourceManager.
                          GetObject($"{cardList[index]}") as Image;
            string[] card2arr = GetSplit(cardList, index);
            index++;
            Card3.Image = Properties.Resources.ResourceManager.
                          GetObject($"{cardList[index]}") as Image;
            string[] card3arr = GetSplit(cardList, index);
            index++;
            Card4.Image = Properties.Resources.ResourceManager.
                          GetObject($"{cardList[index]}") as Image;
            string[] card4arr = GetSplit(cardList, index);
            index++;
            Card5.Image = Properties.Resources.ResourceManager.
                          GetObject($"{cardList[index]}") as Image;
            string[] card5arr = GetSplit(cardList, index);


            // 족보 알아내기 위한 준비작업
            string[][] cardsarr = [card1arr, card2arr, card3arr, card4arr, card5arr];

            string[] cardsvalue = [cardsarr[0][value], 
                                   cardsarr[1][value], 
                                   cardsarr[2][value],
                                   cardsarr[3][value],
                                   cardsarr[4][value]];

            string[] cardssuit  = [cardsarr[0][suit],
                                   cardsarr[1][suit],
                                   cardsarr[2][suit],
                                   cardsarr[3][suit],
                                   cardsarr[4][suit]];

            // 테스트용 값
            //cardsvalue = ["10", "jack", "queen", "king", "ace"];
            //cardsvalue = ["ace", "2", "3", "4", "5"];
            //cardsvalue = ["ace", "2", "3", "4", "5"];
            //cardsvalue = ["7", "7", "3", "7", "7"];
            //cardsvalue = ["7", "7", "3", "7", "3"];

            // 이 아래부터 족보 알아내는 코드들
            Dictionary<string, int> valueCounts = [];

            foreach (var value in cardsvalue)
            {
                if (valueCounts.ContainsKey(value))
                    valueCounts[value]++;
                else
                    valueCounts[value] = 1;
            }

            int pairs   = 0;
            int triples = 0;
            int quads   = 0;

            foreach (var count in valueCounts.Values) {
                if (count == 2) {
                    pairs++;
                    if (count == 4)
                        pairs++; 
                }
                else if (count == 3)
                    triples++;
                else if (count == 4)
                    quads++;
            }

            bool straight      = false;
            bool backstraight  = false;
            bool royalstraight = false;

            if (pairs == 1 && triples == 0)
                label1.Text = "원페어";
            else if (pairs == 2)
                label1.Text = "투페어";
            else if (triples == 1 && pairs == 0)
                label1.Text = "트리플";
            else if (triples == 1 && pairs == 1)
                label1.Text = "풀하우스";
            else if (quads == 1)
                label1.Text = "포카드";
            else if (cardsvalue[0] == "10"    && 
                     cardsvalue[1] == "jack"  && 
                     cardsvalue[2] == "queen" && 
                     cardsvalue[3] == "king"  && 
                     cardsvalue[4] == "ace")
                label1.Text = "마운틴";
            else if (cardsvalue[0] == "9"     && 
                     cardsvalue[1] == "10"    && 
                     cardsvalue[2] == "jack"  && 
                     cardsvalue[3] == "queen" && 
                     cardsvalue[4] == "king")
                label1.Text = "스트레이트";
            else if (cardsvalue[0] == "8"     && 
                     cardsvalue[1] == "9"     && 
                     cardsvalue[2] == "10"    && 
                     cardsvalue[3] == "jack"  && 
                     cardsvalue[4] == "queen")
                label1.Text = "스트레이트";
            else if (cardsvalue[0] == "7"     && 
                     cardsvalue[1] == "8"     && 
                     cardsvalue[2] == "9"     && 
                     cardsvalue[3] == "10"    && 
                     cardsvalue[4] == "jack")
                label1.Text = "스트레이트";
            else if (cardsvalue[0] == "6"     && 
                     cardsvalue[1] == "7"     && 
                     cardsvalue[2] == "8"     && 
                     cardsvalue[3] == "9"     && 
                     cardsvalue[4] == "10")
                label1.Text = "스트레이트";
            else if (cardsvalue[0] == "5"     && 
                     cardsvalue[1] == "6"     && 
                     cardsvalue[2] == "7"     && 
                     cardsvalue[3] == "8"     && 
                     cardsvalue[4] == "9")
                label1.Text = "스트레이트";
            else if (cardsvalue[0] == "4"     && 
                     cardsvalue[1] == "5"     && 
                     cardsvalue[2] == "6"     && 
                     cardsvalue[3] == "7"     && 
                     cardsvalue[4] == "8")
                label1.Text = "스트레이트";
            else if (cardsvalue[0] == "3"     && 
                     cardsvalue[1] == "4"     && 
                     cardsvalue[2] == "5"     && 
                     cardsvalue[3] == "6"     && 
                     cardsvalue[4] == "7")
                label1.Text = "스트레이트";
            else if (cardsvalue[0] == "2"     && 
                     cardsvalue[1] == "3"     && 
                     cardsvalue[2] == "4"     && 
                     cardsvalue[3] == "5"     && 
                     cardsvalue[4] == "6")
                label1.Text = "스트레이트";
            else if (cardsvalue[0] == "ace"   && 
                     cardsvalue[1] == "2"     && 
                     cardsvalue[2] == "3"     && 
                     cardsvalue[3] == "4"     && 
                     cardsvalue[4] == "5")
                label1.Text = "백스트레이트";
            else
                label1.Text = "기타";
            if (label1.Text == "스트레이트")
                straight = true;
            else if (label1.Text == "마운틴")
                royalstraight = true;
            else if (label1.Text == "백스트레이트")
                backstraight  = true;

            //테스트용 값
            //cardssuit = ["a", "a", "a", "a", "a"];

            if ((cardssuit[0] == cardssuit[1]) && 
                (cardssuit[1] == cardssuit[2]) && 
                (cardssuit[2] == cardssuit[3]) && 
                (cardssuit[3] == cardssuit[4]) && 
                (cardssuit[4] == cardssuit[0]))
            {
                if (straight == true)
                    label1.Text = "스트레이트 플러쉬";
                else if (royalstraight == true)
                    label1.Text = "로얄스트레이트 플러쉬";
                else if (backstraight  == true)
                    label1.Text = "백스트레이트 플러쉬";
                else
                    label1.Text = "플러쉬";
            }

            // split된 string 잘 저장되었나 확인하는 코드
            label3.Text = $"{cardsvalue[0]}, {cardsvalue[1]}, {cardsvalue[2]}, {cardsvalue[3]}, {cardsvalue[4]}";
            label4.Text = $"{cardssuit[0]},  {cardssuit[1]},  {cardssuit[2]},  {cardssuit[3]},  {cardssuit[4]}"; 
        }
    }
}