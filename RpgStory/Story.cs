using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgStory
{
    class Story
    {
        private Player Player;
        string[] story = new string[0];

        public Story()
        {
            Player = new Player();
            generateStory();
            beginStory();

        }

        private void generateStory()
        {
            Array.Resize(ref story, 1);
            story[0] = "/F You encounter /N Nauticus N/";
        }

        private void beginStory()
        {
            foreach(string s in story)
            {
                string worded = s.Replace("/F ", "");
                worded = worded.Replace("/N ", "");
                worded = worded.Replace(" N/", "");
                Console.WriteLine(worded);
                if(s.StartsWith("/F"))
                {
                    int first = s.IndexOf("/N")+3;
                    int last = s.IndexOf("N/")-1;
                    Interactions.fightSequence(Player, new Enemy(Player.Level, s.Substring(first, last - first)));
                }

            }
        }
    }
}
