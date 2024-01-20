class QueenPiece : DirectionalPiece
{
    static readonly int[][] scores = new int[][] {
        new int[] { -20, -10, -10, -5, -5, -10, -10, -20 },
        new int[] { -10, 0, 0, 0, 0, 0, 0, -10 },
        new int[] { -10, 0, 5, 5, 5, 5, 0, -10 },
        new int[] { -5, 0, 5, 5, 5, 5, 0, -5 },
        new int[] { 0, 0, 5, 5, 5, 5, 0, -5 },
        new int[] { -10, 5, 5, 5, 5, 5, 0, -10 },
        new int[] { -10, 0, 5, 0, 0, 0, 0, -10 },
        new int[] { -20, -10, -10, -5, -5, -10, -10, -20 },
    };

    static readonly int[][] ennemyScores = ReverseScores(scores);
    public QueenPiece(bool isPlayer) : base(isPlayer, KingPiece.directions, false) { }

    public override string GetName()
    {
        return "Queen";
    }

    public override int[][] GetScores()
    {
        return isPlayer ? scores : ennemyScores;
    }

    public override int GetValue()
    {
        return 900;
    }
}
