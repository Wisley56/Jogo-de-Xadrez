using System;
using Board;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;

namespace Chess
{
    internal class ChessGame //classe controla o jogo de xadrez
    {
        public Tray Tab { get; private set; }
        public int Shift { get; private set; } //turno
        public Color PlayerCurrent { get; private set; } //cor dojogador atual
        public bool End { get; private set; } //para dizer que o jogo acabou
        private HashSet<Piece> Pieces; //conjunto de peças
        private HashSet<Piece> Captureds; //conjuntos de capturadas
        public bool Check { get; private set; } //variavel de xeque
        public Piece vulnerableEnPassant { get; private set; }

        public ChessGame()
        {
            Tab = new Tray(8, 8);
            Shift = 1;
            PlayerCurrent = Color.White;
            Pieces = new HashSet<Piece>();
            Captureds = new HashSet<Piece>();
            Check = false;
            positionInitial();
            End = false;
            vulnerableEnPassant = null;
        }

        public Piece performMovement(Position origin, Position destiny) //executa os movimentos
        {
            Piece p = Tab.removePiece(origin); //remove a peça de origem
            p.increaseMovement(); //incrementa o movimenta da peça
            Piece capturedPiece = Tab.removePiece(destiny);//captura a peça da posiçao de destino (se houver)
            Tab.changePiece(p, destiny); //coloca a peça p na posiçao de destino
            if(capturedPiece != null)
                Captureds.Add(capturedPiece);

            //JOGADAS ESPECIAIS

            //roque pequeno
            if(p is King && destiny.Column == origin.Column + 2)
            {
                Position originT = new Position(origin.Line, origin.Column + 3);
                Position destinyT = new Position(origin.Line, origin.Column + 1);
                Piece T = Tab.removePiece(originT);
                T.increaseMovement();
                Tab.changePiece(T, destinyT);
            }

            //roque grande
            if (p is King && destiny.Column == origin.Column - 2)
            {
                Position originT = new Position(origin.Line, origin.Column - 4);
                Position destinyT = new Position(origin.Line, origin.Column - 1);
                Piece T = Tab.removePiece(originT);
                T.increaseMovement();
                Tab.changePiece(T, destinyT);
            }

            //en passant
            if(p is Pawn)
            {
                if(origin.Column != destiny.Column && capturedPiece == null) //ocorreu o en passant
                {
                    Position posP;
                    if (p.Color == Color.White)
                        posP = new Position(destiny.Line + 1, destiny.Column);

                    else
                        posP = new Position(destiny.Line - 1, destiny.Column);
                    capturedPiece = Tab.removePiece(posP);
                    Captureds.Add(capturedPiece);
                }
            }

            return capturedPiece;
        }
        public void undoMove(Position origin, Position destiny, Piece capturedPiece) //desfaz o movimento
        {
            Piece p = Tab.removePiece(destiny);
            p.decrementMovement();
            if (capturedPiece != null)
            {
                Tab.changePiece(capturedPiece, destiny);
                Captureds.Remove(capturedPiece);
            }
            Tab.changePiece(p, origin);

            //JOGADAS ESPECIAIS

            //roque pequeno
            if (p is King && destiny.Column == origin.Column + 2)
            {
                Position originT = new Position(origin.Line, origin.Column + 3);
                Position destinyT = new Position(destiny.Line, destiny.Column + 1);
                Piece T = Tab.removePiece(destinyT);
                T.decrementMovement();
                Tab.changePiece(T, originT);
            }
            //roque grande
            if (p is King && destiny.Column == origin.Column - 2)
            {
                Position originT = new Position(origin.Line, origin.Column - 4);
                Position destinyT = new Position(destiny.Line, destiny.Column - 1);
                Piece T = Tab.removePiece(destinyT);
                T.increaseMovement();
                Tab.changePiece(T, originT);
            }

            //en passant
            if(p is Pawn)
            {
                if(origin.Column != destiny.Column && capturedPiece == vulnerableEnPassant)
                {
                    Piece pawn = Tab.removePiece(destiny);
                    Position posP;
                    if (p.Color == Color.White)
                        posP = new Position(3, destiny.Column);
                    else
                        posP = new Position(4, destiny.Column);

                    Tab.changePiece(pawn, posP);
                }
            }
        }
        public void performsMoves(Position origin, Position destiny) //realiza a jogada na partida
        {
            Piece capturedPiece = performMovement(origin, destiny);
            if(isInCheck(PlayerCurrent))
            {
                undoMove(origin, destiny, capturedPiece);
                throw new TrayExceptions("You cannot put yourself in check!");
            }
            if (isInCheck(rivalColor(PlayerCurrent))) //verifica se o jogador adversario esta em xeque
            {
                Check = true;
                makeSoundCheck();
            }
            else
                Check = false;
            if (checkmateTest(rivalColor(PlayerCurrent))) //verifica se o jogador adversario esta em xequemate para finalizar o jogo
            {
                makeSoundCheckmate();
                End = true;
            }
            else
            {
                Shift++;
                playerChange();
            }

            Piece p = Tab.getPiece(destiny); //peça movida

            //JOGADA ESPECIAL: EN PASANT

            if (p is Pawn && (destiny.Line == origin.Line - 2 || destiny.Line == origin.Line + 2))
                vulnerableEnPassant = p;
            else
                vulnerableEnPassant = null;
        }
        public void validateOriginPosition(Position pos)
        {
            if (Tab.getPiece(pos) == null)
                throw new TrayExceptions("There is no part in the chosen origin position!");
            if (PlayerCurrent != Tab.getPiece(pos).Color)
                throw new TrayExceptions("The chosen source part is not yours!");
            if (!Tab.getPiece(pos).existMovesPossibles())
                throw new TrayExceptions("No moves possible!");
        }
        public void validateDestinyPosition(Position origin, Position destiny)
        {
            if (!Tab.getPiece(origin).canMoveTo(destiny))
                throw new TrayExceptions("Invalid target position!");
        }
        private void playerChange() //mudar jogador
        {
            if (PlayerCurrent == Color.White)
                PlayerCurrent = Color.Black;
            else
                PlayerCurrent = Color.White;
        }
        public void putNewPart(char column, int line, Piece piece) //metodo para colocar nova peça e adicionar no conjunto
        {
            Tab.changePiece(piece, new ChessPosition(column, line).toPosition());
            Pieces.Add(piece);
        }
        private void positionInitial() //metodo para iniciar as peças nas devidas posiçoes
        { 

            putNewPart('a', 2, new Pawn(Color.White, Tab, this));
            putNewPart('b',2, new Pawn(Color.White, Tab, this));
            putNewPart('c', 2, new Pawn(Color.White, Tab, this));
            putNewPart('d', 2, new Pawn(Color.White, Tab, this));
            putNewPart('e', 2, new Pawn(Color.White, Tab, this));
            putNewPart('f', 2, new Pawn(Color.White, Tab, this));
            putNewPart('g', 2, new Pawn(Color.White, Tab, this));
            putNewPart('h', 2, new Pawn(Color.White, Tab, this));
            putNewPart('a', 1, new Tower(Color.White, Tab));
            putNewPart('h', 1, new Tower(Color.White, Tab));
            putNewPart('b', 1, new Horse(Color.White, Tab));
            putNewPart('g', 1, new Horse(Color.White, Tab));
            putNewPart('c', 1, new Bishop(Color.White, Tab));
            putNewPart('f', 1, new Bishop(Color.White, Tab));
            putNewPart('d', 1, new Queen(Color.White, Tab));
            putNewPart('e', 1, new King(Color.White, Tab, this));

            putNewPart('a', 7, new Pawn(Color.Black, Tab, this));
            putNewPart('b', 7, new Pawn(Color.Black, Tab, this));
            putNewPart('c', 7, new Pawn(Color.Black, Tab, this));
            putNewPart('d', 7, new Pawn(Color.Black, Tab, this));
            putNewPart('e', 7, new Pawn(Color.Black, Tab, this));
            putNewPart('f', 7, new Pawn(Color.Black, Tab, this));
            putNewPart('g', 7, new Pawn(Color.Black, Tab, this));
            putNewPart('h', 7, new Pawn(Color.Black, Tab, this));
            putNewPart('a', 8, new Tower(Color.Black, Tab));
            putNewPart('h', 8, new Tower(Color.Black, Tab));
            putNewPart('b', 8, new Horse(Color.Black, Tab));
            putNewPart('g', 8, new Horse(Color.Black, Tab));
            putNewPart('c', 8, new Bishop(Color.Black, Tab));
            putNewPart('f', 8, new Bishop(Color.Black, Tab));
            putNewPart('d', 8, new Queen(Color.Black, Tab));
            putNewPart('e', 8, new King(Color.Black, Tab, this));
        }
        public HashSet<Piece> capturedPieces(Color c) //retorna o conjunto de peças capturadas em jogo da cor escolhida
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach(Piece x in Captureds)
            {
                if (x.Color == c)
                    aux.Add(x);
            }
            return aux;
        }
        public HashSet<Piece> PiecesInGame(Color c) //retorna o conjunto de peças em jogo
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in Pieces)
            {
                if (x.Color == c)
                    aux.Add(x);
            }
            aux.ExceptWith(capturedPieces(c));
            return aux;
        }
        private Color rivalColor(Color c) //descobrindo a cor da peça adversaria
        {
            if (c == Color.Black)
                return Color.White;
            else
                return Color.Black;
        }
        private Piece king(Color c)
        {
            foreach(Piece x in PiecesInGame(c))
            {
                if (x is King)
                    return x;
            }
            return null;
        }
        public bool isInCheck(Color c) //testando se o rei da cor 'c' esta em xeque
        {
            Piece K = king(c);
            if (K == null)
                throw new TrayExceptions("No color king " + c + " in board!");
            foreach(Piece x in PiecesInGame(rivalColor(c)))
            {
                bool[,] mat = x.possiblesMoves();
                if (mat[K.Position.Line, K.Position.Column])
                    return true;
            }
            return false;
        }
        public bool checkmateTest(Color c)
        {
            if (!isInCheck(c))
                return false;
            foreach(Piece x in PiecesInGame(c))
            {
                bool[,] mat = x.possiblesMoves();
                for(int i = 0; i < Tab.Lines; i++)
                {
                    for(int j = 0; j < Tab.Columns; j++)
                    {
                        if (mat[i, j])
                        {
                            Position origin = x.Position;
                            Position destiny = new Position(i, j);
                            Piece capturedPiece = performMovement(origin, destiny);
                            bool checkTest = isInCheck(c);
                            undoMove(origin, destiny, capturedPiece);
                            if (!checkTest)
                                return false;
                        }
                    }
                }
            }
            return true;
        }

        public static void makeSoundCheck() //funcao para emitir um toque se for xeque
        {
            int hz = 1000; //frequencia
            int ms = 500; //milissegundos
            Console.Beep(hz, ms);
        }
        public static void makeSoundCheckmate() //funcao para emitir um toque se for xequemate
        {
            int hz = 950; //frequencia
            int ms = 500; //milissegundos
            Console.Beep(hz, ms);
        }
    }
}
