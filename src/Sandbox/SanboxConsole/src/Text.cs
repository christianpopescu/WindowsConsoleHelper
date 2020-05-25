using System;
using System.Collections.Generic;

namespace SanboxConsole
{
    public class Text
    {
        public List<string> content = new List<string>();

        private Position _max;

        public Text()
        {


        }
        public Text(List<string> content)
        {
            this.content = content;
        }

        public Position Max 
        {
            get 
            {
                if (_max == null)
                {
                    _max = new Position(0,0);
                    _max.raw = content.Count;
                    _max.column = 0;
                    foreach (var s in content)
                        if (_max.column < s.Length) _max.column = s.Length;
                }
                return _max;

            }
        }
    }
}