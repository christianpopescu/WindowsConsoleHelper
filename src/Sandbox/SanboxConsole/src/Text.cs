using System.Collections.Generic;

namespace SanboxConsole
{
    public class Text
    {
        public List<string> content = new List<string>();

        public Text()
        {
            

        }
        public Text(List<string> content)
        {
            this.content = content;
        }
    }
}