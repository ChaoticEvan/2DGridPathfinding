using _2DGridPathfinding.Searcher.Graph;

namespace _2DGridPathfinding.Objects.Tiles
{
    abstract public class Tile
    {
        protected int DeltaHealth;
        protected int DeltaMoves;
        protected TileId TileId;
        protected string TileChar;
        protected State TileState;

        public override string ToString()
        {
            return TileChar;
        }
        public int AffectMoves()
        {
            return DeltaMoves;
        }
        public int AffectHealth()
        {
            return DeltaHealth;
        }
        public void SetState(int xCoordinate, int yCoordinate)
        {
            TileState = new State()
            {
                xCoordinate = xCoordinate,
                yCoordinate = yCoordinate
            };
        }

        public State GetState()
        {
            return TileState;
        }
    }

    public enum TileId
    {
        Blank,
        Speeder,
        Lava,
        Mud,
        Start,
        End
    }
}
