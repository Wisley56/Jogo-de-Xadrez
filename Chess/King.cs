using Board;

namespace Chess
{
    internal class King : Piece //rei e suas propriedades
    {
        public King(Color color, Tray tray) : base(color, tray) { }
        public override string ToString()
        {
            return "K";
        }
    }
}
