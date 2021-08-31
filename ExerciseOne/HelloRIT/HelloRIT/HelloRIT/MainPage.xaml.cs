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

            //adds a tap gesture and move the top label to new spot in 1 second
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += async (s, e) =>
            {
                await topLabel.TranslateTo(100, 500, 1000, Easing.BounceOut);
                await topLabel.RotateTo(360, 1000);
                await topLabel.ScaleTo(0.5, 1000, Easing.SpringOut);
                await topLabel.FadeTo(0, 1000);

            };
            
            //add the gesture to the main stack
            mainStack.GestureRecognizers.Add(tapGestureRecognizer);

            //Tap animation for the bottom layer
             var tapGestureRecognizerBottom = new TapGestureRecognizer();
            tapGestureRecognizerBottom.Tapped += async (s, e) =>
            {
                await bottomLabel.TranslateTo(100, 200, 1000);
                await bottomLabel.ScaleTo(1.5, 1000, Easing.Linear);
                await bottomLabel.FadeTo(0.5, 1000);
            };

            //add animation for bottom layer to main stack
            mainStack.GestureRecognizers.Add(tapGestureRecognizerBottom);

            //tap animation for name label
            var tapGestureRecognizerName = new TapGestureRecognizer();
            tapGestureRecognizerName.Tapped += async (s, e) =>
            {
                await myName.RotateTo(360, 1000);
                await myName.FadeTo(0.7, 1000);
            };

            //add name animation to the main stack 
            mainStack.GestureRecognizers.Add(tapGestureRecognizerName);
        }
    }
}
