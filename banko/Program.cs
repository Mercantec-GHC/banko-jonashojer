using banko.Models;

namespace banko;

class Program {
    static void Main(string[] args) {
      			// Tal er taget fra seedet "jonas"
			int[,] rows = { 
				{ 1, 21, 31, 40, 80 }, 
				{ 13, 51, 64, 72, 88 }, 
				{ 18, 49, 59, 68, 90 },
			};

			Console.WriteLine("Seed: jonas");
			Console.WriteLine("/--------------------------------------------\\");
			for (int i = 0; i < 3; i++) {
				for (int j = 0; j < 5; j++) {
					if (j == 4) {
						if (rows[i, j] == 0) {
							Console.Write("    |\n");
						} else {
							Console.Write($" {rows[i, j]} |\n");
						}
					} else if (j == 0) {
                        if (rows[i, j] == 0) {
                            Console.Write("|    |");
                        } else {
                            Console.Write($"| {rows[i, j]}  |");
                        }
					} else {
                        if (rows[i, j] == 0) {
                            Console.Write("    |");
                        } else {
                            Console.Write($" {rows[i, j]} |");
                        }
                        
					}
				}
                if (i != 2)
                {
                    Console.WriteLine(" --------------------------------------------");
                }
            }
			Console.WriteLine("\\--------------------------------------------/\n");

            bool[,] fieldMarked = new bool[3, 5];
            bool[] rowBingo = new bool[3];


        while (true)
        {
            Console.WriteLine("Enter a number: ");
            int number = Convert.ToInt32(Console.ReadLine());

            // Mark the number on the corresponding board
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (rows[i, j] == number)
                    {
                        fieldMarked[i, j] = true;
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

