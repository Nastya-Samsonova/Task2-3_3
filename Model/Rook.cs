using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessApp.Model
{
    public class Rook : Figure
    {
        public Rook(Color color, (int row, int column) position) : base(color, position)
        {
        }

        protected override bool IsMovePossible(int row, int column)
        {
            return !(row < 0 || row > 7 || column < 0 || column > 7) &&
                   (Position.row == row || Position.column == column);
        }
    }
}
