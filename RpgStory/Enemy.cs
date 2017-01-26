using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgStory
{
    class Enemy : Character
    {
        public Enemy(int level,string name)
        {
            Name = name;
            Random rand = new Random();
            Level = level;
            int skillPoints = level * 6;
            ATK = rand.Next(1, skillPoints / 2);//allow the random generator to spend half the points for each.
            skillPoints -= ATK;
            DEF = rand.Next(1, skillPoints / 2);
            skillPoints -= DEF;
            SPD = rand.Next(1, skillPoints / 2);
            skillPoints -= SPD;
            AGI = rand.Next(1, skillPoints);//if there is only 1 skill point remaining why divide 
            skillPoints -= AGI;
            HP = calcHP();
        }
        public Enemy(int atki, int defi, int spdi, int agii, string namei)
        {
            ATK = atki;
            DEF = defi;
            SPD = spdi;
            AGI = agii;
            HP = calcHP();
            Name = namei;
        }//end Enemy Constructor
       
        public void giveDamage(Player player)
        {
            player.takeDamage(ATK);
        }//end giveDamage
    }//end class
}//end namespace
