using Board;

namespace Chess
{
    internal class Bishop : Piece //bispo e suas propriedades
    {
        public Bishop(Color color, Tray tray) : base(color, tray) { }
        public override string ToString()
        {
            return "B";
        }
        public bool canMove(Position pos) //verifica se pode mover
        {
            Piece p = Tray.getPiece(pos);
            return p == null || p.Color != this.Color;
        }
        public override bool[,] possiblesMoves()
        {
            bool[,] mat = new bool[Tray.Lines, Tray.Columns];
            Position pos = new Position(0, 0);
            return mat;
        }
    }
}
