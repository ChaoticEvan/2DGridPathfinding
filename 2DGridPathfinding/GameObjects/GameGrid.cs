using System.Text;
using _2DGridPathfinding.Objects.Tiles;
using _2DGridPathfinding.Searcher;
using _2DGridPathfinding.Searcher.Graph;

namespace _2DGridPathfinding.Objects
{
    public class GameGrid
    {
        /// <summary>
        /// Grid size is specified from problem.pdf
        /// </summary>
        private const int GRID_SIZE = 100;
        private const int GRID_BORDER_BUFFER = 2;

        private const int START_X_COORDINATE = 1;
        private const int START_Y_COORDINATE = 1;
        private const int END_X_COORDINATE = 6;
        private const int END_Y_COORDINATE = 6;


        private const string BORDER_STRING = "#";
        private Tile[,] Grid;
        public State StartState { get; set; }
        public State EndState { get; set; }

        public GameGrid()
        {
            Grid = new Tile[100, 100];
            FillGridWithBlanks();
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
                    Grid[i, j].SetState(i, j);
                }
            }
            Grid[START_X_COORDINATE, START_Y_COORDINATE] = new StartTile();
            Grid[START_X_COORDINATE, START_X_COORDINATE].SetState(START_X_COORDINATE, START_X_COORDINATE);
            StartState = Grid[START_X_COORDINATE, START_X_COORDINATE].GetState();
            Grid[END_X_COORDINATE, END_Y_COORDINATE] = new EndTile();
            Grid[END_X_COORDINATE, END_Y_COORDINATE].SetState(END_X_COORDINATE, END_Y_COORDINATE);
            EndState = Grid[END_X_COORDINATE, END_Y_COORDINATE].GetState();
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
                    Grid[i, j].SetState(i, j);

                }
            }
            Grid[0, 0] = new StartTile();
            Grid[0, 0].SetState(0, 0);
            StartState = Grid[0, 0].GetState();

            Grid[99, 99] = new EndTile();
            Grid[99, 99].SetState(99, 99);
            EndState = Grid[99, 99].GetState();
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

        public List<Tuple<State, Transition, double>> GetChildren(State currentState, GameGrid gameGrid)
        {
            List<Tuple<State, Transition, double>> children = new List<Tuple<State, Transition, double>>();
            int currentXCoordinate = currentState.xCoordinate;
            int currentYCoordinate = currentState.yCoordinate;

            // Add West neighbor
            if (currentXCoordinate > 0)
            {
                State neighborState = Grid[currentXCoordinate - 1, currentYCoordinate].GetState();
                children.Add(new Tuple<State, Transition, double>(
                        neighborState,
                        Transition.North,
                        1.0
                    ));
            }

            // Add East neighbor
            if (currentXCoordinate < 99)
            {
                State neighborState = Grid[currentXCoordinate + 1, currentYCoordinate].GetState();
                children.Add(new Tuple<State, Transition, double>(
                        neighborState,
                        Transition.South,
                       1.0
                    ));
            }

            // Add North neighbor
            if (currentYCoordinate > 0)
            {
                State neighborState = Grid[currentXCoordinate, currentYCoordinate - 1].GetState();
                children.Add(new Tuple<State, Transition, double>(
                        neighborState,
                        Transition.West,
                        1.0
                    ));
            }

            // Add South neighbor
            if (currentYCoordinate < 99)
            {
                State neighborState = Grid[currentXCoordinate, currentYCoordinate + 1].GetState();
                children.Add(new Tuple<State, Transition, double>(
                        neighborState,
                        Transition.East,
                        1.0
                    ));
            }

            return children;
        }
    }
}
