using CraneClikcer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace CraneClikcer.ViewModels
{
    public class StorePageViewModel : INotifyPropertyChanged
    {
        //properties
        public ObservableCollection<StoreItems> items { get; set; }

        public int Score
        {
            get { return App.score; }
        }

        public StorePageViewModel()
        {
            items = new ObservableCollection<StoreItems>
            {
                new StoreItems{ numScissors = Preferences.Get("Scissors", 0), numPaper = 0, numSibings = 0, numFriends = 0, numCoWorkers = 0, storeVM = this, MPVM = new MainPageViewModel()},
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        internal void UpdateScore()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Score"));
        }
    }
}
