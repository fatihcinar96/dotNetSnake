using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SnakeApp
{
    enum snakeDirection
    {
        Up,
        Down,
        Left,
        Right
    }
    class Program
    {

        static void Main(string[] args)
        {
            
            Snake snake = new Snake();
            snake.printFrame();
            snake.feed();
            snake.setScore(0);
            snake.writeSnake();
            snake.prepareSnake();
            snake.moveSnake();
            //snake.setTime();
            while (true)
            {

            }

        }

    }

    class Coordinate
    {
        public int x;
        public int y;
        public Coordinate(int x , int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    class Snake
    {
        public void printFrame()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            for(int x = 0; x<80; x++)
            {
                for (int y = 0; y<23; y++)
                {
                    if(y == 0 || y == 22 || x== 0 || x == 79)
                    {
                        Console.SetCursorPosition(x, y);
                        Console.Write((char)178);
                    }
                }
            } 
        }

        public void setScore(int score)
        {
            Console.SetCursorPosition(0, 23);
            Console.Write("Score : {0}", score);
        }
        
        public void setTime()
        {
            int seconds = 0;
            while (true)
            {
                Thread.Sleep(1000);
                Console.SetCursorPosition(68, 23);
                Console.Write("Time : {0}", ++seconds);
            }
        }

        public void feed()
        {
            Random rnd = new Random();
            for(int i = 0; i<10; i++)
            {
                Console.SetCursorPosition(rnd.Next(2, 60), rnd.Next(2, 15));
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write((char)178);
            }
        }
        snakeDirection direction;
        public void keyControl()
        {
            
            if (Console.KeyAvailable)
            {
                var ch = Console.ReadKey(true).Key;
                switch(ch)
                {
                    case ConsoleKey.UpArrow:
                        direction = snakeDirection.Up;
                        break;

                    case ConsoleKey.DownArrow:
                        direction = snakeDirection.Down;
                        break;

                    case ConsoleKey.LeftArrow:
                        direction = snakeDirection.Left;
                        break;

                    case ConsoleKey.RightArrow:
                        direction = snakeDirection.Right;
                        break;
                }
            }
        }

        public void snakeCreate()
        {
            Random rnd = new Random();
            String ch = ">>>";
            Console.SetCursorPosition(rnd.Next(2, 40), rnd.Next(2, 15));
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(ch);
        }
        List<Coordinate> snake = new List<Coordinate>();
        public void prepareSnake()
        {
            snake.Add(new Coordinate(40, 10));
            snake.Add(new Coordinate(41, 10));
            snake.Add(new Coordinate(42, 10));
        }
        public void moveSnake()
        {
            Coordinate head = snake[0];
            switch(direction)
            {
                case snakeDirection.Left:
                    snake.Insert(0, new Coordinate(head.x - 1, head.y));
                    break;

                case snakeDirection.Right:
                    snake.Insert(0, new Coordinate(head.x + 1, head.y));
                    break;

                case snakeDirection.Up:
                    snake.Insert(0, new Coordinate(head.x, head.y - 1));
                    break;

                case snakeDirection.Down:
                    snake.Insert(0, new Coordinate(head.x, head.y + 1));
                    break;
            }
                
        }
        public void writeSnake()
        {
            Random rnd = new Random();
            Console.SetCursorPosition(rnd.Next(10,60), rnd.Next(10,15));
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write((char)223);
        }
       
    }
}