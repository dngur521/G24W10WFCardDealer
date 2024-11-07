namespace G24W10WFCardDealer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void OnDeal(object sender, EventArgs e)
        {
            string[] suits = ["spades", "diamonds", "hearts", "clubs"];
            string[] values = ["ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "jack", "queen", "king"];
            int cardval = suits.Length * values.Length;

            Random random = new Random();
            int card = random.Next(cardval);

            string suit = suits[card / values.Length];
            string value = values[card % values.Length];

            //if (value == "jack" || value == "queen" || value == "king") {
            //    suit += "2";
            //}
            if (value is "jack" or "queen" or "king") {
                suit += "2";
            }

            Card1.Image = Properties.Resources
                        .ResourceManager
                        .GetObject($"{value}_of_{suit}") 
                        as Image;
        }
    }
}
