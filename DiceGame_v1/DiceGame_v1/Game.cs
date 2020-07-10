using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame_v1
{
    class Game
    {
        //-----DECLARES PLAYER NUMBER VARIABLE
        public static int playerNumber = 0;

        //-----MAIN METHOD APPLICATION START
        static void Main(string[] args)
        {
            //-----DISPLAYS ON APPLICATION START
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Welcome to DiceGame v1.0.0");
            Console.WriteLine("--------------------------");
            Console.WriteLine("|1|         PLAY         |");
            Console.WriteLine("|2|         EXIT         |");
            Console.WriteLine("--------------------------");
            Console.WriteLine("{0:d}         {0:t}", DateTime.Now);
            //-----CHECKS KEY INPUT FOR QUERY AND TAKES APPROPRIATE ACTION
            startQuery:
            ConsoleKeyInfo cki = Console.ReadKey(true);
            switch (cki.Key)
            {
                case ConsoleKey.D1: Console.WriteLine("\nLoading...");
                    System.Threading.Thread.Sleep(1000);
                    Player.playerMaxScore();
                    DiceGame();
                    break;
                case ConsoleKey.D2: Console.WriteLine("\nExiting...");
                    System.Threading.Thread.Sleep(1000);
                    Environment.Exit(0);
                    break;
                default: goto startQuery;
            }
        }

        //-----DICE GAME METHOD
        public static void DiceGame()
        {
            //-----DECLARES GAME WINNER STRING
            string gameWinner = "";

            //-----GAME NESTED IN A WHILE LOOP UNTIL THE USER DEFINED SCORE IS MET
            while (Player.scoreOne < Player.scoreMax && Player.scoreTwo < Player.scoreMax)
            {
                //-----STARTS WITH PLAYER ONE, QUERIES THE DICE ROLL AND CALLS THE APPROPRIATE METHODS
                playerNumber = 1;
                queryOne:
                Die.rollOnce = false;
                Console.Clear();
                Console.WriteLine("Player {0}: Press 'R' to roll / 'T' to throw all dice once", playerNumber);
                ConsoleKeyInfo ckiOne = Console.ReadKey(true);
                if (ckiOne.Key == ConsoleKey.R)
                {
                    Die.dieRoll();
                }
                else if (ckiOne.Key == ConsoleKey.T)
                {
                    Die.rollOnce = true;
                    Die.dieRoll();
                }
                else
                {
                    Console.WriteLine("Please press the 'R/T' key.");
                    System.Threading.Thread.Sleep(100);
                    goto queryOne;
                }

                //-----MOVES ON TO PLAYER TWO, QUERIES THE DICE ROLL AND CALLS THE APPROPRIATE METHODS
                playerNumber = 2;
                queryTwo:
                Die.rollOnce = false;
                Console.Clear();
                Console.WriteLine("Player {0}: Press 'R' to roll / 'T' to throw all dice once", playerNumber);
                ConsoleKeyInfo ckiTwo = Console.ReadKey(true);
                if (ckiTwo.Key == ConsoleKey.R)
                {
                    Die.dieRoll();
                }
                else if (ckiTwo.Key == ConsoleKey.T)
                {
                    Die.rollOnce = true;
                    Die.dieRoll();
                }
                else
                {
                    Console.WriteLine("Please press the 'R/T' key.");
                    System.Threading.Thread.Sleep(100);
                    goto queryTwo;
                }
            }

            //-----IF AND ELSE IF STATEMENTS SET THE GAMEWINNER STRING TO CORRECT VALUE
            if (Player.scoreOne > Player.scoreTwo)
            {
                gameWinner = "Player One";
            }
            else if (Player.scoreOne < Player.scoreTwo)
            {
                gameWinner = "Player Two";
            }
            else if (Player.scoreOne == Player.scoreTwo)
            {
                gameWinner = "(Draw) N/A";
            }

            //-----DISPLAYS END GAME SCREEN
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("|        GAME OVER        |");
            Console.WriteLine("|{0} is the winner!|", gameWinner);
            Console.WriteLine("---------------------------");
            Console.WriteLine("Player 1 Score: {0}", Player.scoreOne);
            Console.WriteLine("Player 2 Score: {0}", Player.scoreTwo);
            System.Threading.Thread.Sleep(5000);
            Console.WriteLine("\n\nExiting...");
            System.Threading.Thread.Sleep(1000);
            Environment.Exit(0);
        }
    }
}
