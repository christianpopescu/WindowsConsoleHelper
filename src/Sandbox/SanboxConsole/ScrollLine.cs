namespace SanboxConsole
{
    public class ScrollLine
    {
        public int Current;
        public string Content;
        public int Width;
        public int Max;

        public void Left()
        {
            Current = Current == 0 ? Current : Current - 1;
        }

        public void Right()
        {
            Current = Current == Max - Width ? Current : Current + 1;
        }
    }
}
