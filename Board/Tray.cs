
namespace Board
{
    internal class Tray // classe tabuleiro
    {
        public int Lines { get; set; }
        public int Columns { get; set; }
        private Piece[,] pieces;
        
        public Tray(int lines, int columns)
        {
            this.Lines = lines;
            this.Columns = columns;
            pieces = new Piece[Lines, Columns];
        }
        public Piece getPiece(int line, int column)
        {
            return pieces[line, column];
        }
        public void changePiece(Piece p, Position pos) // muda a peça de lugar
        {
            pieces[pos.Line, pos.Columns] = p;
            p.Position = pos;
        }
    }
}
