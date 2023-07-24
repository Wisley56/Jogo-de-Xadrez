using Board;

namespace Chess
{
    internal class Pawn : Piece //peão e suas propriedades
    {
        private ChessGame game;
        public Pawn(Color color, Tray tray, ChessGame game) : base(color, tray)
        {
            this.game = game;
        }
        public override string ToString()
        {
            return "P";
        }
        public bool canMove(Position pos) //verifica se tem inimigo para comer a peça
        {
            Piece p = Tray.getPiece(pos);
            return p != null && p.Color != Color;
        }
        private bool free(Position pos)
        {
            return Tray.getPiece(pos) == null;
        }
        public override bool[,] possiblesMoves() //retorna a matriz com os possiveis movimentos
        {
            bool[,] mat = new bool[Tray.Lines, Tray.Columns];
            Position pos = new Position(0, 0);

             if(Color == Board.Color.White)
             {
                pos.setPositon(Position.Line - 1, Position.Column);
                if (Tray.validPosition(pos) && free(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.setPositon(Position.Line - 2, Position.Column);
                Position p2 = new Position(Position.Line - 1, Position.Column);
                if (Tray.validPosition(p2) && free(p2) && Tray.validPosition(pos) && free(pos) && QtMovement == 0)
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.setPositon(Position.Line - 1, Position.Column - 1);
                if (Tray.validPosition(pos) && canMove(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.setPositon(Position.Line - 1, Position.Column + 1);
                if (Tray.validPosition(pos) && canMove(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }

                //JOGADA ESPECIAL: EN PASSANT

                if(Position.Line == 3)//verificando se as peças brancas podem realizar a jogada especial
                {
                    Position leftP = new Position(Position.Line, Position.Column - 1);
                    if(Tray.validPosition(leftP) && canMove(leftP) && game.vulnerableEnPassant == Tray.getPiece(leftP))
                        mat[leftP.Line - 1, leftP.Column] = true;
                    Position rightP = new Position(Position.Line, Position.Column + 1);
                    if (Tray.validPosition(rightP) && canMove(rightP) && game.vulnerableEnPassant == Tray.getPiece(rightP))
                        mat[rightP.Line - 1, rightP.Column] = true;
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
                Position p2 = new Position(Position.Line + 1, Position.Column);
                if (Tray.validPosition(p2) && free(p2) && Tray.validPosition(pos) && free(pos) && QtMovement == 0)
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.setPositon(Position.Line + 1, Position.Column - 1);
                if (Tray.validPosition(pos) && canMove(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.setPositon(Position.Line + 1, Position.Column + 1);
                if (Tray.validPosition(pos) && canMove(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }

                //JOGADA ESPECIAL: EN PASSANT

                if (Position.Line == 4)//verificando se as peças pretas podem realizar a jogada especial
                {
                    Position leftP = new Position(Position.Line, Position.Column - 1);
                    if (Tray.validPosition(leftP) && canMove(leftP) && game.vulnerableEnPassant == Tray.getPiece(leftP))
                        mat[leftP.Line + 1, leftP.Column ] = true;
                    Position rightP = new Position(Position.Line, Position.Column + 1);
                    if (Tray.validPosition(rightP) && canMove(rightP) && game.vulnerableEnPassant == Tray.getPiece(rightP))
                        mat[rightP.Line + 1, rightP.Column] = true;
                }
            }
            return mat;
        }
        
    }
}
