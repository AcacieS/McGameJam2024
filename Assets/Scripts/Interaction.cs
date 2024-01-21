using UnityEngine;

abstract class Interaction : MonoBehaviour
{
    public abstract void OnAction();

    public string title;
    public string description;

    public virtual bool IsAvailable() {
        return true;
    }

    private Outline outline;

    public void Start()
    {
        if (!gameObject.GetComponent<MeshCollider>())
        {
            gameObject.AddComponent<MeshCollider>();
        }

        try
        {
            outline = gameObject.AddComponent<Outline>();
        }
        catch
        {
            Debug.Log("Outline not found");
        }

        outline.enabled = false;
        outline.OutlineColor = Color.cyan;
        outline.OutlineMode = Outline.Mode.OutlineAll; ;
        outline.OutlineWidth = 10f;
    }

    public void OnHit()
    {
        outline.enabled = true;
    }

    public void NoHit()
    {
        outline.enabled = false;
    }

}