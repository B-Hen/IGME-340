using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
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
            }
        }
        public int numPaper { get; set; }
        public int numSibings { get; set; }
        public int numFriends { get; set; }
        public int numCoWorkers { get; set; }

        private Command addScissors;

        public ICommand AddScissors
        {
            get
            {
                if (addScissors == null)
                {
                    addScissors = new Command(PerformaddScissors);
                }

                return addScissors;
            }
        }

        private void PerformaddScissors()
        {
            numScissors++;
        }
    }
}
