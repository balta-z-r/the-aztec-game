using System;
using System.Collections.Generic;

namespace the_aztec_game
{
    class Armor : Item
    {
        public Dictionary<string, double> perks { get; set; }

        public Armor(string name, int cost, Dictionary<string, double> armorPerks, string image) : base(name, cost, image)
        {
            perks = armorPerks;
        }

        override public double getRandDmg()
        {
            return 0;
        }

        override public string getStringStats()
        {
            return string.Format(@"Armor buffs:
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