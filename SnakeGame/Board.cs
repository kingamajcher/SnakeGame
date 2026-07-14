using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public static class Board
    {
        public static readonly int minRow = 0;
        public static readonly int maxRow = 23;
        public static readonly int minColumn = 0;
        public static readonly int maxColumn = 80;

        public static void DrawBoard()
        {
            int requiredHeight = maxRow + 1;
            int requiredWidth = maxColumn;

            if (Console.BufferHeight < requiredHeight)
                Console.BufferHeight = requiredHeight;

            if (Console.WindowHeight < requiredHeight)
                Console.WindowHeight = requiredHeight;

            if (Console.BufferWidth < requiredWidth)
                Console.BufferWidth = requiredWidth;

            if (Console.WindowWidth < requiredWidth)
                Console.WindowWidth = requiredWidth;

            Console.Clear();

            ConsoleColor originalBg = Console.BackgroundColor;
            ConsoleColor originalFg = Console.ForegroundColor;

            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;

            Console.SetCursorPosition(minColumn, minRow);
            Console.Write(new string(' ', maxColumn));

            Console.SetCursorPosition(minColumn, maxRow);
            Console.Write(new string(' ', maxColumn));

            for (int i = minRow + 1; i < maxRow; i++)
            {
                Console.SetCursorPosition(minColumn, i);
                Console.Write(" ");

                Console.SetCursorPosition(maxColumn - 1, i);
                Console.Write(" ");
            }

            Console.BackgroundColor = originalBg;
            Console.ForegroundColor = originalFg;

            WriteScore(0);
            Console.SetWindowPosition(0, 0);
        }

        public static void WriteScore(int score)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.SetCursorPosition(minColumn + 28, maxRow);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Score = {0}", score);
            Console.BackgroundColor = ConsoleColor.Black;
        }

    }
}
