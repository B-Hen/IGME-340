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

        public event PropertyChangedEventHandler PropertyChanged;

        public int Score
        {
            get { return App.Score; }
        }

        public int Scissors
        {
            get { return App.Scissors; }
        }

        public StorePageViewModel()
        {
            //create the items
            items = new ObservableCollection<StoreItems>
            {
                new StoreItems{ numScissors = App.Scissors, numPaper = 0, numSibings = 0, numFriends = 0, numCoWorkers = 0, storeVM = this},
            };
        }

        //update the score whenever there is a change
        internal void UpdateScore()
        {
            //also check to see if the add scissor button can be enabled/disabled
            items[0].addScissors.ChangeCanExecute();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Score"));
        }

        //method to update the scissors
        internal void UpdateScissors()
        {
            //check to see if the x1 x10 x100 buttons need to be disable/enabled
            items[0].subtractScissorsX1.ChangeCanExecute();
            items[0].subtractScissorsX10.ChangeCanExecute();
            items[0].subtractScissorsX100.ChangeCanExecute();
        }
    }
}
