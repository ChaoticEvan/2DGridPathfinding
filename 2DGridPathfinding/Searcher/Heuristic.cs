using _2DGridPathfinding.Objects;
using _2DGridPathfinding.Searcher.Graph;

namespace _2DGridPathfinding.Searcher
{
    public class Heuristic
    {
        private GameGrid GameGrid;

        private const double DISTANCE_WEIGHT = 1.0; 
        private const double HEALTH_WEIGHT = 5;
        private const double MOVES_WEIGHT = 12.5;

        public Heuristic(GameGrid gameGrid)
        {
            GameGrid = gameGrid;
        }

        public double GetCost(State currentPosition)
        {
            return (DISTANCE_WEIGHT * CalculateEuclideanDistance(currentPosition)) + 
                (HEALTH_WEIGHT * CalculateHealthScore(currentPosition)) + 
                (MOVES_WEIGHT * CalculateMoveScore(currentPosition));
        }

        private double CalculateEuclideanDistance(State currentPosition)
        {
            int currentXCoordinate = currentPosition.xCoordinate;
            int currentYCoordinate = currentPosition.yCoordinate;
            int endXCoordinate = GameGrid.EndState.xCoordinate;
            int endYCoordinate = GameGrid.EndState.yCoordinate;

            return Math.Pow(Math.Pow(currentXCoordinate - endXCoordinate, 2) + Math.Pow(currentYCoordinate - endYCoordinate, 2), 0.5);
        }

        private double CalculateHealthScore(State currentPosition)
        {
            return GameGrid.GetTile(currentPosition.xCoordinate, currentPosition.yCoordinate).AffectHealth();
        }

        private double CalculateMoveScore(State currentPosition)
        {
            return GameGrid.GetTile(currentPosition.xCoordinate, currentPosition.yCoordinate).AffectMoves();
        }
    }
}
