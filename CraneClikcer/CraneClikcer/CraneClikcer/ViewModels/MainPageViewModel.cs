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
        public int Score
        {
            get { return App.score; }
        }

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

        private void PerformAddScore()
        {
            App.score++;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Score"));
        }

        public MainPageViewModel() { }

        internal void UpdateScore()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Score"));
        }
    }
}
