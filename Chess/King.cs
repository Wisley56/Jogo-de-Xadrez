using Board;

namespace Chess
{
    internal class King : Piece //rei e suas propriedades
    {
        private ChessGame game;
        public King(Color color, Tray tray, ChessGame game) : base(color, tray)
        {
            this.game = game;
        }
        public override string ToString()
        {
            return "K";
        }
        public bool canMove(Position pos) //verifica se pode mover
        {
            Piece p = Tray.getPiece(pos);
            return p == null || p.Color != this.Color;
        }
        private bool rookTest(Position pos)
        {
            Piece p = Tray.getPiece(pos);
            return p != null && p is Tower && p.Color == Color && p.QtMovement == 0;
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

            // JOGADAS ESPECIAIS: ROQUE

            if(QtMovement == 0 && !game.Check)
            {
                //roque pequeno
                Position T1 = new Position(Position.Line, Position.Column + 3);
                if(rookTest(T1))
                {
                    Position p1 = new Position(Position.Line, Position.Column + 1); //uma casa a direita do rei
                    Position p2 = new Position(Position.Line, Position.Column + 2); //duas casas a direita do rei
                    if (Tray.getPiece(p1) == null && Tray.getPiece(p2) == null)
                        mat[Position.Line, Position.Column + 2] = true;
                }
                //roque grande
                Position T2 = new Position(Position.Line, Position.Column - 4);
                if (rookTest(T2))
                {
                    Position p1 = new Position(Position.Line, Position.Column - 1); //uma casa a direita do rei
                    Position p2 = new Position(Position.Line, Position.Column - 2); //duas casas a direita do rei
                    Position p3 = new Position(Position.Line, Position.Column - 3); //tres casas a direita do rei
                    if (Tray.getPiece(p1) == null && Tray.getPiece(p2) == null && Tray.getPiece(p3) == null)
                        mat[Position.Line, Position.Column - 2] = true;
                }
            }
            return mat;
        }
    }
}
