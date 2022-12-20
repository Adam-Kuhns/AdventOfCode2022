using System;
using System.IO;
using System.Linq;

namespace Part2
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = File.ReadAllText("/Users/adamkuhns/Desktop/Advent of Code-2022/Day6/input.txt");
            char[] lineChar = input.ToCharArray();
            for (int i = 0; i < lineChar.Length - 13; i++)
            {
                char[] check = new char[14];
                for (int y = 0; y < 14; y++)
                {
                    check[y] = lineChar[i + y];
                }

                //Console.WriteLine(check);
                bool uniq = true;

                if (check.Count() != check.Distinct().Count())
                {
                    uniq = false;
                }

                if (uniq)
                {
                    Console.WriteLine(check);
                    Console.WriteLine(i + 14);
                    break;
                }
            }
        }
    }
}
