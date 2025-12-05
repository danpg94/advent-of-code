string filePath = "input.txt";
string text = File.ReadAllText(filePath);
string[] half = text.Split("\n\n");
string[] ranges = half[0].Split("\n");
string[] ids = half[1].Split("\n");
int sum_spoiled = 0;
foreach (string id in ids){
    long i = Convert.ToInt64(id);
    foreach (string range in ranges){
        long range_int_lower = Convert.ToInt64(range.Split("-")[0]);
        long range_int_upper = Convert.ToInt64(range.Split("-")[1]);
        if (i >= range_int_lower && i <= range_int_upper){
            sum_spoiled += 1;
            break;
        }}}
Console.WriteLine($"Sum of spoiled ids: {sum_spoiled}");