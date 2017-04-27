using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using TowerDefenseGame.Invaders;
using TowerDefenseGame.Towers;

namespace TowerDefenseGame
{
    class Level
    {
        private readonly IInvader[] _invaders;

        public Level(IInvader[] invaders)
        {
            _invaders = invaders;
        }

        public Tower[] Towers { get; set; }

        // Returns: true if the player wins, false otherwise.
        public bool Play()
        {
            // Run until all invaders are neutralized or reches the end of the path
            int remainingInvaders = _invaders.Length;

            while (remainingInvaders > 0)
            {
                // Each tower has the opportunity to fire on invaders
                foreach (Tower tower in Towers)
                {
                    tower.FireOnInvanders(_invaders);
                }

                // Count and move the invaders that are still alive
                remainingInvaders = 0;
                foreach (IInvader invader in _invaders)
                {
                    if (invader.IsActive)
                    {
                        invader.Move();
                        if (invader.HasScored)
                        {
                            return false;
                        }
                        remainingInvaders++;
                    }
                }
            }
            return true;
        }
    }
}
