using System;



namespace Gade_POE
{
    public class Map
        {
            //CLASS VARIABLES
            public char[,] map = new char[20, 20];
            public int unitAmount;
            public int buildingAmount;
            public Unit[] units;
            public Building[] buildings;

            //CLASS CONSTRUCTOR
            public Map(int _unitAmount, int _buildingAmount)
            {
                unitAmount = _unitAmount;
                buildingAmount = _buildingAmount;
            }

            //CLASS METHODS
            public void BattlefieldCreator()
            {
                for (int i = 0; i < 20; i++)
                {
                    for (int k = 0; k < 20; k++)
                    {
                        map[i, k] = Convert.ToChar(".");
                    }
                }

                Random rnd = new Random();
                units = new Unit[unitAmount];

                for (int i = 0; i < unitAmount; i++)
                {

                    int x = rnd.Next(0, 20);
                    int y = rnd.Next(0, 20);
                    int team = rnd.Next(0, 2);
                    int unit = rnd.Next(0, 2);

                    if (map[x, y] != '.')
                    {
                        for (int k = 0; k < 1000; k++)
                        {
                            x = rnd.Next(0, 20);
                            y = rnd.Next(0, 20);

                            if (map[x, y] == '.')
                            {
                                k = 1000;
                            }
                        }
                    }

                    if (unit == 1 & team == 0)
                    {
                        Unit RangedUnit = new Unit(x, y, 10, 1, 3, 5, team, Convert.ToChar("R"), false, "RangedUnit");
                        map[x, y] = RangedUnit.symbol;
                        units[i] = RangedUnit;
                    }

                    if (unit == 1 & team == 1)
                    {
                        Unit RangedUnit = new Unit(x, y, 10, 1, 3, 5, team, Convert.ToChar("r"), false, "RangedUnit");
                        map[x, y] = RangedUnit.symbol;
                        units[i] = RangedUnit;
                    }

                    if (unit == 0 & team == 0)
                    {
                        Unit MeleeUnit = new Unit(x, y, 20, 1, 2, 1, team, Convert.ToChar("M"), false, "MeleeUnit");
                        map[x, y] = MeleeUnit.symbol;
                        units[i] = MeleeUnit;
                    }

                    if (unit == 0 & team == 1)
                    {
                        Unit MeleeUnit = new Unit(x, y, 20, 1, 2, 1, team, Convert.ToChar("m"), false, "MeleeUnit");
                        map[x, y] = MeleeUnit.symbol;
                        units[i] = MeleeUnit;

                    }
                }

                buildings = new Building[buildingAmount];
                

                for (int j = 0; j < buildings.Length; j++)
                {
                    int x = rnd.Next(0, 20);
                    int y = rnd.Next(0, 20);
                    int team = rnd.Next(0, 2);
                    int buildingType = rnd.Next(0, 2);
                    

                    if (buildingType == 0)
                    {
                        ResourceBuilding B = new ResourceBuilding(x, y, 100, team, 'O');
                        map[x, y] = B.Symbol ;
                        buildings[j] = B;
                    }
                    else if (buildingType == 1)
                    {
                        FactoryBuilding B = new FactoryBuilding(x, y, 100, team, 'F');
                        map[x, y] = B.Symbol;
                        buildings[j] = B;
                    }
                    
                }
            }

            public string PopulateMap(Unit[] units, Building[] buildings)
            {
                string mapLayout = "";

                for (int k = 0; k < units.Length; k++)
                {

                    if (units[k].Health > 0)
                    {
                        map[units[k].xPos, units[k].yPos] = units[k].symbol;
                    }
                    else
                    {
                        map[units[k].xPos, units[k].yPos] = '.';
                    }
                }

                for (int j = 0; j < 20; j++)
                {
                    for (int l = 0; l < 20; l++)
                    {
                        mapLayout += map[j, l];
                    }
                    mapLayout = mapLayout + "\n";
                }

                return mapLayout;
            }

            public void UpdatePosition(int i, int oldX, int oldY)
            {

                map[units[i].xPos, units[i].yPos] = units[i].symbol;
                map[oldX, oldY] = '.';
            }

        }
}
