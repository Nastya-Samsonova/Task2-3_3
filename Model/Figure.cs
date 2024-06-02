using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using static System.Diagnostics.Activity;

namespace ChessApp.Model
{
    public enum Color
    {
        White,
        Black,
    }

    public abstract class Figure
    {
        public Color Color { get; set; }
        public (int row, int column) Position { get; set; }

        readonly Dictionary<int, string> mapRev = new() {
        {0, "a"}, {1, "b"},
        {2, "c"}, {3, "d"},
        {4, "e"}, {5, "f"},
        {6, "g"}, {7, "h"}};

        public Figure(Color color, (int row, int column) position)
        {
            Color = color;
            Position = position;
        }

        public bool MakeMove(int row, int column)
        {
            if (IsMovePossible(row, column))
            {
                Position = (row, column);
                return true;
            }
            return false;
        }

        protected abstract bool IsMovePossible(int row, int column);

        public override string ToString()
        {
            char[] mapRev = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
            int figureRow = Position.row + 1;
            string figureCol = mapRev[Position.column].ToString();
            return figureCol + figureRow;
        }

    }
}
