using CraneClikcer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace CraneClikcer.ViewModels
{
    class StorePageViewModel 
    {
        //properties
        public ObservableCollection<StoreItems> items { get; set; }

        public StorePageViewModel()
        {
            items = new ObservableCollection<StoreItems>
            {
                new StoreItems{ numScissors = 0, numPaper = 0, numSibings = 0, numFriends = 0, numCoWorkers = 0 },
            };
        }
    }
}
