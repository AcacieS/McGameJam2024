using UnityEngine;

public class ChessBoardManager : MonoBehaviour
{

    private GameObject[][] board;
    private GameObject[][] pieces;

    private readonly ChessBoard chessBoard = new();

    public GameObject selectedPiece;
    public bool isPlayerTurn = true;

    public void Start()
    {
        GameObject whiteSquare = GameObject.Find("White Square");
        GameObject blackSquare = GameObject.Find("Black Square");
        whiteSquare.SetActive(false);
        blackSquare.SetActive(false);
        board = new GameObject[8][];
        pieces = new GameObject[8][];
        bool isWhite = true;
        for (int i = 0; i < 8; i++)
        {
            board[i] = new GameObject[8];
            pieces[i] = new GameObject[8];
            for (int j = 0; j < 8; j++)
            {
                GameObject square = Instantiate(isWhite ? whiteSquare : blackSquare, gameObject.transform);
                SquareInteraction interaction = square.AddComponent<SquareInteraction>();
                interaction.boardManager = this;

                square.transform.position = new Vector3(i, 1, j);
                square.SetActive(true);
                board[i][j] = square;
                isWhite = !isWhite;
            }
            isWhite = !isWhite;
        }



        AddPiece(new RookPiece(true), 0, 0);
    }

    public void AddPiece(ChessPiece piece, int x, int y)
    {
        chessBoard.AddPiece(piece, x, y);

        string name = piece.GetName();
        Debug.Log(name);
        GameObject pieceObject = Resources.Load<GameObject>(name);
        GameObject cloned = Instantiate(pieceObject, gameObject.transform);
        cloned.transform.position = new Vector3(x, 1, y);
        cloned.SetActive(true);
        pieces[x][y] = cloned;
        PieceInteraction interation = cloned.AddComponent<PieceInteraction>();

        interation.title = name;
        interation.description = "Press E to select this piece to move it";
        interation.boardManager = this;

        MeshRenderer meshRenderer = cloned.GetComponent<MeshRenderer>();
        if (piece.isPlayer)
        {
            cloned.transform.Rotate(0, 180, 0);
            meshRenderer.material.color = Color.white;
        }
        else
        {
            cloned.transform.Rotate(0, 0, 0);
            meshRenderer.material.color = Color.black;
        }
    }

    public XY GetSelectedXY()
    {
        int x0 = 0;
        int y0 = 0;
        for (int y = 0; y < 8; y++)
            for (int x = 0; x < 8; x++)
            {
                if (pieces[y][x] == selectedPiece)
                {
                    x0 = x;
                    y0 = y;
                    break;
                }
            }
        return new XY { x = x0, y = y0 };
    }

    public void ShowMovesForSelected()
    {
        ResetSquares();
        XY xy = GetSelectedXY();
        int x = xy.x;
        int y = xy.y;
        XY[] moves = chessBoard.board[y][x].GetMoves(x, y, chessBoard.board);

        foreach (XY move in moves)
        {
            int dx = move.x;
            int dy = move.y;
            int newX = x + dx;
            int newY = y + dy;
            GameObject square = board[newX][newY];
            square.GetComponent<MeshRenderer>().material.color = Color.green;
            square.GetComponent<SquareInteraction>().enableSquare = true;
        }
    }

    public void ResetSquares()
    {
        for (int y = 0; y < 8; y++)
            for (int x = 0; x < 8; x++)
            {
                GameObject square = board[x][y];
                square.GetComponent<MeshRenderer>().material.color = square.name.Contains("White") ? Color.white : Color.black;
                square.GetComponent<SquareInteraction>().enableSquare = false;
            }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
