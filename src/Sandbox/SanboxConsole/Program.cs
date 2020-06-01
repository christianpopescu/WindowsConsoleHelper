using System;

namespace SanboxConsole
{
    class Program
    {
        static void Main()
        {
            
           // ScrollLineMethod();
           DoScrollTextBlock();

        }
//todo: Add Scroll function

        // static void Scroll
        static void DoScrollTextBlock()
        {
            Text text = new Text(@"E:\Temp\TempToDelete\input.txt");
            ScrollTextBlock stb = new ScrollTextBlock(text, new Position(10, 10));
            char c;
            Console.SetCursorPosition(1,1);
            while ((c = Console.ReadKey().KeyChar) != 'q')
            {
                switch(c)
                {
                    case 'l' : stb.Left(); break;
                    case 'm' : stb.Right(); break;
                    case 'p' : stb.Up(); break;
                    case ':' : stb.Down(); break;
                    default : break;

                }
                stb.ShowTextInView();
                Console.SetCursorPosition(1,1);
            }
 
        }
        static void ScrollLineMethod()
        {
            Console.WriteLine("l - scroll left  :  m - scroll right : q - quit");
            ScrollLine sl = new ScrollLine();
            sl.Content = "Text to be scrolled to left or to right. This is a longer test to be done";
            sl.Max = sl.Content.Length;
            sl.Width = 15;
            sl.Current = 0;
            char c;
            
            Console.SetCursorPosition(1, 1);
            Console.Write(sl.Content.Substring(sl.Current, sl.Width));
            Console.SetCursorPosition(1, 10);
            while ((c = Console.ReadKey().KeyChar) != 'q')
            {
                if (c == 'l') 
                    sl.Left();
                else if (c == 'm')
                    sl.Right();
                Console.SetCursorPosition(1, 1);
                Console.Write(sl.Content.Substring(sl.Current, sl.Width));

                Console.SetCursorPosition(1, 10);
            }
        }
    }
}
