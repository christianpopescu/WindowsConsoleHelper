using System;
using System.Runtime.InteropServices;

namespace SanboxConsole
{
    class Program
    {
[DllImport("kernel32.dll", SetLastError = true)]
static extern IntPtr GetConsoleWindow();

[DllImport("user32.dll", SetLastError = true)]
internal static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);
        static void Main()
        {
            
           // ScrollLineMethod();
/*           ShowConsoleStatistics();
            int origWidth  = Console.WindowWidth;
    int origHeight = Console.WindowHeight;
    Console.WriteLine( origWidth);
    Console.WriteLine(origHeight);
    Console.WriteLine(Console.BufferWidth);
    Console.WriteLine(Console.BufferHeight);
           Console.WindowLeft = 0;
           Console.WindowTop = 0 ;
    Console.WriteLine(Console.IsOutputRedirected) ;
    Console.WriteLine(Console.LargestWindowHeight);
    Console.WriteLine(Console.LargestWindowWidth);
    Console.BufferHeight = 120;*/
    IntPtr ptr = GetConsoleWindow();
    MoveWindow(ptr, 0, 0, 1000, 400, true);
    Console.SetWindowPosition(0,0);
    Console.WriteLine(Console.LargestWindowHeight);
    Console.WriteLine(Console.LargestWindowWidth);
    Console.WindowHeight = 35;
    Console.WindowWidth = 134;

//           Console.SetBufferSize(300,120);
//           Console.SetWindowSize(25,120);
           DoScrollTextBlock();

        }
//todo: Add Scroll function

        // static void Scroll
        static void DoScrollTextBlock()
        {
            Console.WriteLine("l - scroll left  :  m - scroll right  : p - scroll up : ':' - scroll down: q - quit");
            Text text = new Text(@"E:\Temp\TempToDelete\input.txt");
            ScrollTextBlock stb = new ScrollTextBlock(text, new Position(10, 15));
            char c;
            Console.CursorVisible = false;
            stb.ShowTextInView();
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

          private static void ShowConsoleStatistics()
        {
            Console.WriteLine("Console statistics:");
            Console.WriteLine("   Buffer: {0} x {1}", Console.BufferHeight, Console.BufferWidth);
            Console.WriteLine("   Window: {0} x {1}", Console.WindowHeight, Console.WindowWidth);
            Console.WriteLine("   Window starts at {0}.", Console.WindowLeft);
        }
    }
}
