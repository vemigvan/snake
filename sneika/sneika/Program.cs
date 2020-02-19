using System;
using System.Linq;
using System.Text;

namespace sneika
{

    enum Direction
    {
        LEFT,
        UP,
        RIGHT,
        DOWN
    }

    
    class Program
    {
        static int x = 50, y = 25;

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            ConsoleKey key;

            Console.BufferWidth = Console.WindowWidth = x + 14;
            Console.BufferHeight = Console.WindowHeight = y;

            do
            {
                Game game = new Game(x, y);
                Console.Clear();
                SetInfo();

                Snake zmey = new Snake(x / 2, y / 2, 3);

                game.GameLogic(zmey);

                Console.SetCursorPosition(x / 2 - 5, y / 2-2);
                Console.Write("Game Over");

                Console.SetCursorPosition(x / 2 - 13, y / 2);
                Console.Write("R - restart     Esc - exit");

                do
                {
                    key = Console.ReadKey(true).Key;
                } while (key != ConsoleKey.R && key != ConsoleKey.Escape);
            } while (key == ConsoleKey.R);
        }


        delegate void Cursor(int i);
        public static void SetInfo()
        {
            
            Cursor cursor = i => Console.SetCursorPosition(x + 2, i);
            cursor(0);
            Console.Write("-=SNEIKA=-");
            cursor(3);
            Console.Write("Score: 000");
            cursor(5);
            Console.Write("Space-pause");
            cursor(6);
            Console.Write("Esc - exit");
        }

    }
}
