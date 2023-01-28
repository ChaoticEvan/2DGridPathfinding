using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DGridPathfinding.Objects.Tiles
{
    public class StartTile : Tile
    {
        public StartTile()
        {
            DeltaMoves = 0;
            DeltaHealth = 0;
            TileId = TileId.Start;
            TileChar = "A";
        }
    }
}
