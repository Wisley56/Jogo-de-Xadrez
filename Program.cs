using System;
using Board;

namespace Xadrez___Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Tray tab = new Tray(8, 8);
            Screen.PrintBoard(tab);
        }
    }
}