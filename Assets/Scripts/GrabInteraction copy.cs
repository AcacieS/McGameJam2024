using UnityEngine;

class Grabbable : Interaction
{
    public new Camera camera;

    private Transform parentTransform;

    private InteractionManager interaction;
    private bool isGrabbed = false;

    public new void Start()
    {
        base.Start();
        interaction = GameObject.Find("Player").GetComponent<InteractionManager>();
    }

    public void OnDrop()
    {
        Debug.Log("Dropped " + title);
        gameObject.transform.SetParent(parentTransform);
        interaction.grabbedObject = null;
        isGrabbed = false;
    }
    public override bool IsAvailable()
    {
        return !isGrabbed;
    }

    public override void OnAction()
    {
        Debug.Log("Interacted with " + title);
        if (interaction.grabbedObject == null)
        {
            parentTransform = gameObject.transform.parent;
            gameObject.transform.SetParent(camera.transform);
            interaction.grabbedObject = gameObject;
            isGrabbed = true;
        }
    }
}