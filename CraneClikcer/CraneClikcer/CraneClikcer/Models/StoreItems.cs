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

        public string ScissorsText { get { return App.ScissorText; } }

        public Command addSubScissors { get; set; }
        public ICommand AddSubScissors
        {
            get
            {
                if(addSubScissors == null)
                {
                    addSubScissors = new Command(PerformAddSubScissors, EnableAddSubScissors);
                }

                return addSubScissors;
            }
        }

        public void PerformAddSubScissors()
        {
            //first check to see if you have to add or subtracnt
            if(storeVM.BuySell == true) // buy
            {
                numScissors += storeVM.BuySellAmount;
                App.Scissors += storeVM.BuySellAmount;
                App.Score -= App.ScissorCost * storeVM.BuySellAmount;
                App.ScissorCost = (int)Math.Pow(App.ScissorCost, 1.15);
                App.ScissorSell = (int)Math.Pow(App.ScissorCost, 1.0 / 1.15);
                if (App.ScissorSell == 0 & App.ScissorCost > 15) App.ScissorSell = 5;
                storeVM.UpdateScore();
                addSubScissors.ChangeCanExecute();
                UpdateScissorsText();
            }
            else if (storeVM.BuySell == false) //sell
            {
                numScissors -= storeVM.BuySellAmount;
                App.Scissors -= storeVM.BuySellAmount;
                App.Score += App.ScissorSell * storeVM.BuySellAmount;
                App.ScissorSell--;
                if (App.ScissorSell <= 0) App.ScissorSell = 0;
                if (numScissors <= 0) App.ScissorSell = 0;
                storeVM.UpdateScore();
                addSubScissors.ChangeCanExecute();
                UpdateScissorsText();

            }
        }

        public bool EnableAddSubScissors()
        {
            if (storeVM.BuySell == true) //buy
            {
                if(App.Score >= App.ScissorCost * storeVM.BuySellAmount)
                {
                    return true;
                }

                return false;
            }
            else if (storeVM.BuySell == false) //sell
            {
                if(App.Scissors >= storeVM.BuySellAmount)
                {
                    return true;
                }

                return false;
            }

            return false;
        }

        public void UpdateScissorsText()
        {
            if(storeVM.BuySell == true) // buy
            {
                App.ScissorText =  "Buy For " + App.ScissorCost * storeVM.BuySellAmount + " Cranes";
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ScissorsText"));
            }
            else if (storeVM.BuySell == false) //sell
            {
                App.ScissorText = "Sell For " + App.ScissorSell * storeVM.BuySellAmount + " Cranes";
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ScissorsText"));
            }
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
