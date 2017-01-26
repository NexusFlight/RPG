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
            int skillPoints = 6;
            Console.Title = "Runes Of The Dead";
            Console.WriteLine("Welcome To the Runes of The Dead!");
            WeaponStore weaponStore = new WeaponStore();
            Weapon[] weapons = weaponStore.createWeaponStore();
            
            Player player = characterBuilder(skillPoints);//run characterBuilder to return Player object for future use.

            Console.WriteLine("Hello {0} you are level {5} and you have {1} ATK {2} DEF {3} SPD {4} AGI",player.Name,player.getAttackUnmod(),player.DEF,player.SPD,player.AGI,player.Level);
            player.giveWeapon(new Weapon(2, 0, 0, 0, "Doom"));//create a new Weapon object with stats and give to Player objec
            Console.WriteLine("You equpied {0} This has a Bonus ATK of {1} your total ATK is {2}",player.Wep.Name,player.Wep.ATK,player.ATK);
            Enemy firstFight = enemyGenerator(player.Level,"Tester");//run enemyGenerator to create a Enemy object of equal level to player and name it tester

            Console.WriteLine("You face {0} their stats are {1} ATK {2} DEF {3} SPD {4} AGI",firstFight.Name,firstFight.ATK,firstFight.DEF,firstFight.SPD,firstFight.AGI);

            fightSequence(player, firstFight);//run fightSequence with the Player object and fightFight object
            Console.WriteLine("{0} you are level {5} and you have {1} ATK {2} DEF {3} SPD {4} AGI", player.Name, player.getAttackUnmod(), player.DEF, player.SPD, player.AGI, player.Level);

            player.giveWeapon(new Weapon(4, 0, 0, 0, "DoomShroom"));//Testing giveWeapons remove previous weapon.
            Console.WriteLine("You equpied {0} This has a Bonus ATK of {1} your total ATK is {2}", player.Wep.Name, player.Wep.ATK, player.ATK);

            Console.ReadLine();
        }//end main

        private static Player characterBuilder(int skillPoints)
        {
            int atk = 0;
            int def = 0;
            int spd = 0;
            int agi = 0;
            string name = "";
            string[] statNames = { "Attack", "Defence", "Speed", "Agility" };
            Console.WriteLine("What is your name?");
            name = Console.ReadLine();
            Console.Clear();
            for (int i = 0; i < 4; i++)
            {
                if(skillPoints == 0)//if they run out of skillpoints quit the loop
                {
                    break;
                }//end if
                Console.WriteLine("You have {0} skill points to spend, Spend them wisely", skillPoints);
                Console.WriteLine("How many skill points would you like in {0}",statNames[i]);
                int input = Convert.ToInt32(Console.ReadLine());
                if (input <= skillPoints)
                {
                    skillPoints -= input;//remove how many skillpoints have been spent
                    switch(i)//determine the inputs stat to modify
                    {
                        case 0:
                            atk = input;
                            break;

                        case 1:
                            def = input;
                            break;

                        case 2:
                            spd = input;
                            break;

                        case 3:
                            agi = input;
                            break;

                    }//end switch
                }//end if
                else
                {
                    i--;//if the input was invalid rollback counter 1
                }//end else if
                Console.Clear();
            }//end for
            
            return new Player(atk,def,spd,agi,name);//returns player object with stats defined by user
        }//end characterBuilder

        private static Enemy enemyGenerator(int Level,string name)
        {
            int atk = 0;
            int def = 0;
            int spd = 0;
            int agi = 0;
            Random rand = new Random();
            int skillPoints = Level * 6;
            atk = rand.Next(1,skillPoints / 2);//allow the random generator to spend half the points for each.
            skillPoints -= atk;
            def = rand.Next(1,skillPoints / 2);
            skillPoints -= def;
            spd = rand.Next(1,skillPoints / 2);
            skillPoints -= spd;
            agi = rand.Next(1,skillPoints);//if there is only 1 skill point remaining why divide 
            skillPoints -= agi;
            return new Enemy(atk, def, spd, agi, name);//return enemy object with computer determined stats
        }//end enemyGenerator

        private static void fightSequence(Player player, Enemy enemy)
        {
            string action = "";
            bool takeDamage = true;
            bool fighting = true;
            bool levelUp = true;
            Random rand = new Random();
            while (fighting)
            {
                if (player.HP <= 0 || enemy.HP <= 0)//if the player or enemy has 0 or less health then break the loop.
                {
                    break;
                }//end if
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("Fight    Dodge       Search      Run");
                action = Console.ReadLine().ToLowerInvariant();
                Console.Clear();
                switch (action)
                {
                    case "fight":
                        if(rand.Next(player.SPD *2) < player.SPD)//check if the random genrator has created a number(SPD*2) less than the players SPD
                        {
                            player.giveDamage(enemy);//pass giveDamage the Enemy object to damage
                            Console.WriteLine("Enemy HP is {0}",enemy.HP);
                        }//end if
                        else
                        {
                            Console.WriteLine("You missed!");
                        }//end if else
                        break;

                    case "dodge":
                        if(rand.Next(player.SPD*4) < player.SPD)
                        {
                            takeDamage = false;
                            Console.WriteLine("You Dodge The Attack");
                        }//end if
                        else
                        {
                            Console.WriteLine("You failed to dodge");
                        }//end else if
                        break;

                    case "search":
                        break;

                    case "run":
                        if(player.SPD > enemy.SPD)
                        {
                            fighting = false;
                            Console.WriteLine("You Coward, You Ran!");
                        }//end if
                        else if (player.SPD == enemy.SPD)
                        {
                            if(rand.Next(100) < 10)//gives user 1 in 10 chance to run if their SPD is equal to the enemy
                            {
                                fighting = false;
                                Console.WriteLine("You Coward, You Ran!");
                                levelUp = false;
                            }//end if
                            else
                            {
                                Console.WriteLine("You Failed to Run");
                            }//end else if
                        }//end else if
                        else
                        {
                            Console.WriteLine("You are too slow you cannot escape {0}",enemy.Name);
                        }//end if statement
                        break;
                }//end switch
                
                if (takeDamage)
                {
                    enemy.giveDamage(player);
                    Console.WriteLine("Your HP is {0}",player.HP);
                }//end if
                takeDamage = true;
            }//end while

            if(player.HP > 0)//if the player won give the player the levelUp options
            {
                if (levelUp)//if they didn't run then they get a level up
                {
                    Console.WriteLine("You defeated {0} You have leveled up!",enemy.Name);
                    player.levelUp(6);//gives the user 6 skill points to spend
                }//end if
            }//end if
            else
            {
                Console.WriteLine("You are DEAD!");
            }//end else if
        }//end fightSequence

    }//end class
}//end namespace