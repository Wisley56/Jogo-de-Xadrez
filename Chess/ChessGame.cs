using System;
using Board;

namespace Chess
{
    internal class ChessGame //classe controla o jogo de xadrez
    {
        public Tray Tab { get; private set; }
        public int Shift { get; private set; } //turno
        public Color PlayerCurrent { get; private set; } //cor dojogador atual
        public bool End { get; private set; }

        public ChessGame()
        {
            Tab = new Tray(8, 8);
            Shift = 1;
            PlayerCurrent = Color.White;
            positionInitial();
            End = false;
        }

        public void performMovement(Position origin, Position destiny) //executa os movimentos
        {
            Piece p = Tab.removePiece(origin); //remove a peça de origem
            p.increaseMovement(); //incrementa o movimenta da peça
            Piece capturedPiece = Tab.removePiece(destiny);//captura a peça da posiçao de destino (se houver)
            Tab.changePiece(p, destiny); //coloca a peça p na posiçao de destino
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
        private void positionInitial() //metodo para iniciar as peças nas devidas posiçoes
        {
            Tab.changePiece(new Pawn(Color.White, Tab), new ChessPosition('a', 2).toPosition());
            Tab.changePiece(new Pawn(Color.White, Tab), new ChessPosition('b', 2).toPosition());
            Tab.changePiece(new Pawn(Color.White, Tab), new ChessPosition('c', 2).toPosition());
            Tab.changePiece(new Pawn(Color.White, Tab), new ChessPosition('d', 2).toPosition());
            Tab.changePiece(new Pawn(Color.White, Tab), new ChessPosition('e', 2).toPosition());
            Tab.changePiece(new Pawn(Color.White, Tab), new ChessPosition('f', 2).toPosition());
            Tab.changePiece(new Pawn(Color.White, Tab), new ChessPosition('g', 2).toPosition());
            Tab.changePiece(new Pawn(Color.White, Tab), new ChessPosition('h', 2).toPosition());
            Tab.changePiece(new Tower(Color.White, Tab), new ChessPosition('a', 1).toPosition());
            Tab.changePiece(new Tower(Color.White, Tab), new ChessPosition('h', 1).toPosition());
            Tab.changePiece(new Horse(Color.White, Tab), new ChessPosition('b', 1).toPosition());
            Tab.changePiece(new Horse(Color.White, Tab), new ChessPosition('g', 1).toPosition());
            Tab.changePiece(new Bishop(Color.White, Tab), new ChessPosition('c', 1).toPosition());
            Tab.changePiece(new Bishop(Color.White, Tab), new ChessPosition('f', 1).toPosition());
            Tab.changePiece(new Queen(Color.White, Tab), new ChessPosition('d', 1).toPosition());
            Tab.changePiece(new King(Color.White, Tab), new ChessPosition('e', 1).toPosition());

            Tab.changePiece(new Pawn(Color.Black, Tab), new ChessPosition('a', 7).toPosition());
            Tab.changePiece(new Pawn(Color.Black, Tab), new ChessPosition('b', 7).toPosition());
            Tab.changePiece(new Pawn(Color.Black, Tab), new ChessPosition('c', 7).toPosition());
            Tab.changePiece(new Pawn(Color.Black, Tab), new ChessPosition('d', 7).toPosition());
            Tab.changePiece(new Pawn(Color.Black, Tab), new ChessPosition('e', 7).toPosition());
            Tab.changePiece(new Pawn(Color.Black, Tab), new ChessPosition('f', 7).toPosition());
            Tab.changePiece(new Pawn(Color.Black, Tab), new ChessPosition('g', 7).toPosition());
            Tab.changePiece(new Pawn(Color.Black, Tab), new ChessPosition('h', 7).toPosition());
            Tab.changePiece(new Tower(Color.Black, Tab), new ChessPosition('a', 8).toPosition());
            Tab.changePiece(new Tower(Color.Black, Tab), new ChessPosition('h', 8).toPosition());
            Tab.changePiece(new Horse(Color.Black, Tab), new ChessPosition('b', 8).toPosition());
            Tab.changePiece(new Horse(Color.Black, Tab), new ChessPosition('g', 8).toPosition());
            Tab.changePiece(new Bishop(Color.Black, Tab), new ChessPosition('c', 8).toPosition());
            Tab.changePiece(new Bishop(Color.Black, Tab), new ChessPosition('f', 8).toPosition());
            Tab.changePiece(new Queen(Color.Black, Tab), new ChessPosition('d', 8).toPosition());
            Tab.changePiece(new King(Color.Black, Tab), new ChessPosition('e', 8).toPosition());
        }
    }
}
