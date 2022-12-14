using System;
using System.IO;

namespace Part2
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = File.ReadAllText("/Users/adamkuhns/Desktop/Advent of Code-2022/Day4/input.txt");
            string[] pairs = input.Split('\n');
            int total = 0;

            foreach (string pair in pairs)
            {
                string[] ranges = pair.Split(',');
                string[] range1 = ranges[0].Split('-');
                string[] range2 = ranges[1].Split('-');
                int range1Start = Int32.Parse(range1[0]);
                int range1End = Int32.Parse(range1[1]);
                int range2Start = Int32.Parse(range2[0]);
                int range2End = Int32.Parse(range2[1]);

                //5-7, 7-9  yes
                //2-4, 6-8 NO

                if (range1Start >= range2Start &&  range1Start <= range2End || range2Start >= range1Start && range2Start <= range1End)
                {
                    Console.WriteLine(pair);
                    total++;
                }

            }
            Console.WriteLine(total);
        }
    }
}
