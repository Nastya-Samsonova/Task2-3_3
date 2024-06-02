using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessApp.Model
{
    public class Queen : Figure
    {
        public Queen(Color color, (int row, int column) position) : base(color, position)
        {
        }

        protected override bool IsMovePossible(int row, int column)
        {
            if (row < 0 || row > 7 || column < 0 || column > 7) return false;
            if (Position.row != row && Position.column != column && ((Position.row + Position.column) != (row + column)) && ((Position.row - Position.column) != (row - column)))
            {
                return false;
            }
            return true;
        }
    }
}
