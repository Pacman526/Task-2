﻿using System;



namespace Gade_POE
{
    public class Unit
    {
        //CLASS VARIABLES 
        public int xPos, yPos, Health, maxHealth, speed, attack, attackRange;
        public int team;
        public char symbol;
        public bool combatCheck;
        public string info;
        public int count;
        public string name;


        //CLASS CONSTRUCTOR
        public Unit(int _xPos, int _yPos, int _health, int _speed, int _attack, int _attackRange, int _team, char _symbol, bool _combatCheck, string _name)
        {
            xPos = _xPos;
            yPos = _yPos;
            Health = _health;
            maxHealth = _health;
            speed = _speed;
            attack = _attack;
            attackRange = _attackRange;
            team = _team;
            symbol = _symbol;
            combatCheck = _combatCheck;
            name = _name;
        }

        //CLASS METHODS

        public void save()
        {

        }


        public void MoveUnit(Unit u, Unit closestUnit)
        {
            if (((u.Health * 100) / u.maxHealth) < 25)
            {
                u.combatCheck = false;
                Random rnd = new Random();

                int temp = rnd.Next(0, 4);
                if (temp == 0)
                {
                    if (u.xPos - u.speed < 0)
                    {

                    }
                    else
                        u.xPos = u.xPos - u.speed;
                }
                else if (temp == 1)
                {
                    if (u.yPos - u.speed < 0)
                    {

                    }
                    else
                        u.yPos = u.yPos - u.speed;
                }
                else if (temp == 2)
                {
                    if (u.xPos + u.speed > 19)
                    {

                    }
                    else
                        u.xPos = u.xPos + u.speed;
                }
                else if (temp == 3)
                {
                    if (u.yPos + u.speed > 19)
                    {

                    }
                    else
                        u.yPos = u.yPos + u.speed;
                }
            }
            else
                for (int k = 0; k < u.speed; k++)
                {
                    if (u.xPos > closestUnit.xPos)
                    {
                        u.xPos = u.xPos - 1;
                    }
                    else
                    if (u.xPos < closestUnit.xPos)
                    {
                        u.xPos = u.xPos + 1;
                    }
                    else
                    if (u.yPos > closestUnit.yPos)
                    {
                        u.yPos = u.yPos - 1;
                    }
                    else
                    if (u.yPos < closestUnit.yPos)
                    {
                        u.yPos = u.yPos + 1;
                    }
                }

        }

        public void CombatHandler(Unit closestUnit, Unit u)
        {
            closestUnit.Health -= u.attack;
        }

        public bool RangeCheck(Unit closestUnit, Unit u)
        {
            if (u.attackRange >= Math.Sqrt(Math.Pow((closestUnit.xPos - u.xPos), 2) + Math.Pow((closestUnit.yPos - u.yPos), 2)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Unit ClosestUnit(Unit[] units, int numUnits, Unit u)
        {

            double distance = 0;
            int counter = 0;
            double smallestDist;
            Unit closestUnit = u;

            smallestDist = 15;
            for (int j = 0; j < units.Length; j++)
            {
                if (units[counter].team != u.team && units[counter].Health > 0)
                {
                    distance = Math.Sqrt(Math.Pow((units[counter].xPos - u.xPos), 2) + Math.Pow((units[counter].yPos - u.yPos), 2));
                    if (distance < smallestDist)
                    {
                        smallestDist = distance;
                        closestUnit = units[j];
                    }
                    counter += 1;
                }
                else
                {
                    counter += 1;
                }
            }
            return closestUnit;
        }

        public void Death(Unit[] units, int i)
        {

            //for (int k = i; k < units.Length - 1; k++)
            //{
            //units[k] = units[k + 1];
            //}



        }

        public string ToString(Unit u, Unit[] units, int i)
        {
            info = "";

            if (u.Health <= 0)
            {

            }
            else
            {
                info += u.name + "\n" + "____________" + "\n" + "Hp : " + u.Health + "\n" + "Damage : " + u.attack + "\n" + "Team : " + (u.team + 1) + "\n" + "In Combat : " + u.combatCheck + "\n" + "Symbol: " + u.symbol; ;
                info = info + "\n" + "\n";
            }

            return info;
        }

    }
}
