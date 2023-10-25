using banko.Models;

namespace banko;

class Program
{
    static void Main(string[] args)
    {
        // Tal er taget fra seedet "jonas"
        string[] seeds = { "jonas", "lukas", "mikkel", "alex" };
        

        int[,,] rows = new int[,,] {
                {
                    // jonas
                    { 1, 21, 31, 40, 80 },
                    { 13, 51, 64, 72, 88 },
                    { 18, 49, 59, 68, 90 }
                },
                { 
                    // lukas
                    { 7, 10, 25, 62, 73 },
                    { 13, 27, 47, 55, 64 },
                    { 15, 36, 56, 77, 89 }
                },
                {
                    // mikkel
                    { 10, 32, 43, 51, 61 },
                    { 26, 44, 55, 77, 89 },
                    { 9, 18, 67, 78, 90 }
                },
                {
                    // alex
                    { 13, 20 ,61 ,71, 83 },
                    { 8, 33, 44, 52, 84 },
                    { 9, 18, 37, 69, 75 }
                }
            };

        for (int h = 0; h < rows.GetLength(0); h++)
        {
        Console.WriteLine($"Seed: {seeds[h]}");
        Console.WriteLine("/------------------------\\");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (j == 4)
                    {
                        Console.Write($" {rows[h, i, j]} |\n");
                    }
                    else if (j == 0)
                    {
                        if (rows[h, i, j].ToString().Length == 1)
                        {
                            Console.Write($"| {rows[h, i, j]}  |");
                        }
                        else
                        {
                            Console.Write($"| {rows[h, i, j]} |");
                        }
                    }
                    else
                    {
                        Console.Write($" {rows[h, i, j]} |");
                    }
                }
                if (i != 2)
                {
                    Console.WriteLine(" -------------------------");
                }
            }
        Console.WriteLine("\\------------------------/\n");
        }


        bool[,] fieldMarked = new bool[3, 5];
        bool[] rowBingo = new bool[3];


        while (true)
        {
            Console.WriteLine("Enter a number(1-90): ");
            string number = Console.ReadLine();
            if (int.TryParse(number, out int validNumber) && validNumber >= 1 && validNumber <= 90)
            {
                for (int h = 0; h < rows.GetLength(0); h++)
                {
                    // Mark the number on the corresponding board
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            if (rows[h, i, j] == validNumber)
                            {
                                fieldMarked[i, j] = true;
                            }
                        }
                    }
                }
                // Check for banko on each row and update the row banko status
                for (int i = 0; i < 3; i++)
                {
                    if (!rowBingo[i] && CheckBankoRow(fieldMarked, i))
                    {
                        Console.WriteLine($"You've bingo on row {i + 1}!");
                        rowBingo[i] = true;
                    }
                }
                if (rowBingo.All(x => x))
                {
                    Console.WriteLine("You've gotten full plate!");
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid number");
            }
        }
    }
    private static bool CheckBankoRow(bool[,] marked, int row)
    {
        for (int j = 0; j < 5; j++)
        {
            if (!marked[row, j])
            {
                return false;
            }
        }
        return true;
    }
}

