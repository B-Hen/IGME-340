using CraneClikcer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CraneClikcer.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        //Properties
        public int Score
        {
            get { return App.Score; }
        }

        public int Rate
        {
            get { return App.Rate; }
        }

        //command to add to the score
        private Command addScore;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand AddScore
        {
            get
            {
                if (addScore == null)
                {
                    addScore = new Command(PerformAddScore);
                }

                return addScore;
            }
        }

        //method to add to the score whenever the image is tapped also update the rate
        private void PerformAddScore()
        {
            App.Score++;
            App.Rate++;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Score"));
        }

        public MainPageViewModel() { }

        //method to update the score whenever it changes
        internal void UpdateScore()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Score"));
        }

        //method to update the rate whenever it changes
        internal void UpdateRate()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Rate"));
        }
    }
}
