using Board;

namespace Chess
{
    internal class Horse : Piece //cavalo e suas propriedades
    {
        public Horse(Color color, Tray tray) : base(color, tray) { }
        public override string ToString()
        {
            return "H";
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
