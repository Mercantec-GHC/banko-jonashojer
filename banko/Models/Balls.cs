using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace banko.Models {
    public class Balls {
        public int amount { get; set; }

        public static List<int[]> GenerateBalls(int amount = 5) {
            List<int[]> numbersResult = new List<int[]>();
            Random random = new Random();
            int randMin = 1;
            int randMax = 91;

            for (int i = 0; i < amount; i++) {
                List<int> numbersAdded = new List<int>();
                while (true) {
                    int result = random.Next(randMin, randMax);
                    if (!numbersAdded.Contains(result)) {
                        numbersAdded.Add(result);
                        break;
                    }
                }
                int[] array = numbersAdded.ToArray();
                numbersResult.Add(array);
            }
            return numbersResult;        
        }
        public void DrawBalls(List<int> balls)
        {
            // Print the number of each ball to the console
            foreach (int ball in balls)
            {
                Console.Write(ball);
            }
        }
    }

}
