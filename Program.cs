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
                ChessGame game = new ChessGame();

                while(!game.End)
                {
                    Console.Clear();
                    Screen.printBoard(game.Tab);

                    Console.WriteLine();

                    Console.Write("Origin Position: ");
                    Position origin = Screen.readChessPosition().toPosition();
                    Console.Write("Destiny Position: ");
                    Position destiny = Screen.readChessPosition().toPosition();

                    game.performMovement(origin, destiny);
                }
                
                
            }
            catch(TrayExceptions e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}