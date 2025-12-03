string filePath = "input.txt";
string text = File.ReadAllText(filePath);
string[] banks = text.Split('\n');
int sum_joltage = 0;
foreach (string bank in banks)
{
    int highest = 0;
    for (int i = 0 ; i < bank.Length ; i++)
    {
        int tens = (int)char.GetNumericValue(bank[i]) * 10;
        if (tens >= highest)
        {
            for (int j = i+1 ; j < bank.Length ; j++)
            {
                int unit = (int)char.GetNumericValue(bank[j]);
                if (tens+unit > highest)
                {
                    highest = tens+unit;
                }
            }
        }
    }
    sum_joltage += highest;
}
Console.WriteLine($"The sum is {sum_joltage}");