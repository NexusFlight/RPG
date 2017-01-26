﻿using System;
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

            Player player = characterBuilder(skillPoints);

            Console.WriteLine("Hello {0} you are level {5} and you have {1} ATK {2} DEF {3} SPD {4} AGI",player.Name,player.getAttackUnmod(),player.DEF,player.SPD,player.AGI,player.Level);
            player.giveWeapon(new Weapon(2, 0, 0, 0, "Doom"));
            Console.WriteLine("You equpied {0} This has a Bonus ATK of {1} your total ATK is {2}",player.Wep.Name,player.Wep.ATK,player.ATK);
            Enemy firstFight = enemyGenerator(player.Level,"Tester");

            Console.WriteLine("You face {0} their stats are {1} ATK {2} DEF {3} SPD {4} AGI",firstFight.Name,firstFight.ATK,firstFight.DEF,firstFight.SPD,firstFight.AGI);

            fightSequence(player, firstFight);
            Console.WriteLine("{0} you are level {5} and you have {1} ATK {2} DEF {3} SPD {4} AGI", player.Name, player.getAttackUnmod(), player.DEF, player.SPD, player.AGI, player.Level);

            player.giveWeapon(new Weapon(4, 0, 0, 0, "DoomShroom"));
            Console.WriteLine("You equpied {0} This has a Bonus ATK of {1} your total ATK is {2}", player.Wep.Name, player.Wep.ATK, player.ATK);
        }

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
                if(skillPoints == 0)
                {
                    break;
                }
                Console.WriteLine("You have {0} skill points to spend, Spend them wisely", skillPoints);
                Console.WriteLine("How many skill points would you like in {0}",statNames[i]);
                int input = Convert.ToInt32(Console.ReadLine());
                if (input <= skillPoints)
                {
                    skillPoints -= input;
                    switch(i)
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

                    }
                }else
                {
                    i--;
                }
                Console.Clear();
            }
            
            return new Player(atk,def,spd,agi,name);
        }

        private static Enemy enemyGenerator(int Level,string name)
        {
            int atk = 0;
            int def = 0;
            int spd = 0;
            int agi = 0;
            Random rand = new Random();
            int skillPoints = Level * 6;
            atk = rand.Next(1,skillPoints / 2);
            skillPoints -= atk;
            def = rand.Next(1,skillPoints / 2);
            skillPoints -= def;
            spd = rand.Next(1,skillPoints / 2);
            skillPoints -= spd;
            agi = rand.Next(1,skillPoints);
            skillPoints -= agi;
            return new Enemy(atk, def, spd, agi, name);
        }

        private static void fightSequence(Player player, Enemy enemy)
        {
            string action = "";
            bool takeDamage = true;
            bool fighting = true;
            Random rand = new Random();
            while (fighting)
            {
                
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("Fight    Dodge       Search      Run");
                action = Console.ReadLine().ToLowerInvariant();
                Console.Clear();
                switch (action)
                {
                    case "fight":
                        if(rand.Next(player.SPD *2) < player.SPD)
                        {
                            player.giveDamage(enemy);
                            Console.WriteLine("Enemy HP is {0}",enemy.HP);
                        }
                        else
                        {
                            Console.WriteLine("You missed!");
                        }
                        break;

                    case "dodge":
                        if(rand.Next(player.SPD*4) < player.SPD)
                        {
                            takeDamage = false;
                            Console.WriteLine("You Dodge The Attack");
                        }else
                        {
                            Console.WriteLine("You failed to dodge");
                        }
                        break;

                    case "search":
                        break;

                    case "run":
                        break;
                }
                if (player.HP <= 0 || enemy.HP <= 0)
                {
                    fighting = false;
                    takeDamage = false;
                }
                if (takeDamage)
                {
                    enemy.giveDamage(player);
                    Console.WriteLine("Your HP is {0}",player.HP);
                }
                takeDamage = true;
            }

            if(player.HP > 0)
            {
                player.levelUp(6);
            }
        }

    }
}
