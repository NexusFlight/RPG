using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgStory
{
    class Player
    {
        public int ATK { get; private set; }
        public int DEF { get; private set; }
        public int SPD { get; private set; }
        public int AGI { get; private set; }
        public int HP { get; private set; }
        public int Level { get; private set; }
        public string Name { get; private set; }
        public Weapon Wep { get; private set; }

        public Player(int atki, int defi, int spdi, int agii, string namei)
        {
            ATK = atki;
            DEF = defi;
            SPD = spdi;
            AGI = agii;
            HP = calcHP();
            Name = namei;
            Level = calcLevel();
        }

        private int calcHP()
        {
            return DEF * 5 + 1;
        }

        private int calcLevel()
        {
            int lev = (ATK + DEF + SPD + AGI) / 6;
            return lev;
        }

        public void takeDamage(int damage)
        {
            if (damage > DEF)
            {
                HP -= damage - DEF;
            }
            else
            {
                HP -= 1;
            }
        }

        public void giveWeapon(Weapon weapon)
        {
            if (Wep != null)
            {
                removeWeapon(Wep);
            }
            Wep = weapon;
            addWeapon(Wep);
        }

        public void giveDamage(Enemy enemy)
        {
            enemy.takeDamage(ATK);
        }

        public void addWeapon(Weapon weapon)
        {
            ATK += weapon.ATK;
            DEF += weapon.DEF;
            SPD += weapon.SPD;
            AGI += weapon.AGI;
        }

        public void removeWeapon(Weapon weapon)
        {
            ATK -= weapon.ATK;
            DEF += weapon.DEF;
            SPD += weapon.SPD;
            AGI += weapon.AGI;
            Wep = null;
        }

        public void levelUp(int skillPoints)
        {
            string[] statNames = { "Attack", "Defence", "Speed", "Agility" };
            Console.Clear();
            for (int i = 0; i < 4; i++)
            {
                if (skillPoints == 0)
                {
                    break;
                }
                Console.WriteLine("You have {0} skill points to spend, Spend them wisely", skillPoints);
                Console.WriteLine("How many skill points would you like in {0}", statNames[i]);
                int input = Convert.ToInt32(Console.ReadLine());
                if (input <= skillPoints)
                {
                    skillPoints -= input;
                    switch (i)
                    {
                        case 0:
                            ATK += input;
                            break;

                        case 1:
                            DEF += input;
                            break;

                        case 2:
                            SPD += input;
                            break;

                        case 3:
                            AGI += input;
                            break;

                    }
                }
                else
                {
                    i--;
                }
                Console.Clear();
            }
            Level = calcLevel();
            calcHP();
        }

    }
}
