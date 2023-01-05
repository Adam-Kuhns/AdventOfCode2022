using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;

namespace Part1
{

    public class Tree<TDerived> where TDerived : Tree<TDerived>
    {
        public TDerived Parent { get; private set; }
        public List<TDerived> Children { get; private set; }
        public Tree(TDerived parent)
        {
            this.Parent = parent;
            this.Children = new List<TDerived>();
            if (parent != null) { parent.Children.Add((TDerived)this); }
        }
        public bool IsRoot { get { return Parent == null; } }
        public bool IsLeaf { get { return Children.Count == 0; } }
    }

    public class FileSys : Tree<FileSys>
    {
        FileSys() : base(null) { }
        FileSys(FileSys parent) : base(parent) { }
        public string Current { get; set; }
        public static FileSys NewRoot() { return new FileSys(); }
        public FileSys NewChild(string localPos)
        {
            return new FileSys(this) { Current = localPos };
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            var currentDir = FileSys.NewRoot();//0 is blank, CurrentDir, Children

            var A = FileSys.NewRoot();
            currentDir = A;

            string input = File.ReadAllText("/Users/adamkuhns/Desktop/Advent of Code-2022/Day7/input.txt");
            string[] lines = input.Split('\n');
            bool ls = false;
            

            foreach (string x in lines)
            {
                
                char[] lineChar = x.ToCharArray();

                if(lineChar[0] == '$')//command
                {
                    //Console.WriteLine("Command: " + x);
                    ls = false;
                    if (lineChar[2] == 'c')//cd
                    {
                        if (lineChar[5] == '.')//move back
                        {
                            currentDir = currentDir.Parent;
                        }
                        else//move forward
                        {
                            string[] forwardDir = x.Split(' ');//split command string to get directory
                            

                            FileSys[] output = currentDir.Children.ToArray();//array of current dirs children
                            for (int i = 0; i < output.Length; i++)
                            {
                                if (output[i].Current == forwardDir[2])//if child == forward dir ..not ever moving forward
                                {
                                    currentDir = output[i]; 
                                }
                                
                            }

                        }
                    }
                    else //ls
                    {
                        ls = true;
                    }
                }
                if (ls)
                {
                    if(lineChar[0] == 'd')//create dir
                    {
                        string[] dirName = x.Split(' ');
                        currentDir.NewChild(dirName[1]);
                    }
                    else if(lineChar[0] != '$')//create file 
                    {
                        currentDir.NewChild(x);
                    }
                }

            }

            printTree(A, 0);
            BigInteger dirOver100K = 0;
            dirCount(A,0, ref dirOver100K);
            
            static void printTree(FileSys x, int indent)
            {
                FileSys[] root = x.Children.ToArray();
                if (x.IsRoot)
                {
                    for (int i =0; i < indent; i++)
                    {
                        Console.Write("  ");
                    }
                    Console.WriteLine("Dir /");
                }
                else
                {
                    for (int i = 0; i < indent; i++)
                    {
                        Console.Write("  ");
                    }
                    Console.WriteLine("Dir " + x.Current);
                }
                for (int i = 0; i < x.Children.Count; i++) 
                {
                    
                    if (root[i].IsLeaf)//file not dir
                    {
                        for (int y = 0; y < indent; y++)
                        {
                            Console.Write("  ");
                        }
                        Console.WriteLine("  "+root[i].Current);
                    }
                    else
                    {
                        int a = indent + 1;
                        printTree(root[i], a);
                    }

                }
                
                   
            }
            

            static BigInteger dirCount(FileSys x, BigInteger count, ref BigInteger dirOver100k)
            {

                count = 0;
                FileSys[] root = x.Children.ToArray();//directory
                for (int i = 0; i < x.Children.Count; i++)
                {
                    if (root[i].IsLeaf)//file not dir
                    {
                        string[] file = root[i].Current.Split(' ');//getting file size
                        BigInteger fileSize = Int32.Parse(file[0]);
                        count = count + fileSize;
                    }
                    else
                    {
                        count = count + dirCount(root[i], count, ref dirOver100k);
                    }

                }
                if (x.IsRoot && count <= 100000)
                {
                    Console.WriteLine("/ " + count);
                    dirOver100k = dirOver100k + count;
                }
                else if(count <= 100000)
                {
                    dirOver100k = dirOver100k + count;
                }
                return count; 

            }

            Console.WriteLine("Dir over 100k total: "+dirOver100K);

        }
    }
}
