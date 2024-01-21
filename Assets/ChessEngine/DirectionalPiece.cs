using System.Collections.Generic;

abstract class DirectionalPiece : ChessPiece
{
    private readonly XY[] directions;
    private readonly bool once;
    public DirectionalPiece(bool isPlayer, XY[] directions, bool once) : base(isPlayer)
    {
        this.directions = directions;
        this.once = once;
    }
    public override XY[] GetMoves(int x, int y, ChessPiece[][] board)
    {
        List<XY> moves = new();
        foreach (XY direction in directions)
        {
            int dx = direction.x;
            int dy = direction.y;
            while (IsEmpty(x + dx, y + dy, board))
            {
                moves.Add(new XY { x = dx, y = dy });
                if (once)
                    break;
                dx += direction.x;
                dy += direction.y;
            }
            if (IsValid(x + dx, y + dy, board))
                moves.Add(new XY { x = dx, y = dy });
        }
        return moves.ToArray();
    }
}