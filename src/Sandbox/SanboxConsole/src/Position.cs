using System;
using System.Collections.Generic;
using System.Text;

namespace SanboxConsole
{
    public class Position
    {

        public Position(int r, int c)
        { 
            raw = r;
            column = c;
        }
        public int raw;
        public int column;
    }
}
