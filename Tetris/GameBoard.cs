using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class GameBoard : Board
    {
        public GameBoard(int _row, int _lane): base(_row, _lane)
        {

        }

        public int removeFullLines()
        {
            int nrOfLines = 0;

            for (int row = rows-1; row >= 0 ; row--)
            {
                bool full = true;
                for (int lane = 0; lane < lanes; lane++)
                {
                    full = full && !isEmpty(row, lane);
                }
                if (full)
                {
                    for (int _row = row; _row > 0; _row--)
                    {
                        for (int lane = 0; lane < lanes; lane++)
                        {
                            grid[_row][lane] = grid[_row - 1][lane];
                        }
                    }
                    // Top line
                    for (int lane = 0; lane < lanes; lane++)
                    {
                        grid[0][lane] = '.';
                    }

                    nrOfLines++;
                    row++;
                }
            }
            return nrOfLines;
        }
    }
}
