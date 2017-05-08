using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static bool isLeap { get; set; }
        enum Days { Sun=1, Mon, Tue, Wed, Thu, Fri, Sat };
        
        static void Main(string[] args)
        {
           
            int year = 0;
            
            List<string> months = new List<string> {"January","February","March","April","May","June","July","August","September","October","November","December" };
            List<string> weeks = new List<string> {"Sun","Mon","Tue","Wed","Thu","Fri","Sat" };
            Console.Clear();
            bool validInput=false;
            while (!validInput)
            {
                Console.Write("ENTER YEAR:");
                string inpt=Console.ReadLine();
                if(int.TryParse(inpt,out year))
                {
                    if (year >= 1000 & year < 9999)
                        validInput = true;
                    
                        
                }
                if(!validInput)
                    Console.WriteLine("Invalid year. Must be 4 digit number.");
                
                
            }
            Console.WriteLine("\nCALENDAR "+year+"\n");
            Days dayStart = GetDayofYear(year);
            foreach (string m in months)
            {
                Console.WriteLine(m + " " + year);
                int Tdays = GetNumberofDays(m);
                int day = 1;
                for (int x = 1; x <= 7; x++)
                {
                    Console.Write((Days)x+"\t");
                    if (x == 7)
                        Console.WriteLine();
                }

                Days dayPlot = dayStart;
                for (int x = 1; x < (int)dayStart;x++ )
                {
                    Console.Write("\t");
                }
                while(day<Tdays)
                {
                    while (dayPlot <(Days) 8)
                    {
                        if (day <= Tdays)
                        {
                            Console.Write(day.ToString("00") + "\t");
                            day++;
                            if (dayPlot == (Days)7)
                            {
                                Console.WriteLine();
                                dayPlot = (Days)1;
                            }
                            else
                                dayPlot++;
                        }
                        else
                            break;
                        
                    }
                    
                    
                }
                dayStart = dayPlot;
                Console.WriteLine(); 
                Console.WriteLine();
            }
            Console.ReadLine();
            
        }
        static int GetNumberofDays(string month)
        {
            switch (month)
            {
                case "January":
                case "March":
                case "May":
                case "July":
                case "August":
                case "October":
                case "December":
                    return 31;
                case "February":
                    if(isLeap)
                        return 29;
                    return 28;
                case "April":
                case "June":
                case "September":
                case "November":
                    return 30;
                default:
                    throw new Exception("Unexpected error. Month not found.");

            }
        }
        static Days GetDayofYear(int year)
        {
            int tmpYear=2017;
            Days BaseDay = Days.Sun;
            
            if (year <= tmpYear)
            {
                while (tmpYear > year)
                {
                    isLeap = false;
                    tmpYear--;
                    DecreaseDay(ref BaseDay);
                    if (checkIfLeap(tmpYear))
                    {
                        DecreaseDay(ref BaseDay);
                        isLeap = true;
                    }
                    
                }
            }
            if (year > tmpYear)
            {
                
                while (tmpYear < year)
                {
                    isLeap = false;
                    tmpYear++;
                    IncreaseDay(ref BaseDay);
                    if (checkIfLeap(tmpYear-1))
                    {
                        IncreaseDay(ref BaseDay);
                    }
                    if (checkIfLeap(tmpYear))
                        isLeap = true;

                    
                }
            }
            return BaseDay;
        }
        static void DecreaseDay(ref Days day)
        {
            if (day == (Days)1)
                day = (Days)7;
            else
                day--;
        }
        static void IncreaseDay(ref Days day)
        {
            if (day == (Days)7)
                day = (Days)1;
            else
                day++;
        }
        static bool checkIfLeap(int year)
        {
            if ( year%4 == 0)
            {
                if (year % 100 != 0)
                    return true;
                else if (year % 400==0)
                    return true;
            }
            return false;
                
        }
    }
}
