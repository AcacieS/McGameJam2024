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
                interaction.y = i;
                interaction.x = j;
                interaction.title = "Square " + j + "," + i;
                interaction.description = "Press E to move the selected piece to this square";
                square.transform.position = new Vector3(j, 1, i);
                square.SetActive(true);
                board[i][j] = square;
                isWhite = !isWhite;
            }
            isWhite = !isWhite;
        }



        AddPiece(new RookPiece(true), 0, 0);
        AddPiece(new KnightPiece(true), 1, 0);
        AddPiece(new BishopPiece(true), 2, 0);
        AddPiece(new QueenPiece(true), 3, 0);
        AddPiece(new KingPiece(true), 4, 0);
        AddPiece(new BishopPiece(true), 5, 0);
        AddPiece(new KnightPiece(true), 6, 0);
        AddPiece(new RookPiece(true), 7, 0);

        // AddPiece(new PawnPiece(true), 0, 1);
        // AddPiece(new PawnPiece(true), 1, 1);
        // AddPiece(new PawnPiece(true), 2, 1);
        // AddPiece(new PawnPiece(true), 3, 1);
        // AddPiece(new PawnPiece(true), 4, 1);
        // AddPiece(new PawnPiece(true), 5, 1);
        // AddPiece(new PawnPiece(true), 6, 1);
        // AddPiece(new PawnPiece(true), 7, 1);

        AddPiece(new RookPiece(false), 0, 7);
        AddPiece(new KnightPiece(false), 1, 7);
        AddPiece(new BishopPiece(false), 2, 7);
        AddPiece(new QueenPiece(false), 3, 7);
        AddPiece(new KingPiece(false), 4, 7);
        AddPiece(new BishopPiece(false), 5, 7);
        AddPiece(new KnightPiece(false), 6, 7);
        AddPiece(new RookPiece(false), 7, 7);

        AddPiece(new PawnPiece(false), 0, 6);
        AddPiece(new PawnPiece(false), 1, 6);
        AddPiece(new PawnPiece(false), 2, 6);
        AddPiece(new PawnPiece(false), 3, 6);
        AddPiece(new PawnPiece(false), 4, 6);
        AddPiece(new PawnPiece(false), 5, 6);
        AddPiece(new PawnPiece(false), 6, 6);
        AddPiece(new PawnPiece(false), 7, 6);


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
        pieces[y][x] = cloned;

        if (piece.isPlayer)
        {

            PieceInteraction interation = cloned.AddComponent<PieceInteraction>();
            interation.title = name;
            interation.description = "Press E to select this piece to move it";
            interation.boardManager = this;
        }
        else
        {
            SquareInteraction squareInteraction = cloned.AddComponent<SquareInteraction>();
            squareInteraction.title = "Square " + x + "," + y;
            squareInteraction.description = "Press E to move the selected piece to this square";
        }

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
            GameObject square = board[newY][newX];
            square.GetComponent<MeshRenderer>().material.color = Color.green;
            square.GetComponent<SquareInteraction>().enableSquare = true;
        }
    }

    public void ResetSquares()
    {
        for (int y = 0; y < 8; y++)
            for (int x = 0; x < 8; x++)
            {
                GameObject square = board[y][x];
                square.GetComponent<MeshRenderer>().material.color = square.name.Contains("White") ? Color.white : Color.black;
                square.GetComponent<SquareInteraction>().enableSquare = false;
            }
    }

    public void MoveFromTo(int x0, int y0, int x, int y)
    {
        ChessPiece piece = chessBoard.board[y0][x0];
        chessBoard.ApplyPieceMove(new PieceMove
        {
            move = new XY { x = x - x0, y = y - y0 },
            piece = piece,
            position = new XY { x = x0, y = y0 }
        });

        if (pieces[y][x] != null)
        {
            Destroy(pieces[y][x]);
        }
        pieces[y][x] = pieces[y0][x0];
        pieces[y0][x0] = null;
        pieces[y][x].transform.position = new Vector3(x, 1, y);
        ResetSquares();
        isPlayerTurn = !isPlayerTurn;
        selectedPiece = null;
    }

    public void MoveSelectedTo(int x, int y)
    {
        XY xy = GetSelectedXY();
        MoveFromTo(xy.x, xy.y, x, y);
    }

    public void EnnemyMove()
    {
        PieceMove? bestMove = chessBoard.GetBestMove(false, 3);
        if (bestMove != null)
        {
            Debug.LogWarning("Ennemy move: " + bestMove.Value.piece.GetName() + " " + bestMove.Value.move.x + " " + bestMove.Value.move.y);
            MoveFromTo(bestMove.Value.position.x, bestMove.Value.position.y, bestMove.Value.position.x + bestMove.Value.move.x, bestMove.Value.position.y + bestMove.Value.move.y);
            isPlayerTurn = true;
        }
        else
        {
            Debug.Log("No move found");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
