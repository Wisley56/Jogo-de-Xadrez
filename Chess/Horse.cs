using Board;

namespace Chess
{
    internal class Horse : Piece //cavalo e suas propriedades
    {
        public Horse(Color color, Tray tray) : base(color, tray) { }
        public override string ToString()
        {
            return "H";
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
            pos.setPositon(Position.Line - 2, Position.Column + 1); //p/ cima e direita
            if (Tray.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            pos.setPositon(Position.Line - 2, Position.Column - 1); //p/ cima e esquerda
            if (Tray.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            pos.setPositon(Position.Line + 2, Position.Column + 1); //p/ baixo e direita
            if (Tray.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            pos.setPositon(Position.Line + 2, Position.Column - 1); //p/ baixo e esquerda
            if (Tray.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            pos.setPositon(Position.Line - 1, Position.Column - 2); //p/ esquerda e sobe
            if (Tray.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            pos.setPositon(Position.Line + 1, Position.Column - 2); //p/ esquerda e desce
            if (Tray.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            pos.setPositon(Position.Line - 1, Position.Column + 2); //p/ direita e sobe
            if (Tray.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            pos.setPositon(Position.Line + 1, Position.Column + 2); //p/ direita e desce
            if (Tray.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            return mat;
        }
    }
}
