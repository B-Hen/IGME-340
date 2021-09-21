using System;
using System.Collections.Generic;
using System.Text;

namespace DatabindingListView.Models
{
    class GameLevel
    {
        //properties
        public string Name { get; set; }
        public int LevelNumber { get; set; }
        public int MinPlayerLevel { get; set; }
        public int MaxPlayerLevel { get; set; }
        public int SuggestLevel { get; set; }
        public int NumberOfTries { get; set; }

        public override string ToString()
        {
            return "Name : " + Name + " Level: " + LevelNumber + " Player: " + MinPlayerLevel + "-" + MaxPlayerLevel 
                + " Suggest Level: " + SuggestLevel + " Number of deaths: " + NumberOfTries;
        }
    }
}
