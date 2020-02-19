using System.Collections.Generic;
using System;

namespace sneika
{
    public class Snake
    {
        public List<Item> snake;
        private Direction dir;

        public Snake(int x, int y, int length)
        {
            snake = new List<Item>();
            for(int i=0; i < length; i++)
            {
                Item s = new Item(x, y+i, 'o');
                snake.Add(s);
                s.Draw();
            }
            dir = Direction.UP;
        }

        public void Move()
        {
            int xNext = snake[0].x;
            int yNext = snake[0].y;

            snake[0].Clear();
            switch (dir)
            {
                case Direction.LEFT:
                    snake[0].x--;
                    break;

                case Direction.UP:
                    snake[0].y--;
                    break;

                case Direction.RIGHT:
                    snake[0].x++;
                    break;

                case Direction.DOWN:
                    snake[0].y++;
                    break;
            }
            snake[0].Draw();

            for(int i = 1, xt, yt; i < snake.Count; i++)
            {
                xt = snake[i].x;
                yt = snake[i].y;

                snake[i].Clear();
                snake[i].x = xNext;
                snake[i].y = yNext;
                snake[i].Draw();

                xNext = xt;
                yNext = yt;
            }
        }
        

        public void Rotate(ConsoleKey btn)
        {
            switch (dir)
            {
                case Direction.DOWN:
                case Direction.UP:
                    switch (btn) {
                        case ConsoleKey.RightArrow:
                            dir = Direction.RIGHT;
                            break;
                        case ConsoleKey.LeftArrow:
                            dir = Direction.LEFT;
                            break;
                    }
                    break;

                case Direction.RIGHT:
                case Direction.LEFT:
                    switch (btn)
                    {
                        case ConsoleKey.UpArrow:
                            dir = Direction.UP;
                            break;
                        case ConsoleKey.DownArrow:
                            dir = Direction.DOWN;
                            break;
                    }
                    break;
            }
        }

        
    }
}
