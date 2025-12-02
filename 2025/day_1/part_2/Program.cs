using System;
using System.IO;
using System.Text;

namespace day_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "input.txt";
            string[] lines = File.ReadAllLines(filePath);
            int position = 50;
            int zero_count = 0;
            int number = 0;
            foreach (string line in lines)
            {
                zero_count += Convert.ToInt32(line[1..]) / 100;
                number = Convert.ToInt32(line[1..]) % 100;
                if (line[0] == 'L'){ number *= -1; }
                if ((position+number <= 0 || position+number >= 100) && (position != 0)) {zero_count += 1;}        
                
                position += number;
                if (position < 0 ){ position +=100;}
                if (position >=100) {position %= 100;}
                //if (position == 0) {zero_count += 1;}
                Console.WriteLine(position);

            }
            Console.WriteLine("Zero count is {0}", zero_count);
        }
    }
}