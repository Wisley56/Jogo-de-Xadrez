

namespace Board
{
    internal class Piece // classe peças
    {
        public Position? Position { get; set; }
        public Color? Color { get; protected set; }
        public int QtMovement { get; protected set; }
        public Tray? Tray { get; protected set; }

        public Piece(Position? position, Color? color, Tray? tray)
        {
            this.Position = position;
            this.Color = color;
            this.QtMovement = 0;
            this.Tray = tray;
        }
    }
}
