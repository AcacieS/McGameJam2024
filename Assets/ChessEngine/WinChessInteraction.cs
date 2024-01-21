using UnityEngine;

class WinChessInteraction: Interaction {

    private Canvas canvas;
    public new void Start()
    {
        base.Start();
        title = "Win";
        description = "Press E to decrypt and read the message";
        canvas = GameObject.Find("ExitCanvas").GetComponent<Canvas>();
        canvas.enabled = false;
    }
    public override void OnAction()
    {
        Debug.Log("Interacted with " + title);
        canvas.enabled = true;
    }
}