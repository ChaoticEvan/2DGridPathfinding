using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DGridPathfinding.Objects.Tiles
{
    public class BlankTile : Tile
    {
        public BlankTile()
        {
            DeltaHealth = 0;
            DeltaMoves = -1;
            TileId = TileId.Blank;
            TileChar = "_";
        }
    }
}
