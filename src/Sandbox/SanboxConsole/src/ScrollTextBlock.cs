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
            if (topLeftCorner.Raw > 0) topLeftCorner.Raw--;
        }

        public void Down()
        {
            if (topLeftCorner.Raw < text.Max.Raw-1) topLeftCorner.Raw++;
        }

        public void Left()
        {
            if (topLeftCorner.Column > 0) topLeftCorner.Column--;
        }
        public void Right()
        {
            if (topLeftCorner.Column < text.Max.Column - 1) topLeftCorner.Column++;
        }

        public void ShowTextInView()
        {
            ClearView();
            Console.SetCursorPosition(5, 5);
            ConsoleColor save = Console.BackgroundColor;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            for (int i = topLeftCorner.Raw; i < Math.Min(text.Max.Raw, size.Raw+topLeftCorner.Raw); i++) 
            {
                Console.SetCursorPosition(5, 5+i-topLeftCorner.Raw);
                Console.Write(text.content[i].SafeSubstring(topLeftCorner.Column,size.Column));
            }
            Console.BackgroundColor = save;
        }

        public void ClearView()
        {
            Console.SetCursorPosition(5, 5);
            ConsoleColor save = Console.BackgroundColor;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            String clearString = new String(' ',size.Column);
            for (int i = 0; i <  size.Raw; i++) 
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
            int bottom = 5-1+size.Column+1;
            int right = 5-1 + size.Raw+1;
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
            Console.Write(new String(Convert.ToChar(0x2500),size.Column));
             Console.SetCursorPosition(top+1,right);
            Console.Write(new String(Convert.ToChar(0x2500),size.Column)); 
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