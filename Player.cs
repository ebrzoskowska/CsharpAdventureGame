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
			Console.WriteLine("");
			Console.WriteLine("        PLAYER STATS        ");
            Console.WriteLine("");
            Console.WriteLine("****************************");
            Console.WriteLine("");
            Console.WriteLine("Health: " + Program.currentPlayer.health);
            Console.WriteLine("Coins: " + Program.currentPlayer.coins);
            Console.WriteLine("");
            Console.WriteLine("****************************");
            Console.ReadKey();
            Console.Clear();
			if (Program.currentPlayer.health <= 0)
            {
				Program.gameOver();
            }
        }

        public static void newPlayer()
        {

			string characterChoice;
			string choiceConfirmation;
			int correct = 0;

			do
			{

				Console.Clear();
				Console.WriteLine("");
				Console.WriteLine("Please choose character type as below: ");
				Console.WriteLine("");
				Console.WriteLine("(M)age");
				Console.WriteLine("(W)arrior");
				Console.WriteLine("(R)ogue");
				Console.WriteLine("");
				Console.WriteLine("Choice: ");
				characterChoice = Console.ReadLine().ToLower();
				Console.Clear();

				switch (characterChoice)
				{
					case "m":
					case "mage":
						Console.WriteLine("");
						Console.WriteLine("This character is a spell-caster that uses fire and shadow magic against their enemies.");
						Console.WriteLine("Is this the character you wish to play?");
						Console.WriteLine("");
						Console.WriteLine(" Y / N ");
						Console.WriteLine("");
						Console.WriteLine("Choice: ");
						choiceConfirmation = Console.ReadLine().ToLower();

						switch (choiceConfirmation)
						{
							case "yes":
							case "y":
								correct = 1;
								break;
							case "no":
							case "n":
								correct = 0;
								break;
							default:
								Console.WriteLine("Just try again...");
								Console.WriteLine("press ENTER to continue");
								break;
						}

						break;
					case "w":
					case "warrior":
						Console.WriteLine("");
						Console.WriteLine("This character has the widest array of weapons to choose from in the game,");
						Console.WriteLine("being able to equip every weapon type in the game except for wands.");
						Console.WriteLine("Is this the character you wish to play?");
						Console.WriteLine("");
						Console.WriteLine(" Y / N ");
						Console.WriteLine("");
						Console.WriteLine("Choice: ");
						choiceConfirmation = Console.ReadLine().ToLower();

						switch (choiceConfirmation)
						{
							case "yes":
							case "y":
								correct = 1;
								break;
							case "no":
							case "n":
								correct = 0;
								break;
							default:
								Console.WriteLine("Just try again...");
								Console.WriteLine("press ENTER to continue");
								break;
						}

						break;
					case "r":
					case "rouge":
						Console.WriteLine("");
						Console.WriteLine("A rogue is a versatile character, capable of sneaky combat and nimble tricks.");
						Console.WriteLine("The rogue is stealthy and dexterous, capable of finding and disarming traps and picking locks.");
						Console.WriteLine("Is this the character you wish to play?");
						Console.WriteLine("");
						Console.WriteLine(" Y / N ");
						Console.WriteLine("");
						Console.WriteLine("Choice: ");
						choiceConfirmation = Console.ReadLine().ToLower();

						switch (choiceConfirmation)
						{
							case "yes":
							case "y":
								correct = 1;
								break;
							case "no":
							case "n":
								correct = 0;
								break;
							default:
								Console.WriteLine("Just try again...");
								Console.WriteLine("press ENTER to continue");
								break;
						}

						break;
					default:
						Console.WriteLine("Just try again...");
						Console.WriteLine("press ENTER to continue");
						break;
				}
			} while (correct == 0);
		}
    }
}
