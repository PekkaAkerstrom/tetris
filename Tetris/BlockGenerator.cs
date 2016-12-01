using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class BlockGenerator
    {
        public static String getNextBlock()
        {
            Random r = new Random(DateTime.Now.Second);
            String[] blocks = { "XXXX" , ".I..I..I.", "AA..AA...", ".T.TTT..." };
            return blocks[r.Next(0, 3)];
        }
    }
}
