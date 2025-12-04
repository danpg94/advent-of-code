string filePath = "input.txt";
string text = File.ReadAllText(filePath);
string[] rows = text.Split('\n');
int row_len = rows.Length;
int col_len = rows[0].Length;
int[,] matrix = new int[row_len, col_len];

for (int i = 0 ; i < row_len ; i++){
        for (int j = 0; j < col_len ; j++){
            matrix[i, j] = rows[i][j];
        }
}

int total_removable_rolls = 0;
Console.WriteLine($"rows {row_len} cols {col_len}");

int removable_rolls = 0;
do {
    removable_rolls = 0;
    for (int i = 0 ; i < row_len ; i++){
        for (int j = 0; j < col_len ; j++){
            int adjacent_count = 0;
            if (matrix[i,j] == '@') {
                Console.WriteLine($"{matrix[i,j]} at {i} {j}");
                if ((i-1 >= 0 && j-1 >= 0) && (matrix[i-1,j-1] == '@')){ // Upper Left
                    Console.WriteLine($"\t{i-1} {j-1}");
                    adjacent_count += 1;
                }
                if ((i-1 >= 0) && (matrix[i-1,j] == '@')) // Up
                {
                    Console.WriteLine($"\t{i-1} {j}");
                    adjacent_count += 1;
                }
                if ((i-1 >= 0 && j+1 < col_len) && (matrix[i-1,j+1]== '@')) // Upper Right
                {
                    Console.WriteLine($"\t{i-1} {j+1}");
                    adjacent_count += 1;
                }
                if ((j-1 >= 0) && matrix[i,j - 1] == '@') // Left
                {
                    Console.WriteLine($"\t{i} {j-1}");
                    adjacent_count += 1;
                }
                if ((j+1 < col_len) && matrix[i,j + 1] == '@') // Right
                {
                    Console.WriteLine($"\t{i} {j+1}");
                    adjacent_count += 1;
                }
                if ((i+1 < row_len && j-1 >= 0) && (matrix[i+1,j-1] == '@')) // Bottom Left
                {
                    Console.WriteLine($"\t{i+1} {j-1}");
                    adjacent_count += 1;
                }
                if ((i+1 < row_len) && (matrix[i+1,j] == '@') ) // Down
                {
                    Console.WriteLine($"\t{i+1} {j}");
                    adjacent_count += 1;
                }
                if ((i+1 < row_len && j+1 < col_len) && (matrix[i+1,j+1] == '@')) //Bottom Right
                {
                    Console.WriteLine($"\t{i+1} {j+1}");
                    adjacent_count += 1;
                }

                if (adjacent_count < 4)
                {
                    removable_rolls += 1;
                    matrix[i,j] = 'x';
                    Console.WriteLine("\tRemovable");
                }
            }
        }
    }
    total_removable_rolls += removable_rolls;
} while (removable_rolls != 0);
Console.WriteLine($"Total rolls are: {total_removable_rolls}");