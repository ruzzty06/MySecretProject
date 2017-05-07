using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            int cntstCnt = 0;
            bool validInput=false;
            List<int> contestants = new List<int>();
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
                        contestants.Add(tmp);
                    }
                    Console.WriteLine("Invalid value. Must be positive/negative integer.");
                }
            }
            bool done=false;
            int rounds = 0;
            do
            {
                rounds++;


            }
            while (!(done));
            

        }
        static List<int> doRound(List<int> contestants)
        {
            int matches = 0;
            if (contestants.Count % 2 == 0)
            {
                matches = contestants.Count / 2;
            }
            else
                matches = (contestants.Count / 2)+1;
                for (int x = 0; x <= matches; x++)
                {
                    //Default
                    if(matches>(contestants.Count/2))
                        Console.WriteLine(
                    int winner=getWinner(
                }
        }
        static int getWinner(int A, int B)
        {

        }
    }
}
