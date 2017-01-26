using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgStory
{
    class WeaponStore
    {
        public Weapon[] createWeaponStore()
        {
            Weapon[] weaponStore = new Weapon[4];
            weaponStore[0] = new Weapon(2, 0, 0, 0, "Stone Sword");
            weaponStore[1] = new Weapon(4, 0, 0, 0, "Iron Sword");
            weaponStore[2] = new Weapon(6, 0, 0, 0, "Steel Sword");
            weaponStore[3] = new Weapon(8, 0, 0, 0, "Broad Sword");
            return weaponStore;
        }
    }
}
