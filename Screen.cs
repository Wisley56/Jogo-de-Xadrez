using System;
using Board;
using Chess;

namespace Xadrez___Console
{
    internal class Screen //classe sobre iterações com a tela
    {
        public static void printGame(ChessGame game) //imprime a tela principal
        {
            Screen.printBoard(game.Tab);
            Console.WriteLine();
            printCapturedPieces(game);
            Console.WriteLine();
            if (!game.End)
            {
                Console.WriteLine("Shift: " + game.Shift);
                Console.WriteLine("Waiting for move: " + game.PlayerCurrent);
                if (game.Check)
                    Console.WriteLine("CHECK!!");
            }
            else
            {
                Console.WriteLine("CHECKMATE!!");
                Console.WriteLine("Wineer is " + game.PlayerCurrent);
            }
        }
        public static void printBoard(Tray tab) //imprime o tabuleiro
        {
            for(int i = 0; i < tab.Lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.Columns; j++)
                {
                    printPiece(tab.piece(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }
        public static void printBoard(Tray tab, bool[,] possiblePositions) //imprime o tabuleiro com as possibilidades de jogada
        {
            ConsoleColor originalBackground = Console.BackgroundColor;
            ConsoleColor changedBackground = ConsoleColor.DarkGray;
            for (int i = 0; i < tab.Lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.Columns; j++)
                {
                    if (possiblePositions[i, j])
                        Console.BackgroundColor = changedBackground;
                    else
                        Console.BackgroundColor = originalBackground;
                    printPiece(tab.piece(i, j));
                    Console.BackgroundColor = originalBackground;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = originalBackground;
        }
        public static void printPiece(Piece piece) //imprime uma peça
        {
            if (piece == null)
            {
                Console.Write("- ");
            }
            else
            { 
                if (piece.Color == Color.White)
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
                Console.Write(" ");
            }

        }
        public static ChessPosition readChessPosition() //ler uma posiçao 
        {
            string s = Console.ReadLine();
            char column = s[0];
            int line = int.Parse(s[1] + "");
            return new ChessPosition(column, line);
        }
        public static void printCapturedPieces(ChessGame game) //imprime as peças capturadas
        {
            Console.WriteLine("Captured Pieces:");
            Console.WriteLine("White: ");
            printGroup(game.capturedPieces(Color.White));
            Console.WriteLine();
            Console.WriteLine("Black: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Black;
            printGroup(game.capturedPieces(Color.Black));
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }
        public static void printGroup(HashSet<Piece> group) //imprime o conjunto
        {
            Console.Write("[");
            foreach(Piece x in group) 
            {
                Console.Write(x + " ");
            }
            Console.WriteLine("]");
        }
    }
}
