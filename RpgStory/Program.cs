﻿using System;
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
            hp = calcHP(DEF);
            name = namei;
            level = calcLevel();
        }

        private int calcHP(int def)
        {
            return def * 5;
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
            }else
            {
                hp -= 1;
            }
        }

        public void giveWeapon(Weapon weapon)
        {
            wep = weapon;
            addWeapon(wep, true);
        }

        public void giveDamage(Enemy enemy)
        {
            enemy.takeDamage(atk);
        }

        public void addWeapon(Weapon weapon, bool reset)
        {
            if (reset)
            {
                atk += weapon.ATK;
                def += weapon.DEF;
                spd += weapon.SPD;
                agi += weapon.AGI;
            }
        }
        
    }
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

        public Enemy(int atki, int defi, int spdi, int agii, string namei )
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
    class Program
    {
        static void Main(string[] args)
        {
            int skillPoints = 6;
            Console.Title = "Runes Of The Dead";
            Console.WriteLine("Welcome To the Runes of The Dead!");

            Player player = characterBuilder(skillPoints);

            Console.WriteLine("Hello {0} you are level {5} and you have {1} ATK {2} DEF {3} SPD {4} AGI",player.Name,player.ATK,player.DEF,player.SPD,player.AGI,player.Level);
            player.giveWeapon(new Weapon(2, 0, 0, 0, "Doom"));
            Console.WriteLine("You equpied {0} This has a Bonus ATK of {1} your total ATK is {2}",player.Wep.Name,player.Wep.ATK,player.ATK);
            Enemy firstFight = enemyGenerator(player.Level);

            Console.WriteLine("You face {0} their stats are {1} ATK {2} DEF {3} SPD {4} AGI",firstFight.Name,firstFight.ATK,firstFight.DEF,firstFight.SPD,firstFight.AGI);

            fightSequence(player, firstFight);
        }

        private static Player characterBuilder(int skillPoints)
        {
            int atk = 0;
            int def = 0;
            int spd = 0;
            int agi = 0;
            string name = "";
            bool doCheck = true;
            Console.WriteLine("What is your name?");
            name = Console.ReadLine();
            Console.Clear();
            while (skillPoints > 0) 
            {
                while (doCheck)
                {
                    Console.WriteLine("You have {0} skill points to spend, Spend them wisely", skillPoints);
                    Console.WriteLine("How many skill points would you like in Attack?");
                    atk = Convert.ToInt16(Console.ReadLine());
                    if (atk <= skillPoints)
                    {
                        skillPoints -= atk;
                        if (skillPoints == 0)
                            break;
                        doCheck = false;
                    }
                }
                doCheck = true;
                Console.Clear();
                while (doCheck)
                {
                    if (skillPoints == 0)
                        break;
                    Console.WriteLine("You have {0} skill points remaing", skillPoints);
                    Console.WriteLine("How many skill points would you like in Defence?");
                    def = Convert.ToInt16(Console.ReadLine());
                    if (def <= skillPoints)
                    {
                        skillPoints -= def;
                        doCheck = false;
                    }
                }
                doCheck = true;
                Console.Clear();
                while (doCheck)
                {
                    if (skillPoints == 0)
                        break;
                    Console.WriteLine("You have {0} skill points remaing", skillPoints);
                    Console.WriteLine("How many skill points would you like in Speed?");
                    spd = Convert.ToInt16(Console.ReadLine());
                    if (spd <= skillPoints)
                    {
                        skillPoints -= spd;
                        doCheck = false;
                    }
                }
                doCheck = true;
                Console.Clear();
                while (doCheck)
                {
                    if (skillPoints == 0)
                        break;
                    Console.WriteLine("You have {0} skill points remaing", skillPoints);
                    Console.WriteLine("How many skill points would you like in Agility?");
                    agi = Convert.ToInt16(Console.ReadLine());
                    if (agi <= skillPoints)
                    {
                        skillPoints -= agi;
                        doCheck = false;
                    }
                }
                Console.Clear();

            } 
            return new Player(atk,def,spd,agi,name);
        }

        private static Enemy enemyGenerator(int Level)
        {
            int atk = 0;
            int def = 0;
            int spd = 0;
            int agi = 0;
            Random rand = new Random();
            int skillPoints = Level * 6;
            string name = "Tester";
            atk = rand.Next(1,skillPoints / 2);
            skillPoints -= atk;
            def = rand.Next(1,skillPoints / 2);
            skillPoints -= def;
            spd = rand.Next(1,skillPoints / 2);
            skillPoints -= spd;
            agi = rand.Next(1,skillPoints / 1);
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
        }

    }
}