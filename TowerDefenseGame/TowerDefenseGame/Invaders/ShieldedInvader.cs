using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefenseGame.Invaders
{
    class ShieldedInvader : Invader
    {
        private const double _deflect = .5;

        public override int Health { get; protected set; } = 2;

        public ShieldedInvader(Path path) : base(path) // Passes the path parameter to the constructor of the base class aka Invader
        {
        }

        public override void DecreaseHealth(int factor) // Overrides the DecreaseHealth() from it's parent class Invader
        {
            if (Random.NextDouble() < _deflect) // NextDouble returns a value between 0 - 1
            {
                base.DecreaseHealth(factor);
            }
            else
            {
                Console.WriteLine("Shot at shielded invader but it sustained no damage!");
            }
        }
    }
}
