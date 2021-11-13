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
        public static int ScissorSell { get; set; }
        public static string ScissorText { get; set; }

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
            BuySellx10 = Preferences.Get("buysellx1", "BUY x10");
            BuySellx100 = Preferences.Get("buysellx1", "BUY x100");
            Scissors = (int)Preferences.Get("scissors", 0);
            ScissorCost = (int)Preferences.Get("scissorsCost", 15);
            ScissorSell = (int)Preferences.Get("scissorsSell", 0); 
            ScissorText = Preferences.Get("scissorsText", "Buy For 15 Cranes");

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
            Preferences.Set("scissorsSell", ScissorSell);
            Preferences.Set("scissorsText", ScissorText);
        }

        protected override void OnResume()
        {
        }
    }
}
