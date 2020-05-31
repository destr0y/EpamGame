using System;
using System.Collections.Generic;
using System.Linq;

namespace EpamGame
{
    class Program
    {
        public static Player player;
        public static List<Trap> traps;
        
        static void Main()
        {
            player = new Player();
            GenerateTraps();
            
            DrawField();
            Console.WriteLine("Your position is 'P' and you must go to 'F'.");
            Console.WriteLine("Press arrows ('↑','←','↓','→') to go.");

            while (player.Position != (9, 9))
            {
                var key = Console.ReadKey(true).Key;
                player.Go(key);

                var trap = traps.FirstOrDefault(trap => trap.Position == player.Position);
                if (trap != null && trap.IsActive)
                {
                    trap.IsVisible = true;
                    trap.IsActive = false;
                    player.Health -= trap.Damage;
                    if (player.Health <= 0)
                    {
                        Console.Clear();
                        Console.WriteLine("You loose! Do you want to try again?");
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
                Console.WriteLine("You win! Do you want to try again?");
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
                if (traps.FirstOrDefault(x => x.Position == trap.Position) != null)
                    continue;
                
                traps.Add(trap);
            }
        }

        static void RepeatGame()
        {
            Console.WriteLine("Press 'Enter' if yes and 'Escape' if no");
            var key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.Enter: 
                    Main(); 
                    break;
                case ConsoleKey.Escape: 
                    Environment.Exit(0); 
                    break;
                default:
                    Console.WriteLine("Incorrect input");
                    RepeatGame();
                    break;
            }
        }

        static void DrawField()
        {
            Console.Clear();

            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    var trap = traps.FirstOrDefault(t => t.Position == (x, y));
                    
                    if ((x,y) == player.Position) 
                        Console.Write("P ");
                    else if ((x,y) == (9,9)) 
                        Console.Write("F");
                    else if (trap != null && trap.IsVisible)
                        Console.Write($"{trap.Damage} ");
                    else Console.Write("# ");
                }
                Console.WriteLine();
            }
        }
    }
}