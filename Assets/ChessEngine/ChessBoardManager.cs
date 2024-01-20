using UnityEngine;

public class ChessManager : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject[][] board;
    private GameObject[][] pieces;

    private GameObject selectedPiece;
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



        
        MeshRenderer meshRenderer = cloned.GetComponent<MeshRenderer>();
        if (piece.isPlayer)
        {
            cloned.transform.Rotate(0, 180, 0);
            meshRenderer.material.color = Color.white;
        } else
        {
            cloned.transform.Rotate(0, 0, 0);
            meshRenderer.material.color = Color.black;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
