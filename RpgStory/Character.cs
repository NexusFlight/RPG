using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgStory
{
    class Character
    {
        public int ATK { get; protected set; }//creates a public readable Int ATK but only allows this class to set the values.
        public int DEF { get; protected set; }
        public int SPD { get; protected set; }
        public int AGI { get; protected set; }
        public int HP { get; protected set; }
        public int Level { get; protected set; }
        public string Name { get; protected set; }

        protected int calcHP()
        {
            return DEF * 5 + 1;//ensures the player has atleast 1hp
        }//end calcHP

        protected int calcLevel()
        {
            int lev = (ATK + DEF + SPD + AGI) / 6;//as 6 is the standard skill point set then a level is however many skillpoints / 6
            return lev;
        }//end calcLevel

        public void takeDamage(int damage)
        {
            if (damage > DEF)//if the damage is greater than defence then take defence away from damage else only take 1 hp
            {
                HP -= damage - DEF;
            }//end if
            else
            {
                HP -= 1;
            }//end else if
        }//end takeDamage

    }
}
