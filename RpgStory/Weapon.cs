using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgStory
{
    class Weapon
    {
        private int atk;
        public int ATK { get { return atk; } private set { } }
        private int def;
        public int DEF { get { return def; } private set { } }
        private int spd;
        public int SPD { get { return spd; } private set { } }
        private int agi;
        public int AGI { get { return agi; } private set { } }
        private string name;
        public string Name { get { return name; } private set { } }

        public Weapon(int atki, int defi, int spdi, int agii, string namei)
        {
            atk = atki;
            def = defi;
            spd = spdi;
            agi = agii;
            name = namei;
        }
    }
}
