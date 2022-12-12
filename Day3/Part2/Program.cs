using System;
using System.Collections.Generic;
using System.IO;
//1007 to low
//3040 to high
namespace Day3P2
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = File.ReadAllText("/Users/adamkuhns/Desktop/Advent of Code-2022/Day3/input.txt");
            string[] rucksack = input.Split('\n');
            int total = 0;


            for (int i = 0; i < (rucksack.Length)-2; i++)
            {
                char[] cp1Arr = rucksack[i].ToCharArray();

                for (int y = 0; y < cp1Arr.Length; y++)
                {
                    if (rucksack[i + 1].Contains(cp1Arr[y]) && rucksack[i + 2].Contains(cp1Arr[y]))
                    {
                        i = i + 2;
                        if (Char.IsUpper(cp1Arr[y]))
                        {
                            total = total + (((int)cp1Arr[y]) - 38);
                            Console.Write(((int)cp1Arr[y]) - 38);
                        }
                        else
                        {
                            total = total + (((int)cp1Arr[y]) - 96);
                            Console.Write(((int)cp1Arr[y]) - 96);
                        }
                        Console.WriteLine();
                        //Console.WriteLine(cp1Arr[y]);
                        break;
                    }
                }

            }
            Console.WriteLine(total);
        }
    }
}
