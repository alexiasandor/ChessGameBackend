namespace CheesGame
{
    // the class will be abstract because it does not represent a specific piece
    public abstract class Piece
    {
        // 2 abstract properties which all pieces must override
        public abstract PieceType Type { get; }
        public abstract Player Color { get; }
        public bool HasMoved { get; set; } = false;

        public abstract Piece Copy();

        public abstract IEnumerable<Move> GetMoves(Position from, Board board); 

        protected IEnumerable<Position> MovePositionsInDir(Position from, Board board, Direction direction)
        {
            for(Position pos = from  + direction; Board.IsInside(pos); pos += direction)
            {
                if(board.IsEmpty(pos))
                {
                    yield return pos;
                    continue;
                }
                Piece piece = board[pos];

                if(piece.Color != Color)
                {
                    yield return pos;
                }

                yield break; 
            }
        }
      //takes an array of directions
        protected IEnumerable<Position> MovePositionsInDirs(Position from, Board board, Direction[] directions)
        {
            return directions.SelectMany(direction => MovePositionsInDir(from, board, direction));
        }

        public virtual bool CanCaptureOpponentKing(Position from, Board board)
        {
            return GetMoves(from, board).Any(move =>
            {
                Piece piece = board[move.ToPosition];
                return piece != null && piece.Type == PieceType.King;
            });
        }
       
    }
}
