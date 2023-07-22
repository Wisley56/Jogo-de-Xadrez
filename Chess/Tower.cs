using Board;

namespace Chess
{
    internal class Tower : Piece //torre e suas propriedades
    {
        public Tower(Color color, Tray tray) : base(color, tray) { }
        public override string ToString()
        {
            return "T";
        }
    }
}
