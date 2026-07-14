using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class Snake
    {
        private static LinkedList<Point> snakeBody = new LinkedList<Point>();
        public static Direction turn;

        public static void MakeSnake()
        {
            Random random = new Random();
            int initialLength = random.Next(3, 10);
            for (int i = 1; i <= initialLength; i++)
            {
                snakeBody.AddFirst(new Point(i, Board.minRow + 6));
            }
            turn = Direction.Right;
            DrawSnake();
        }

        public static void DrawPoint(Point point)
        {
            Console.SetCursorPosition(point.X, point.Y);
            Console.Write("#");
        }

        public static void RemovePoint(Point point)
        {
            Console.SetCursorPosition(point.X, point.Y);
            Console.Write(" ");
        }

        public static void DrawSnake()
        {
            foreach (Point point in snakeBody)
            {
                DrawPoint(point);
            }
        }

        public static void RemoveSnake()
        {
            foreach (Point point in snakeBody)
            {
                RemovePoint(point);
            }
            snakeBody.Clear();
        }

        private static void DetermineOffsetForHead(ref int verticalOffset, ref int horizontalOffset)
        {
            if (turn == Direction.Left)
            {
                horizontalOffset = -1;
            }
            else if (turn == Direction.Right)
            {
                horizontalOffset = 1;
            }

            if (turn == Direction.Up)
            {
                verticalOffset = -1;
            }
            else if (turn == Direction.Down)
            {
                verticalOffset = 1;
            }
        }

        private static void DetermineOffsetForTail(ref int verticalOffset, ref int horizontalOffset)
        {
            DetermineOffsetForHead(ref verticalOffset, ref horizontalOffset);
            verticalOffset *= -1;
            horizontalOffset *= -1;
        }

        private static void MakeMove()
        {
            int verticalOffset = 0;
            int horizontalOffset = 0;
            RemovePoint(snakeBody.Last.Value);
            snakeBody.RemoveLast();
            DetermineOffsetForHead(ref verticalOffset, ref horizontalOffset);
            Point point = new Point();
            point.X = snakeBody.First.Value.X + horizontalOffset;
            point.Y = snakeBody.First.Value.Y + verticalOffset;

            snakeBody.AddFirst(point);
            DrawPoint(point);
        }

        public static bool MoveSnake()
        {
            bool moveAllowed = true;

            int headX = snakeBody.First.Value.X;
            int headY = snakeBody.First.Value.Y;

            if ((turn == Direction.Right && headX >= Board.maxColumn - 2) ||
                (turn == Direction.Left && headX <= Board.minColumn + 1) ||
                (turn == Direction.Up && headY <= Board.minRow + 1) ||
                (turn == Direction.Down && headY >= Board.maxRow - 1)) 
            { 
                moveAllowed = false;
            }
            else
            {
                MakeMove();
            }
            return moveAllowed;
        }

        public static void ElongateSnake()
        {
            int verticalOffset = 0;
            int horizontalOffset = 0;
            Point point = new Point();
            DetermineOffsetForTail(ref verticalOffset, ref horizontalOffset);
            point.X = snakeBody.Last.Value.X + horizontalOffset;
            point.Y = snakeBody.Last.Value.Y + verticalOffset;
            snakeBody.AddLast(point);
            DrawPoint(point);
        }

        public static bool HasRewardInside(Point rewardPoint)
        {
            bool result = false;
            foreach (Point point in snakeBody)
            {
                if (point.X == rewardPoint.X &&  point.Y == rewardPoint.Y)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        public static bool EatenItself()
        {
            bool result = false;
            bool firstPoint = true;
            foreach(Point point in snakeBody)
            {
                if (!firstPoint)
                {
                    if (snakeBody.First.Value.X == point.X && snakeBody.First.Value.Y == point.Y)
                    {
                        result = true;
                        break;
                    }
                }
                firstPoint = false;
            }
            return result;
        }
    }
}
