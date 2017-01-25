using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgStory
{
    class Enemy
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
        private string name;
        public string Name { get { return name; } private set { } }

        public Enemy(int atki, int defi, int spdi, int agii, string namei)
        {
            atk = atki;
            def = defi;
            spd = spdi;
            agi = agii;
            hp = calcHP();
            name = namei;
        }



        private int calcHP()
        {
            return def * 5;
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

        public void giveDamage(Player player)
        {
            player.takeDamage(atk);
        }
    }
}
