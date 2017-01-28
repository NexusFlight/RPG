using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgStory
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Runes Of The Dead";
            Console.WriteLine("Welcome To the Runes of The Dead!");
            WeaponStore weaponStore = new WeaponStore();
            Weapon[] weapons = weaponStore.createWeaponStore();

            Story story = new Story();

            //Player player = new Player();//create a new player and use the constructor to get all the stats
            //Console.WriteLine("Hello {0} you are level {5} and you have {1} ATK {2} DEF {3} SPD {4} AGI {6} HP",player.Name,player.getAttackUnmod(),player.DEF,player.SPD,player.AGI,player.Level,player.HP);

            //player.giveWeapon(weapons[0]);//gets the first weapon from the weapon store with stats and give to Player object
            //Console.WriteLine("You equipped {0} This has a Bonus ATK of {1} your total ATK is {2}", player.Wep.Name,player.Wep.ATK,player.ATK);

            //Enemy firstFight = new Enemy(player.Level,"Tester");//create a Enemy object of equal level to player and name it tester
            //Console.WriteLine("You face {0} their stats are {1} ATK {2} DEF {3} SPD {4} AGI {5} HP",firstFight.Name,firstFight.ATK,firstFight.DEF,firstFight.SPD,firstFight.AGI,firstFight.HP);

            //Interactions.fightSequence(player, firstFight);//run fightSequence with the Player object and fightFight object
            //Console.WriteLine("{0} you are level {5} and you have {1} ATK {2} DEF {3} SPD {4} AGI {6} HP", player.Name, player.getAttackUnmod(), player.DEF, player.SPD, player.AGI, player.Level, player.HP);

            //player.giveWeapon(weapons[1]);//Testing giveWeapons remove previous weapon.
            //Console.WriteLine("You equipped {0} This has a Bonus ATK of {1} your total ATK is {2}", player.Wep.Name, player.Wep.ATK, player.ATK);

            Console.ReadLine();
        }//end main


    }//end class
}//end namespace