using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2DGridPathfinding.Objects.Tiles;

namespace _2DGridPathfinding.Objects
{
    public class GameGrid
    {
        private const int GRID_SIZE = 100;
        private const int GRID_BORDER_BUFFER = 2;
        private const string BORDER_STRING = "#";
        private Tile[,] Grid;

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
                    stringBuilder.Append(Grid[i,j].ToString());
                }
                stringBuilder.Append(BORDER_STRING);
                stringBuilder.AppendLine();
            }

            PrintTopOrBottomBorder(stringBuilder);
            return stringBuilder.ToString();
        }

        private void PrintTopOrBottomBorder(StringBuilder stringBuilder)
        {
            for(int i = 0; i < GRID_SIZE + GRID_BORDER_BUFFER; i++)
            {
                stringBuilder.Append(BORDER_STRING);
            }
            stringBuilder.AppendLine();
        }

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
            Grid[99,99] = new EndTile();
        }

    }
}
