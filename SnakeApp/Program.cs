using System;
using System.Threading;
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
            PrintFrame frame = new PrintFrame();
            frame.printFrame();
            Score score = new Score();
            
            
            List<Coordinate> snake = new List<Coordinate>();
            snake.Add(new Coordinate(40, 10));
            snake.Add(new Coordinate(41, 10));
            snake.Add(new Coordinate(42, 10));
            toEat yemek = new toEat();
            yemek.yemler();
            TimerX time = new TimerX();
            time.setTime();
            createSnake snakeCreate = new createSnake();
            snakeCreate.snake();

            ControlKeys keyControl = new ControlKeys();
            keyControl.keyControl();
        }
        
    }
    class PrintFrame
    {
        public void printFrame()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            for (int x = 0; x < 80; x++)
            {
                for (int y = 0; y < 23; y++)
                {
                    if (y == 0 || y == 22 || x == 0 || x == 79)
                    {
                        Console.SetCursorPosition(x, y);
                        Console.Write((char)178);
                    }
                }
            }
        }
    }
    class Score
    {
        public void setScore(int score)
        {
            Console.SetCursorPosition(0, 23);
            Console.Write("Score : {0}", score);
        }
    }
    class TimerX
    {
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
    }
    class Coordinate
    {
        public int x;
        public int y;

        public Coordinate(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    class toEat
    {
        public void yemler()
        {
            Random rnd = new Random();
            
            for(int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(rnd.Next(0, 60), rnd.Next(2,15 ));
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write((char)178);
            }
        }
    }
    class createSnake
    {
        public void snake()
        {
            Random rnd = new Random();

            Console.SetCursorPosition(rnd.Next(2, 60), rnd.Next(2, 15));
            Console.ForegroundColor = ConsoleColor.Yellow;
            String[] snakeArr = new string[] {"---->"};
            
            Console.Write("YILANNN");
        }
    }

    class ControlKeys
    {
        public void keyControl()
        {
            snakeDirection direction;
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
    }
}
