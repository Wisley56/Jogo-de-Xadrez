using Board;

namespace Chess
{
    internal class Queen : Piece //rainha e suas propriedades
    {
        public Queen(Color color, Tray tray) : base(color, tray) { }
        public override string ToString()
        {
            return "Q";
        }
        public override bool[,] possiblesMoves()
        {
            bool[,] mat = new bool[Tray.Lines, Tray.Columns];
            Position pos = new Position(0, 0);
            return mat;
        }
    }
}
