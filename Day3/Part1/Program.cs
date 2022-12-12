using System;
using System.IO;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = File.ReadAllText("/Users/adamkuhns/Desktop/Advent of Code-2022/Day3/input.txt");
            string[] rucksack = input.Split('\n');
            int total = 0;
            

            foreach (string x in rucksack)
            {

                char[] found = new char[104];
                int foundCn = 0;
                string compartment1 = x.Substring(0,(x.Length) / 2);
                string compartment2 = x.Substring((x.Length)/2);

                char[] cp1Arr = compartment1.ToCharArray();
                
                for (int i = 0; i < cp1Arr.Length; i++)
                {
                    
                    
                    if (compartment2.Contains(cp1Arr[i]))
                    {
                      bool exists = false;
                      for(int inner = 0; inner < foundCn; inner++)
                        {
                            if (found[inner] == cp1Arr[i])
                            {
                                exists = true;
                                break;
                            }
                        }
                      if(exists == false)
                        {
                            found[foundCn] = cp1Arr[i];
                            Console.Write(cp1Arr[i]+": ");
                            if (Char.IsUpper(cp1Arr[i]))
                            {
                                total = total + (((int)cp1Arr[i]) - 38);
                                Console.Write(((int)cp1Arr[i]) - 38);
                            }
                            else
                            {
                                total = total + (((int)cp1Arr[i]) - 96);
                                Console.Write(((int)cp1Arr[i]) - 96);
                            }
                            foundCn++;
                            Console.WriteLine();
                        }
                    }
                }
                
                //Console.WriteLine(compartment1 +" : "+ compartment2);
            }
            Console.WriteLine(total);
            //Console.WriteLine(foundCn);
        }
    }
}
