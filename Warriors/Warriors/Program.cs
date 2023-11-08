using System;
using System.Reflection.PortableExecutable;

namespace Warriors
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("start");

            var character = new Warrior();
            Console.WriteLine(character.ToString()); 
        }
    }
}