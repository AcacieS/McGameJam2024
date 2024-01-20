class BishopPiece : DirectionalPiece
{

    static readonly int[][] scores = new int[][] {
        new int[] { -20, -10, -10, -10, -10, -10, -10, -20 },
        new int[] { -10, 0, 0, 0, 0, 0, 0, -10 },
        new int[] { -10, 0, 5, 10, 10, 5, 0, -10 },
        new int[] { -10, 5, 5, 10, 10, 5, 5, -10 },
        new int[] { -10, 0, 10, 10, 10, 10, 0, -10 },
        new int[] { -10, 10, 10, 10, 10, 10, 10, -10 },
        new int[] { -10, 5, 0, 0, 0, 0, 5, -10 },
        new int[] { -20, -10, -10, -10, -10, -10, -10, -20 },
    };

    static readonly int[][] ennemyScores = ReverseScores(scores);

    static readonly XY[] directions = new XY[] {
        new () { x = 1, y = 1 },
        new () { x = -1, y = 1 },
        new () { x = -1, y = -1 },
        new () { x = 1, y = -1 },
    };
    public BishopPiece(bool isPlayer) : base(isPlayer, directions, false) { }

    public override int[][] GetScores()
    {
        return isPlayer ? scores : ennemyScores;
    }

    public override int GetValue()
    {
        return 300;
    }
}
