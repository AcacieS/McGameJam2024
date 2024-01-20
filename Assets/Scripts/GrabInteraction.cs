using UnityEngine;

class Grabbable: Interaction {
    public new Camera camera;

    private Transform parentTransform;

    public void OnInteraction() {
        Debug.Log("Interacted with " + title);
        parentTransform = gameObject.transform.parent;
        gameObject.transform.SetParent(camera.transform);
    }

    public void OnDrop() {
        Debug.Log("Dropped " + title);
        gameObject.transform.SetParent(parentTransform);
    }
}