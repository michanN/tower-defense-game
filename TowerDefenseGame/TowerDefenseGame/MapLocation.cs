using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefenseGame
{
    class MapLocation : Point // MapLocation is now a sub-class of the Point class
    {
        public MapLocation(int x, int y, Map map) : base(x, y) // Constructor - In this case the Point class is the base/parent/super class
        {
            if (!map.OnMap(this)) // "this" referrs to the current object - aka the MapLocation being constructed
            {
                throw new OutOfBoundsException(this + " is outside the boundries of the map!");
            }
        }

        public bool InRangeOf(MapLocation location, int range)
        {
            return DistanceTo(location) <= range;
        }
    }
}
