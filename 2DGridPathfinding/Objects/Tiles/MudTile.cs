using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DGridPathfinding.Objects.Tiles
{
    public class MudTile : Tile
    {
        public MudTile() 
        {
            DeltaMoves = -5;
            DeltaHealth = -10;
            TileId = TileId.Mud;
            TileChar = "&";
        }
    }
}
