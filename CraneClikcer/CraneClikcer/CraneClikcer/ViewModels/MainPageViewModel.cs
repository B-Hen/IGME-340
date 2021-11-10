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
            set
            {
                App.score = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Score"));
            }
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
            Score++;
        }

        public MainPageViewModel(StoreItems item)
        {
            item.MPVM = this;
        }

        public MainPageViewModel() { }

        internal void UpdateScore()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Score"));
        }
    }
}
