public abstract class ChessPiece
{
    public ChessPiece(bool isPlayer)
    {
        this.isPlayer = isPlayer;
    }
    public bool isPlayer;
    public abstract XY[] GetMoves(int x, int y, ChessPiece[][] board);

    public abstract int[][] GetScores();

    public abstract string GetName();

    public abstract int GetValue();

    public bool IsInBounds(int x, int y)
    {
        return x >= 0 && x < 8 && y >= 0 && y < 8;
    }

    public bool IsEmpty(int x, int y, ChessPiece[][] board)
    {
        return IsInBounds(x, y) && board[y][x] == null;
    }

    public bool IsEnemy(int x, int y, ChessPiece[][] board)
    {
        return IsInBounds(x, y) && board[y][x] != null && board[y][x].isPlayer != isPlayer;
    }

    public bool IsValid(int x, int y, ChessPiece[][] board)
    {
        return IsEmpty(x, y, board) || IsEnemy(x, y, board);
    }

    public static int[][] ReverseScores(int[][] scores)
    {
        int[][] reversed = new int[8][];
        for (int i = 0; i < 8; i++)
        {
            reversed[i] = new int[8];
            for (int j = 0; j < 8; j++)
            {
                reversed[i][j] = scores[7 - i][j];
            }
        }
        return reversed;
    }
};
