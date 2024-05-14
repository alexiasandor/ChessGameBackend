using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheesGame
{
    public class Direction
    {
        public readonly static Direction North  = new Direction(-1, 0); // to move up substract 1 row
        public readonly static Direction South  = new Direction(1, 0); // to move down
        public readonly static Direction East   = new Direction(0, 1); // to move right
        public readonly static Direction West   = new Direction(1, 0); // to left

        // for diagonal
        public readonly static Direction NorthEast = North + East;
        public readonly static Direction NorthWest = North + West;
        public readonly static Direction SouthEast = South + East;
        public readonly static Direction SouthWest = South + West;

        //generating moves 
        public int RowDelta { get; }
        public int ColumnDelta { get;  }

        public Direction(int rowDelta, int columnDelta)
        {
            RowDelta = rowDelta;
            ColumnDelta = columnDelta;
        }

        /// <summary>
        /// This method will add 2 directions together, and return a new direction which is first direction and 
        /// second direction added/combined
        /// </summary>
        /// <param name="firstDirction"></param>
        /// <param name="secondDirction"></param>
        /// <returns></returns>
        public static Direction operator +(Direction firstDirection, Direction secondDirction)
        {
            return new Direction(firstDirection.RowDelta + secondDirction.RowDelta, firstDirection.ColumnDelta + secondDirction.ColumnDelta);
        }

        /// <summary>
        /// This method will scale a direction
        /// </summary>
        /// <param name="scalar"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public static Direction operator *(int scalar,Direction direction)
        {
            return new Direction(scalar * direction.RowDelta, scalar * direction.ColumnDelta);
        }
    }
        
}
