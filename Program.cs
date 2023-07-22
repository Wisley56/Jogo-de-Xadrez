using System;
using Board;
using Chess;

namespace Xadrez___Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            try
            {
                Tray tab = new Tray(8, 8);
                tab.changePiece(new King(Color.Black, tab), new Position(0, 0));
                tab.changePiece(new Tower(Color.Black, tab), new Position(3, 6));
                tab.changePiece(new King(Color.White, tab), new Position(1, 5));
                tab.changePiece(new Pawn(Color.White, tab), new Position(3, 0));

                Screen.printBoard(tab);
            }
            catch(TrayExceptions e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}