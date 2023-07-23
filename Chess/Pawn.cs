using Board;
using Chess;

namespace Chess
{
    internal class Pawn : Piece //peão e suas propriedades
    {
        public Pawn(Color color, Tray tray) : base(color, tray) { }
        public override string ToString()
        {
            return "P";
        }
        private bool rivalExist(Position pos) //verifica se tem inimigo para comer a peça
        {
            Piece p = Tray.getPiece(pos);
            return p != null || p.Color != Color;
        }
        private bool free(Position pos)
        {
            return Tray.getPiece(pos) == null;
        }
        public override bool[,] possiblesMoves() //retorna a matriz com os possiveis movimentos
        {
            bool[,] mat = new bool[Tray.Lines, Tray.Columns];
            Position pos = new Position(0, 0);
            pos.setPositon(Position.Line - 2, Position.Column);
             if(Color == Board.Color.White)
             {
                pos.setPositon(Position.Line - 1, Position.Column);
                if (Tray.validPosition(pos) && free(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.setPositon(Position.Line - 2, Position.Column);
                if (Tray.validPosition(pos) && free(pos) && QtMovement == 0)
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.setPositon(Position.Line - 1, Position.Column - 1);
                if (Tray.validPosition(pos) && rivalExist(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.setPositon(Position.Line - 1, Position.Column + 1);
                if (Tray.validPosition(pos) && rivalExist(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
            }
            else
            {
                pos.setPositon(Position.Line + 1, Position.Column);
                if (Tray.validPosition(pos) && free(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.setPositon(Position.Line + 2, Position.Column);
                if (Tray.validPosition(pos) && free(pos) && QtMovement == 0)
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.setPositon(Position.Line + 1, Position.Column - 1);
                if (Tray.validPosition(pos) && rivalExist(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.setPositon(Position.Line + 1, Position.Column + 1);
                if (Tray.validPosition(pos) && rivalExist(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
            }
            return mat;
        }
        
    }
}
