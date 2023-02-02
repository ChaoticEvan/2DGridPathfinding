using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DGridPathfinding.GameObjects
{
    public class Player
    {
        private const int STARTING_HEALTH = 250;
        private const int STARTING_MOVES = 100;

        private int Health;
        private int Moves;
        public Player()
        {
            Health = STARTING_HEALTH;
            Moves = STARTING_MOVES;
        }

        public int GetHealth()
        {
            return Health;
        }

        public int GetMoves()
        {
            return Moves;
        }

        public void AffectHealth(int deltaHealth)
        {
            Health += deltaHealth;
        }

        public void AffectMoves(int deltaMoves)
        {
            Moves += deltaMoves;
        }
    }
}
