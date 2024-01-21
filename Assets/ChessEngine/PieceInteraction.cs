using UnityEngine;

class PieceInteraction : Interaction
{

    public ChessBoardManager boardManager;

    public override bool IsAvailable()
    {
        return boardManager.isPlayerTurn;
    }

    public override void OnAction()
    {
        boardManager.selectedPiece = gameObject;
        boardManager.ShowMovesForSelected();
    }
}