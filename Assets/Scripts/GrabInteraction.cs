using UnityEngine;

class Grabbable: Interaction {
    public new Camera camera;

    private Transform parentTransform;

    private InteractionManager interaction;

    public new void Start() {
        base.Start();
        interaction = GameObject.Find("Player").GetComponent<InteractionManager>();
    }

    public void OnInteraction() {
        Debug.Log("Interacted with " + title);
        parentTransform = gameObject.transform.parent;
        gameObject.transform.SetParent(camera.transform);
        interaction.grabbedObject = gameObject;
    }

    public void OnDrop() {
        Debug.Log("Dropped " + title);
        gameObject.transform.SetParent(parentTransform);
        interaction.grabbedObject = null;
    }
}