using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefenseGame
{
    class TowerDefenseException : Exception
    {
        public TowerDefenseException() // default constructor without any parameters - like overloading method
        {
        }

        public TowerDefenseException(string message) : base(message)
        {
        }
    }

    class OutOfBoundsException : TowerDefenseException
    {
        public OutOfBoundsException()
        {
        }

        public OutOfBoundsException(string message) : base(message)
        {
        }
    }

    class TowerCantBeOnPathException : TowerDefenseException
    {
        public TowerCantBeOnPathException()
        {
        }

        public TowerCantBeOnPathException(string message) : base(message)
        {
        }
    }
}
