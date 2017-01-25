using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgStory
{
    class Player
    {
        private int atk;
        public int ATK { get { return atk; } private set { } }
        private int def;
        public int DEF { get { return def; } private set { } }
        private int spd;
        public int SPD { get { return spd; } private set { } }
        private int agi;
        public int AGI { get { return agi; } private set { } }
        private int hp;
        public int HP { get { return hp; } private set { } }
        private int level;
        public int Level { get { return level; } private set { } }
        private string name;
        public string Name { get { return name; } private set { } }
        private Weapon wep;
        public Weapon Wep { get { return wep; } private set { } }

        public Player(int atki, int defi, int spdi, int agii, string namei)
        {
            atk = atki;
            def = defi;
            spd = spdi;
            agi = agii;
            hp = calcHP();
            name = namei;
            level = calcLevel();
        }

        private int calcHP()
        {
            return def * 5 + 1;
        }

        private int calcLevel()
        {
            int lev = (atk + def + spd + agi) / 6;
            return lev;
        }

        public void takeDamage(int damage)
        {
            if (damage > def)
            {
                hp -= damage - def;
            }
            else
            {
                hp -= 1;
            }
        }

        public void giveWeapon(Weapon weapon)
        {
            if (wep != null)
            {
                removeWeapon(wep);
            }
            wep = weapon;
            addWeapon(wep);
        }

        public void giveDamage(Enemy enemy)
        {
            enemy.takeDamage(atk);
        }

        public void addWeapon(Weapon weapon)
        {
            atk += weapon.ATK;
            def += weapon.DEF;
            spd += weapon.SPD;
            agi += weapon.AGI;
        }

        public void removeWeapon(Weapon weapon)
        {
            atk -= weapon.ATK;
            def += weapon.DEF;
            spd += weapon.SPD;
            agi += weapon.AGI;
            wep = null;
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
                int input = Convert.ToInt16(Console.ReadLine());
                if (input <= skillPoints)
                {
                    skillPoints -= input;
                    switch (i)
                    {
                        case 0:
                            atk += input;
                            break;

                        case 1:
                            def += input;
                            break;

                        case 2:
                            spd += input;
                            break;

                        case 3:
                            agi += input;
                            break;

                    }
                }
                else
                {
                    i--;
                }
                Console.Clear();
            }
            level = calcLevel();
            calcHP();
        }

    }
}
