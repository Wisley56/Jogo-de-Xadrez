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
    }
}
