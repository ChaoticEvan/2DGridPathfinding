using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DGridPathfinding.Objects.Tiles
{
    public class LavaTile : Tile
    {
        public LavaTile()
        {
            DeltaMoves = -10;
            DeltaHealth = -50;
            TileId = TileId.Lava;
            TileChar = "@";
        }
    }
}
