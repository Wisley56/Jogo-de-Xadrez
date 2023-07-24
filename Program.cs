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

                ChessGame game = new ChessGame();
            try
            {
                while (!game.End)
                {
                    try
                    {
                        Console.Clear();
                        Screen.printGame(game);

                        Console.WriteLine();

                        Console.Write("Origin Position: ");
                        Position origin = Screen.readChessPosition().toPosition();
                        game.validateOriginPosition(origin);

                        bool[,] possiblePositions = game.Tab.getPiece(origin).possiblesMoves();

                        Console.Clear();
                        Screen.printBoard(game.Tab, possiblePositions);

                        Console.WriteLine();

                        Console.Write("Destiny Position: ");
                        Position destiny = Screen.readChessPosition().toPosition();
                        game.validateDestinyPosition(origin, destiny);

                        game.performsMoves(origin, destiny);
                    }
                    catch (TrayExceptions e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
            }
            catch(TrayExceptions e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}