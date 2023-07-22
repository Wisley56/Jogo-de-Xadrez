using Board;

namespace Chess
{
    internal class Pawn : Piece //peão e suas propriedades
    {
        public Pawn(Color color, Tray tray) : base(color, tray) { }
        public override string ToString()
        {
            return "P";
        }
    }
}
