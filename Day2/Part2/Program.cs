using System;
using System.IO;

namespace Day2_Part2
{
    class Program
    {
        static void Main(string[] args)
        {
            string strategy = File.ReadAllText("/Users/adamkuhns/Desktop/Advent of Code-2022/Day 2/input.txt");
            string[] games = strategy.Split('\n');

            //column #1 OPPONENT A B C = rock paper scissors
            //column #2 YOU X Y Z =      lose draw win

            //11420 to low

            int score = 0;
            int opnt = 0;
            int you = 0;
            foreach (string play in games)
            {

                string[] plays = play.Split(' ');
                switch (plays[0])
                {
                    case "A":
                        opnt = 1;
                        break;
                    case "B":
                        opnt = 2;
                        break;
                    case "C":
                        opnt = 3;
                        break;
                }
                switch (plays[1])
                {
                    case "X"://lose
                        if (opnt == 1)
                        {
                            you = 3;
                        }
                        else { you = opnt -1; }
                        break;
                    case "Y"://draw
                        you = opnt;
                        break;
                    case "Z"://win
                        if (opnt == 3)
                        {
                            you = 1;
                        }
                        else { you = opnt + 1; }
                        break;
                }

                if ((opnt - you) == 0) //tie
                {
                    score = score + (you + 3);
                }
                if ((((you - opnt) + 3) % 3) == 1) //win
                {
                    score = score + (you + 6);
                }
                if ((((you - opnt) + 3) % 3) == 2) //lose
                {
                    score = score + (you + 0);
                }


            }
            Console.WriteLine(score);
        }
    }
}
