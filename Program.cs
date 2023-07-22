using System;
using Board;
using Chess;

namespace Xadrez___Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Tray tab = new Tray(8, 8);

                ChessPosition pos = new ChessPosition('c', 7);
                Console.WriteLine(pos);

                Console.WriteLine(pos.toPosition());
            }
            catch(TrayExceptions e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}