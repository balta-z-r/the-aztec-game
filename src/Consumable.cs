using System;
using System.Collections.Generic;

namespace the_aztec_game
{
    class Consumable : Item
    {
        public Dictionary<string, double> perks { get; set; }

        public Consumable(string name, int cost, Dictionary<string, double> consumablePerks, string image) : base(name, cost, image)
        {
            perks = consumablePerks;

        }

        override public double getRandDmg()
        {
            return 0;
        }

        override public string getStringStats()
        {
            return string.Format(@"Consumable buffs:
                  Health: {0}
                  Strength: {1}
                  Speed: {2}
                  Courage: {3}
                  Luck: {4}", perks["hp"], perks["dmgmod"], perks["speed"], perks["courage"], perks["luck"]);
        }

        override public Dictionary<string, double> getPerks()
        {
            return perks;
        }
    }
}