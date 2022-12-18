using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Part1
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = File.ReadAllText("/Users/adamkuhns/Desktop/Advent of Code-2022/Day5/input.txt");
            string[] lines = input.Split('\n');

            List<char>[] stacks = new List<char>[10];
            for (int i = 0; i < stacks.Length; i++)
                stacks[i] = new List<char>();


            foreach (string line in lines)
            {
                char[] lineChar = line.ToCharArray();
                int count = 0;
                foreach (char x in lineChar)
                {
                    count++;
                    if(x != '[' && x != ']' && x != ' ' && x != '1' && x != 'm')
                    {
                        if (count == 2)
                        {
                            stacks[0].Insert(0, x);
                            //Console.WriteLine(x + " : " + "0");
                        }
                        else
                        {
                            int place = count / 4;
                            stacks[place].Insert(0, x);
                            //Console.WriteLine(x + " : " + place);
                        }

                        
                    }
                    if(x == '1')
                    {
                        break;
                    }
                    if (x == 'm')//movement
                    {
                        int moveNum = 0;
                        int fromNum = 0;
                        int toNum = 0;
                        if (lineChar[6] == ' ') //single digit
                        {
                            moveNum = lineChar[5] - '0';
                            fromNum = (lineChar[12] - '0')-1;
                            toNum = (lineChar[17] - '0')-1;   
                        }
                        if (lineChar[6] != ' ') //double digit
                        {
                            string dblDig = lineChar[5] +""+ lineChar[6];

                            moveNum = Int32.Parse(dblDig);
                            fromNum = (lineChar[13] - '0') - 1;
                            toNum = (lineChar[18] - '0') - 1;
                        }

                        for (int a = 0; a < moveNum; a++)
                        {
                            char move = stacks[fromNum].Last();
                            stacks[fromNum].RemoveAt(stacks[fromNum].Count - 1);
                            stacks[toNum].Add(move);
                        }


                        //Console.WriteLine(lineChar);
                        for (int y = 0; y < stacks.Length; y++)
                        {
                            for (int z = 0; z < stacks[y].Count; z++)
                            {
                                Console.Write(stacks[y][z]);
                            }
                            Console.WriteLine();
                        }

                        break;
                    }

                }

            }
            Console.WriteLine("FINAL OUTPUT:");
            for (int y = 0; y < stacks.Length; y++)
            {
                for (int z = 0; z < stacks[y].Count; z++)
                {
                    Console.Write(stacks[y][z]);
                }
                Console.WriteLine();
            }
        }
    }
}
