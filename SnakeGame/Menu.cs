using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class Menu
    {
        public static void StartMenu()
        {
            Console.Title = "Snake Game";
            Console.SetWindowSize(Board.maxColumn, Board.maxRow + 1);
            Console.SetBufferSize(Board.maxColumn, Board.maxRow + 3);
            

            while (true)
            {
                Console.Clear();
                Console.CursorVisible = false;
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.SetCursorPosition(Board.minColumn + 28, Board.minRow + 10);
                Console.Write("       Snake game");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.SetCursorPosition(Board.minColumn + 28, Board.minRow + 12);
                Console.Write("Press 1 to start the game");
                Console.SetCursorPosition(Board.minColumn + 28, Board.minRow + 14);
                Console.Write("    Press 2 to exit");
                Console.ForegroundColor = ConsoleColor.White;
                ConsoleKeyInfo k = Console.ReadKey();
                switch (k.Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        Game.NewGame();
                        break;
                    case ConsoleKey.D2:
                        Console.Clear();
                        return;


                }
            }
        }

    }
}
