using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefenseGame.Invaders
{
    interface IMappable
    {
        MapLocation Location { get; } // Auto-Properties - if we write it like this we can remove the field entirely - "public MapLocation Location { get; private set; }"
        // This is now a computed property aka the field does not exist anymore
    }

    interface IMoveable
    {
        void Move();
    }

    interface IInvader : IMappable, IMoveable // An interface defines the public methods and properties of a class.
    {
        int Health { get; }

        bool HasScored { get; }

        bool IsNeutralized { get; }

        bool IsActive { get; }

        void DecreaseHealth(int factor); // Virtual makes it possible for sub classes to be "polymorphic" aka have different implementations of DecreaseHealth()
    }
}
