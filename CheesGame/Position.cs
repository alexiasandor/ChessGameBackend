
namespace CheesGame
{
    public class Position
    {
        public int Row {  get;  }
        public int Column { get;  }
        public Position(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public Player SquareColor()
        {
            if((Row+Column) % 2 == 0)
            {
                return Player.White;
            }

           return Player.Black;
        }

        public override bool Equals(object obj)
        {
            return obj is Position position &&
                   Row == position.Row &&
                   Column == position.Column;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Row, Column);
        }

        public static bool operator ==(Position left, Position right)
        {
            return EqualityComparer<Position>.Default.Equals(left, right);
        }

        public static bool operator !=(Position left, Position right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Takes a position and a direction and returns the position you get by taking one step in that direction 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="direction"></param>
        /// <returns></returns>

        public static Position operator +(Position position, Direction direction)
        {
            return new Position(position.Row + direction.RowDelta, position.Column + direction.ColumnDelta);
        }
    }
}
