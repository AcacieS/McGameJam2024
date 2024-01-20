class RookPiece : DirectionalPiece
{

    static readonly int[][] scores = new int[][] {
        new int[] { 0, 0, 0, 0, 0, 0, 0, 0 },
        new int[] { 5, 10, 10, 10, 10, 10, 10, 5 },
        new int[] { -5, 0, 0, 0, 0, 0, 0, -5 },
        new int[] { -5, 0, 0, 0, 0, 0, 0, -5 },
        new int[] { -5, 0, 0, 0, 0, 0, 0, -5 },
        new int[] { -5, 0, 0, 0, 0, 0, 0, -5 },
        new int[] { -5, 0, 0, 0, 0, 0, 0, -5 },
        new int[] { 0, 0, 0, 5, 5, 0, 0, 0 },
    };

    static readonly int[][] ennemyScores = ReverseScores(scores);

    static readonly XY[] directions = new XY[] {
        new () { x = 1, y = 0 },
        new () { x = 0, y = 1 },
        new () { x = -1, y = 0 },
        new () { x = 0, y = -1 },
    };
    public RookPiece(bool isPlayer) : base(isPlayer, directions, false) { }

    public override string GetName()
    {
        return "Rook";
    }

    public override int[][] GetScores()
    {
        return isPlayer ? scores : ennemyScores;
    }

    public override int GetValue()
    {
        return 500;
    }
}
