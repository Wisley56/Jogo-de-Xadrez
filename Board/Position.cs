namespace Board //tabuleiro
{
    internal class Position
    {
        public int Line { get; set; }
        public int Column { get; set; }

        public Position(int line, int columns)
        {
            this.Line = line;
            this.Column = columns;
        }
        public void setPositon(int line, int column)
        {
            this.Line = line;
            this.Column = column;
        }
        public override string ToString()
        {
            return Line + "," + Column;
        }
    }
}
