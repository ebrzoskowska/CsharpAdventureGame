using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;
using AdventureGame.Adventures;

namespace AdventureGame
{
    public class Program
    {
        public static Player currentPlayer = new Player();
        public static Random rnd = new Random();

        static void Main(string[] args)
        {
            
            gameMenu();
            gameTitle();
            //firstChapter();
            //thirdChapter();
            //Encounters.firstEncounter();
            //secondChapter();
            //Player.playerStats();


        }

        public static void gameMenu()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            makeMenuOptions();

            bool choiceValid = false;
            while (!choiceValid)
            {
                string choice = Console.ReadLine().ToUpper();
                if (choice == "S" || choice == "L" || choice == "C")
                {
                    choiceValid = true;                  
                    if (choice == "S")
                    {
                        gameTitle();
                    }
                    else if (choice == "C")
                    {
                        Player.newPlayer();
                    }
                    else if (choice == "L")
                    {
                        loadGame();
                    }
                }
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("Well...you did not pick the right letter...");
                    Console.WriteLine("Just try again");
                    makeMenuOptions();
                    choiceValid = false;                   
                }
            }
        }

        private static void makeMenuOptions()
        {           
            Console.WriteLine("");
            Console.WriteLine("(S)tart a new game");
            Console.WriteLine("(L)oad a game");
            Console.WriteLine("(C)reate new character");
        }

        public static void gameTitle()
        {
            Console.Clear();
            var basePath = $"{AppDomain.CurrentDomain.BaseDirectory}adventures";
            var initialAdventure = new Adventure();
            if (File.Exists($"{basePath}\\initial.json"))
            {
                var directory = new DirectoryInfo(basePath);
                var initialJsonFile = directory.GetFiles("initial.json");
                using (StreamReader fi = File.OpenText(initialJsonFile[0].FullName))
                {
                    initialAdventure = JsonConvert.DeserializeObject<Adventure>(fi.ReadToEnd());
                }
                Console.WriteLine($"{initialAdventure.Title}");
                Console.WriteLine($"{initialAdventure.gameTitleDescription}");
            }
            Console.ReadLine();
            Console.Clear();
        }

        public static void firstChapter()
        {
            Console.WriteLine("");
            Console.WriteLine("You awake in a cold stone dark room. You feel dazed and having trouble remembering anything from last");
            Console.WriteLine("few days. Through the window you can see dark magic lights of the city, the town where you were born");
            Console.WriteLine("and from which you ran away. Where, in ages past, there had been an empty cavern of roughly shaped ");
            Console.WriteLine("stalactites and stalagmites now stands artistry, row after row of carved castles thrumming in a quiet");
            Console.WriteLine("glow of magic. There is only one place you cannot see through the window and that fact makes your");
            Console.WriteLine("blood curdle, because you are pretty sure that your new jail it is one of the room in the castle of");
            Console.WriteLine("your lethal enemy, your brother Serge the Destroyer. You know that there is no escape through the window,");
            Console.WriteLine("as castle is on the top of the mountain which can be reached only by large wings of an Royal Griffin.");
            Console.WriteLine("The city is perfection of form, where not a stone has been left to its natural shape.");
            Console.WriteLine("This sense of order and control, however, is but a cruel facade, a deception hiding the chaos and");
            Console.WriteLine("vileness. You touching the wall of your cell in the darkness for a way out, but walls seems solid,");
            Console.WriteLine("you touch them very thoroughly in the dark and finally you can sense air movement in a gap in the");
            Console.WriteLine("rocks and you push this place with all your body weight and hidden door are moving without making");
            Console.WriteLine("a sound. You can see you captor standing with his back to you outside the door.");
            Console.ReadLine();
            Console.Clear();
        }


        public static void secondChapter()
        {
            string choice, secondChoice;
            Console.WriteLine("");
            Console.WriteLine("Your eyes keep scanning the next room. It is another empty stone chamber but this time giant ornamented door");
            Console.WriteLine("invite you to use them and reach for yor freedom. Beautifull and sported a thousand carvings, all of which");
            Console.WriteLine("blended into a single piece of art. You are sure that this cannot be that easy, but you have to try. You pushed");
            Console.WriteLine("the door strongly but they stayed closed only two statues of gargoyles on high walls started to red-glowing.");
            Console.WriteLine("The statues seemed such an ominous guard. You stepped back and you felt loose rock in the floor under you shoes.");
            Console.WriteLine("You kneeled down and pick up the rock. In the same moment when you saw parchment in the hole in the floor, the door");
            Console.WriteLine("started to red-glowing and you knew that somehow this two items are connected.");
            Console.WriteLine("With trembling hands you lay out parchment on the floor. On a start there was nothing on it, but after few second");
            Console.WriteLine("first pale letters and finally full sentence appear on it. You took the paper and move it up to your face.");
            Console.WriteLine("Reading in the dark was hard but not impossible...");
            Console.WriteLine("");
            Console.WriteLine("'I WILL LET YOU FREE IF YOU SOLVE MY RIDDLE. DO YOU WANT TO TRY?'");
            Console.WriteLine("");
            Console.WriteLine(" Y / N ");
            Console.WriteLine("");
            Console.WriteLine("Choice: ");
            choice = Console.ReadLine().ToLower();
            Console.Clear();

            switch (choice)
            {
                case "y":
                case "yes":
                    do
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Here is my riddle:");
                        Console.WriteLine("");
                        Console.WriteLine("Truly no one is outstanding without me, nor fortunate. I embrace all those whose hearts ask");
                        Console.WriteLine("for me. He who goes without me goes about in the company of death; and he who bears me will");
                        Console.WriteLine("remain lucky for ever.But I stand lower than earth and higher than heaven.");
                        Console.WriteLine("");
                        Console.WriteLine("(W)isdom | (H)appiness | (P)atience | (M)eeknes");
                        Console.WriteLine("");
                        Console.WriteLine("Choice: ");
                        secondChoice = Console.ReadLine().ToLower();
                        Console.Clear();
                        switch (secondChoice)
                        {
                            case "w":
                            case "wisdom":
                                Console.WriteLine("");
                                Console.WriteLine("No, try again...");
                                Console.ReadLine();
                                Console.Clear();
                                break;
                            case "h":
                            case "happiness":
                                Console.WriteLine("");
                                Console.WriteLine("No, try again...");
                                Console.ReadLine();
                                Console.Clear();
                                break;
                            case "p":
                            case "patience":
                                Console.WriteLine("");
                                Console.WriteLine("No, try again...");
                                Console.ReadLine();
                                Console.Clear();
                                break;
                            case "m":
                            case "meeknes":
                                Console.WriteLine("");
                                Console.WriteLine("Door opens silently...");
                                Console.WriteLine("You look around for the last time and you feel inner urge to check one more time hiding spot in");
                                Console.WriteLine("the floor. You kneeled down again and examine very conscientiously whole hidden spot. ");
                                Console.WriteLine("To your enormous disappointment, you cannot find anything useful or helpful, there is only one");
                                Console.WriteLine("thing in the hole, and that is small black diamond. After some hesitation you decide to put");
                                Console.WriteLine("this gem into your pocket.");
                                Console.WriteLine("");
                                Console.WriteLine("With a feeling of misgiving you pushed straight through the door...");
                                Console.WriteLine("");
                                Console.WriteLine("Now you know that your concerns were justified..");
                                Console.WriteLine(@"

                       _             _,-----------._        ___
                      (_,.-      _,-'_,-----------._`-._    _)_)
                          |     ,'_,-'  ___________  `-._`.
                        `'   ,','  _,-'___________`-._  `.`.
                           ,','  ,'_,-'     .     `-._`.  `.`.
                          /,'  ,','        >|<        `.`.  `.\
                             ,','      ><  ,^.  ><      `.`.  \\
                            /,'      ><   / | \   ><      `.\  \\
                           //      ><    \/\^/\/    ><      \\  \\
                      ;;  ;;              `---'              ::  ::
                      ||  ||              (____              ||  ||
                     _||__||_            ,'----.            _||__||_
                    (o.____.o)____        `---'        ____(o.____.o)
                      |    | /,--.)                   (,--.\ |    |
                      |    |((  -`___               ___`   ))|    |
                      |    | \\,'',  `.           .'  .``.// |    |
                      |    |  // (___,'.         .'.___) \\  |    |
                     /|    | ;;))  ____) .     . (____  ((\\ |    |\
                     \|.__ | ||/ .'.--.\/       `/,--.`. \;: | __,|;
                      |`-,`;.| :/ /,'  `)-'   `-('  `.\ \: |.;',-'|
                      |   `..  ' / \__.'         `.__/ \ `  ,.'   |
                      |    |,\  /,                     ,\  /,|    |
                      |    ||: : )          .          ( : :||    |
                     /|    |:; |/  .      ./|\,      ,  \| :;|    |\
                     \|.__ |/  :  ,/-    <--:-->    ,\.  ;  \| __,|;
                      |`-.``:   `'/-.     '\|/`     ,-\`;   ;'',-'|
                      |   `..   ,' `'       '       `  `.   ,.'   |
                      |    ||  :                         :  ||    |
                      |    ||  |                         |  ||    |
                      |    ||  |                         |  ||    |
                      |    |'  |            _            |  `|    |
                      |    |   |          '|))           |   |    |
                      ;____:   `._        `'           _,'   ;____:
                     {______}     \___________________/     {______}
                     |______|_______________________________|______|
");
                                Console.ReadLine();
                                Console.Clear();
                                Encounters.basicEncounter();
                                break;
                        }
                    } while (secondChoice != "m");

                    break;
                case "n":
                case "no":
                    Encounters.basicEncounter();
                    Console.ReadLine();
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("If you cannot press the button proper I am pretty sure you cannot solve my riddle!");
                    gameOver();
                    break;
            }
        }

        public static void thirdChapter()
        {
            List<char> chars = new char[] { '@', '#', '$', '%', '&', '*', 'V', '^', 'N', 'F' }.ToList();
            List<int> positions = new List<int>();
            char c = chars[rnd.Next(0, 10)];
            chars.Remove(c);
            Console.Clear();
            Console.WriteLine("You are walking down a hall. You see that floor is covered in runes.");

            int e = 0;
            while (e < 4)
            {
                int f = 0;
                int pos = rnd.Next(0, 4);
                positions.Add(pos);
                while (f < 4)
                {
                    if (f == pos)
                        Console.Write(c + " ");
                    else
                        Console.Write(chars[rnd.Next(0, 8)] + " ");
                    f++;
                }
                Console.WriteLine();
                e++;
            }

            Console.WriteLine("Choose your path...");
            Console.WriteLine("Type the position of the rune you want to stand on.");
            for (int i = 0; i < 4; i++)
            {
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out int input) && input < 5 && input > 0)
                    {
                        if (positions[i] == input - 1)
                            break;
                        else
                            Console.WriteLine("Darts fly out of the walls. You take 2 damage.");
                        Program.currentPlayer.health -= 2;
                        if (Program.currentPlayer.health <= 0)
                        {
                            //Player is dead
                            Console.ReadLine();
                            Console.Clear();
                            Console.WriteLine("You took a deep breath. It hurt your ribcage. You exhaled, inhaled again, and tried");
                            Console.WriteLine("to inched your arms under you and pushed yourself up on your hands and knees, it did not work.");
                            Console.WriteLine("Your head swam. You felt your stomach tighten and you threw up, which hurt the ribs even more.");
                            Console.WriteLine("Everything blurred for a minute, you inhaled some more unfortunately that was your last breath.");
                            Console.ReadKey();
                            Program.gameOver();
                        }
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Use whole numbers only (from 1 to 4)...");
                    }
                }
            }
            Console.WriteLine("You have successfully cross the hallway");

        }

        public static void fourtChapter()
        {
            string choice;
            Console.WriteLine("You can go in 3 different directions ");
            Console.WriteLine("Choice: ");
            choice = Console.ReadLine().ToLower();
            Console.Clear();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Your fist pound int Mr torm face");
                    break;
                case "2":
                    Console.WriteLine("Your fist pound int Mr torm face");
                    break;
                case "3":
                    Console.WriteLine("Your fist pound int Mr torm face");
                    secondChapter();
                    break;
                default:
                    Console.WriteLine("I do not understand this command...");
                    firstChapter();
                    break;
            }
        }
        public static void fifthChapter()
        {

        }
        public static void sixthChapter()
        {
            Random rnd = new Random();
            string[] sixthChapterOption = {
                    "Around the corner you can see big fat jaba",
                    "You decide to quit your crazy life and live on WWW",
                    "You scared about the future so you kill yourself."};

            int randomNumber = rnd.Next(0, 3);
            string sixthText = sixthChapterOption[randomNumber];

            string sixthChoice;
            Console.WriteLine(sixthText);
            Console.WriteLine("Did you try therapy? YES or NO");
            Console.WriteLine("Choice: ");
            sixthChoice = Console.ReadLine().ToLower();
            Console.Clear();

            if (sixthChoice == "yes" || sixthChoice == "y")
            {
                youWin();
            }
            else if (sixthChoice == "no" || sixthChoice == "n")
            {
                Console.WriteLine("A meteor slams into the place you were staying. All what left of you is dust.");
                Console.WriteLine("Press 'ENTER' to countinue.");
                Console.ReadLine();
                gameOver();
            }
            else
            {
                Console.WriteLine("I do not understand this command...");
                Console.WriteLine("Just try again you loser");
                sixthChapter();
            }

        }

        public static void loadGame()
        {
//
        }

        public static void youWin()
        {
            Console.Clear();
            Console.WriteLine("At you funeral they play songs about your bravery.");
            Console.WriteLine("Better luck next time.");
            Console.WriteLine("Press 'ENTER' to try again.");
            Console.ReadLine();
            Console.Clear();
            firstChapter();
        }

        public static void gameOver()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine(@"
                ┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼
                ███▀▀▀██┼███▀▀▀███┼███▀█▄█▀███┼██▀▀▀
                ██┼┼┼┼██┼██┼┼┼┼┼██┼██┼┼┼█┼┼┼██┼██┼┼┼
                ██┼┼┼▄▄▄┼██▄▄▄▄▄██┼██┼┼┼▀┼┼┼██┼██▀▀▀
                ██┼┼┼┼██┼██┼┼┼┼┼██┼██┼┼┼┼┼┼┼██┼██┼┼┼
                ███▄▄▄██┼██┼┼┼┼┼██┼██┼┼┼┼┼┼┼██┼██▄▄▄
                ┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼
                ███▀▀▀███┼▀███┼┼██▀┼██▀▀▀┼██▀▀▀▀██▄┼
                ██┼┼┼┼┼██┼┼┼██┼┼██┼┼██┼┼┼┼██┼┼┼┼┼██┼
                ██┼┼┼┼┼██┼┼┼██┼┼██┼┼██▀▀▀┼██▄▄▄▄▄▀▀┼
                ██┼┼┼┼┼██┼┼┼██┼┼█▀┼┼██┼┼┼┼██┼┼┼┼┼██┼
                ███▄▄▄███┼┼┼─▀█▀┼┼─┼██▄▄▄┼██┼┼┼┼┼██▄
                ┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼
                ┼┼┼┼┼┼┼┼██┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼██┼┼┼┼┼┼┼┼┼
                ┼┼┼┼┼┼████▄┼┼┼▄▄▄▄▄▄▄┼┼┼▄████┼┼┼┼┼┼┼
                ┼┼┼┼┼┼┼┼┼▀▀█▄█████████▄█▀▀┼┼┼┼┼┼┼┼┼┼
                ┼┼┼┼┼┼┼┼┼┼┼█████████████┼┼┼┼┼┼┼┼┼┼┼┼
                ┼┼┼┼┼┼┼┼┼┼┼██▀▀▀███▀▀▀██┼┼┼┼┼┼┼┼┼┼┼┼
                ┼┼┼┼┼┼┼┼┼┼┼██┼┼┼███┼┼┼██┼┼┼┼┼┼┼┼┼┼┼┼
                ┼┼┼┼┼┼┼┼┼┼┼█████▀▄▀█████┼┼┼┼┼┼┼┼┼┼┼┼
                ┼┼┼┼┼┼┼┼┼┼┼┼███████████┼┼┼┼┼┼┼┼┼┼┼┼┼
                ┼┼┼┼┼┼┼┼▄▄▄██┼┼█▀█▀█┼┼██▄▄▄┼┼┼┼┼┼┼┼┼
                ┼┼┼┼┼┼┼┼▀▀██┼┼┼┼┼┼┼┼┼┼┼██▀▀┼┼┼┼┼┼┼┼┼
                ┼┼┼┼┼┼┼┼┼┼▀▀┼┼┼┼┼┼┼┼┼┼┼▀▀┼┼┼┼┼┼┼┼┼┼┼
                ┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼

        ");
            Console.WriteLine("That was hell of a ride...");
            Console.WriteLine("Press 'ENTER' to try again.");
            Console.ReadLine();
            Console.Clear();
            gameTitle();
        }
    }
}

