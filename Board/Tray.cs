
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
    }
}
