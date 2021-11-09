using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace CraneClikcer
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            //ints for the rate and the score
            int rate = 0;
            int score = (int)Preferences.Get("score", 0);
            Score.Text = Preferences.Get("scoreText", "Score: 0");

            //check for taps on the crane image
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += async(s,e) =>
            {
                //add to the score and the rate and update the score UI
                score++;
                Preferences.Set("score", score);
                Score.Text = "Score: " + score;
                Preferences.Set("scoreText", Score.Text);
                rate++;
            };

            //add the tap gesture to the image
            craneImage.GestureRecognizers.Add(tapGestureRecognizer);

            //Check each second for the rate of clicjs
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                //change the rate UI and then reset the rat
                Rate.Text = "Rate: " + rate + "/s";
                rate = 0;

                //return true so the time starts again
                return true;
            });
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new StorePage());
        }
    }
}
