using System;
namespace SanboxConsole
{
    class ScrollTextBlock
    {
        public Text text;

        public Position size;

        public Position topLeftCorner = new Position(0,0);

        public ScrollTextBlock(Position size) => this.size = size;

        public ScrollTextBlock(Text text) => this.text = text;

        public ScrollTextBlock(Text text, Position size) : this(text) =>this.size =size;
     
        public ScrollTextBlock()
        {
        }

        public void Up()
        {
            if (topLeftCorner.raw > 0) topLeftCorner.raw--;
        }

        public void Down()
        {
            if (topLeftCorner.raw < text.Max.raw-1) topLeftCorner.raw++;
        }

        public void Left()
        {
            if (topLeftCorner.column > 0) topLeftCorner.column--;
        }
        public void Right()
        {
            if (topLeftCorner.column < text.Max.column - 1) topLeftCorner.column++;
        }

        public void ShowTextInView()
        {
            ClearView();
            Console.SetCursorPosition(2, 2);
            ConsoleColor save = Console.BackgroundColor;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            for (int i = topLeftCorner.raw; i < Math.Min(text.Max.raw, size.raw+topLeftCorner.raw); i++) 
            {
                Console.SetCursorPosition(2, 2+i-topLeftCorner.raw);
                Console.Write(text.content[i].SafeSubstring(topLeftCorner.column,size.column));
            }
            Console.BackgroundColor = save;
        }

        public void ClearView()
        {
            Console.SetCursorPosition(2, 2);
            ConsoleColor save = Console.BackgroundColor;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            String clearString = new String(' ',size.column);
            for (int i = 0; i <  size.raw; i++) 
            {
                Console.SetCursorPosition(2, 2+i);
                Console.Write(clearString);
            }
            Console.BackgroundColor = save;
        }

    }
}