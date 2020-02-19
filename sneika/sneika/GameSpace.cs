using System;

namespace sneika
{
    public class Game
    {
        int x;
        int y;
        public int score=0;
        public Game(int x = 50, int y = 25)
        {
            this.x = x;
            this.y = y;
        }

        public void GameLogic(Snake snk)
        {
            bool gameover = false;
            int time = 150;
            Random rnd = new Random();
            Item apple = new Item(rnd.Next(1, x - 1), rnd.Next(1, y - 1), 'O');
            apple.Draw();

            DrawWalls();

            while (!gameover)
            {
                //Moving
                if (Console.KeyAvailable)
                {
                    ConsoleKey key = Console.ReadKey(true).Key;

                    switch (key)
                    {
                        case ConsoleKey.Spacebar:
                            while (Console.ReadKey(true).Key != ConsoleKey.Spacebar) { };
                            break;

                        case ConsoleKey.Escape:
                            Environment.Exit(0);
                            break;

                        case ConsoleKey.LeftArrow:
                        case ConsoleKey.UpArrow:
                        case ConsoleKey.RightArrow:
                        case ConsoleKey.DownArrow:
                            snk.Rotate(key);
                            break;

                    }
                }
                snk.Move();

                if (snk.snake[snk.snake.Count - 1].x == apple.x && snk.snake[snk.snake.Count - 1].y == apple.y)
                {
                    int tx = snk.snake[snk.snake.Count - 1].x;
                    int ty = snk.snake[snk.snake.Count - 1].y;
                    System.Threading.Thread.Sleep(time);
                    snk.Move();
                    Item tail = new Item(tx, ty, 'o');
                    tail.Draw();
                    snk.snake.Add(tail);

                    do
                    {
                        tx = rnd.Next(1, x - 1);
                        ty = rnd.Next(1, y - 1);
                    }
                    while (!Check(tx, ty, snk));
                    apple.x = tx;
                    apple.y = ty;
                    apple.Draw();

                    if (time > 30)
                        time -= 10;

                    score += 10;
                    PrintScore();
                }

                if (CheckLoose(snk) == false)
                    gameover = true;


                System.Threading.Thread.Sleep(time);
            }
        }

        public void DrawWalls()
        {
            char ch = '#';
            int i;
            int j;
            Console.SetCursorPosition(0, 0);

            for (j = 0; j < x; j++)//top wall
            {
                Console.Write(ch);
            }
            Console.WriteLine();

            for (i = 1; i < y - 1; i++)//borders
            {
                Console.SetCursorPosition(0, i);
                Console.WriteLine(ch);
                Console.SetCursorPosition(x-1, i);
                Console.WriteLine(ch);
            }

            //bottom wall
            for (j = 0; j < x; j++)
            {
                Console.Write(ch);
            }
        }



        private bool Check(int x, int y, Snake a)
        {
            foreach (Item el in a.snake)
            {
                if (x == el.x && y == el.y)
                {
                    return false;
                }
            }
            return true;

        }

        private bool CheckLoose(Snake a)
        {
            for(int i = 1; i < a.snake.Count; i++)
            {
                if (a.snake[0].x == a.snake[i].x && a.snake[0].y == a.snake[i].y)
                    return false;
            }
            if (a.snake[0].x == x - 1 || a.snake[0].y == y - 1 || a.snake[0].x == 0 || a.snake[0].y == 0)
            {
                foreach (Item el in a.snake)
                {
                    el.ch = 'x';
                    el.Draw();
                }
                return false;
            }
            return true;
        }

        private void PrintScore()
        {
            if (score<100)
                Console.SetCursorPosition(x + 10, 3);
            else
                Console.SetCursorPosition(x + 9, 3);
            Console.Write(score);
        }
    }
}

