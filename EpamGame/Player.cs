using System;

namespace EpamGame
{
    public class Player
    {
        public (int, int) Position { get; set; } = (0, 0);
        public int Health { get; set; } = 10;

        public void Go(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                {
                    if (Position.Item2 != 0)
                        Position = (Position.Item1, Position.Item2 - 1);
                    break;
                }
                case ConsoleKey.LeftArrow:
                {
                    if (Position.Item1 != 0)
                        Position = (Position.Item1 - 1, Position.Item2);
                    break;
                }
                case ConsoleKey.DownArrow:
                {
                    if (Position.Item2 != 9)
                        Position = (Position.Item1, Position.Item2 + 1);
                    break;
                }
                case ConsoleKey.RightArrow:
                {
                    if (Position.Item1 != 9)
                        Position = (Position.Item1 + 1, Position.Item2);
                    break;
                }
            }
        }
    }
}