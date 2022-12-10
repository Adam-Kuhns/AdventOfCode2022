using System;
using System.IO;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            string elves = File.ReadAllText("/Users/adamkuhns/Desktop/Advent of Code-2022/Day 1/input.txt");

            int[] topThree = new int[3];

            int total = 0;
            string[] calories = elves.Split('\n');
            foreach(string x in calories)
            {
                if(x == "")
                {
                    total = 0;
                }
                else
                {
                    int value = Int32.Parse(x);
                    total = total + value;
                }
               
                if(total > topThree[2] && total < topThree[1])
                {
                    topThree[2] = total;
                }
                if (total > topThree[1] && total < topThree[0])
                {
                    topThree[2] = topThree[1];
                    topThree[1] = total;
                }
                if (total > topThree[0])
                {
                    topThree[1] = topThree[0];
                    topThree[0] = total;
                }
            }

            int grandTotal = 0;
            foreach (int i in topThree) { grandTotal = grandTotal + i; }
            Console.WriteLine(grandTotal);
        }
    }
}
