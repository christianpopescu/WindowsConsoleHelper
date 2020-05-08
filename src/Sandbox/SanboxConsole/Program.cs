using System;

namespace SanboxConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ScrollLine sl = new ScrollLine();
            sl.Content = "Text to be scrolled to left or to right. This is a longer test to be done";
            sl.Max = sl.Content.Length;
            sl.Width = 15;
            sl.Current = 0;
            char c = 'q';
            
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
