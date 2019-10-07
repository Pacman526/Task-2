namespace Gade_POE
{
    abstract public class Building
        {
            //CLASS VARIABLES 
            protected int xPos;
            protected int yPos;
            protected int HP;
            protected int maxHP;
            protected int team;
            protected char symbol;


            //CLASS CONSTRUCTOR
            public Building(int _xPos, int _yPos, int _HP, int _team, char _symbol)
            {
                xPos = _xPos;
                yPos = _yPos;
                HP = _HP;
                team = _team;
                symbol = _symbol;

            }

            //CLASS METHODS
            public abstract void save();
            public abstract void Death(Building b);
            public abstract string ToString(Building[] buildings, Building b);     
        }
}
