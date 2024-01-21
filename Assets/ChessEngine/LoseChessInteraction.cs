using UnityEngine;

class LoseChessInteraction: Interaction {

    public ChessBoardManager manager;

    public new void Start()
    {
        base.Start();
        manager = GameObject.Find("ChessBoard").GetComponent<ChessBoardManager>();
        title = "Lose";
        description = "Press E to restart the match";
    }
    public override void OnAction()
    {
        Debug.Log("Interacted with " + title);
        manager.ResetBoard();
    }
}