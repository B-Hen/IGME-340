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

        public App()
        {
            InitializeComponent();

            //Set the variables
            Score = (int)Preferences.Get("score", 0);
            Rate = (int)Preferences.Get("rate", 0);
            Scissors = (int)Preferences.Get("scissors", 0);
            ScissorCost = (int)Preferences.Get("scissorsCost", 15);

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
            Preferences.Set("scissors", Scissors);
            Preferences.Set("scissorsCost", ScissorCost);
        }

        protected override void OnResume()
        {
        }
    }
}
