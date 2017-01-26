using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgStory
{
    class Weapon
    {

        public int ATK { get; private set; }
        public int DEF { get; private set; }
        public int SPD { get; private set; }
        public int AGI { get; private set; }
        public int HP { get; private set; }
        public int Level { get; private set; }
        public string Name { get; private set; }

        public Weapon(int atki, int defi, int spdi, int agii, string namei)
        {
            ATK = atki;
            DEF = defi;
            SPD = spdi;
            AGI = agii;
            Name = namei;
        }
    }
}
