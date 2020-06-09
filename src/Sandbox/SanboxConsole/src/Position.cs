using System;
using System.Collections.Generic;
using System.Text;

namespace SanboxConsole
{
    public class Position
    {

        public Position():this(0,0) {}
        public Position(int r, int c)
        { 
            Raw = r;
            Column = c;
        }
        public int Raw {get; set;}
        public int Column {get; set;}
    }
}
