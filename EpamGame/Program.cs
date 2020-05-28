using System;
using System.Collections.Generic;
using System.Linq;

namespace EpamGame
{
    class Program
    {
        public static Player player;
        public static List<Trap> traps;
        
        static void Main(string[] args)
        {
            player = new Player();
            GenerateTraps();

            DrawField();
            Console.WriteLine("Your position is 'P' and you must go to 'F'. Press W,A,S,D to go");

            while (player.Position != (9, 9))
            {
                var key = Console.ReadKey().Key;
                player.Go(key);

                var damage = traps.FirstOrDefault(trap => trap.Position == player.Position)?.Damage;
                if (damage.HasValue)
                {
                    player.Health -= damage.Value;
                    if (player.Health <= 0)
                    {
                        Console.Clear();
                        Console.WriteLine("You loose. Do you want to try again?");
                        RepeatGame();
                        break;
                    }
                }

                DrawField();
                Console.WriteLine($"Your health: {player.Health}");
            }

            if (player.Position == (9, 9))
            {
                Console.Clear();
                Console.WriteLine("You won! Do you want to try again?");
                RepeatGame();
            }

        }

        static void GenerateTraps()
        {
            traps = new List<Trap>();
            
            while (traps.Count != 10)
            {
                var trap = new Trap();
                
                if (trap.Position == (0,0) || trap.Position == (9,9))
                    continue;
                if (traps.Find(x => x.Position == trap.Position) != null)
                    continue;
                
                traps.Add(trap);
            }
        }

        static void RepeatGame()
        {
            Console.WriteLine("Press 'Y' if yes and 'N' if no");
            var key = Console.ReadKey().Key;

            if (key == ConsoleKey.Y)
            {
                Main(null);
            }
            else if (key == ConsoleKey.N)
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Incorrect input");
                RepeatGame();
            }
        }

        static void DrawField()
        {
            Console.Clear();
            
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    if ((x,y) == player.Position) 
                        Console.Write("P ");
                    else if ((x,y) == (9,9)) 
                        Console.Write("F");
                    else Console.Write("# ");
                }
                Console.WriteLine();
            }
        }
    }
}