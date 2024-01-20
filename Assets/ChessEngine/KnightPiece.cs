class KnightPiece : DirectionalPiece
{

    static readonly int[][] scores = new int[][] {
        new int[] { -50, -40, -30, -30, -30, -30, -40, -50 },
        new int[] { -40, -20, 0, 0, 0, 0, -20, -40 },
        new int[] { -30, 0, 10, 15, 15, 10, 0, -30 },
        new int[] { -30, 5, 15, 20, 20, 15, 5, -30 },
        new int[] { -30, 0, 15, 20, 20, 15, 0, -30 },
        new int[] { -30, 5, 10, 15, 15, 10, 5, -30 },
        new int[] { -40, -20, 0, 5, 5, 0, -20, -40 },
        new int[] { -50, -40, -30, -30, -30, -30, -40, -50 },
    };

    static readonly int[][] ennemyScores = ReverseScores(scores);

    static readonly XY[] directions = new XY[] {
        new () { x = 1, y = 2 },
        new () { x = 2, y = 1 },
        new () { x = -1, y = 2 },
        new () { x = -2, y = 1 },
        new () { x = 1, y = -2 },
        new () { x = 2, y = -1 },
        new () { x = -1, y = -2 },
        new () { x = -2, y = -1 },
    };
    public KnightPiece(bool isPlayer) : base(isPlayer, directions, true) { }

    public override string GetName()
    {
        return "Knight";
    }

    public override int[][] GetScores()
    {
        return isPlayer ? scores : ennemyScores;
    }

    public override int GetValue()
    {
        return 300;
    }
}
