using System.Text;
using _2DGridPathfinding.Objects.Tiles;

namespace _2DGridPathfinding.Objects
{
    public class GameGrid
    {
        /// <summary>
        /// Grid size is specified from problem.pdf
        /// </summary>
        private const int GRID_SIZE = 100;
        private const int GRID_BORDER_BUFFER = 2;
        private const string BORDER_STRING = "#";
        private Tile[,] Grid;

        public GameGrid()
        {
            Grid = new Tile[100, 100];
            FillGridWithRandomTiles();
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            PrintTopOrBottomBorder(stringBuilder);

            for (int i = 0; i < GRID_SIZE; i++)
            {
                stringBuilder.Append(BORDER_STRING);
                for (int j = 0; j < GRID_SIZE; j++)
                {
                    stringBuilder.Append(Grid[i, j].ToString());
                }
                stringBuilder.Append(BORDER_STRING);
                stringBuilder.AppendLine();
            }

            PrintTopOrBottomBorder(stringBuilder);
            return stringBuilder.ToString();
        }

        private void PrintTopOrBottomBorder(StringBuilder stringBuilder)
        {
            for (int i = 0; i < GRID_SIZE + GRID_BORDER_BUFFER; i++)
            {
                stringBuilder.Append(BORDER_STRING);
            }
            stringBuilder.AppendLine();
        }

        /// <summary>
        /// Testing method for filling grid with blank tiles
        /// </summary>
        private void FillGridWithBlanks()
        {
            for (int i = 0; i < GRID_SIZE; i++)
            {
                for (int j = 0; j < GRID_SIZE; j++)
                {
                    Grid[i, j] = new BlankTile();
                }
            }
            Grid[0, 0] = new StartTile();
            Grid[99, 99] = new EndTile();
        }

        /// <summary>
        /// Testing method for filling grid with semi-random tiles
        /// </summary>
        private void FillGridWithRandomTiles()
        {
            for (int i = 0; i < GRID_SIZE; i++)
            {
                for (int j = 0; j < GRID_SIZE; j++)
                {
                    Grid[i, j] = GetRandomTile();
                }
            }
            Grid[0, 0] = new StartTile();
            Grid[99, 99] = new EndTile();
        }

        /// <summary>
        /// Helper method for filling grid with random tiles
        /// </summary>
        /// <returns>A blank tile 50% of the time, speeder tile 30% of the time, lava tile 10% of the time, and mud tile 10% of the time</returns>
        private Tile GetRandomTile()
        {
            Random random = new Random();
            int next = random.Next(0, 10);
            switch (next)
            {
                default:
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                    return new BlankTile();
                case 5:
                case 6:
                case 7:
                    return new SpeederTile();
                case 8:
                    return new LavaTile();
                case 9:
                    return new MudTile();
            }
        }
    }
}
