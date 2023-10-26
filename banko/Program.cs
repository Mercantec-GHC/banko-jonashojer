using banko.Models;

namespace banko;

class Program
{
    static void Main(string[] args)
    {

        int[,] jonas = { { 1, 21, 31, 40, 80 }, { 13, 51, 64, 72, 88 }, { 18, 49, 59, 68, 90 } };
        int[,] lukas = { { 7, 10, 25, 62, 73 }, { 13, 27, 47, 55, 64 }, { 15, 36, 56, 77, 89 } };

        Console.WriteLine("Seed: jonas");
        Console.WriteLine("/------------------------\\");
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (j == 4)
                {
                    Console.Write($" {jonas[i, j]} |\n");
                }
                else if (j == 0)
                {
                    if (jonas[i, j].ToString().Length == 1)
                    {
                        Console.Write($"| {jonas[i, j]}  |");
                    }
                    else
                    {
                        Console.Write($"| {jonas[i, j]} |");
                    }
                }
                else
                {
                    Console.Write($" {jonas[i, j]} |");
                }
            }
            if (i != 2)
            {
                Console.WriteLine(" -------------------------");
            }
        }
        Console.WriteLine("\\------------------------/\n");

        Console.WriteLine("Seed: lukas");
        Console.WriteLine("/------------------------\\");
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (j == 4)
                {
                    Console.Write($" {lukas[i, j]} |\n");
                }
                else if (j == 0)
                {
                    if (lukas[i, j].ToString().Length == 1)
                    {
                        Console.Write($"| {lukas[i, j]}  |");
                    }
                    else
                    {
                        Console.Write($"| {lukas[i, j]} |");
                    }
                }
                else
                {
                    Console.Write($" {lukas[i, j]} |");
                }
            }
            if (i != 2)
            {
                Console.WriteLine(" -------------------------");
            }
        }
        Console.WriteLine("\\------------------------/\n");

        bool[,] jonasMarked = new bool[3, 5];
        bool[,] lukasMarked = new bool[3, 5];

        bool[] jonasRowBingo = new bool[3];
        bool[] lukasRowBingo = new bool[3];

        while (true)
        {
            Console.WriteLine("Enter a number(1-90): ");
            string number = Console.ReadLine();
            if (int.TryParse(number, out int validNumber) && validNumber >= 1 && validNumber <= 90)
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (jonas[i, j] == validNumber)
                        {
                            jonasMarked[i, j] = true;
                        }
                        if (lukas[i, j] == validNumber)
                        {
                            lukasMarked[i, j] = true;
                        }
                    }
                    if (!jonasRowBingo[i] && CheckBankoRow(jonasMarked, i))
                    {
                        Console.WriteLine($"You've bingo on row {i + 1} on plate: jonas!");
                        jonasRowBingo[i] = true;
                    }
                    if (!lukasRowBingo[i] && CheckBankoRow(lukasMarked, i))
                    {
                        Console.WriteLine($"You've bingo on row {i + 1} on plate: lukas!");
                        lukasRowBingo[i] = true;
                    }
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
