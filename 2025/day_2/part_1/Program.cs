string filePath = "input.txt";
string text = File.ReadAllText(filePath);
string[] ranges = text.Split(',');
long sum_invalid = 0;
foreach (string range in ranges)
{
    Console.WriteLine(range);
    long bottomRange = Convert.ToInt64(range.Split('-')[0]);
    long topRange = Convert.ToInt64(range.Split('-')[1]);
    for (long i = bottomRange ; i < topRange + 1 ; i++)
    {
        string str = Convert.ToString(i);
        if (str.Length % 2 == 0) 
        {
            int half = str.Length / 2;
            if (str[0..half] == str[half..])
            {
                Console.WriteLine(str);
                sum_invalid += Convert.ToInt64(str);
            }
        }
    }
}
Console.WriteLine("Sum of invalid IDs: {0}", sum_invalid);