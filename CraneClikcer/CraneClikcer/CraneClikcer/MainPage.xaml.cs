using CraneClikcer.ViewModels;
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

            //Check each second for the rate of clicks
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                //notify the app that the rate variable has updated 
                ((MainPageViewModel)BindingContext).UpdateRate();
                App.Rate = 0;

                //return true so the time starts again
                return true;
            });

            //for every second add to the score * the amount of scissors
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                //only do this is the user has scissors
                if(App.Scissors > 0)
                {
                    App.Score += 5 * App.Scissors;
                    App.Rate += 5 * App.Scissors;
                }

                //update the score because there was a change
                ((MainPageViewModel)BindingContext).UpdateScore();

                //reutrn true to restart the timer
                return true;
            });
        }

        //go to the store page when the store button is pressed
        private void Store_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new StorePage());
        }

        //Update the score when returning to the home page if there was a chaneg
        protected override void OnAppearing()
        {
            base.OnAppearing();
            ((MainPageViewModel)BindingContext).UpdateScore();
        }
    }
}
