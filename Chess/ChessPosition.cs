using System;
using Board;

namespace Chess
{
    internal class ChessPosition //classe para pasar a lógica do xadrez para a lógica de programaçao
    {
        public char Column { get; set; }
        public int Line { get; set; }
        public ChessPosition(char column, int line)
        {
            this.Column = column;
            this.Line = line;
        }
        public override string ToString()
        {
            return "" + Column + Line;
        }
        public Position toPosition()
        {
            return new Position(8 - Line, Column - 'a');
        }
    }
}
