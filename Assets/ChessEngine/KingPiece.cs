class KingPiece : DirectionalPiece
{

    private static readonly int[][] scores = new int[][] {
        new int[] { -30, -40, -40, -50, -50, -40, -40, -30 },
        new int[] { -30, -40, -40, -50, -50, -40, -40, -30 },
        new int[] { -30, -40, -40, -50, -50, -40, -40, -30 },
        new int[] { -30, -40, -40, -50, -50, -40, -40, -30 },
        new int[] { -20, -30, -30, -40, -40, -30, -30, -20 },
        new int[] { -10, -20, -20, -20, -20, -20, -20, -10 },
        new int[] { 20, 20, 0, 0, 0, 0, 20, 20 },
        new int[] { 20, 30, 10, 0, 0, 10, 30, 20 },
    };

    private static readonly int[][] ennemyScores = ReverseScores(scores);

    public static readonly XY[] directions = new XY[] {
        new () { x = 1, y = 0 },
        new () { x = 1, y = 1 },
        new () { x = 0, y = 1 },
        new () { x = -1, y = 1 },
        new () { x = -1, y = 0 },
        new () { x = -1, y = -1 },
        new () { x = 0, y = -1 },
        new () { x = 1, y = -1 },
    };
    public KingPiece(bool isPlayer) : base(isPlayer, directions, true) { }

    public override int[][] GetScores()
    {
        return isPlayer ? scores : ennemyScores;
    }

    public override int GetValue()
    {
        return 10000;
    }
}
