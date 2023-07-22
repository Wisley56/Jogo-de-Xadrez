using System;
using Board;

namespace Xadrez___Console
{
    internal class Screen //classe sobre iterações com a tela
    {
        public static void printBoard(Tray tab) //imprime o tabuleiro
        {
            for(int i = 0; i < tab.Lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.Columns; j++)
                {
                    if(tab.piece(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        printPiece(tab.piece(i, j));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
        }
        public static void printPiece(Piece piece)
        {
            if(piece.Color == Color.White)
            {
                Console.Write(piece);
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(piece);
                Console.ForegroundColor = aux;
            }
        }
    }
}
