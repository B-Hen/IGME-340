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

            //ints for the rate and the score
            int rate = 0;

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

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ((MainPageViewModel)BindingContext).UpdateScore();
        }
    }
}
