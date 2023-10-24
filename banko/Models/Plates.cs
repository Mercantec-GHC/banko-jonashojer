using System;
namespace banko.Models {

	public class Plates {
		public void GeneratePlate(int numberOfPlates = 1) {

			for (int h = 0; h < numberOfPlates; h++) {
				Console.WriteLine("/----------------------------------------\\");
				for (int i = 0; i < 3; i++) {
					for (int j = 0; j < 9; j++) {
						if (j == 8) {
							Console.Write($" 22 |\n");
						} else if (j == 0) {
							Console.Write("| ");
						} else {
							Console.Write($" 22 |");
						}
					}
					if (i != 2) {
						Console.WriteLine(" ----------------------------------------");
					}
				}
				Console.WriteLine("\\----------------------------------------/\n");
			}
		}

		public void StaticPlate() {
			// Tal er taget fra seedet "jonas"
			int[,] rows = { 
				{ 1, 0, 21, 31, 40, 0, 0, 0, 80 }, 
				{ 0, 13, 0, 0, 0, 51, 64, 72, 88 }, 
				{ 0, 18, 0, 0, 49, 59, 68, 0, 90 },
			};

			Console.WriteLine(rows[0, 3]);

			Console.WriteLine("/--------------------------------------------\\");
			for (int i = 0; i < 3; i++) {
				for (int j = 0; j > 9; j++) {
					if (j == 8) {
						Console.Write($" {rows[i, j]} |\n");
					} else if (j == 0) {
						Console.Write($"| {rows[i, j]} ");
					} else {
						Console.Write($" {rows[i, j]} |");
					}
					if (i != 2) {
						Console.WriteLine(" ----------------------------------------");
					}
				}
			}
			Console.WriteLine("\\--------------------------------------------/\n");
		}

        private static List<int?[]> GenerateNumbers() {
			List<int?[]> numbersResult = new List<int?[]>();
			Random random = new Random();
			int randMin = 1;
			int randMax = 9;

			for (int i = 0; i < 9; i++) {
				List<int?> numbersAdded = new List<int?>();
				for (int j = 0; j < 3; j++) {
					while (true) {
						int result = random.Next(randMin, randMax);
						if (!numbersAdded.Contains(result)) {
							numbersAdded.Add(result);
							break;
						}
					}
				}
				if (i == 0) {
					randMin = 0;
					randMax = 9;
				}
				randMin += 10;
				randMax += 10;
				numbersAdded.Sort();
				int?[] array = numbersAdded.ToArray();
				numbersResult.Add(array);
			}
			return numbersResult;
		}
	}
}

