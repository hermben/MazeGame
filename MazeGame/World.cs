using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MazeGame
{
    class World
    {

        private string[,] Grid;
       private int Rows;
        private int Cols;

        public World(string[,]grid)
        {
            Grid = grid; 
            Rows = grid.GetLength(0);
            Cols = grid.GetLength(1);

        }
           
        public void draw()
        {
            for (int y = 0; y < Rows; y++)
            {
                for (int x = 0; y < Cols; x++)
                {
                    string element = Grid [x, y];
                   Console.SetCursorPosition(y, x);
                   Console.Write(element);

                }


            }

        }

        // making Grid accessible to other class
        public string GetElementAt(int x, int y)
        {

            return Grid[y, x];

        }

        public bool IsPositionWalkable(int x, int y)

        {

            if (x < 0 || y < 0 || x >= Cols|| y >= Rows)
            {

                return false;
            }

            return Grid[y, x] == " " || Grid[y, x] == "X";
        }
    }
}
