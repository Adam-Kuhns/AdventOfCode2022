using System;
using System.IO;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            string strategy = File.ReadAllText("/Users/adamkuhns/Desktop/Advent of Code-2022/Day 2/input.txt");
            string[] games = strategy.Split('\n');

            //column #1 OPPONENT A B C = rock paper scissors
            //column #2 YOU X Y Z =      rock paper scissors

            //1pt for rock 2 for paper 3 for scissors + 6pt for win 3 for draw 0 for loss

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
                    case "X":
                        you = 1;
                        break;
                    case "Y":
                        you = 2;
                        break;
                    case "Z":
                        you = 3;
                        break;
                }
                
                if((opnt - you) == 0) //tie
                {
                    score = score + (you + 3);
                }
                if ((((you - opnt)+3) %3) == 1) //win
                {
                    score = score + (you + 6);
                }
                if ((((you - opnt)+3) %3) == 2) //lose
                {
                    score = score + (you + 0);
                }


            }
            Console.WriteLine(score);
        }
    }
}
