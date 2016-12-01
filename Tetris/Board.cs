using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Board : Grid
    {
        public int rows { get; }
        public int lanes { get; }

        protected char[][] grid;

        public Board(int _row, int _lane)
        {
            rows = _row;
            lanes = _lane;

            grid = new char[_row][];
            for (int row = 0; row < rows; row++)
            {
                grid[row] = new char[_lane];
                for (int lane = 0; lane < lanes; lane++)
                {
                    grid[row][lane] = '.';
                }
            }
        }

        public void setCell(int row, int lane, char x)
        {
            grid[row][lane] = x;
        }

        public bool isEmpty(int row, int lane)
        {
            return grid[row][lane] == '.';
        }

        public char getCell(int row, int lane)
        {
            return grid[row][lane];
        }

    }
}
