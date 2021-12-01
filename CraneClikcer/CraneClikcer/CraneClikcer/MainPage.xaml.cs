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
        int TimerForLuckyCranes = 1;
        int luckyRate = 0;

        public MainPage()
        {
            InitializeComponent();

            Random Rand = new Random();
            LuckyImage.TranslateTo(-1000, 1000, 1);
            LuckyImage.FadeTo(0.0, 1);
            LuckyImage.ScaleTo(0.3, 1);
            LuckyText.FadeTo(0, 1);

            //when done testing should be from every 300-900 seconds
            Device.StartTimer(TimeSpan.FromSeconds(Rand.Next(300, 901)), () =>
            {
                LuckyAnimation();
                return true;
            });


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
                    if (luckyRate == 0) { luckyRate = 1; }
                    App.Score += 5 * App.Scissors * luckyRate;
                    App.Rate += 5 * App.Scissors * luckyRate;
                    luckyRate = 0;
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
                    if (luckyRate == 0) { luckyRate = 1; }
                    App.Score += 15 * App.Paper * luckyRate;
                    App.Rate += 15 * App.Paper * luckyRate;
                    luckyRate = 0;
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
                    if (luckyRate == 0) { luckyRate = 1; }
                    App.Score += 35 * App.Sibling * luckyRate;
                    App.Rate += 35 * App.Sibling * luckyRate;
                    luckyRate = 0;
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
                    if (luckyRate == 0) { luckyRate = 1; }
                    App.Score += 75 * App.Friends * luckyRate;
                    App.Rate += 75 * App.Friends * luckyRate;
                    luckyRate = 0;
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
                    if (luckyRate == 0) { luckyRate = 1; }
                    App.Score += 100 * App.CoWorkers * luckyRate;
                    App.Rate += 100 * App.CoWorkers * luckyRate;
                    luckyRate = 0;
                }

                //update the score because there was a change
                ((MainPageViewModel)BindingContext).UpdateScore();

                //reutrn true to restart the timer
                return true;
            });
        }

        //Update the score when returning to the home page if there was a chaneg
        protected override void OnAppearing()
        {
            base.OnAppearing();
            ((MainPageViewModel)BindingContext).UpdateScore();
        }

        //go to the store page when the store button is pressed
        private void Store_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new StorePage());
        }

        private void Instructions_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new InstructionPage());
        }

        private void AboutPage_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AboutPage());
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            //add the lucky rate to the score;
            App.Score += luckyRate;
            ((MainPageViewModel)BindingContext).UpdateScore();
            await craneImage.RotateTo(-10, 100, Easing.Linear);
            await craneImage.RotateTo(10, 100, Easing.Linear);
            await craneImage.RotateTo(0, 100, Easing.Linear);
        }

        //animation to spawn the lucky cookie
        private async void LuckyAnimation()
        {
            Random rand = new Random();

            await LuckyImage.TranslateTo(rand.Next(-200, 200), rand.Next(-200, 200), 1);
            await LuckyImage.FadeTo(1, 100);
            await LuckyImage.FadeTo(0, 5000);
        }

        private async void LuckyImage_Tappped(object sender, EventArgs e)
        {
            Random rand = new Random();

            int randomNum = rand.Next(1, 10);

            if(randomNum > 0 && randomNum < 4)
            {
                LuckyText.Text = "Gained " + 100 * randomNum;
                App.Score = App.Score + (100 * randomNum);
                ((MainPageViewModel)BindingContext).UpdateScore();
            }
            else if(randomNum > 3 && randomNum < 7)
            {
                int itemRandomNum = rand.Next(1, 6);
                int itemAmount = rand.Next(1, 11);

                if(itemRandomNum == 1)
                {
                    LuckyText.Text = "You gained " + itemAmount + " Scissors";
                    App.Scissors += itemAmount;
                }
                else if(itemRandomNum == 2)
                {
                    LuckyText.Text = "You gained " + itemAmount + " Paper";
                    App.Paper += itemAmount;
                }
                else if(itemRandomNum == 3)
                {
                    LuckyText.Text = "You gained " + itemAmount + " Siblings";
                    App.Sibling += itemAmount;
                }
                else if(itemRandomNum == 4)
                {
                    LuckyText.Text = "You gained " + itemAmount + " Friends";
                    App.Friends += itemAmount;
                }
                else
                {
                    LuckyText.Text = "You gained " + itemAmount + " Co-Workers";
                    App.CoWorkers += itemAmount;
                }
            }
            else
            {
                if(randomNum == 7)
                {
                    luckyRate = 2;
                    TimerForLuckyCranes = 30;
                    LuckyText.Text = "x" + luckyRate + " extra Cranes for 30 seconds";
                }
                else if(randomNum == 8)
                {
                    luckyRate = 3;
                    TimerForLuckyCranes = 60;
                    LuckyText.Text = "x" + luckyRate + " extra Cranes for 60 seconds";
                }
                else
                {
                    luckyRate = 4;
                    TimerForLuckyCranes = 90;
                    LuckyText.Text = "x" + luckyRate + " extra Cranes for 90 seconds";
                }

                Device.StartTimer(TimeSpan.FromSeconds(TimerForLuckyCranes), () =>
                {
                    luckyRate = 0;
                    TimerForLuckyCranes = 1;
                    return true;
                });

            }

            await LuckyImage.FadeTo(0, 100);
            await LuckyImage.TranslateTo(1000, 1000, 1);
            await LuckyText.FadeTo(1, 500);
            await LuckyText.FadeTo(0, 5000);
        }
    }
}
