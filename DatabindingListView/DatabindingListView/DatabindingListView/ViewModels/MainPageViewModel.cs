using DatabindingListView.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace DatabindingListView.ViewModels
{
    class MainPageViewModel
    {
        //preoperties
        public ObservableCollection<GameLevel> Levels { get; set; }
        public Command AddCommand { get; set; }
        public Command RemoveCommand { get; set; }

        //constructor
        public MainPageViewModel()
        {
            Levels = new ObservableCollection<GameLevel>
            {
                new GameLevel { Name = "Baby Mode", LevelNumber = 1, MinPlayerLevel = 1, MaxPlayerLevel = 10, SuggestLevel = 1, NumberOfTries = 3},
                new GameLevel { Name = "Gamer Mode", LevelNumber = 63, MinPlayerLevel = 50, MaxPlayerLevel = 150, SuggestLevel = 60, NumberOfTries = 15},
                new GameLevel { Name = "Epic Gamer Mode", LevelNumber = 150, MinPlayerLevel = 200, MaxPlayerLevel = 500, SuggestLevel = 350, NumberOfTries = 420}
            };

            AddCommand = new Command(Add);
            RemoveCommand = new Command(Remove);
        }

        public void Add()
        {
            Levels.Add(new GameLevel { LevelNumber = Levels.Count, Name = "Added Level " + Levels.Count, SuggestLevel = Levels.Count, NumberOfTries = Levels.Count});
        }

        public void Remove()
        {
            if (Levels.Count > 0)
            {
                Levels.RemoveAt(Levels.Count - 1);
            }
        }
    }
}
