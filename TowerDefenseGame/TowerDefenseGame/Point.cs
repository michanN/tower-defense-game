using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefenseGame
{
    class Point
    {
        public readonly int X;
        public readonly int Y;

        public Point(int x, int y) // Constructor
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return X + "," + Y;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Point)) // checks if the obj is a Point or is null
            {
                return false;
            }

            Point that = obj as Point;
            return this.X == that.X && this.Y == that.Y;
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() * 31 + Y.GetHashCode();
        }

        public int DistanceTo(int x, int y)
        {
            return (int) Math.Sqrt(Math.Pow(X-x, 2) + // Cartesian distance formula
                         Math.Pow(Y-y, 2));
        }

        public int DistanceTo(Point point) // Overloading - same method that takes different parameters - in this case a parameter of type Point
        {
            return DistanceTo(point.X, point.Y);
        }
    }
}
