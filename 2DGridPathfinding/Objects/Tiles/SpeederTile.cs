using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DGridPathfinding.Objects.Tiles
{
    public class SpeederTile : Tile
    {
        public SpeederTile()
        {
            DeltaMoves = 0;
            DeltaHealth = -5;
            TileId = TileId.Speeder;
            TileChar = ">";
        }
    }
}
