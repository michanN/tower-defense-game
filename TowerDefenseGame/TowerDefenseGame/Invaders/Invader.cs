using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefenseGame.Invaders
{
    abstract class Invader : IInvader
    {
        private readonly Path _path;
        private int _pathStep = 0; // Fields are always initialized before the constructor is called

        protected Invader(Path path)
        {
            _path = path;
        }

        public MapLocation Location => _path.GetLocationAt(_pathStep); // Auto-Properties - if we write it like this we can remove the field entirely - "public MapLocation Location { get; private set; }"
                                                                       // This is now a computed property aka the field does not exist anymore

        public abstract int Health { get; protected set; }

        public bool HasScored => _pathStep >= _path.Length;

        public bool IsNeutralized => Health <= 0;

        public bool IsActive => !(IsNeutralized || HasScored);

        public void Move() => _pathStep += StepSize;

        public virtual void DecreaseHealth(int factor) // Virtual makes it possible for sub classes to be "polymorphic" aka have different implementations of DecreaseHealth()
        {
            Health -= factor;
            Console.WriteLine("Shot at and hit an invader!");
        }

        protected virtual int StepSize { get; } = 1; // Protected makes so that only the Invader class and it's sub classes can access this property
    }
}
