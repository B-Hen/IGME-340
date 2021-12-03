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
        //variables for the lucky crane pop ups
        int TimerForLuckyCranes = 1;
        int luckyRate = 0;

        public MainPage()
        {
            InitializeComponent();

            //random variable used for the lucky crane pop ups and so quick animation set up
            Random Rand = new Random();
            LuckyImage.TranslateTo(-1000, 1000, 1);
            LuckyImage.FadeTo(0.0, 1);
            LuckyImage.ScaleTo(0.3, 1);
            LuckyText.FadeTo(0, 1);

            #region Timer
            //when done testing should be from every 300-900 seconds
            Device.StartTimer(TimeSpan.FromSeconds(Rand.Next(300, 901)), () =>
            {
                //play the animation to make the lucky crane appear
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
            #endregion
        }

        #region Pages
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

        //go to the inmstruction page whenever the instruction button is clicked
        private void Instructions_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new InstructionPage());
        }

        //go to the about page whenever the about button is clicked 
        private void AboutPage_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AboutPage());
        }
        #endregion

        #region Tapped
        //tap gesturce for main cram
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            //add the lucky rate to the score;
            App.Score += luckyRate;

            //update the score
            ((MainPageViewModel)BindingContext).UpdateScore();

            //play animation to indicate the the crame has been tapped
            await craneImage.RotateTo(-10, 100, Easing.Linear);
            await craneImage.RotateTo(10, 100, Easing.Linear);
            await craneImage.RotateTo(0, 100, Easing.Linear);
        }
        #endregion

        #region Lucky Crane
        //animation to spawn the lucky cookie
        private async void LuckyAnimation()
        {
            //random number to change the location of where the crane will pop up from
            Random rand = new Random();

            //animate the crane
            await LuckyImage.TranslateTo(rand.Next(-200, 200), rand.Next(-200, 200), 1);
            await LuckyImage.FadeTo(1, 100);
            await LuckyImage.FadeTo(0, 5000);
        }

        //tap gesture to see if the lucky crane have been clicked
        private async void LuckyImage_Tappped(object sender, EventArgs e)
        {
            //animate that the crane was clicked
            await LuckyImage.RotateTo(-10, 100, Easing.Linear);
            await LuckyImage.RotateTo(10, 100, Easing.Linear);
            await LuckyImage.RotateTo(0, 100, Easing.Linear);

            //random number to decided what the user will get
            Random rand = new Random();

            int randomNum = rand.Next(1, 10);

            //check to see if the number is between 1 and 3 if so the user gains 100 * rand cranes
            if(randomNum > 0 && randomNum < 4)
            {
                //update the lucky crane text to show what the user got 
                LuckyText.Text = "Gained " + 100 * randomNum;

                //add the number of cranes to the score and update the score
                App.Score = App.Score + (100 * randomNum);
                ((MainPageViewModel)BindingContext).UpdateScore();
            }
            //check to see if the number is between 4 and 6 if so the user gains items
            else if(randomNum > 3 && randomNum < 7)
            {
                //random number for which item and the amount of the item the user will get
                int itemRandomNum = rand.Next(1, 6);
                int itemAmount = rand.Next(1, 11);

                //if 1 the user will gain scissors
                if(itemRandomNum == 1)
                {
                    LuckyText.Text = "You gained " + itemAmount + " Scissors";
                    App.Scissors += itemAmount;
                }
                //if 2 the user will get paper
                else if(itemRandomNum == 2)
                {
                    LuckyText.Text = "You gained " + itemAmount + " Paper";
                    App.Paper += itemAmount;
                }
                //if 3 the user will get siblings
                else if(itemRandomNum == 3)
                {
                    LuckyText.Text = "You gained " + itemAmount + " Siblings";
                    App.Sibling += itemAmount;
                }
                //if4 the user will gain friends
                else if(itemRandomNum == 4)
                {
                    LuckyText.Text = "You gained " + itemAmount + " Friends";
                    App.Friends += itemAmount;
                }
                //if 5 the user will gain co-workers
                else
                {
                    LuckyText.Text = "You gained " + itemAmount + " Co-Workers";
                    App.CoWorkers += itemAmount;
                }
            }
            //else if rand is between 7 and 9 each tape will add x# more cranes
            else
            {
                //if 7 there will be x2 more taps for each tap
                if(randomNum == 7)
                {
                    luckyRate = 2;
                    TimerForLuckyCranes = 30;
                    LuckyText.Text = "x" + luckyRate + " extra Cranes for 30 seconds";
                }
                //if 8 there will be x3 more taps for each tap
                else if(randomNum == 8)
                {
                    luckyRate = 3;
                    TimerForLuckyCranes = 60;
                    LuckyText.Text = "x" + luckyRate + " extra Cranes for 60 seconds";
                }
                //if 9 there will be x4 more taps for each tap
                else
                {
                    luckyRate = 4;
                    TimerForLuckyCranes = 90;
                    LuckyText.Text = "x" + luckyRate + " extra Cranes for 90 seconds";
                }

                //start the time that will add more taps, once timer is out the x# will go back to being 0
                Device.StartTimer(TimeSpan.FromSeconds(TimerForLuckyCranes), () =>
                {
                    luckyRate = 0;
                    TimerForLuckyCranes = 1;
                    return true;
                });

            }

            //play animation to fade the screen and move it off screen
            await LuckyImage.FadeTo(0, 100);
            await LuckyImage.TranslateTo(1000, 1000, 1);
            await LuckyText.FadeTo(1, 500);
            await LuckyText.FadeTo(0, 5000);
        }
        #endregion
    }
}
