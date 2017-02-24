using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeDemo
{

    class Snake
    {
        int boardWidth, boardHeight;
        int snakeLength;
        List<int> positionX;
        List<int> positionY;

        public Snake (int boardWidth, int boardHeight, int snakeLength)
        {
            this.boardWidth = boardWidth;
            this.boardHeight = boardHeight;
            this.snakeLength = snakeLength;
            positionX = new List<int>();
            positionY = new List<int>();
            for (int i = this.snakeLength; i >= 1; i--)
            {
                positionX.Add(i);
                positionY.Add(1);
            }
        }
        
        // 0 - right
        // 1 - up
        // 2 - left
        // 3 - down
        void moveSnake(int direction)
        {
            for (int i = this.snakeLength - 1; i >= 1; i--)
            {
                positionX[i] = positionX[i - 1];
                positionY[i] = positionY[i - 1];
            }
            if (direction == 0)
            {
                positionX[0]++;
            }
            else if (direction == 1)
            {
                positionY[0]--;
            }
            else if (direction == 2)
            {
                positionX[0]--;
            }
            else if (direction == 3)
            {
                positionY[0]++;
            }
        }

        void print()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < this.boardWidth + 2; i++)
            {
                for (int j = 0; j < this.boardHeight + 2; j++)
                {
                    if (i == 0 || j == 0 
                        || i == this.boardWidth + 1 
                        || j == this.boardHeight + 1)
                    {
                        Console.SetCursorPosition(i, j);
                        Console.Write("*");
                    }
                }
            }
            for (int i = 0; i < this.snakeLength; i++)
            {
                Console.SetCursorPosition(positionX[i], positionY[i]);
                if (i == 0)
                {
                    Console.Write("X");
                } else
                {
                    Console.Write("o");
                }
            }
        }

        public void run()
        {
            print();
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.RightArrow)
                {
                    moveSnake(0);
                }
                else if (key.Key == ConsoleKey.UpArrow)
                {
                    moveSnake(1);
                }
                else if (key.Key == ConsoleKey.LeftArrow)
                {
                    moveSnake(2);
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    moveSnake(3);
                }
                print();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Snake snake = new Snake(20, 10, 6);
            snake.run();
        }
    }
}
