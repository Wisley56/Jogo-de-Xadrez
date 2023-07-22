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
    }
}
