using System;

namespace Warriors
{
    abstract class Character
    {
        public override string ToString()
        {
            return "character";
        }

        public Character()
        {
        }
    }

    class Warrior: Character
    {
        public Warrior()
        {

        }
        override public  string ToString()
        {
            return "warrior";
        }
    }
}