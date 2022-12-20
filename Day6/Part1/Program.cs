using System;
using System.IO;
using System.Linq;

namespace Part1
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = File.ReadAllText("/Users/adamkuhns/Desktop/Advent of Code-2022/Day6/input.txt");
            char[] lineChar = input.ToCharArray();
            for (int i =0; i < lineChar.Length - 3; i++)
            {
                char[] check = {lineChar[i], lineChar[i+1], lineChar[i+2], lineChar[i+3] };
                //Console.WriteLine(check);
                bool uniq = true;

                if (check.Count() != check.Distinct().Count())
                {
                    uniq = false;
                }

                if (uniq)
                {
                    Console.WriteLine(check);
                    Console.WriteLine(i+4);
                    break;
                }

                
            }
        }
    }
}
