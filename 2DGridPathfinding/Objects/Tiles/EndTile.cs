using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DGridPathfinding.Objects.Tiles
{
    public class EndTile : Tile
    {
        public EndTile()
        {
            DeltaMoves = 0;
            DeltaHealth = 0;
            TileId = TileId.End;
            TileChar = "B";
        }
        public override int AffectHealth()
        {
            throw new NotImplementedException();
        }

        public override int AffectMoves()
        {
            throw new NotImplementedException();
        }
    }
}
