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

        public void Lef()
        {
            if (topLeftCorner.column > 0) topLeftCorner.column--;
        }
        public void Righ()
        {
            if (topLeftCorner.column < text.Max.column - 1) topLeftCorner.column++;
        }

        public void ShowTextInView()
        {
            for (int i = topLeftCorner.raw; i < Math.Min(text.Max.raw,size.raw); i++) 
            {
                Console.WriteLine(text.content[i].Substring(topLeftCorner.column,size.column));
            }
        }

    }
}