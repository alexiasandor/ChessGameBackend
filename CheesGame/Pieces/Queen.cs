namespace CheesGame
{
    public class Queen : Piece
    {
        public override PieceType Type => PieceType.Queen;
        public override Player Color {get;}

        public static readonly Direction[] directions = new Direction[]
        {
            Direction.North,
            Direction.South,
            Direction.East,
            Direction.West,
            Direction.NorthEast,
            Direction.NorthWest,
            Direction.SouthEast,
            Direction.SouthWest
        };

        public Queen(Player color)
        {
            Color = color;
        }

        public override Piece Copy()
        {
            Queen copy = new Queen(Color);
            copy.HasMoved = HasMoved;
            return copy;

        }

        public override IEnumerable<Move> GetMoves(Position from, Board baord)
        {
            return MovePositionsInDirs(from, baord, directions).Select(to => new NormalMove(from, to)); 
        }
    }
}
