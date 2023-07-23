using Board;
using System.Transactions;

namespace Chess
{
    internal class Tower : Piece //torre e suas propriedades
    {
        public Tower(Color color, Tray tray) : base(color, tray) { }
        public override string ToString()
        {
            return "T";
        }
        public bool canMove(Position pos) //verifica se pode mover
        {
            Piece p = Tray.getPiece(pos);
            return p == null || p.Color != this.Color;
        }
        public override bool[,] possiblesMoves() //retorna a matriz com os possiveis movimentos
        {
            bool[,] mat = new bool[Tray.Lines, Tray.Columns];
            Position pos = new Position(0, 0);

            //verificando acima
            pos.setPositon(Position.Line - 1, Position.Column);
            while(Tray.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if(Tray.getPiece(pos) != null && Tray.getPiece(pos).Color != Color)
                {
                    break;
                }
                pos.Line = pos.Line - 1;
            }
            //verificando abaixo
            pos.setPositon(Position.Line + 1, Position.Column);
            while (Tray.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Tray.getPiece(pos) != null && Tray.getPiece(pos).Color != Color)
                {
                    break;
                }
                pos.Line = pos.Line + 1;
            }
            //verificando direita
            pos.setPositon(Position.Line, Position.Column + 1);
            while (Tray.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Tray.getPiece(pos) != null && Tray.getPiece(pos).Color != Color)
                {
                    break;
                }
                pos.Column = pos.Column + 1;
            }
            //verificando esquerda
            pos.setPositon(Position.Line, Position.Column - 1);
            while (Tray.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Tray.getPiece(pos) != null && Tray.getPiece(pos).Color != Color)
                {
                    break;
                }
                pos.Column = pos.Column - 1;
            }
            return mat;
        }
    }
}
