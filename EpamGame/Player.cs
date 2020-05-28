using System;

namespace EpamGame
{
    public class Player
    {
        public (int, int) Position { get; set; }
        public int Health { get; set; }

        public Player()
        {
            Position = (0, 0);
            Health = 10;
        }

        public void Go(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.W:
                {
                    if (Position.Item2 != 0)
                        Position = (Position.Item1, Position.Item2 - 1);
                    break;
                }
                case ConsoleKey.A:
                {
                    if (Position.Item1 != 0)
                        Position = (Position.Item1 - 1, Position.Item2);
                    break;
                }
                case ConsoleKey.S:
                {
                    if (Position.Item2 != 9)
                        Position = (Position.Item1, Position.Item2 + 1);
                    break;
                }
                case ConsoleKey.D:
                {
                    if (Position.Item1 != 9)
                        Position = (Position.Item1 + 1, Position.Item2);
                    break;
                }
            }
        }
    }
}