using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CraneClikcer
{
    public partial class App : Application
    {
        public static int score { get; set; }
        public App()
        {
            InitializeComponent();

            score = (int)Preferences.Get("score", 0);
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
            Preferences.Set("score", score);
        }

        protected override void OnResume()
        {
        }
    }
}
