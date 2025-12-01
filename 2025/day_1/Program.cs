using System;
using System.IO;
using System.Text;

namespace day_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "/home/dan/repos/advent-of-code/2025/day_1/input.txt";
            string[] lines = File.ReadAllLines(filePath);
            int position = 50;
            int zero_count = 0;
            int turns = 0;
            foreach (string line in lines)
            {
                if (line[1..].Length == 3) {
                    turns = Convert.ToInt32(line[2..]);
                    }
                else {
                    turns = Convert.ToInt32(line[1..]);
                    }
                if (line[0] == 'L'){
                    position -= turns;
                    if (position < 0) { position += 100;}
                } else {
                    position += turns;
                    if (position >= 100) { position -= 100;}
                }
                if (position == 0) {zero_count += 1;}

            }
            Console.WriteLine("Zero count is {0}", zero_count);
        }
    }
}