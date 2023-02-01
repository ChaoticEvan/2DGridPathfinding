// This is the body of the main method
using _2DGridPathfinding.Objects;
using _2DGridPathfinding.Searcher;
using _2DGridPathfinding.Searcher.Graph;
using System.Transactions;

GameGrid grid = new GameGrid();
Console.WriteLine(grid.ToString());

Searcher searcher = new Searcher(grid);
List<Transition> moves = searcher.Search();
foreach(var move in moves)
{
    Console.WriteLine(move);
}