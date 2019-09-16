using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace the_aztec_game
{
  class Game
  {
    private Room[] templeMap = new Room[17];
    private Player player;

    public Game()
    {
      typewriterStyleOutput("What is your player's name?: ");
      string name = Console.ReadLine();

      typewriterStyleOutput("What is your player's occupation?: ");
      string occupation = Console.ReadLine();

      player = new Player(name, occupation);

      int characterPoints = 200;

      typewriterStyleOutput(string.Format(@"
Character Points: 200
{0}
There are four categories to place your character points: Health, Damage, Speed, Courage, and Luck.
", player.getStats()));

      typewriterStyleOutput(@"
Every character point added to health adds 1 health point. 
How many character points would you like to spend on health?: ");
      int cphp = Int32.Parse(Console.ReadLine());
      characterPoints -= cphp;
      player.stats["hp"] += cphp;

      typewriterStyleOutput(@"
Every character point added to strength adds 0.05 to the damage modifier. 
How many character points would you like to spend on strength?: ");
      int cpdm = Int32.Parse(Console.ReadLine());
      characterPoints -= cpdm;
      player.stats["dmgmod"] += cpdm * 0.05;

      typewriterStyleOutput(@"
Every character point added to speed increases the chance of attacking first by 1%. 
How many character points would you like to spend on speed?: ");
      int cps = Int32.Parse(Console.ReadLine());
      characterPoints -= cps;
      player.stats["speed"] += cps;

      typewriterStyleOutput(@"
Every character point added to courage increase the chance of dealing crits by 1%. 
How many character points would you like to spend on courage?: ");
      int cpc = Int32.Parse(Console.ReadLine());
      characterPoints -= cpc;
      player.stats["courage"] += cpc;

      typewriterStyleOutput(@"
Every character point added to luck increases the chance of meeting a weaker enemy by 0.5%.
How many character points would you like to spend on luck?: ");
      int cpl = Int32.Parse(Console.ReadLine());
      characterPoints -= cpl;
      player.stats["luck"] += cpl * 0.5;
      player.stats["hp"] += characterPoints;

      typewriterStyleOutput(string.Format("\n{0}\n", player.getStats()));
      typewriterStyleOutput(string.Format(@"
It is the year 1952, you have convinced a private American company that goes by the name
“Dart” to fund you for a trip to Mexico to investigate a mysterious aztec ruin that you saw in a
dream. Despite being initially hesitant about going on this quest, you have been “convinced”
by the Chicago mafia who want your payment. You hope that the money is enough to pay for
your studies while being a {0} and your debt to the Chicago Outfit, a well
known gang made by Al Capone.
", player.occupation));
      typewriterStyleOutput(@"
Your great idea started one early morning in Chicago:

It was just like any other morning as you walked down fifth street in your work clothes. Traffic
blaring, and sky littered with puffs of clouds. Crowds of people in their suits and overcoats
stroll past you as you make your way to work.
");
      System.Threading.Thread.Sleep(100);

      typewriterStyleOutput(@"
Suddenly, the noises stop. The fedoras and the suits disappear. The streets and roads are 
completely empty. You wonder what just happened, but before you know it, everything becomes 
dark. You begin to hear the sound of bugs and realize you’re deep in a jungle. You realize you 
are somewhere near El Mammeyal with a small village near it. The jungle pulls you in.
Torches light up and you see moss covered walls with vines slithered in between the cracks. 
You look ahead and there appears to be a gigantic temple-like structure, parts of it plated in 
gold.");

      typewriterStyleOutput("\n\nPress <Enter> to investigate");
      Console.Read();

      typewriterStyleOutput(@"
You have entered the center of the temple. All of a sudden, your surroundings light up and 
everything is set ablaze. You have no way out and fear ripples throughout you.
");
      System.Threading.Thread.Sleep(1000);

      Console.WriteLine("\nBOOM BOOM");
      System.Threading.Thread.Sleep(1000);

      typewriterStyleOutput("\nYou begin to hear beats of drums.\n");
      System.Threading.Thread.Sleep(1000);

      Console.WriteLine("\nBOOM BOOM");
      System.Threading.Thread.Sleep(1000);

      typewriterStyleOutput(@"
They appear to be getting louder. You feel a dribble of cold sweat slide down behind your neck.
Suddenly it all becomes quiet. Then you hear a voice speaking a mysterious language calling 
to you and an insane laughter. The voices get louder and louder until…
");
      Console.WriteLine("\nRING!!!");
      System.Threading.Thread.Sleep(1000);

      typewriterStyleOutput(string.Format(@"
You open your eyes and sit up on your bed. With your whole body drenched with sweat, you 
realize you are in your bedroom–and it was all a dream. Or was it?
You look besides you, and pick up the phone with dread. It was Tony Accardo, the Big boss of {0}

Tony: do you have the money yet?
You: I-I’m getting it soon.
Tony: I’m getting really impatient. Tell us what you need to earn this money, or it’s a bye bye.

In this frenzy, you realize that temple of gold would be your way out of debt.", player.name));
      System.Threading.Thread.Sleep(5000);

      typewriterStyleOutput(@"

You arrive in mexico, to meet with the locals there around the location of the ruins. You have 
1000 pesos. There you can buy supplies that could be important to the journey. You walk into 
a house of one of the locals, a man named Juan Perez greets you.
");
      typewriterStyleOutput(string.Format(@"
You: My name is {0}, a {1} from America.
Juan Perez: Hello, {0}, that is a nice job, my niece works as a {1} 
  too. So, what brings you here?
You (Thinking about your debt to the Chicago Outfit): I… I am here to find the ruins of the 
  nearby Aztec temple.
Juan Perez: How do you know of this temple? Only few people outside of this town knows of it.
You: I had a dream that I will find it here.
Juan Perez: It is interesting that you know of this ruin, but if you were to explore it, beware of 
  the tecuanitin of the jungle.
You: If you already know of the ruin, why haven’t you explored it yet?
Juan Perez: Because of local legends surrounding the place.
You: Alright.
Juan Perez: Wait… Eat this herb, it will help you against the mosquitos

You took the herb from Juan Perez and ate it, it was slightly bitter, but it was okay. You felt 
slightly dizzy, but it was short lasting.

You: How do I get there?
Juan Perez: Remember this sequence: you go North, North, East, East, South, than West.
You, thinking to yourself: Ok. I hope I remember. Although my job as a {1} did 
  not prepare me for this.", player.name, player.occupation));
      typewriterStyleOutput(@"

You walked away before seeing a small store that sold equipments for jungle exploration, from
a place called Las cosas de Daniel.

What do you do?

1: Get equipments from Daniel’s

or

2: Ehhh… I don’t need Daniel’s slimy tools.");
    }

    private void initTempleMap()
    {
      String[] dirs = { "n", "e", "s", "w" };
      using (StreamReader r = new StreamReader("map.json"))
      {
        string json = r.ReadToEnd();
        Dictionary<string, dynamic> d = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(json);
        foreach (var key in d.Keys)
        {
          templeMap[Int32.Parse(key)] = new Room();
        }
        foreach (var key in d.Keys)
        {
          foreach (String dir in dirs)
          {
            if (d[key].ContainsKey(dir))
            {
              typeof(Room).GetProperty(dir).SetValue(templeMap[Int32.Parse(key)], templeMap[Int32.Parse(d[key][dir])]);
            }
          }
        }
      }
    }

    private void typewriterStyleOutput(string message)
    {
      for (int i = 0; i < message.Length; i++)
      {
        Console.Write(message[i]);
        System.Threading.Thread.Sleep(3);
        // System.Threading.Thread.Sleep(50);
      }
    }
  }
}