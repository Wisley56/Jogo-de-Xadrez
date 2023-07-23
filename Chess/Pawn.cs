using Board;
using Chess;

namespace Chess
{
    internal class Pawn : Piece //peão e suas propriedades
    {
        public Pawn(Color color, Tray tray) : base(color, tray) { }
        public override string ToString()
        {
            return "P";
        }
        public bool canMove(Position pos) //verifica se pode mover
        {
            Piece p = Tray.getPiece(pos);
            return p == null || p.Color != this.Color;
        }
        public override bool[,] possiblesMoves() //retorna a matriz com os possiveis movimentos
        {
            bool[,] mat = new bool[Tray.Lines, Tray.Columns];
            Position pos = new Position(0, 0);
            if()

            return mat;
        }
        public int getShift( ChessGame game)
        {
            return game.Shift;
        }
    }
}
