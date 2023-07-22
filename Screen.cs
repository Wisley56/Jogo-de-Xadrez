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
