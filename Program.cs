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
            while (true)
            {           
            gameMenu();
            firstChapter();
            Encounters.firstEncounter();
            Player.playerStats();
            secondChapter();
            Player.playerStats();
            thirdChapter();
            Player.playerStats();
            fourthChapter();
            Player.playerStats();
            fifthChapter();
            }
        }

        public static void gameMenu()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            makeMenuOptions();

            bool choiceValid = false;
            while (!choiceValid)
            {
                string choice = Console.ReadLine().ToUpper();
                if (choice == "S" ||  choice == "C")
                {
                    choiceValid = true;                  
                    if (choice == "S")
                    {
                        gameTitle();
                    }
                    else if (choice == "C")
                    {
                        Player.newPlayer();
                        gameTitle();
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
            asciiTitle();
            Console.WriteLine("(S)tart a new game");
            Console.WriteLine("(C)reate new character");
            Console.WriteLine("");
        }

        public static void gameTitle()
        {
            Console.Clear();
            Adventure adventuresDescription = jsonReader();
            Console.WriteLine($"{adventuresDescription.Title}");
            Console.WriteLine($"{adventuresDescription.gameTitleDescription}");
            Console.ReadLine();
            Console.Clear();
        }

        private static Adventure jsonReader()
        {
            var basePath = $"{AppDomain.CurrentDomain.BaseDirectory}adventures";
            var adventuresDescription = new Adventure();
            if (File.Exists($"{basePath}\\initial.json"))
            {
                var directory = new DirectoryInfo(basePath);
                var initialJsonFile = directory.GetFiles("initial.json");
                using (StreamReader fi = File.OpenText(initialJsonFile[0].FullName))
                {
                    adventuresDescription = JsonConvert.DeserializeObject<Adventure>(fi.ReadToEnd());
                }
            }
            return adventuresDescription;
        }

        public static void firstChapter()
        {
            Adventure adventuresDescription = jsonReader();
            Console.WriteLine($"{adventuresDescription.firstChapterDescription}");
            Console.ReadLine();
            Console.Clear();
            asciiSpiders();
            Console.ReadLine();
            Console.Clear();
        }


        public static void secondChapter()
        {

            string choice, secondChoice;
            Adventure adventuresDescription = jsonReader();
            Console.WriteLine($"{adventuresDescription.secondChapterDescription}");
            choice = Console.ReadLine().ToLower();
            Console.Clear();

            switch (choice)
            {
                case "y":
                case "yes":
                    do
                    {
                        Console.WriteLine($"{adventuresDescription.secondChapterRiddle}");
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
                                Console.WriteLine($"{adventuresDescription.secondChapterPropAnswer}");
                                Program.currentPlayer.health += 2;
                                Console.ReadLine();
                                Console.Clear();
                                Player.playerStats();
                                asciiDoor();                                
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
                    break;
                default:
                    Console.WriteLine("If you cannot press the button proper I am pretty sure you cannot solve my riddle!");
                    gameOver();
                    break;
            }
        }

        public static void thirdChapter()
        {
            Console.Clear();
            Adventure adventuresDescription = jsonReader();
            Console.WriteLine($"{adventuresDescription.thirdChapterDescription}");

            List<int> positions = runesGenerator();
            for (int i = 0; i < 4; i++)
            {
                bool choiceValid = false;
                while (!choiceValid)
                {
                    if (int.TryParse(Console.ReadLine(), out int input) && input < 5 && input > 0)
                    {
                        if (positions[i] == input - 1)
                            break;
                    }
                    else
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Poisoned darts fly out of the walls...");
                        Console.ReadLine();
                        Console.Clear();
                        gameOver();
                        choiceValid = false;
                    }
                }
            }
        }

        private static List<int> runesGenerator()
        {
            Console.WriteLine("");
            List<char> chars = new char[] { '@', '#', '$', '%', '&', '*', 'V', '^', 'N', 'F' }.ToList();
            List<int> positions = new List<int>();
            char c = chars[rnd.Next(0, 10)];
            chars.Remove(c);
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
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Choose your path, find the pattern in each row...");
            Console.WriteLine("");
            Console.WriteLine("Type the position of the rune (number from 1 to 4), press ENTER and type another position you want to stand on.");
            return positions;
        }

        public static void fourthChapter()
        {
            Program.currentPlayer.health += 2;
            Adventure adventuresDescription = jsonReader();
            Console.WriteLine($"{adventuresDescription.fourthChapterDescription}");
            Program.currentPlayer.health += 3;
            Program.currentPlayer.health += 2;
            Console.ReadLine();
            Console.Clear();
        }

        public static void fifthChapter()
        {
            string choice;
            Adventure adventuresDescription = jsonReader();
            Console.WriteLine($"{adventuresDescription.fifthChapterDescription}");
            choice = Console.ReadLine().ToLower();
            Console.Clear();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("");
                    Console.WriteLine("You feel weak and little dizzy...");
                    firstChapter();
                    break;
                case "2":
                    Encounters.sergeEncounter();
                    if (Program.currentPlayer.health <= 0)
                    {
                        //Player is dead
                        Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine($"{adventuresDescription.playerIsDead}");
                        Console.ReadKey();
                        Program.gameOver();
                    } else
                    {
                        youWin();
                    }
                    break;
                case "3":
                    Console.WriteLine("You tourned the door handle and in the same time you felt like thousand little nedles");
                    Console.WriteLine("Poisoned darts fly out of the walls...");
                    gameOver();
                    break;
                default:
                    Console.WriteLine("I do not understand this command...");
                    break;
            }
        }


        public static void youWin()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("CONGRATULATIONS!!");
            asciiYouWon();
            Console.WriteLine("");
            Console.WriteLine("Press 'ENTER' if you want to play again");
            Console.ReadLine();
            Console.Clear();
            gameMenu();
        }

        public static void gameOver()
        {
            Console.Clear();
            Console.WriteLine("");
            asciiGameOver();
            Console.WriteLine("That was hell of a ride...");
            Console.WriteLine("Press 'ENTER' if you want to play again");
            Console.ReadLine();
            Console.Clear();
            gameMenu();
        }

        public static void asciiTitle()
        {
            Console.WriteLine(@"

████████╗██╗░░██╗███████╗  ██╗░░░██╗███╗░░██╗██████╗░███████╗██████╗░██████╗░░█████╗░██████╗░██╗░░██╗
╚══██╔══╝██║░░██║██╔════╝  ██║░░░██║████╗░██║██╔══██╗██╔════╝██╔══██╗██╔══██╗██╔══██╗██╔══██╗██║░██╔╝
░░░██║░░░███████║█████╗░░  ██║░░░██║██╔██╗██║██║░░██║█████╗░░██████╔╝██║░░██║███████║██████╔╝█████═╝░
░░░██║░░░██╔══██║██╔══╝░░  ██║░░░██║██║╚████║██║░░██║██╔══╝░░██╔══██╗██║░░██║██╔══██║██╔══██╗██╔═██╗░
░░░██║░░░██║░░██║███████╗  ╚██████╔╝██║░╚███║██████╔╝███████╗██║░░██║██████╔╝██║░░██║██║░░██║██║░╚██╗
░░░╚═╝░░░╚═╝░░╚═╝╚══════╝  ░╚═════╝░╚═╝░░╚══╝╚═════╝░╚══════╝╚═╝░░╚═╝╚═════╝░╚═╝░░╚═╝╚═╝░░╚═╝╚═╝░░╚═╝
");
        }

        public static void asciiSpiders()
        {
            Console.WriteLine(@"
                                   _
       /      \         __      _\( )/_
    \  \  ,,  /  /   | /  \ |    /(O)\ 
     '-.`\()/`.-'   \_\\  //_/    _.._   _\(o)/_  //  \\
    .--_'(  )'_--.   .'/()\'.   .'    '.  /(_)\  _\\()//_
   / /` /`''`\ `\ \   \\  //   /   __   \       / //  \\ \
    |  |  ><  |  |          ,  |   ><   |  ,     | \__/ |
    \  \      /  /         . \  \      /  / .              _
   _    '.__.'    _\(O)/_   \_'--`(  )'--'_/     __     _\(_)/_
_\( )/_            /(_)\      .--'/()\'--.    | /  \ |   /(O)\
 /(O)\  //  \\         _     /  /` '' `\  \  \_\\  //_/
       _\\()//_     _\(_)/_    |        |      //()\\ 
      / //  \\ \     /(o)\      \      /       \\  //
       | \__/ |
");
        }

        public static void asciiDoor()
        {
            Console.WriteLine(@"
                       _             _,-----------._        ___
                      (_,.-      _,-'_,-----------._`-._    _)_)
                          |     ,'_,-'  ___________  `-._`.
                        `'   ,','  _,-'___________`-._  `.`.
                           ,','  ,'_,-'     .     `-._`.  `.`.
                          /,'  ,','        >|<        `.`.  `.\
                         /   ,','      ><  ,^.  ><      `.`.  \\
                        /   /,'      ><   / | \   ><      `.\  \\
                       /   //      ><    \/\^/\/    ><      \\  \\
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
                      |    ||  :                         :  ||    |
                      |    ||  :                         :  ||    |
                      ;____:   `._        `'           _,'   ;____:
                     {______}     \___________________/     {______}
                     |______|_______________________________|______|

");
            Console.WriteLine("");
            Console.WriteLine("Now you know that your concerns were justified..");
        }

        public static void asciiYouWon()
        {
            Console.WriteLine(@"

██╗░░░██╗░█████╗░██╗░░░██╗  ░██╗░░░░░░░██╗░█████╗░███╗░░██╗
╚██╗░██╔╝██╔══██╗██║░░░██║  ░██║░░██╗░░██║██╔══██╗████╗░██║
░╚████╔╝░██║░░██║██║░░░██║  ░╚██╗████╗██╔╝██║░░██║██╔██╗██║
░░╚██╔╝░░██║░░██║██║░░░██║  ░░████╔═████║░██║░░██║██║╚████║
░░░██║░░░╚█████╔╝╚██████╔╝  ░░╚██╔╝░╚██╔╝░╚█████╔╝██║░╚███║
░░░╚═╝░░░░╚════╝░░╚═════╝░  ░░░╚═╝░░░╚═╝░░░╚════╝░╚═╝░░╚══╝
");
        }

        public static void asciiGameOver()
        {
            Console.WriteLine(@"

░██████╗░░█████╗░███╗░░░███╗███████╗  ░█████╗░██╗░░░██╗███████╗██████╗░
██╔════╝░██╔══██╗████╗░████║██╔════╝  ██╔══██╗██║░░░██║██╔════╝██╔══██╗
██║░░██╗░███████║██╔████╔██║█████╗░░  ██║░░██║╚██╗░██╔╝█████╗░░██████╔╝
██║░░╚██╗██╔══██║██║╚██╔╝██║██╔══╝░░  ██║░░██║░╚████╔╝░██╔══╝░░██╔══██╗
╚██████╔╝██║░░██║██║░╚═╝░██║███████╗  ╚█████╔╝░░╚██╔╝░░███████╗██║░░██║
░╚═════╝░╚═╝░░╚═╝╚═╝░░░░░╚═╝╚══════╝  ░╚════╝░░░░╚═╝░░░╚══════╝╚═╝░░╚═╝

");            
        }
    }
}

