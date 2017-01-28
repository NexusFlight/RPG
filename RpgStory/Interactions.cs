using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgStory
{
    class Interactions
    {

        public static void fightSequence(Player player, Enemy enemy)
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
                        if (rand.Next(player.SPD * 2) < player.SPD)//check if the random genrator has created a number(SPD*2) less than the players SPD
                        {
                            player.giveDamage(enemy);//pass giveDamage the Enemy object to damage
                            Console.WriteLine("Enemy HP is {0}", enemy.HP);
                        }//end if
                        else
                        {
                            Console.WriteLine("You missed!");
                        }//end if else
                        break;

                    case "dodge":
                        if (rand.Next(player.AGI * 4) < player.AGI)
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
                        if (player.SPD > enemy.SPD)
                        {
                            fighting = false;
                            Console.WriteLine("You Coward, You Ran!");
                        }//end if
                        else if (player.SPD == enemy.SPD)
                        {
                            if (rand.Next(100) < 10)//gives user 1 in 10 chance to run if their SPD is equal to the enemy
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
                            Console.WriteLine("You are too slow you cannot escape {0}", enemy.Name);
                        }//end if statement
                        break;
                }//end switch

                if (takeDamage)
                {
                    enemy.giveDamage(player);
                    Console.WriteLine("Your HP is {0}", player.HP);
                }//end if
                takeDamage = true;
            }//end while

            if (player.HP > 0)//if the player won give the player the levelUp options
            {
                if (levelUp)//if they didn't run then they get a level up
                {
                    Console.WriteLine("You defeated {0} You have leveled up!", enemy.Name);
                    player.levelUp(6);//gives the user 6 skill points to spend
                }//end if
            }//end if
            else
            {
                Console.WriteLine("You are DEAD!");
                Console.WriteLine("Press Enter To Exit");
                Console.ReadLine();
                Environment.Exit(0);
            }//end else if
        }//end fightSequence
    }
}
