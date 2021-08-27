using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HelloRIT
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            //variables for the top and bottom label
            var topLabel = new Label();
            var bottomLabel = new Label();

            //change the top label properties
            topLabel.Text = "Hello";
            topLabel.FontSize = 36;

            //add it to the main stack
            mainStack.Children.Add(topLabel);

            //change the bottom label properties
            bottomLabel.Text = "RIT";
            bottomLabel.FontSize = 48;
            bottomLabel.HorizontalTextAlignment = TextAlignment.Center;

            //ass it to the main stack
            mainStack.Children.Add(bottomLabel);

            //change the background color
            BackgroundColor = Color.Orange;

            //add a new label for my name
            var myName = new Label();

            //change the properties for the myName label
            myName.Text = "Breanna Henriquez";
            myName.FontSize = 30;
            myName.HorizontalTextAlignment = TextAlignment.Center;
            myName.VerticalTextAlignment = TextAlignment.End;
            myName.TextColor = Color.Blue;

            //add it to the main stack
            mainStack.Children.Add(myName);
        }
    }
}
