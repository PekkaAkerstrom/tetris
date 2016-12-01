using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Block : RotatingGrid
    {
        public int rows { get; }
        public int lanes { get; }

        private char[][] grid;

        public int rowPosititon { get; private set; }
        public int lanePosititon { get; private set; }

        public Block(String x)
        {
            if (x.Length == 1)
            {
                rows = 1;
                lanes = 1;
            } else if (x.Length == 4)
            {
                rows = 2;
                lanes = 2;
            } else if (x.Length == 9)
            {
                rows = 3;
                lanes = 3;
            }
            rowPosititon = 0;
            lanePosititon = 0;
            grid = new char[rows][];
            
            for(int row=0; row< rows; row++ ) {
                grid[row] = new char[lanes];
                for (int lane = 0; lane < lanes; lane++)
                {
                    grid[row][lane] = x[(row*lanes) + lane];
                }
            }
        }

        public Block(Grid _grid, int rowPos, int lanePos)
        {
            rows = _grid.rows;
            lanes = _grid.lanes;
            rowPosititon = rowPos;
            lanePosititon = lanePos;

            grid = new char[rows][];

            for (int row = 0; row < rows; row++)
            {
                grid[row] = new char[lanes];
                for (int lane = 0; lane < lanes; lane++)
                {
                    grid[row][lane] = _grid.getCell(row, lane);
                }
            }
        }

        public void move(int x, int y)
        {
            rowPosititon += x;
            lanePosititon += y;
        }

        public Grid rotate(int steps)
        {
            if(rows == 3)
            {
                //RotateGrid if size is 3
                Grid g = this;
                while(steps < 0)
                {
                    steps++;
                    // 1 step left is 3 right
                    g = Rotater.rotate(this);
                    g = Rotater.rotate(this);
                    g = Rotater.rotate(this);
                }
                while (steps > 0)
                {
                    steps--;
                    g = Rotater.rotate(this);
                }
                return g;
            }
            // Do not return a valid grid if we cannot rotate it.
            return null;
        }

        public char getCell(int row, int lane)
        {
            return grid[row][lane];
        }

        public char getGlobalCell(int row, int lane)
        {
            return grid[row - rowPosititon][lane - lanePosititon];
        }

        public bool isGlobalPositionOccupied(int row, int lane)
        {
            if (row - rowPosititon < rows &&
                row - rowPosititon >= 0 &&
                lane - lanePosititon < lanes &&
                lane - lanePosititon >= 0)
            {
                return grid[row - rowPosititon][lane - lanePosititon] != '.';
            }
            return false;
        }
    }
}
