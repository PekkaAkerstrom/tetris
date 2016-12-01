using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    interface Grid
    {
        int rows { get; }
        int lanes { get; }

        char getCell(int row, int lane);
    }
}
