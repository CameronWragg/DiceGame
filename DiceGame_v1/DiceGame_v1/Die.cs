using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame_v1
{
    class Die
    {
        //-----DECLARES RANDOM NUMBER VARIABLE, INTEGER ARRAYS AND BOOLEANS
        public static Random r = new Random();
        public static int[] dieNos = new int[5]{0, 0, 0, 0, 0};
        public static int[] dieReNos = new int[5]{0, 0, 0, 0, 0};
        public static bool reRolled = false;
        public static bool rollOnce = false;

        //-----DICE ROLL METHOD
        public static void dieRoll()
        {
            //-----FOR LOOP TO 'ROLL 5 DIE' GENERATING 5 RANDOM NUMBERS BETWEEN 1 AND 6
            for (int i = 0; i < 5; i++)
            { 
                dieNos[i] = r.Next(1, 7);
            }
            //-----WRITES THE PLAYER PLAYING AND OUTCOME OF THE ROLL
            Console.Clear();
            Console.WriteLine("-------------------------");
            Console.WriteLine("+ Player {0} Roll Outcome +", Game.playerNumber);
            Console.WriteLine("+ | {0} | {1} | {2} | {3} | {4} | +", dieNos[0], dieNos[1], dieNos[2], dieNos[3], dieNos[4]);
            Console.WriteLine("-------------------------");
            //-----SORTS THE DIE NUMBERS ARRAY
            Array.Sort(dieNos);
            //-----SETS RE ROLLED BOOLEAN TO FALSE
            reRolled = false;
            //-----CALLS DICE MATCHING METHOD
            dieMatch();
        }

        //-----DICE MATCH METHOD
        public static void dieMatch()
        {
            //-----CHECKS FOR 5 OF A KIND WITH THE SORTED ARRAY
            if (dieNos[0] == dieNos[4])
            {
                Console.WriteLine("Congratulations! (5-of-a-kind)");
                System.Threading.Thread.Sleep(1500);
                if (Game.playerNumber == 1)
                {
                    Player.scoreOne = Player.scoreOne + 12;
                    if (rollOnce == true) { Player.scoreOne = Player.scoreOne + 12; }
                    else { Player.scoreOne = Player.scoreOne + 0; }
                }
                else if (Game.playerNumber == 2)
                {
                    Player.scoreTwo = Player.scoreTwo + 12;
                    if (rollOnce == true) { Player.scoreTwo = Player.scoreTwo + 12; }
                    else { Player.scoreTwo = Player.scoreTwo + 0; }
                }
            }
            //-----CHECKS FOR 4 OF A KIND
            else if (dieNos[0] == dieNos[3] || dieNos[1] == dieNos[4])
            {
                Console.WriteLine("Wowe! (4-of-a-kind)");
                System.Threading.Thread.Sleep(1500);
                if (Game.playerNumber == 1)
                {
                    Player.scoreOne = Player.scoreOne + 6;
                    if (rollOnce == true) { Player.scoreOne = Player.scoreOne + 6; }
                    else { Player.scoreOne = Player.scoreOne + 0; }
                }
                else if (Game.playerNumber == 2)
                {
                    Player.scoreTwo = Player.scoreTwo + 6;
                    if (rollOnce == true) { Player.scoreTwo = Player.scoreTwo + 6; }
                    else { Player.scoreTwo = Player.scoreTwo + 0; }
                }
            }
            //-----CHECKS FOR 3 OF A KIND
            else if (dieNos[0] == dieNos[2] || dieNos[1] == dieNos[3] || dieNos[2] == dieNos[4])
            {
                Console.WriteLine("Winner! (3-of-a-kind)");
                System.Threading.Thread.Sleep(1500);
                if (Game.playerNumber == 1)
                {
                    Player.scoreOne = Player.scoreOne + 3;
                    if (rollOnce == true) { Player.scoreOne = Player.scoreOne + 3; }
                    else { Player.scoreOne = Player.scoreOne + 0; }
                }
                else if (Game.playerNumber == 2)
                {
                    Player.scoreTwo = Player.scoreTwo + 3;
                    if (rollOnce == true) { Player.scoreTwo = Player.scoreTwo + 3; }
                    else { Player.scoreTwo = Player.scoreTwo + 0; }
                }
            }
            //-----CHECKS FOR 2 MATCHES, OFFERS REROLL IF RADO OR REROLLED ALREADY ARENT TRUE
            else if (dieNos[0] == dieNos[1] || dieNos[1] == dieNos[2] || dieNos[2] == dieNos[3] || dieNos[3] == dieNos[4])
            {
                Console.Write("Unlucky!");
                if (rollOnce == true) { Console.WriteLine(" Cannot ReRoll"); System.Threading.Thread.Sleep(1500); }
                else if (!reRolled)
                {
                    Console.Write(" (ReRoll? Y/N)\n");
                    rrQuery:
                    ConsoleKeyInfo cki = Console.ReadKey(true);
                    switch (cki.Key)
                    {
                        case ConsoleKey.Y:
                            dieReRoll();
                            break;
                        case ConsoleKey.N:
                            reRolled = false;
                            break;
                        default: goto rrQuery;
                    }
                }
                else if (reRolled == true)
                {
                    Console.WriteLine(" Already ReRolled");
                    System.Threading.Thread.Sleep(1500);
                }
            }
            //-----NO MATCHES
            else {
                Console.WriteLine("No Matches :(");
                System.Threading.Thread.Sleep(1500);
            }
        }

        //-----DICE RE ROLL METHOD
        public static void dieReRoll()
        {
            //-----ROLLS A SEPARATE SET OF 5 DICE
            for (int i = 0; i < 5; i++)
            {
                dieReNos[i] = r.Next(1, 7);
            }
            //-----IF AND ELSE IF STATEMENTS CHECK FOR THE MATCHED NUMBERS TO KEEP AND CHANGES THE CORRECT ARRAY ITEMS TO THE NEW RANDOM NUMBERS
            if (dieNos[0] == dieNos[1])
            {
                dieReNos[0] = dieNos[0];
                dieReNos[1] = dieNos[1];
            }
            else if (dieNos[1] == dieNos[2])
            {
                dieReNos[1] = dieNos[1];
                dieReNos[2] = dieNos[2];
            }
            else if (dieNos[2] == dieNos[3])
            {
                dieReNos[2] = dieNos[2];
                dieReNos[3] = dieNos[3];
            }
            else if (dieNos[3] == dieNos[4])
            {
                dieReNos[3] = dieNos[3];
                dieReNos[4] = dieNos[4];
            }
            //-----SETS REROLLED TO TRUE AND DISPLAYS THE RE ROLLED DICE
            reRolled = true;
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("+ Player {0} ReRoll Outcome +", Game.playerNumber);
            Console.WriteLine("+  | {0} | {1} | {2} | {3} | {4} |  +", dieReNos[0], dieReNos[1], dieReNos[2], dieReNos[3], dieReNos[4]);
            Console.WriteLine("---------------------------");
            dieNos = dieReNos;
            //-----SORTS AND MATCHES AGAIN
            Array.Sort(dieNos);
            dieMatch();
        }
    }
}
