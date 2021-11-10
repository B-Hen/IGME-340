using CraneClikcer.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace CraneClikcer.Models
{
    public class StoreItems : INotifyPropertyChanged
    {
        //event
        public event PropertyChangedEventHandler PropertyChanged;

        //properties
        private int scissors;
        public int numScissors
        {
            get { return scissors; }
            set
            {
                scissors = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("numScissors"));
                Preferences.Set("Scissors", scissors);
            }
        }

        private Command addScissors;

        public ICommand AddScissors
        {
            get
            {
                if (addScissors == null)
                {
                    addScissors = new Command(PerformaddScissors, EnableScissors);
                }

                return addScissors;
            }
        }

        private void PerformaddScissors()
        {
            numScissors++;

            App.score -= 5;
            addScissors.ChangeCanExecute();
            storeVM.UpdateScore();
            MPVM.UpdateScore();
        }

        private bool EnableScissors()
        {
            if (App.score >= 5)
            {
                return true;
            }

            return false;
        }

        public StorePageViewModel storeVM{ get; set; }
        public MainPageViewModel MPVM { get; set; }

        private int paper;
        public int numPaper
        {
            get { return paper; }
            set
            {
                paper = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("numPaper"));
            }
        }
        public int numSibings { get; set; }
        public int numFriends { get; set; }
        public int numCoWorkers { get; set; }

        private Command addPaper;

        public ICommand AddPaper
        {
            get
            {
                if(addPaper == null)
                {
                    addPaper = new Command(PerformAddPaper);
                }

                return addPaper;
            }
        }

        public void PerformAddPaper()
        {
            numPaper++;
        }
    }
}
