using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace Motivator
{
    class MainPageViewModel : INotifyPropertyChanged
    {
        //strings
        private string title;
        private string sayingText;
        private string categoryText;
        private string moreAdvice;
        private List<string> healthySayings;
        private Random rand;

        //INotifyPropertyChanged event
        public event PropertyChangedEventHandler PropertyChanged;

        //property for the title
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        //property for the sayingText
        public string SayingText
        {
            get { return sayingText; }
            set
            {
                sayingText = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SayingText"));
            }
        }

        //property for categoryText
        public string CategoryText
        {
            get { return categoryText; }
            set { categoryText = value; }
        }

        //property for more advice 
        public string MoreAdvice
        {
            get { return moreAdvice; }
            set { moreAdvice = value; }
        }

        //property for the motivate command
        public Command MotivateCommand { get; set; }

        //property for the more advice command
        public Command MoreAdviceCommand { get; set; }

        public MainPageViewModel()
        {
            rand = new Random();

            title = "Motivator-MVVM";
            sayingText = "Tap a button to get motivated!";
            categoryText = "Eat Vegetables!";
            moreAdvice = "More Advice";

            healthySayings = new List<string>
            {
                "Eat Veggies and you will lose weight",
                "Get some exercise",
                "Turn on your bluelight filtering on the pc",
                "Drink Water it's healthy :)"
            };

            MotivateCommand = new Command(() =>
            {
                SayingText = healthySayings[rand.Next(0, healthySayings.Count)];
            });

            MoreAdviceCommand = new Command(() =>
            {
                SayingText = healthySayings[rand.Next(0, healthySayings.Count)];
            });
        }
    }
}
