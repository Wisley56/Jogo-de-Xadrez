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
        public bool canMove(Position pos) //verifica se pode mover
        {
            Piece p = Tray.getPiece(pos);
            return p == null || p.Color != this.Color;
        }
        public override bool[,] possiblesMoves()
        {
            bool[,] mat = new bool[Tray.Lines, Tray.Columns];
            Position pos = new Position(0, 0);

            //verificando noroeste
            pos.setPositon(Position.Line - 1, Position.Column - 1);
            while (Tray.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Tray.getPiece(pos) != null && Tray.getPiece(pos).Color != Color)
                {
                    break;
                }
                pos.setPositon(pos.Line - 1, pos.Column - 1);
            }
            //verificando nordeste
            pos.setPositon(Position.Line - 1, Position.Column + 1);
            while (Tray.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Tray.getPiece(pos) != null && Tray.getPiece(pos).Color != Color)
                {
                    break;
                }
                pos.setPositon(pos.Line - 1, pos.Column + 1);
            }
            //verificando sudeste
            pos.setPositon(Position.Line + 1, Position.Column + 1);
            while (Tray.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Tray.getPiece(pos) != null && Tray.getPiece(pos).Color != Color)
                {
                    break;
                }
                pos.setPositon(pos.Line +1, pos.Column + 1);
            }
            //verificando sudoeste
            pos.setPositon(Position.Line + 1, Position.Column - 1);
            while (Tray.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Tray.getPiece(pos) != null && Tray.getPiece(pos).Color != Color)
                {
                    break;
                }
                pos.setPositon(pos.Line + 1, pos.Column - 1);
            }
            return mat;
        }
    }
}
