using Paging.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paging.ViewModels
{
    class MainPageViewModel
    {
        //properties
        public List<GameData> Games { get; set; }

        //constructor
        public MainPageViewModel()
        {
            Games = new List<GameData>
            {
                new GameData {Name="Rainbow Six Siege", YearOfRelase=2015, Rating=4.4f,
                Platform=PlatformType.PC, Studio="Ubisoft"},
                new GameData {Name="TitanFall 2", YearOfRelase=2016, Rating=4.8f,
                Platform=PlatformType.PC, Studio="Respawn"},
                new GameData {Name="Bloodborne", YearOfRelase=2015, Rating=4.7f,
                Platform=PlatformType.Console, Studio="FromSoftware"},
                new GameData {Name="Sekiro: Shadows Die Twice", YearOfRelase=2019, Rating=4.4f,
                Platform=PlatformType.Console, Studio="FromSoftware"},
                new GameData {Name="Persona 5", YearOfRelase=2016, Rating=4.7f,
                Platform=PlatformType.Console, Studio="Atlus"}
            };
        }
    }
}
