using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class Reward
    {
        public int Value { get; private set; }
        public Point position = new Point();
        private int maxValue = 5;

        public Reward() 
        { 
            Random random = new Random();
            this.Value = random.Next(0, maxValue + 1);
            position.X = random.Next(Board.minColumn + 1, Board.maxColumn - 2);
            position.Y = random.Next(Board.minRow + 1, Board.maxRow - 1);
        }

        public void ShowReward()
        {
            ConsoleColor color = Console.ForegroundColor;
            Console.SetCursorPosition(position.X, position.Y);
            if (this.Value == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("*");
            }
            Console.ForegroundColor = color;
        }

        public void RemoveReward()
        {
            Console.SetCursorPosition(position.X, position.Y);
            Console.Write(" ");
        }
    }
}
