string filePath = "input.txt";
string text = File.ReadAllText(filePath);
string[] rows = text.Split('\n');
int row_len = rows.Length;
int col_len = rows[0].Length;
//int[,] matrix = new int[row_len, col_len];
int total_rolls = 0;
Console.WriteLine($"rows {row_len} cols {col_len}");

for (int i = 0 ; i < row_len ; i++){
    for (int j = 0; j < col_len ; j++){
        int adjacent_count = 0;
        if (rows[i][j] == '@') {
            Console.WriteLine($"{rows[i][j]} at {i} {j}");
            if ((i-1 >= 0 && j-1 >= 0) && (rows[i-1][j-1] == '@')){ // Upper Left
                Console.WriteLine($"\t{i-1} {j-1}");
                adjacent_count += 1;
            }
            if ((i-1 >= 0) && (rows[i-1][j] == '@')) // Up
            {
                Console.WriteLine($"\t{i-1} {j}");
                adjacent_count += 1;
            }
            if ((i-1 >= 0 && j+1 < col_len) && (rows[i-1][j+1]== '@')) // Upper Right
            {
                Console.WriteLine($"\t{i-1} {j+1}");
                adjacent_count += 1;
            }
            if ((j-1 >= 0) && rows[i][j - 1] == '@') // Left
            {
                Console.WriteLine($"\t{i} {j-1}");
                adjacent_count += 1;
            }
            if ((j+1 < col_len) && rows[i][j + 1] == '@') // Right
            {
                Console.WriteLine($"\t{i} {j+1}");
                adjacent_count += 1;
            }
            if ((i+1 < row_len && j-1 >= 0) && (rows[i+1][j-1] == '@')) // Bottom Left
            {
                Console.WriteLine($"\t{i+1} {j-1}");
                adjacent_count += 1;
            }
            if ((i+1 < row_len) && (rows[i+1][j] == '@') ) // Down
            {
                Console.WriteLine($"\t{i+1} {j}");
                adjacent_count += 1;
            }
            if ((i+1 < row_len && j+1 < col_len) && (rows[i+1][j+1] == '@')) //Bottom Right
            {
                Console.WriteLine($"\t{i+1} {j+1}");
                adjacent_count += 1;
            }

            if (adjacent_count < 4)
            {
                total_rolls += 1;
                Console.WriteLine("\tRemovable");
            }
        }
    }
}
Console.WriteLine($"Total rolls are: {total_rolls}");