using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Rotater
    {
        public static Grid rotate(Grid grid)
        {
            Board board = new Board(grid.rows, grid.lanes);
            board.setCell(0, 0, grid.getCell(2, 0));
            board.setCell(0, 1, grid.getCell(1, 0));
            board.setCell(0, 2, grid.getCell(0, 0));

            board.setCell(1, 0, grid.getCell(2, 1));
            board.setCell(1, 1, grid.getCell(1, 1));
            board.setCell(1, 2, grid.getCell(0, 1));

            board.setCell(2, 0, grid.getCell(2, 2));
            board.setCell(2, 1, grid.getCell(1, 2));
            board.setCell(2, 2, grid.getCell(0, 2));

            return board;
        }
    }
}
