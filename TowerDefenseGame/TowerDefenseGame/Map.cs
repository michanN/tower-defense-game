using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefenseGame
{
    class Map
    {
        public readonly int Width; // accessible to external callers, but they can't change the value 
        public readonly int Height;

        public Map(int width, int height) // constructor method that is used when initializing the Map object/instance. No void because constructors can't return anything
        {
            Width = width;
            Height = height;
        }

        public bool OnMap(Point point) // "Point" = requires that a Point object is passed to the method - point is of the type Point, could be string or whatever
        {
            return point.X >= 0 && point.X < Width && 
                   point.Y >= 0 && point.Y < Height;
        }
    }
}
