using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TowerDefenseGame.Invaders;

namespace TowerDefenseGame.Towers
{
    class Tower
    {
        private readonly MapLocation _location; // This is a field
        private readonly Path _path;

        protected virtual int Range { get; } = 1;
        protected virtual int Power { get; } = 1;
        protected virtual double Accuracy { get; } = .75;

        public Tower(MapLocation location, Path path) // This is the constructor
        {
            _location = location;
            _path = path;

            if (_path.IsOnPath(_location)) // Checks if tower is placed on invader path
            {
                throw new TowerCantBeOnPathException("Towers can't be placed on the invader path!");
            }
        }

        public bool IsSuccessfulShot()
        {
            return Random.NextDouble() < Accuracy;
        }

        public void FireOnInvanders(IInvader[] invaders)
        {
            foreach (IInvader invader in invaders)
            {
                if (invader.IsActive && _location.InRangeOf(invader.Location, Range))
                {
                    if(IsSuccessfulShot())
                    {
                        invader.DecreaseHealth(Power);
                        if (invader.IsNeutralized)
                        {
                           Console.WriteLine("Neutralized an invader at: " + invader.Location); 
                        }
                    }
                    else
                    {
                        Console.WriteLine("Shot at and missed an invader");
                    }
                    break;
                }
            }
        }
    }
}
