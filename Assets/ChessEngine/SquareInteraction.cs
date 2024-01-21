using UnityEngine;

class SquareInteraction : Interaction
{
    public int x;
    public int y;

    public bool enableSquare = false;

    public ChessBoardManager boardManager;

    public override void OnAction()
    {
       Debug.Log("Interacted with " + title);
    }

    public override bool IsAvailable()
    {
        return enableSquare;
    }
}