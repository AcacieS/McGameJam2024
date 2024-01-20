using UnityEngine;

class Interaction: MonoBehaviour {
    public void OnInteration() {
        Debug.Log("Interacted with " + title);
    }

    public string title;
    public string description;

    private Outline outline;

    public void Start() {
        outline = gameObject.GetComponent<Outline>();
        outline.enabled = false;
    }

    public void OnHit() {
        outline.enabled = true;
    }

    public void NoHit() {
        outline.enabled = false;
    }
    
}