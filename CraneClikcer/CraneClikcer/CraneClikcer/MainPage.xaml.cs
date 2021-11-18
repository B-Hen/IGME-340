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

            //for every second add to the score * the amount of paper
            Device.StartTimer(TimeSpan.FromSeconds(10), () =>
            {
                //only do this is the user has Paper
                if (App.Paper > 0)
                {
                    App.Score += 15 * App.Paper;
                    App.Rate += 15 * App.Paper;
                }

                //update the score because there was a change
                ((MainPageViewModel)BindingContext).UpdateScore();

                //reutrn true to restart the timer
                return true;
            });

            //for every second add to the score * the amount of siblings
            Device.StartTimer(TimeSpan.FromSeconds(50), () =>
            {
                //only do this is the user has Paper
                if (App.Sibling > 0)
                {
                    App.Score += 35 * App.Sibling;
                    App.Rate += 35 * App.Sibling;
                }

                //update the score because there was a change
                ((MainPageViewModel)BindingContext).UpdateScore();

                //reutrn true to restart the timer
                return true;
            });

            //for every second add to the score * the amount of friends
            Device.StartTimer(TimeSpan.FromSeconds(100), () =>
            {
                //only do this is the user has Paper
                if (App.Friends > 0)
                {
                    App.Score += 75 * App.Friends;
                    App.Rate += 75 * App.Friends;
                }

                //update the score because there was a change
                ((MainPageViewModel)BindingContext).UpdateScore();

                //reutrn true to restart the timer
                return true;
            });

            //for every second add to the score * the amount of co-workers
            Device.StartTimer(TimeSpan.FromSeconds(150), () =>
            {
                //only do this is the user has Paper
                if (App.CoWorkers > 0)
                {
                    App.Score += 100 * App.CoWorkers;
                    App.Rate += 100 * App.CoWorkers;
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

        private void Instructions_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new InstructionPage());
        }

        private void Settings_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SettingsPage());
        }
    }
}
