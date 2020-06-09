using System;
namespace SanboxConsole
{
    public static class ConsoleExtension 
    {
        public static void WriteAt(Position pos, Boolean keepCursorPosition, String toWrite) 
        {
           Position save = new Position(0,0);
           if (keepCursorPosition)
           {
               save = new Position(Console.CursorTop,Console.CursorLeft);
           }
           Console.SetCursorPosition(pos.raw, pos.column);
           Console.WriteLine(toWrite);
           if (keepCursorPosition)
           {
               Console.SetCursorPosition(save.column,save.raw);
           }

        }
    }
}