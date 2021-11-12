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
        public StorePageViewModel storeVM { get; set; }

        #region Scissors
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

        //command to add to the number of scissors
        public Command addScissors;

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

        //method to add to the scissors and update the score
        private void PerformaddScissors()
        {
            numScissors++;
            App.Scissors++;
            App.Score -= 50;
            addScissors.ChangeCanExecute();
            storeVM.UpdateScore();
        }

        //method to check if you can actually buy scissors
        private bool EnableScissors()
        {
            if (App.Score >= 50)
            {
                return true;
            }

            return false;
        }

        //command to subtract from the number of scissors
        public Command subtractScissorsX1;

        public ICommand SubtractScissorsX1
        {
            get
            {
                if(subtractScissorsX1 == null)
                {
                    subtractScissorsX1 = new Command(PerformsubtractScissorsX1, EnableSubtractScissorsX1);
                }

                return subtractScissorsX1;
            }
        }

        //method to subtract from the scissors by 1 and update the score
        private void PerformsubtractScissorsX1()
        {
            numScissors--;
            App.Scissors = numScissors;
            App.Score += 50;
            subtractScissorsX1.ChangeCanExecute();
            storeVM.UpdateScore();
        }

        //method check if you can subtract by 1 
        private bool EnableSubtractScissorsX1()
        {
            if(App.Scissors >= 1)
            {
                return true;
            }

            return false;
        }

        //command to subtract from scissors by 10 
        public Command subtractScissorsX10;

        public ICommand SubtractScissorsX10
        {
            get
            {
                if (subtractScissorsX10 == null)
                {
                    subtractScissorsX10 = new Command(PerformsubtractScissorsX10, EnableSubtractScissorsX10);
                }

                return subtractScissorsX10;
            }
        }

        //method to subtract by 10 and update the score
        private void PerformsubtractScissorsX10()
        {
            numScissors-=10;
            App.Scissors = numScissors;
            App.Score += 10 * 50;
            subtractScissorsX10.ChangeCanExecute();
            storeVM.UpdateScore();
        }

        //method to check if you can subtract by 10 
        private bool EnableSubtractScissorsX10()
        {
            if (App.Scissors >= 10)
            {
                return true;
            }

            return false;
        }

        //command to subtract scissors by 100 
        public Command subtractScissorsX100;

        public ICommand SubtractScissorsX100
        {
            get
            {
                if (subtractScissorsX100 == null)
                {
                    subtractScissorsX100 = new Command(PerformsubtractScissorsX100, EnableSubtractScissorsX100);
                }

                return subtractScissorsX100;
            }
        }

        //method to subtract scissors by 100 and update the score
        private void PerformsubtractScissorsX100()
        {
            numScissors -= 100;
            App.Scissors = numScissors;
            App.Score += 100 * 50;
            subtractScissorsX10.ChangeCanExecute();
            storeVM.UpdateScore();
        }

        //method to check if you can subtract scissor by 100
        private bool EnableSubtractScissorsX100()
        {
            if (App.Scissors >= 100)
            {
                return true;
            }

            return false;
        }

        #endregion

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
