using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureGame
{
    [Serializable]
    public class Player
    {
        public string name;
        public int coins = 0;
        public int health = 10;
        public int damage = 1;
        public int resistant = 0;

        public static void playerStats()
        {
            Console.Clear();
            Console.WriteLine("        PLAYER STATS        ");
            Console.WriteLine("");
            Console.WriteLine("****************************");
            Console.WriteLine("");
            Console.WriteLine("Health: " + Program.currentPlayer.health);
            Console.WriteLine("Coins: " + Program.currentPlayer.coins);
            Console.WriteLine("");
            Console.WriteLine("****************************");
            Console.ReadKey();
        }

        public static void newPlayer()
        {
//
        }
    }
}
