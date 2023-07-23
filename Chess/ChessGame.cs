using System;
using Board;
using System.Collections.Generic;

namespace Chess
{
    internal class ChessGame //classe controla o jogo de xadrez
    {
        public Tray Tab { get; private set; }
        public int Shift { get; private set; } //turno
        public Color PlayerCurrent { get; private set; } //cor dojogador atual
        public bool End { get; private set; } //para dizer que o jogo acabou
        private HashSet<Piece> Pieces;
        private HashSet<Piece> Captureds;

        public ChessGame()
        {
            Tab = new Tray(8, 8);
            Shift = 1;
            PlayerCurrent = Color.White;
            Pieces = new HashSet<Piece>();
            Captureds = new HashSet<Piece>();
            positionInitial();
            End = false;
        }

        public void performMovement(Position origin, Position destiny) //executa os movimentos
        {
            Piece p = Tab.removePiece(origin); //remove a peça de origem
            p.increaseMovement(); //incrementa o movimenta da peça
            Piece capturedPiece = Tab.removePiece(destiny);//captura a peça da posiçao de destino (se houver)
            Tab.changePiece(p, destiny); //coloca a peça p na posiçao de destino
            if(capturedPiece != null)
                Captureds.Add(capturedPiece);
        }
        public void performsMoves(Position origin, Position destiny) //realiza a jogada na partida
        {
            performMovement(origin, destiny);
            Shift++;
            playerChange();

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
        private void playerChange()
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
            putNewPart('a', 2, new Pawn(Color.White, Tab));
            putNewPart('b',2, new Pawn(Color.White, Tab));
            putNewPart('c', 2, new Pawn(Color.White, Tab));
            putNewPart('d', 2, new Pawn(Color.White, Tab));
            putNewPart('e', 2, new Pawn(Color.White, Tab));
            putNewPart('f', 2, new Pawn(Color.White, Tab));
            putNewPart('g', 2, new Pawn(Color.White, Tab));
            putNewPart('h', 2, new Pawn(Color.White, Tab));
            putNewPart('a', 1, new Tower(Color.White, Tab));
            putNewPart('h', 1, new Tower(Color.White, Tab));
            putNewPart('b', 1, new Horse(Color.White, Tab));
            putNewPart('g', 1, new Horse(Color.White, Tab));
            putNewPart('c', 1, new Bishop(Color.White, Tab));
            putNewPart('f', 1, new Bishop(Color.White, Tab));
            putNewPart('d', 1, new Queen(Color.White, Tab));
            putNewPart('e', 1, new King(Color.White, Tab));

            putNewPart('a', 7, new Pawn(Color.Black, Tab));
            putNewPart('b', 7, new Pawn(Color.Black, Tab));
            putNewPart('c', 7, new Pawn(Color.Black, Tab));
            putNewPart('d', 7, new Pawn(Color.Black, Tab));
            putNewPart('e', 7, new Pawn(Color.Black, Tab));
            putNewPart('f', 7, new Pawn(Color.Black, Tab));
            putNewPart('g', 7, new Pawn(Color.Black, Tab));
            putNewPart('h', 7, new Pawn(Color.Black, Tab));
            putNewPart('a', 8, new Tower(Color.Black, Tab));
            putNewPart('h', 8, new Tower(Color.Black, Tab));
            putNewPart('b', 8, new Horse(Color.Black, Tab));
            putNewPart('g', 8, new Horse(Color.Black, Tab));
            putNewPart('c', 8, new Bishop(Color.Black, Tab));
            putNewPart('f', 8, new Bishop(Color.Black, Tab));
            putNewPart('d', 8, new Queen(Color.Black, Tab));
            putNewPart('e', 8, new King(Color.Black, Tab));
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
    }
}
