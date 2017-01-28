using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RpgStory
{
    class Story
    {
        private Player Player;
        string[] story = new string[0];
        private Weapon[] weapons;

        public Story()
        {
            WeaponStore weaponStore = new WeaponStore();
            weapons = weaponStore.createWeaponStore();
            Player = new Player();
            loadStory();
            beginStory();

        }

        private void loadStory()
        {
            using (StreamReader file = new StreamReader("C:/Dev/Story.Txt"))
            {
                int count = 0;
                while(!file.EndOfStream)
                {
                    Array.Resize(ref story, count+1);
                    story[count] = file.ReadLine();
                    if(story[count] == "")
                    {
                        count--;
                    }
                    count++;
                }
            }

            
        }
        private string removeCommands(string s)
        {
            s = s.Replace("/F ", "");
            s = s.Replace("/N ", "");
            s = s.Replace(" N/", "");
            s = s.Replace("/D", "");
            s = s.Replace("D/", "");
            if (s.StartsWith("/W"))
            {
                s = "";
            }
            if (s.StartsWith("/D"))
            {
                s = "";
            }
            return s;
        }

        private string getVariable(string s,string command)
        {
            int first = s.IndexOf(string.Concat("/",command)) + 3;
            int last = s.IndexOf(string.Concat(command,"/")) - 1;
            return s.Substring(first, last - first);
        }

        private void beginStory()
        {
            for (int i = 0; i < story.GetUpperBound(0)+1; i++)
            {

                string s = story[i];
                string line = removeCommands(s);
                if (line != "")
                {
                    Console.WriteLine(line);
                }
                if (s.StartsWith("/F"))
                {
                    Console.WriteLine("Press enter to continue");
                    Console.ReadLine();
                    Interactions.fightSequence(Player, new Enemy(Player.Level,getVariable(s,"N")));
                }
                if (s.StartsWith("/W"))
                {
                    Weapon wep = weapons[Convert.ToInt32(getVariable(s,"N"))];
                    Player.giveWeapon(wep);
                    Console.WriteLine("The Sword has a ATK bonus of {0}",wep.ATK);
                    Console.WriteLine("Your modified ATK is {0}",Player.ATK);
                }
                if (s.StartsWith("/D"))
                {
                    string output = getVariable(s, "D");
                    Console.WriteLine(output);
                    string input = Console.ReadLine().ToLowerInvariant();
                    string[] parts = input.ToLowerInvariant().Split(' ');
                    if(input == parts[0])
                    {
                        Console.WriteLine("You did {0}", parts[0]);
                    }
                    else if (input == parts[parts.Length - 1])
                    {
                        Console.WriteLine("You did {0}", parts[parts.Length - 1]);
                    }
                }
            }
        }

    }
}
