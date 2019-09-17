using System;
using System.Collections.Generic;

namespace the_aztec_game
{
    class Consumable : Item
    {
        public Dictionary<string, double> perks { get; set; }

        public Consumable(string name, string description) : base(name, description)
        {

        }

        override public double getRandDmg()
        {
            return 0;
        }
    }
}