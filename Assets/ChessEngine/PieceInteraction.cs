using UnityEngine;

class PieceInteraction : Interaction
{
    public void OnInteraction()
    {
        Debug.Log("Interacted with " + title);
    }
}