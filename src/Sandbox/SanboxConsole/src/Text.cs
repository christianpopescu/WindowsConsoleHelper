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

        public Text(string pathToFile)
        {
            content = new List<string>(System.IO.File.ReadAllLines(pathToFile));
        }

        public Position Max 
        {
            get 
            {
                if (_max == null)
                {
                    _max = new Position(0,0);
                    _max.Raw = content.Count;
                    _max.Column = 0;
                    foreach (var s in content)
                        if (_max.Column < s.Length) _max.Column = s.Length;
                }
                return _max;

            }
        }
    }
}