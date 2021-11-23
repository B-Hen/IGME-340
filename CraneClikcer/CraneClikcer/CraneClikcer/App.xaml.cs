using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CraneClikcer
{
    public partial class App : Application
    {
        //Properties
        public static int Score { get; set; }
        public static int Rate { get; set; }
        public static int Scissors { get; set; }
        public static int ScissorCost { get; set; }
        public static int PrevScissorCost { get; set; }
        public static int ScissorSell { get; set; }
        public static string ScissorText { get; set; }

        public static int Paper { get; set; }
        public static int PaperCost { get; set; }
        public static int PrevPaperCost { get; set; }
        public static int PaperSell { get; set; }
        public static string PaperText { get; set; }

        public static int Sibling { get; set; }
        public static int SiblingCost { get; set; }
        public static int PrevSiblingCost { get; set; }
        public static int SiblingSell { get; set; }
        public static string SiblingText { get; set; }

        public static int Friends { get; set; }
        public static int FriendsCost { get; set; }
        public static int PrevFriendCost { get; set; }
        public static int FriendsSell { get; set; }
        public static string FriendsText { get; set; }

        public static int CoWorkers { get; set; }
        public static int CoWorkersCost { get; set; }
        public static int PrevCoWorkersCost { get; set; }
        public static int CoWorkersSell { get; set; }
        public static string CoWorkersText { get; set; }

        public static bool BuySell { get; set; }
        public static int BuySellAmount { get; set; }

        public static string BuySellx1{get; set;}
        public static string BuySellx10{get; set;}
        public static string BuySellx100{get; set;}

        public App()
        {
            InitializeComponent();

            //Set the variables
            Score = (int)Preferences.Get("score", 0);
            Rate = (int)Preferences.Get("rate", 0);
            BuySell = Preferences.Get("buySell", true);
            BuySellAmount = (int)Preferences.Get("buySellAmount", 1);
            BuySellx1 = Preferences.Get("buysellx1", "BUY x1");
            BuySellx10 = Preferences.Get("buysellx10", "BUY x10");
            BuySellx100 = Preferences.Get("buysellx100", "BUY x100");
            Scissors = (int)Preferences.Get("scissors", 0);
            ScissorCost = (int)Preferences.Get("scissorsCost", 15);
            PrevScissorCost = (int)Preferences.Get("prevScissorsCost", 0);
            ScissorSell = (int)Preferences.Get("scissorsSell", 0); 
            ScissorText = Preferences.Get("scissorsText", "Buy For 15 Cranes");
            Paper = (int)Preferences.Get("paper", 0);
            PaperCost = (int)Preferences.Get("paperCost", 50);
            PrevPaperCost = (int)Preferences.Get("prevPaperCost", 0);
            PaperSell = (int)Preferences.Get("paperSell", 0);
            PaperText = Preferences.Get("paperText", "Buy For 50 Cranes");
            Sibling = (int)Preferences.Get("sibling", 0);
            SiblingCost = (int)Preferences.Get("siblingCost", 75);
            PrevSiblingCost = (int)Preferences.Get("prevSiblingCost", 0);
            SiblingSell = (int)Preferences.Get("siblingSell", 0);
            SiblingText = Preferences.Get("siblingText", "Buy For 75 Cranes");
            Friends = (int)Preferences.Get("friends", 0);
            FriendsCost = (int)Preferences.Get("friendsCost", 125);
            PrevFriendCost = (int)Preferences.Get("prevFriendsCost", 125);
            FriendsSell = (int)Preferences.Get("friendsSell", 0);
            FriendsText = Preferences.Get("friendsText", "Buy For 125 Cranes");
            CoWorkers = (int)Preferences.Get("coWorkers", 0);
            CoWorkersCost = (int)Preferences.Get("coWorkersCost", 150);
            PrevCoWorkersCost = (int)Preferences.Get("prevCoWorkersCost", 0);
            CoWorkersSell = (int)Preferences.Get("coWorkersSell", 0);
            CoWorkersText = Preferences.Get("coWorkersText", "Buy For 150 Cranes");

            //create naviagation 
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
            //Save the variales when the app closes
            Preferences.Set("score", Score);
            Preferences.Set("rate", Rate);
            Preferences.Set("buySell", BuySell);
            Preferences.Set("buySellAmount", BuySellAmount);
            Preferences.Set("buysellx1", BuySellx1);
            Preferences.Set("buysellx10", BuySellx10);
            Preferences.Set("buysellx100", BuySellx100);
            Preferences.Set("scissors", Scissors);
            Preferences.Set("scissorsCost", ScissorCost);
            Preferences.Set("prevScissorsCost", PrevScissorCost);
            Preferences.Set("scissorsSell", ScissorSell);
            Preferences.Set("scissorsText", ScissorText);
            Preferences.Set("paper", Paper);
            Preferences.Set("paperCost", PaperCost);
            Preferences.Set("prevPaperCost", PrevPaperCost);
            Preferences.Set("paperSell", PaperSell);
            Preferences.Set("paperText", PaperText);
            Preferences.Set("sibling", Sibling);
            Preferences.Set("siblingCost", SiblingCost);
            Preferences.Set("prevSiblingCost", PrevSiblingCost);
            Preferences.Set("siblingSell", SiblingSell);
            Preferences.Set("siblingText", SiblingText);
            Preferences.Set("friends", Friends);
            Preferences.Set("friendsCost", FriendsCost);
            Preferences.Set("prevFriendsCost", PrevFriendCost);
            Preferences.Set("friendsSell", FriendsSell);
            Preferences.Set("friendsText", FriendsText);
            Preferences.Set("coWorkers", CoWorkers);
            Preferences.Set("coWorkersCost", CoWorkersCost);
            Preferences.Set("prevCoWorkersCost", PrevCoWorkersCost);
            Preferences.Set("coWorkersSell", CoWorkersSell);
            Preferences.Set("coWorkersText", CoWorkersText);
        }

        protected override void OnResume()
        {
        }
    }
}
