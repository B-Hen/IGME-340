using System;
using System.Collections.Generic;
using System.Text;

namespace Paging.Models
{
    //enum
    public enum PlatformType
    {
        Arcade,
        Board,
        PC,
        Console,
        Handheld,
        Mobile
    }

    public class GameData
    {
        //properties
        public string Name { get; set; }
        public int YearOfRelase { get; set; }
        public float Rating { get; set; }
        public PlatformType Platform { get; set; }
        public string Studio { get; set; }

        //methods
        public override string ToString()
        {
            return Name;
        }
    }
}
