

namespace Board
{
    internal abstract class Piece // classe peças
    {
        public Position? Position { get; set; }
        public Color? Color { get; protected set; }
        public int QtMovement { get; protected set; }
        public Tray? Tray { get; protected set; }

        public Piece(Color? color, Tray? tray)
        {
            this.Position = null;
            this.Color = color;
            this.QtMovement = 0;
            this.Tray = tray;
        }
        public void increaseMovement()
        {
            QtMovement++;
        }
        public void decrementMovement()
        {
            QtMovement--;
        }
        public bool existMovesPossibles()
        {
            bool[,] mat = possiblesMoves();
            for(int i = 0; i < Tray.Lines; i++)
            {
                for(int j = 0; j < Tray.Columns; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool canMoveTo(Position pos)
        {
            return possiblesMoves()[pos.Line, pos.Column];
        }
        public abstract bool[,] possiblesMoves();

    }
}
