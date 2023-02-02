using _2DGridPathfinding.Objects;
using _2DGridPathfinding.Objects.Tiles;
using _2DGridPathfinding.Searcher.Graph;

namespace _2DGridPathfinding.Searcher
{
    public class Searcher
    {
        private PriorityQueue<State, double> TileQueue;
        private Dictionary<State, Tuple<State, Transition>> Parents;
        private Dictionary<State, double> Costs;
        private GameGrid GameGrid;
        private State CurrentState;
        private HashSet<State> Visited;

        public Searcher(GameGrid gameGrid)
        {
            TileQueue = new PriorityQueue<State, double>();
            Parents = new Dictionary<State, Tuple<State, Transition>>();
            Costs = new Dictionary<State, double>();
            Costs.Add(gameGrid.StartState, 0);
            GameGrid = gameGrid;
            CurrentState = gameGrid.StartState;
            Visited = new HashSet<State>();
        }

        public void PushState(State state, double priority)
        {
            TileQueue.Enqueue(state, priority);
        }

        public void UpdateParent(State child, Transition transition)
        {
            if (!Parents.ContainsKey(child))
            {
                Parents.Add(child, new Tuple<State, Transition>(CurrentState, transition));
            }
        }

        public bool UpdateCosts(State child, double transitionCost)
        {
            double currentCost = Costs[CurrentState];
            double totalCost = currentCost + transitionCost;
            if (!Costs.ContainsKey(child) || totalCost < Costs[child])
            {
                Costs[child] = currentCost + transitionCost;
                return true;
            }
            return false;
        }

        public List<Transition> Search()
        {

            PushState(CurrentState, 0);

            while (TileQueue.Count > 0)
            {
                CurrentState = TileQueue.Dequeue();

                if (CurrentState.Equals(GameGrid.EndState))
                {
                    break;
                }

                if (Visited.Contains(CurrentState))
                {
                    continue;
                }

                List<Tuple<State, Transition, double>> children = GameGrid.GetChildren(CurrentState, GameGrid);

                foreach (var child in children)
                {
                    if (Visited.Contains(child.Item1))
                    {
                        continue;
                    }

                    UpdateParent(child.Item1, child.Item2);

                    double heuristicCost = new Heuristic(GameGrid).GetCost(child.Item1);
                    if (UpdateCosts(child.Item1, child.Item3))
                    {
                        Parents[child.Item1] = new Tuple<State, Transition>(CurrentState, child.Item2);
                    }
                    double totalCost = child.Item3 + heuristicCost + Costs[CurrentState];

                    PushState(child.Item1, totalCost);
                }

                Visited.Add(CurrentState);
            }

            List<Transition> path = new List<Transition>();

            while (!CurrentState.Equals(GameGrid.StartState))
            {
                State fromState = Parents[CurrentState].Item1;
                Transition fromTransition = Parents[CurrentState].Item2;

                path.Add(fromTransition);
                CurrentState = fromState;
            }

            path.Reverse();
            return path;
        }
    }
}
