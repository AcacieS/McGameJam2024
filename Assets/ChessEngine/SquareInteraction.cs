using UnityEngine;

class SquareInteraction : Interaction
{
    public int x;
    public int y;
    public void OnInteraction()
    {
        Debug.Log("Interacted with " + title);
    }
}