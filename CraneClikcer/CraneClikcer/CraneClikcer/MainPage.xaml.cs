using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CraneClikcer
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            int score = 0;

            //check for taps on the crane image
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += async(s,e) =>
            {
                score++;
                Score.Text = "Score: " + score;
            };

            craneImage.GestureRecognizers.Add(tapGestureRecognizer);
        }
    }
}
