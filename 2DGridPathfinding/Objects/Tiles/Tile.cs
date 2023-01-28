namespace _2DGridPathfinding.Objects.Tiles
{
    abstract public class Tile
    {
        protected int DeltaHealth;
        protected int DeltaMoves;
        protected TileId TileId;
        protected string TileChar;

        public override string ToString()
        {
            return TileChar;
        }
        public abstract int AffectMoves();
        public abstract int AffectHealth();
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
