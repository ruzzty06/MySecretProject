using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication2
{
    class Program
    {
        static int RoundCounter { get; set; }
        static List<int> contestants = new List<int>();
        static void Main(string[] args)
        {
            int cntstCnt = 0;
            bool validInput=false;
            
            //get number of contestants
            while (!(validInput))
            {
                Console.Write("Enter the number of Contestant:");
                string inpt = Console.ReadLine();
                if (int.TryParse(inpt, out cntstCnt))
                {
                    if (cntstCnt >=2)
                    {
                        break;
                    }
                }
                Console.WriteLine("Invalid number of Contestants.");
            }
            //get value of each contestant
            for (int x = 1; x <= cntstCnt; x++)
            {
                validInput = false;
                while (!(validInput))
                {
                    int tmp = 0;
                    Console.Write("Enter Contestant # "+x+":");
                    string inpt = Console.ReadLine();
                    if (int.TryParse(inpt, out tmp))
                    {
                        if (isDuplicateContestant(tmp))
                        {
                            Console.WriteLine("Duplicate contestant.");
                        }
                        else
                        {
                            contestants.Add(tmp);
                            validInput = true;
                        }
                        
                    }
                    else
                        Console.WriteLine("Invalid value. Must be positive/negative integer.");
                }
            }
            
            int brackets = 0;
            RoundCounter = 0;
            Console.WriteLine("\n");
            do
            {
                brackets++;
                contestants= doRounds(contestants);
            }
            while (contestants.Count>1);
            Console.WriteLine("\nChampion: " + contestants[0]);
            Console.WriteLine("Total Bracket Matches: " + brackets);
            Console.WriteLine("Total Rounds: " + RoundCounter);
            Console.ReadLine();
        }
        //check if entered contestant is a Duplicate
        static bool isDuplicateContestant(int cont)
        {
            for (int x = 0; x < contestants.Count; x++)
            {
                if (cont == contestants[x])
                    return true;
            }
            return false;
        }
        //do all rounds of one bracket
        static List<int> doRounds(List<int> contestants)
        {
            
            List<int> newContestants = new List<int>();
            int matches = 0;
            if (contestants.Count % 2 == 0)
            {
                matches = contestants.Count / 2;
            }
            else
            matches = (contestants.Count / 2)+1;
            for (int x = 0; x < matches; x++)
            {
                RoundCounter++;
                Console.Write("Round " + RoundCounter + ": ");
                //Default
                if ((x+1) > (contestants.Count / 2))
                {
                    Console.WriteLine("Default Winner is " + contestants[x]);
                    newContestants.Add(contestants[x]);
                }
                else
                {
                    int winner = getWinner(contestants[x], contestants[contestants.Count - (x+1)]);
                    Console.WriteLine(contestants[x]+" vs "+contestants[contestants.Count - (x+1)]+" Winner is " + winner);
                    newContestants.Add(winner);
                }
                
            }
            return newContestants;
        }
        //higher number will be the winner
        static int getWinner(int A, int B)
        {
            if (A > B)
                return A;
            else if (B > A)
                return B;
            else
                throw new Exception("Unexpected error. Contestants have same value.");
        }
    }
}
