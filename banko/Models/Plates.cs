using System;
namespace banko.Models {

	public class Plates {
		public void Generate() {
			Console.WriteLine("/----------------------------------------\\");
			for (int i = 0; i < 3; i++) {
				for (int j = 0; j < 9; j++) {
					if (j == 8) {
						Console.Write(" 22 |\n");
					} else if (j == 0){
						Console.Write("| ");
					} else {
						Console.Write(" 22 |");
					}
				}
				if (i != 2) {
					Console.WriteLine(" ----------------------------------------");
				}
			}
			Console.WriteLine("\\----------------------------------------/");
		}
	}
}

