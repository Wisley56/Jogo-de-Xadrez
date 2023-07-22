using System;
using Board;

namespace Chess
{
    internal class ChessGame //classe controla o jogo de xadrez
    {
        public Tray Tab { get; private set;}
        private int Shift; //turno
        private Color PlayerCurrent;
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
        private void positionInitial() //metodo para iniciar as peças nas devidas posiçoes
        {
            Tab.changePiece(new King(Color.Black, Tab), new ChessPosition('c', 1).toPosition());
            Tab.changePiece(new Tower(Color.Black, Tab), new ChessPosition('a', 8).toPosition());
            Tab.changePiece(new King(Color.White, Tab), new ChessPosition('b', 5).toPosition());
            Tab.changePiece(new Pawn(Color.White, Tab), new ChessPosition('d', 2).toPosition());
        }
    }
}
