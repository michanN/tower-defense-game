using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TowerDefenseGame.Invaders;
using TowerDefenseGame.Towers;

// -----> 1. Add so that the player can choose where to put his towers

namespace TowerDefenseGame
{
    class Program
    {
        static void Main()
        {
            Map map = new Map(8, 5);

            try
            {

                Path path = new Path(
                    new[]
                    {
                        new MapLocation(0, 2, map),
                        new MapLocation(1, 2, map),
                        new MapLocation(2, 2, map),
                        new MapLocation(3, 2, map),
                        new MapLocation(4, 2, map),
                        new MapLocation(5, 2, map),
                        new MapLocation(6, 2, map),
                        new MapLocation(7, 2, map)
                    }
                );

                IInvader[] invaders =
                {
                    new ShieldedInvader(path),
                    new BasicInvader(path),
                    new StrongInvader(path),
                    new ResurrectingInvader(path),
                    new FastInvader(path)
                };

                Tower[] towers =
                {
                    new SniperTower(new MapLocation(1, 3, map), path),
                    new LongRangeTower(new MapLocation(3, 3, map), path),
                    new PowerTower(new MapLocation(5, 3, map), path)
                };

                Level level = new Level(invaders)
                {
                    Towers = towers
                };

                bool playerWon = level.Play();

                Console.WriteLine("Player " + (playerWon? "won" : "lost"));
            }
            catch (OutOfBoundsException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (TowerCantBeOnPathException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (TowerDefenseException)
            {
                Console.WriteLine("Unhandled TowerDefenseException");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unhandles Exception: " + ex);
            }

        }
    }
}
