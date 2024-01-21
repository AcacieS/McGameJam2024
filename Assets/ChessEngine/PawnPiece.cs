

using UnityEngine;

class PawnPiece : ChessPiece
{

    static readonly int[][] scores = new int[][] {
        new int[] { 0, 0, 0, 0, 0, 0, 0, 0 },
        new int[] { 50, 50, 50, 50, 50, 50, 50, 50 },
        new int[] { 10, 10, 20, 30, 30, 20, 10, 10 },
        new int[] { 5, 5, 10, 25, 25, 10, 5, 5 },
        new int[] { 0, 0, 0, 20, 20, 0, 0, 0 },
        new int[] { 5, -5, -10, 0, 0, -10, -5, 5 },
        new int[] { 5, 10, 10, -20, -20, 10, 10, 5 },
        new int[] { 0, 0, 0, 0, 0, 0, 0, 0 },
    };

    static readonly int[][] ennemyScores = ReverseScores(scores);

    public PawnPiece(bool isPlayer) : base(isPlayer) { }

    public override XY[] GetMoves(int x, int y, ChessPiece[][] board)
    {
        int dy = isPlayer ? 1 : -1;
        int canDoubleForward = 0;
        int canForward = 0;
        int canEatLeft = 0;
        int canEatRight = 0;
        if (y == 1 && isPlayer || y == 6 && !isPlayer)
            if (IsEmpty(x, y + dy + dy, board))
            canDoubleForward = 1;
        if (IsEmpty(x, y + dy, board))
            canForward = 1;
        if (IsEnemy(x + 1, y + dy, board))
            canEatRight = 1;
        if (IsEnemy(x - 1, y + dy, board))
            canEatLeft = 1;
        XY[] moves = new XY[canForward + canEatLeft + canEatRight + canDoubleForward];
        int i = 0;
        if (canForward == 1)
            moves[i++] = new XY { x = 0, y = dy };
        if (canEatLeft == 1)
            moves[i++] = new XY { x = -1, y = dy };
        if (canEatRight == 1)
            moves[i++] = new XY { x = 1, y = dy };
        if (canDoubleForward == 1)
            moves[i++] = new XY { x = 0, y = dy + dy };
        return moves;
    }

    public override string GetName()
    {
        return "Pawn";
    }

    public override int[][] GetScores()
    {
        return isPlayer ? scores : ennemyScores;
    }

    public override int GetValue()
    {
        return 100;
    }
}
