using System;



namespace Gade_POE
{
    class GameEnigine
        {
            public int roundCheck;
            public string info;
            Unit closestUnit;
            public int x, y, i;
            public Map map;
            public int temp;

            

            public void GameLogic(Unit[] units, Building [] buildings)
            {

                info = "";
                if (roundCheck > 0)
                {
                    for (i = 0; i < units.Length; i++)
                    {
                        Unit u = (Unit)units[i];

                        x = u.xPos;
                        y = u.yPos;

                        if (u.Health > 0)
                        {
                            closestUnit = u.ClosestUnit(units, units.Length, u);

                            if (closestUnit == u)
                            {
                                u.combatCheck = false;
                            }
                            else
                            if (u.RangeCheck(closestUnit, u) == true)
                            {
                                u.combatCheck = true;
                                u.CombatHandler(closestUnit, u);
                            }
                            else
                            {
                                u.combatCheck = false;
                                u.MoveUnit(u, closestUnit);
                                map.UpdatePosition(i, x, y);

                            }

                            info += u.ToString(u, units, i);
                        }
                        else
                        {

                        }
                    }

                    for (int k = 0; k < buildings.Length; k++)
                    {
                        Building b = buildings[k];
                        string buildingType = b.GetType().ToString();
                        string[] buildArr = buildingType.Split('.');
                        buildingType = buildArr[buildArr.Length - 1];

                        if (buildingType == "Form1+ResourceBuilding")
                        {
                            ResourceBuilding B = (ResourceBuilding)b;

                            if (B.HP < 0)
                            {
                                B.Death(B);
                            }else
                            {
                                info += B.ToString(buildings, B);
                                if (temp > 4)
                                {
                                    temp = 4;
                                    B.GenerateResources();
                                }
                            }
                            
                        }
                        
                        if (buildingType == "Form1+FactoryBuilding")
                        {
                            FactoryBuilding B = (FactoryBuilding)b;
                            B.productionSpeed = 5;
                            if (B.HP < 0)
                            {
                                B.Death(B);
                            }else
                            {
                                decimal d = roundCheck;
                                if ((d /B.productionSpeed) % 1 == 0)
                                {
                                    Array.Resize(ref units, units.Length + 1);
                                    units[units.Length -1] = B.SpawnUnit(); 
                                }
                                info += B.ToString(buildings, B);
                            }
                        }
                    }
                }
                else
                {
                    for (i = 0; i < units.Length; i++)
                    {
                        Unit u = (Unit)units[i];
                        info += u.ToString(u, units, i);
                    }
                }
            }
        }
}
