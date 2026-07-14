using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

namespace SnakeGame
{
    public static class Game
    {
        public static bool game = true;
        public static DateTime start = DateTime.Now;
        public static Reward reward = new Reward();
        public static int score = 0;

        public static void NewGame()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            game = true;
            score = 0;
            Board.DrawBoard();
            Snake.MakeSnake();
            reward.ShowReward();
            Play();
        }

        private static void Play()
        {
            while (game)
            {
                ReadKey();
                if (!game) break;

                NewReward();
                SnakeEatenItself();
                if (!game) break;

                SnakeMoves();
                if (!game) break;

                SnakeEatenReward();
                Thread.Sleep(100);
            }
        }

        private static void SnakeEatenItself()
        {
            if (Snake.EatenItself())
            {
                GameOver();
            }
        }
        
        private static void SnakeMoves()
        {
            if (!Snake.MoveSnake())
            {
                GameOver();
            }
        }

        private static void SnakeEatenReward()
        {
            if (Snake.HasRewardInside(reward.position))
            {
                if (reward.Value == 0)
                {
                    Snake.RemoveSnake();
                    Snake.MakeSnake();
                    score = 0;
                }
                else
                {
                    score += reward.Value;
                    Snake.ElongateSnake();
                }
                Board.WriteScore(score);
                reward = new Reward();
                reward.ShowReward();
            }
        }

        private static void NewReward()
        {
            Random random = new Random();
            double timeElapsed = random.NextDouble();
            timeElapsed = timeElapsed * 10 + 10;

            if (start <= DateTime.Now.Subtract(TimeSpan.FromSeconds(timeElapsed)))
            {
                reward.RemoveReward();
                start = DateTime.Now;
                reward = new Reward();
                reward.ShowReward();
            }
        }

        private static void GameOver()
        {
            game = false;
            ConsoleColor color = Console.ForegroundColor;
            Console.SetCursorPosition(Board.minColumn + 34, Board.minRow + 12);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Game over");
            Console.ForegroundColor = color;
            Console.ReadKey();
            Snake.RemoveSnake();
        }

        private static void ReadKey()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.LeftArrow && Snake.turn != Direction.Right)
                {
                    Snake.turn = Direction.Left;
                }
                if (key.Key == ConsoleKey.RightArrow && Snake.turn != Direction.Left)
                {
                    Snake.turn = Direction.Right;
                }
                if (key.Key == ConsoleKey.UpArrow && Snake.turn != Direction.Down)
                {
                    Snake.turn = Direction.Up;
                }
                if (key.Key == ConsoleKey.DownArrow && Snake.turn != Direction.Up)
                {
                    Snake.turn = Direction.Down;
                }
                if (key.Key == ConsoleKey.Escape)
                {
                    GameOver();
                }

                while(Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }
            }
        }
    }
}
