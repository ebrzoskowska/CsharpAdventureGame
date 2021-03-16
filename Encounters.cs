using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureGame
{
    public class Encounters
    {
        //Encounters
        static Random rnd = new Random();

        //Basic encounters
        public static void basicEncounter()
        {
            Console.WriteLine("");
            Console.WriteLine("A furious beast appeared in front of you out of nowhere... ");
            Console.WriteLine("");
            combat(true, "", 0, 0);
        }

        public static void firstEncounter()
        {
            Console.WriteLine("");
            Console.WriteLine("You open the door in complete silence and slowly sneak up on your captor.");
            Console.WriteLine("");
            Console.WriteLine("He rapidly turns...");
            Console.WriteLine("");
            combat(false, "Human rouge", 1, 5);
        }

        public static void sergeEncounter()
        {
            Console.WriteLine("");
            Console.WriteLine("The door slowly creaks open as you peer into the dark room.");
            Console.WriteLine("You see your brother, flash and bones, with furious face and ready");
            Console.WriteLine("for fight....");
            Console.WriteLine("");
            combat(false, "Serge the Destroyer", 1, 10);
        }

        //Enemies for random basic encounters
        public static string enemyName()
        {
            switch (rnd.Next(0, 4))
            {
                case 0:
                    return "Skeleton";
                case 1:
                    return "Zombie";
                case 2:
                    return "Troglodyte";
                case 3:
                    return "Goblin";
            }
            return "Ogre";
        }

        //Encounter Tools
        public static void combat(bool random, string name, int power, int health)
        {
            string n = "";
            int p = 0;
            int h = 0;
            int c = rnd.Next(1, 5);

            if (random)
            {
                n = enemyName();
                p = rnd.Next(0, 5);
                h = rnd.Next(0, 6);
            }
            else
            {
                n = name;
                p = power;
                h = health;
            }

            while (Program.currentPlayer.health > 0 && h > 0)
            {
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine("                            ");
                Console.WriteLine("****************************");
                Console.WriteLine("                            ");
                Console.WriteLine("(O)FFENSE         (D)EFFENSE");
                Console.WriteLine("                            ");
                Console.WriteLine("****************************");
                Console.WriteLine("Your health: " + Program.currentPlayer.health);
                Console.WriteLine("");               
                Console.WriteLine(n + " health: " + h);
                Console.WriteLine("");
                string input = Console.ReadLine();

                if (input.ToLower() == "o" || input.ToLower() == "offense")
                {
                    //attack
                    Console.WriteLine("");
                    Console.WriteLine("With a rush, you're trying to surge ahead but all you got are only bare hands.");
                    Console.WriteLine("You threw up your forearms like an offensive lineman blocking a defensive back, you");
                    Console.WriteLine("slipped to the side, pushed him down and away, caught his head, and rolled him into the floor.");
                    Console.WriteLine("Third of a second once contact was made, you  hit " + n + " on the forehead three hard times.");
                    Console.WriteLine("");
                    int damage = p - Program.currentPlayer.resistant;
                    if (damage <= 0) ;
                    damage = rnd.Next(0, 3);
                    int attack = rnd.Next(0, 3);
                    Console.WriteLine("You lose " + damage + " health and deal " + attack + " damage");
                    Console.WriteLine("");
                    Console.WriteLine("press ENTER to continue");
                    Program.currentPlayer.health -= damage;
                    h -= attack;

                }
                else if (input.ToLower() == "d" || input.ToLower() == "deffense")
                {
                    //deffense
                    Console.WriteLine("");
                    Console.WriteLine("As the " + n + " prepares to strike you stepped back and balancing your weight prepared to defense.");
                    Console.WriteLine("He slapped you with his open left hand full across the face. Your headache is like a starburst.");
                    Console.WriteLine("");
                    int damage = (p / 4) - Program.currentPlayer.resistant;
                    if (damage <= 0) ;
                    damage = rnd.Next(0, 3);
                    int attack = rnd.Next(0, 2);
                    Console.WriteLine("You lose " + damage + " health and deal " + attack + " damage");
                    Console.WriteLine("");
                    Console.WriteLine("press ENTER to continue");
                    Program.currentPlayer.health -= damage;
                    h -= attack;
                }
                else
                {
                    Console.WriteLine("Let's try with 'o' or 'd' letters... ");
                    Console.WriteLine("press ENTER to continue");
                }
            }

            if (Program.currentPlayer.health <= 0)
            {
                //Player is dead
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("You took a deep breath. It hurt your ribcage. You exhaled, inhaled again, and tried");
                Console.WriteLine("to inched your arms under you and pushed yourself up on your hands and knees, it did not work.");
                Console.WriteLine("Your head swam. You felt your stomach tighten and you threw up, which hurt the ribs even more.");
                Console.WriteLine("Everything blurred for a minute, you inhaled some more unfortunately that was your last breath.");
                Console.ReadKey();
                Program.gameOver();
            }
            else if (h <= 0)
            {
                //Player wins
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("Your hands are sore, you slowly got yourself together. Everything blurred for a minute,");
                Console.WriteLine("then came back into focus again. You inhaled fresh air and felt a little steadier.");
                Console.WriteLine("But the most importanly you smashed your enemy!");
                Console.WriteLine("");
                Console.WriteLine("You earned " + c + " coins!");
                Program.currentPlayer.coins += c;
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
