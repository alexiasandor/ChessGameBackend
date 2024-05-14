namespace CheesGame.Moves
{
    public class EnPassant: Move
    {
        public override MoveType Type => MoveType.EnPassant;
        public override Position FromPosition { get; }
        public override Position ToPosition { get; }
        private readonly Position capturePosition;

        public EnPassant(Position from, Position to)
        {
            FromPosition = from;
            ToPosition = to;
            capturePosition = new Position(from.Row, to.Column);
        }

        public override bool Execute(Board board)
        {
            new NormalMove(FromPosition, ToPosition).Execute(board);
            board[capturePosition] = null;
            return true;
        }
    }
}
