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
                App.PrevScissorCost = App.ScissorCost;
                App.ScissorCost = (int)Math.Pow(App.ScissorCost, 1.15);
                App.ScissorSell = (int)Math.Pow(App.ScissorCost/5, 1.0 / 1.15);
                storeVM.UpdateScore();
                addSubScissors.ChangeCanExecute();
                UpdateText();
            }
            else if (storeVM.BuySell == false) //sell
            {
                numScissors -= storeVM.BuySellAmount;
                App.Scissors -= storeVM.BuySellAmount;
                App.Score += App.ScissorSell * storeVM.BuySellAmount;
                App.PrevScissorCost = (int)(Math.Pow(App.ScissorCost, 1.0 / 1.15) + 1);
                App.ScissorCost = App.PrevScissorCost;
                App.ScissorSell = (int)Math.Pow(App.ScissorCost / 5, 1.0 / 1.15);
                if (App.ScissorSell <= 0) App.ScissorSell = 0;
                if (numScissors <= 0) App.ScissorSell = 0;
                storeVM.UpdateScore();
                addSubScissors.ChangeCanExecute();
                UpdateText();

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

        #endregion

        #region Paper
        private int paper;
        public int Paper
        {
            get { return paper; }
            set
            {
                paper = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Paper"));
            }
        }

        public string PaperText { get { return App.PaperText; } }

        public Command addSubPaper { get; set; }
        public ICommand AddSubPaper
        {
            get
            {
                if (addSubPaper == null)
                {
                    addSubPaper = new Command(PerformAddSubPaper, EnableAddSubPaper);
                }

                return addSubPaper;
            }
        }

        public void PerformAddSubPaper()
        {
            //first check to see if you have to add or subtracnt
            if (storeVM.BuySell == true) // buy
            {
                Paper += storeVM.BuySellAmount;
                App.Paper += storeVM.BuySellAmount;
                App.Score -= App.PaperCost * storeVM.BuySellAmount;
                App.PrevPaperCost = App.PaperCost;
                App.PaperCost = (int)Math.Pow(App.PaperCost, 1.25);
                App.PaperSell = (int)Math.Pow(App.PaperCost/5, 1.0 / 1.25);
                storeVM.UpdateScore();
                addSubPaper.ChangeCanExecute();
                UpdateText();
            }
            else if (storeVM.BuySell == false) //sell
            {
                Paper -= storeVM.BuySellAmount;
                App.Paper -= storeVM.BuySellAmount;
                App.Score += App.PaperSell * storeVM.BuySellAmount;
                App.PrevPaperCost = (int)(Math.Pow(App.PaperCost, 1.0 / 1.25) + 1);
                App.PaperCost = App.PrevPaperCost;
                App.PaperSell = (int)Math.Pow(App.PaperCost / 5, 1.0 / 1.25);
                if (App.PaperSell <= 0) App.PaperSell = 0;
                if (Paper <= 0) App.PaperSell = 0;
                storeVM.UpdateScore();
                addSubPaper.ChangeCanExecute();
                UpdateText();

            }
        }

        public bool EnableAddSubPaper()
        {
            if (storeVM.BuySell == true) //buy
            {
                if (App.Score >= App.PaperCost * storeVM.BuySellAmount)
                {
                    return true;
                }

                return false;
            }
            else if (storeVM.BuySell == false) //sell
            {
                if (App.Paper >= storeVM.BuySellAmount)
                {
                    return true;
                }

                return false;
            }

            return false;
        }

        #endregion

        #region Siblings
        private int siblings;
        public int Siblings
        {
            get { return siblings; }
            set
            {
                siblings = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Siblings"));
            }
        }

        public string SiblingText { get { return App.SiblingText; } }

        public Command addSubSibling { get; set; }
        public ICommand AddSubSibling
        {
            get
            {
                if (addSubSibling == null)
                {
                    addSubSibling = new Command(PerformAddSubSibling, EnableAddSubSibling);
                }

                return addSubSibling;
            }
        }

        public void PerformAddSubSibling()
        {
            //first check to see if you have to add or subtracnt
            if (storeVM.BuySell == true) // buy
            {
                Siblings += storeVM.BuySellAmount;
                App.Sibling += storeVM.BuySellAmount;
                App.Score -= App.SiblingCost * storeVM.BuySellAmount;
                App.PrevSiblingCost = App.SiblingCost;
                App.SiblingCost = (int)Math.Pow(App.SiblingCost, 1.50);
                App.SiblingSell = (int)Math.Pow(App.SiblingCost/5, 1.0 / 1.50);
                storeVM.UpdateScore();
                addSubSibling.ChangeCanExecute();
                UpdateText();
            }
            else if (storeVM.BuySell == false) //sell
            {
                Siblings -= storeVM.BuySellAmount;
                App.Sibling -= storeVM.BuySellAmount;
                App.Score += App.SiblingSell * storeVM.BuySellAmount;
                App.PrevSiblingCost = (int)(Math.Pow(App.SiblingCost, 1.0 / 1.50) + 1);
                App.SiblingCost = App.PrevSiblingCost;
                App.SiblingSell = (int)Math.Pow(App.SiblingCost / 5, 1.0 / 1.50);
                if (App.SiblingSell <= 0) App.SiblingSell = 0;
                if (Siblings <= 0) App.SiblingSell = 0;
                storeVM.UpdateScore();
                addSubSibling.ChangeCanExecute();
                UpdateText();

            }
        }

        public bool EnableAddSubSibling()
        {
            if (storeVM.BuySell == true) //buy
            {
                if (App.Score >= App.SiblingCost * storeVM.BuySellAmount)
                {
                    return true;
                }

                return false;
            }
            else if (storeVM.BuySell == false) //sell
            {
                if (App.Sibling >= storeVM.BuySellAmount)
                {
                    return true;
                }

                return false;
            }

            return false;
        }
        #endregion

        #region Friends
        private int friends;
        public int Friends
        {
            get { return friends; }
            set
            {
                friends = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Friends"));
            }
        }

        public string FriendsText { get { return App.FriendsText; } }

        public Command addSubFriends { get; set; }
        public ICommand AddSubFriends
        {
            get
            {
                if (addSubFriends == null)
                {
                    addSubFriends = new Command(PerformAddSubFriends, EnableAddSubFriends);
                }

                return addSubFriends;
            }
        }

        public void PerformAddSubFriends()
        {
            //first check to see if you have to add or subtracnt
            if (storeVM.BuySell == true) // buy
            {
                Friends += storeVM.BuySellAmount;
                App.Friends += storeVM.BuySellAmount;
                App.Score -= App.FriendsCost * storeVM.BuySellAmount;
                App.PrevFriendCost = App.FriendsCost;
                App.FriendsCost = (int)Math.Pow(App.FriendsCost, 1.75);
                App.FriendsSell = (int)Math.Pow(App.FriendsCost/5, 1.0 / 1.75);
                storeVM.UpdateScore();
                addSubFriends.ChangeCanExecute();
                UpdateText();
            }
            else if (storeVM.BuySell == false) //sell
            {
                Friends -= storeVM.BuySellAmount;
                App.Friends -= storeVM.BuySellAmount;
                App.Score += App.FriendsSell * storeVM.BuySellAmount;
                App.PrevFriendCost = (int)(Math.Pow(App.FriendsCost, 1.0 / 1.75) + 1);
                App.FriendsCost = App.PrevFriendCost;
                App.FriendsSell = (int)Math.Pow(App.FriendsCost/5, 1.0 / 1.75);
                if (App.FriendsSell <= 0) App.FriendsSell = 0;
                if (Friends <= 0) App.FriendsSell = 0;
                storeVM.UpdateScore();
                addSubFriends.ChangeCanExecute();
                UpdateText();

            }
        }

        public bool EnableAddSubFriends()
        {
            if (storeVM.BuySell == true) //buy
            {
                if (App.Score >= App.FriendsCost * storeVM.BuySellAmount)
                {
                    return true;
                }

                return false;
            }
            else if (storeVM.BuySell == false) //sell
            {
                if (App.Friends >= storeVM.BuySellAmount)
                {
                    return true;
                }

                return false;
            }

            return false;
        }

        #endregion

        #region Co-Workers
        private int coWorkers;
        public int CoWorkers
        {
            get { return coWorkers; }
            set
            {
                coWorkers = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CoWorkers"));
            }
        }

        public string CoWorkersText { get { return App.CoWorkersText; } }

        public Command addSubCoWorkers { get; set; }
        public ICommand AddSubCoWorkers
        {
            get
            {
                if (addSubCoWorkers == null)
                {
                    addSubCoWorkers = new Command(PerformAddSubCoWorkers, EnableAddSubCoWorkers);
                }

                return addSubCoWorkers;
            }
        }

        public void PerformAddSubCoWorkers()
        {
            //first check to see if you have to add or subtracnt
            if (storeVM.BuySell == true) // buy
            {
                CoWorkers += storeVM.BuySellAmount;
                App.CoWorkers += storeVM.BuySellAmount;
                App.Score -= App.CoWorkersCost * storeVM.BuySellAmount;
                App.PrevCoWorkersCost = App.CoWorkersCost;
                App.CoWorkersCost = (int)Math.Pow(App.CoWorkersCost, 2.00);
                App.CoWorkersSell = (int)Math.Pow(App.CoWorkersCost/5, 1.0 / 2.00);
                storeVM.UpdateScore();
                addSubCoWorkers.ChangeCanExecute();
                UpdateText();
            }
            else if (storeVM.BuySell == false) //sell
            {
                CoWorkers -= storeVM.BuySellAmount;
                App.CoWorkers -= storeVM.BuySellAmount;
                App.Score += App.CoWorkersSell * storeVM.BuySellAmount;
                App.PrevCoWorkersCost = (int)Math.Pow(App.CoWorkersCost, 1.0 / 2.00);
                App.CoWorkersCost = App.PrevCoWorkersCost;
                App.CoWorkersSell = (int)Math.Pow(App.CoWorkersCost / 5, 1.0 / 2.00);
                if (App.CoWorkersSell <= 0) App.CoWorkersSell = 0;
                if (CoWorkers <= 0) App.CoWorkersSell = 0;
                storeVM.UpdateScore();
                addSubCoWorkers.ChangeCanExecute();
                UpdateText();

            }
        }

        public bool EnableAddSubCoWorkers()
        {
            if (storeVM.BuySell == true) //buy
            {
                if (App.Score >= App.CoWorkersCost * storeVM.BuySellAmount)
                {
                    return true;
                }

                return false;
            }
            else if (storeVM.BuySell == false) //sell
            {
                if (App.CoWorkers >= storeVM.BuySellAmount)
                {
                    return true;
                }

                return false;
            }

            return false;
        }

        #endregion

        public void UpdateText()
        {
            if (storeVM.BuySell == true) // buy
            {
                App.ScissorText = "Buy For " + App.ScissorCost * storeVM.BuySellAmount + " Cranes";
                App.PaperText = "Buy For " + App.PaperCost * storeVM.BuySellAmount + " Cranes";
                App.SiblingText = "Buy For " + App.SiblingCost * storeVM.BuySellAmount + " Cranes";
                App.FriendsText = "Buy For " + App.FriendsCost * storeVM.BuySellAmount + " Cranes";
                App.CoWorkersText = "Buy For " + App.CoWorkersCost * storeVM.BuySellAmount + " Cranes";
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ScissorsText"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PaperText"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SiblingText"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FriendsText"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CoWorkersText"));
            }
            else if (storeVM.BuySell == false) //sell
            {
                App.ScissorText = "Sell For " + App.ScissorSell * storeVM.BuySellAmount + " Cranes";
                App.PaperText = "Sell For " + App.PaperSell * storeVM.BuySellAmount + " Cranes";
                App.SiblingText = "Sell For " + App.SiblingSell * storeVM.BuySellAmount + " Cranes";
                App.FriendsText = "Sell For " + App.FriendsSell * storeVM.BuySellAmount + " Cranes";
                App.CoWorkersText = "Sell For " + App.CoWorkersSell * storeVM.BuySellAmount + " Cranes";
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ScissorsText"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PaperText"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SiblingText"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FriendsText"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CoWorkersText"));
            }
        }
    }
}
