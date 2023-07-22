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
    }
}
