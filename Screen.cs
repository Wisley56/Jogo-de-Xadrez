using System;
using Board;

namespace Xadrez___Console
{
    internal class Screen
    {
        public static void PrintBoard(Tray tab)
        {
            for(int i = 0; i < tab.Lines; i++)
            {
                for(int j = 0; j < tab.Columns; j++)
                {
                    if(tab.getPiece(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write(tab.getPiece(i, j) + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
