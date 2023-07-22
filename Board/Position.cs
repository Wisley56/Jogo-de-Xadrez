namespace Board //tabuleiro
{
    internal class Position
    {
        public int Line { get; set; }
        public int Columns { get; set; }

        public Position(int line, int columns)
        {
            this.Line = line;
            this.Columns = columns;
        }
        public override string ToString()
        {
            return Line + " ," + Columns;
        }
    }
}
