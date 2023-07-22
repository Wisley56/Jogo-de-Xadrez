
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
        public Piece piece(int line, int column) //retorna a peça na posicao desejada
        {
            return pieces[line, column];
        }
        public Piece getPiece( Position pos) //retorna a peça na posicao atual
        {
            return pieces[pos.Line, pos.Columns];
        }
        public void changePiece(Piece p, Position pos) // muda a peça de lugar
        {
            if(existPiece(pos))
                throw new TrayExceptions("Position occupied!");
            pieces[pos.Line, pos.Columns] = p;
            p.Position = pos;
        }
        public bool validPosition(Position pos) //verificando se a posiçao é valida
        {
            if(pos.Line < 0 || pos.Line >= Lines || pos.Columns < 0 || pos.Columns >= Columns)
                return false;
            return true;
        }
        public void validatePosition(Position pos) //validar a posiçao usando exceçao
        {
            if(!validPosition(pos))
                throw new TrayExceptions("Invalid Position!");
        }
        public bool existPiece(Position pos) //verifica se existe a peça
        {
            validatePosition(pos);
            return getPiece(pos) != null;
        }

    }
}
