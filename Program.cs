using System;
using Board;
using Chess;

namespace Xadrez___Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Tray tab = new Tray(8, 8);

            tab.changePiece(new King(Color.Black, tab), new Position(0, 5));
            tab.changePiece(new Queen(Color.Black, tab), new Position(1, 3));
            tab.changePiece(new Pawn(Color.Black, tab), new Position(5, 7));

            Screen.printBoard(tab);
        }
    }
}