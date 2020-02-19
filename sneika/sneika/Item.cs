using System;

namespace sneika
{
    public class Item
    {
        public int x { get; set; }
        public int y { get; set; }
        public char ch { get; set; }

        public Item(int x, int y, char character)
        {
            this.x = x;
            this.y = y;
            ch = character;
        }

        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(ch);
        }

        public void Clear()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(" ");
        }

    }
}
