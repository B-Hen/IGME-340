using CraneClikcer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
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

        public bool BuySell
        {
            get { return App.BuySell; }
        }
        public int BuySellAmount
        {
            get { return App.BuySellAmount; }
        }

        public string  BuySellx1 { get { return App.BuySellx1; } }
        public string  BuySellx10 { get { return App.BuySellx10; } }
        public string  BuySellx100 { get { return App.BuySellx100; } }

        public StorePageViewModel()
        {
            //create the items
            items = new ObservableCollection<StoreItems>
            {
                new StoreItems{ numScissors = App.Scissors, Paper = App.Paper, Siblings = App.Sibling, Friends = App.Friends, CoWorkers = App.CoWorkers, storeVM = this},
            };
        }

        //update the score whenever there is a change
        internal void UpdateScore()
        {
            //also check to see if the add scissor button can be enabled/disabled
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Score"));
        }

        private Command buy;

        public ICommand Buy
        {
            get
            {
                if(buy == null)
                {
                    buy = new Command(UpdateBuy);
                }

                return buy;
            }
        }

        public void UpdateBuy()
        {
            App.BuySell = true;
            items[0].addSubScissors.ChangeCanExecute();
            items[0].addSubPaper.ChangeCanExecute();
            items[0].addSubSibling.ChangeCanExecute();
            items[0].addSubFriends.ChangeCanExecute();
            items[0].addSubCoWorkers.ChangeCanExecute();
            UpdateBuySellButtonText();
        }

        private Command sell;
        public ICommand Sell
        {
            get
            {
                if(sell == null)
                {
                    sell = new Command(UpdateSell);
                }

                return sell;
            }
        }

        public void UpdateSell()
        {
            App.BuySell = false;
            items[0].addSubScissors.ChangeCanExecute();
            items[0].addSubPaper.ChangeCanExecute();
            items[0].addSubSibling.ChangeCanExecute();
            items[0].addSubFriends.ChangeCanExecute();
            items[0].addSubCoWorkers.ChangeCanExecute();
            UpdateBuySellButtonText();
        }

        public Command x1;
        public Command x10;
        public Command x100;

        public ICommand X1
        {
            get
            {
                if(x1 == null)
                {
                    x1 = new Command(() =>
                    {
                        App.BuySellAmount = 1;
                        items[0].UpdateText();
                        items[0].addSubScissors.ChangeCanExecute();
                        items[0].addSubPaper.ChangeCanExecute();
                        items[0].addSubSibling.ChangeCanExecute();
                        items[0].addSubFriends.ChangeCanExecute();
                        items[0].addSubCoWorkers.ChangeCanExecute();
                    });
                }

                return x1;
            }
        }

        public ICommand X10
        {
            get
            {
                if(x10 == null)
                {
                    x10 = new Command(() =>
                    {
                        App.BuySellAmount = 10;
                        items[0].UpdateText();
                        items[0].addSubScissors.ChangeCanExecute();
                        items[0].addSubPaper.ChangeCanExecute();
                        items[0].addSubSibling.ChangeCanExecute();
                        items[0].addSubFriends.ChangeCanExecute();
                        items[0].addSubCoWorkers.ChangeCanExecute();
                    });
                }

                return x10;
            }
        }

        public ICommand X100
        {
            get
            {
                if(x100 == null)
                {
                    x100 = new Command(() =>
                    {
                        App.BuySellAmount = 100;
                        items[0].UpdateText();
                        items[0].addSubScissors.ChangeCanExecute();
                        items[0].addSubPaper.ChangeCanExecute();
                        items[0].addSubSibling.ChangeCanExecute();
                        items[0].addSubFriends.ChangeCanExecute();
                        items[0].addSubCoWorkers.ChangeCanExecute();
                    });
                }

                return x100;
            }
        }

        public void UpdateBuySellButtonText()
        {
            if(BuySell == true)
            {
                App.BuySellx1 = "BUY x1";
                App.BuySellx10 = "BUY x10";
                App.BuySellx100 = "BUY x100";
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BuySellx1"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BuySellx10"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BuySellx100"));
                items[0].UpdateText();
            }
            else if(BuySell == false)
            {
                App.BuySellx1 = "SELL x1";
                App.BuySellx10 = "SELL x10";
                App.BuySellx100 = "SELL x100";
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BuySellx1"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BuySellx10"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BuySellx100"));
                items[0].UpdateText();
            }
        }

        //method to uopdate the items
        public void UpdateBuySellItems()
        {
            items[0].addSubScissors.ChangeCanExecute();
            items[0].addSubPaper.ChangeCanExecute();
            items[0].addSubSibling.ChangeCanExecute();
            items[0].addSubFriends.ChangeCanExecute();
            items[0].addSubCoWorkers.ChangeCanExecute();
        }
    }
}
