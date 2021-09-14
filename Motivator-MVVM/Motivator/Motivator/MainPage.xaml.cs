using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Motivator
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BindingContext = new MainPageViewModel();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            sayingLabel.Text = "Eat Veggies and you will lose weight!";
        }

        private void Button_Clicked_Advice(object sender, EventArgs e)
        {
            sayingLabel.Text = "Drink Water, it's healthy! :)";
        }
    }
}
