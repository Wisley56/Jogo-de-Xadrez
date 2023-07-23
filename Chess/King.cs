using Board;

namespace Chess
{
    internal class King : Piece //rei e suas propriedades
    {
        public King(Color color, Tray tray) : base(color, tray) { }
        public override string ToString()
        {
            return "K";
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
            if(Tray.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //verificando nordeste
            pos.setPositon(Position.Line - 1, Position.Column + 1);
            if (Tray.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //verificando direita
            pos.setPositon(Position.Line, Position.Column + 1);
            if (Tray.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //verificando sudeste
            pos.setPositon(Position.Line + 1, Position.Column + 1);
            if (Tray.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //verificando abaixo
            pos.setPositon(Position.Line + 1, Position.Column);
            if (Tray.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //verificando sudoeste
            pos.setPositon(Position.Line + 1, Position.Column - 1);
            if (Tray.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //verificando esquerda
            pos.setPositon(Position.Line, Position.Column - 1);
            if (Tray.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //verificando noroeste
            pos.setPositon(Position.Line - 1, Position.Column - 1);
            if (Tray.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            return mat;
        }
    }
}
