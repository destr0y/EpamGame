using System;

namespace EpamGame
{
    public class Trap
    {
        public (int,int) Position { get; set; }
        public int Damage { get; set; }
        public bool IsVisible { get; set; } = false;
        public bool IsActive { get; set; } = true;

        public Trap()
        {
            var random = new Random();
            Position = (random.Next(0,9), random.Next(0,9));
            Damage = random.Next(1,10);
        }
    }
}