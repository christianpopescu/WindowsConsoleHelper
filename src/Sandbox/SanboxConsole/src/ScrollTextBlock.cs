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
            Console.SetCursorPosition(5, 5);
            ConsoleColor save = Console.BackgroundColor;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            for (int i = topLeftCorner.raw; i < Math.Min(text.Max.raw, size.raw+topLeftCorner.raw); i++) 
            {
                Console.SetCursorPosition(5, 5+i-topLeftCorner.raw);
                Console.Write(text.content[i].SafeSubstring(topLeftCorner.column,size.column));
            }
            Console.BackgroundColor = save;
        }

        public void ClearView()
        {
            Console.SetCursorPosition(5, 5);
            ConsoleColor save = Console.BackgroundColor;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            String clearString = new String(' ',size.column);
            for (int i = 0; i <  size.raw; i++) 
            {
                Console.SetCursorPosition(5, 5+i);
                Console.Write(clearString);
            }
            Console.BackgroundColor = save;
        }

        public void ShowBox()
        {
            int top = 5-1;
            int left = 5-1;
            int bottom = 5-1+size.column+1;
            int right = 5-1 + size.raw+1;
            // TODO: To fix top left bottom right
            Console.SetCursorPosition(top,left);
            Console.Write(Convert.ToChar(0x250c));
            Console.SetCursorPosition(bottom, right);
            Console.Write(Convert.ToChar(0x2518));
            Console.SetCursorPosition(top, right);
            Console.Write(Convert.ToChar(0x2514));
            Console.SetCursorPosition(bottom, left);
            Console.Write(Convert.ToChar(0x2510));
            Console.SetCursorPosition(top+1,left);
            Console.Write(new String(Convert.ToChar(0x2500),size.column));
             Console.SetCursorPosition(top+1,right);
            Console.Write(new String(Convert.ToChar(0x2500),size.column)); 
            for (int i=left+1; i<right; ++i)
            {
                Console.SetCursorPosition(top,i);
                Console.Write(Convert.ToChar(0x2502));
            }
            for (int i=left+1; i<right; ++i)
            {
                Console.SetCursorPosition(bottom,i);
                Console.Write(Convert.ToChar(0x2502));
            }
            
            
        }

    }
}