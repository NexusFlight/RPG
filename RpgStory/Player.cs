﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgStory
{
    class Player : Character
    {
        
        public Weapon Wep { get; private set; }

        public Player()//allows for a neat character builder by getting the class it self to set the variables.
        {
            Console.WriteLine("What is your name?");
            Name = Console.ReadLine();
            Console.Clear();
            levelUp(6);
        }//end player Constructor

        public Player(int atki, int defi, int spdi, int agii, string namei)
        {
            ATK = atki;//sets the ATK of the player when the player is created
            DEF = defi;
            SPD = spdi;
            AGI = agii;
            HP = calcHP();
            Name = namei;
            Level = calcLevel();
        }//end Player Constructor

       
        public void giveWeapon(Weapon weapon)
        {
            if (Wep != null)//if they have a weapon already remove it and start again.
            {
                removeWeapon();
            }//end if
            Wep = weapon;
            addWeapon(Wep);
        }//end giveWeapon

        public void giveDamage(Enemy enemy)
        {
            enemy.takeDamage(ATK);
        }//end giveDamage

        public void addWeapon(Weapon weapon)
        {
            ATK += weapon.ATK;
            DEF += weapon.DEF;
            SPD += weapon.SPD;
            AGI += weapon.AGI;
        }//end addWeapon

        public void removeWeapon()
        {
            ATK -= Wep.ATK;
            DEF -= Wep.DEF;
            SPD -= Wep.SPD;
            AGI -= Wep.AGI;
            Wep = null;
        }//end removeWeapon

        public void levelUp(int skillPoints)//same as the characterBuilder in player apart from it doesnt reset the name
        {
            string[] statNames = { "Attack", "Defence", "Speed", "Agility" };
            for (int i = 0; i < 4; i++)
            {
                if (skillPoints == 0)
                {
                    break;
                }//end if
                Console.WriteLine("You have {0} skill points to spend, Spend them wisely", skillPoints);
                Console.WriteLine("How many skill points would you like in {0}", statNames[i]);
                int input = Convert.ToInt32(Console.ReadLine());
                if (input <= skillPoints)
                {
                    skillPoints -= input;
                    switch (i)
                    {
                        case 0:
                            ATK += input;
                            break;

                        case 1:
                            DEF += input;
                            break;

                        case 2:
                            SPD += input;
                            break;

                        case 3:
                            AGI += input;
                            break;

                    }//end switch
                }//end if
                else
                {
                    i--;
                }//end else if
                Console.Clear();
            }//end for
            Level = calcLevel();
            HP = calcHP();
        }//end levelUp

        public int getAttackUnmod()
        {
            if (Wep != null)//if they have a weapon then return the ATK minus the weapon ATK
            {
                return ATK - Wep.ATK;
            }//end if
            else
            {
                return ATK;
            }//end else if
        }//end getAttackUnmod

    }//end class
}//end namespace
