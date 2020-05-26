using System;

namespace SanboxConsole
{
    class Program
    {
        static void Main()
        {
            Text text = new Text(@"E:\Temp\TempToDelete\input.txt");
            ScrollLineMethod();

        }
//todo: Add Scroll function

        // static void Scroll
        
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
