using System;
namespace SLtoMWC.Utilities
{
    public static class Utilities
    {
        public static bool IsRunningOnMono()
        {
            return Type.GetType("Mono.Runtime") != null;
        }

        public static void DrawProgressBar(int complete, int maxVal, int barSize, char progressCharacter)
        {
            decimal thresh1 = 0.2M;
            decimal thresh2 = 0.4M;
            decimal thresh3 = 0.6M;
            decimal thresh4 = 0.8M;

            Console.CursorVisible = false;
            int left = Console.CursorLeft;
            decimal perc = (decimal)complete / (decimal)maxVal;
            int chars = (int)Math.Floor(perc / ((decimal)1 / (decimal)barSize));
            string p1 = string.Empty, p2 = string.Empty;

            for (int i = 0; i < chars; i++) p1 += progressCharacter;
            for (int i = 0; i < barSize - chars; i++) p2 += progressCharacter;

            if (decimal.Compare(perc, thresh1) == -1)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
            }
            else if (decimal.Compare(perc, thresh2) == -1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (decimal.Compare(perc, thresh3) == -1)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            }
            else if (decimal.Compare(perc, thresh4) == -1)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }


            Console.Write(p1);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write(p2);

            Console.ResetColor();
            Console.Write(" {0}%", (perc * 100).ToString("N2"));

            if (perc * 100 == 100)
            {
                Console.WriteLine();
            }
            else
            {
                Console.CursorLeft = left;
            }
        }


    }
}
