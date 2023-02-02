using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DGridPathfinding.Searcher.Graph
{
    public struct State
    {
        public int xCoordinate { get; set; }
        public int yCoordinate { get; set; }

        public State()
        {
        }

        public override string ToString()
        {
            return xCoordinate.ToString() + " " + yCoordinate.ToString();
        }
    }

    public enum Transition
    {
        North,
        South,
        West,
        East
    }
}
