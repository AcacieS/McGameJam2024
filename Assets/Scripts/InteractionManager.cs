using UnityEngine;

class InteractionManager : MonoBehaviour
{

    public GameObject raycastObject;

    private GameObject interactionObject;

    private GameObject billboard;
    private TextMesh billboardTitle;
    private TextMesh billboardDescription;

    public new Camera camera;

    public void Start()
    {
        billboard = GameObject.Find("Billboard");
        billboardTitle = GameObject.Find("BillboardTitle").GetComponent<TextMesh>();
        billboardDescription = GameObject.Find("BillboardDescription").GetComponent<TextMesh>();
        billboard.SetActive(false);
    }
    public void Update()
    {
        Debug.DrawRay(raycastObject.transform.position, raycastObject.transform.forward * 100, Color.red);
        if (Physics.Raycast(raycastObject.transform.position, raycastObject.transform.forward, out RaycastHit hit))
        {


            if (hit.collider.gameObject.TryGetComponent(out Interaction interaction))
            {
                Debug.Log("Hit " + hit.collider.gameObject.name);
                interactionObject = hit.collider.gameObject;
                interaction.OnHit();
                billboard.SetActive(true);
                billboardTitle.text = interaction.title;
                billboardDescription.text = interaction.description;
                billboard.transform.position = interactionObject.transform.position + new Vector3(0, 1f, 0);
                billboard.transform.rotation = camera.transform.rotation;
            }


            return;
        }

        if (interactionObject != null)
        {
            Debug.Log("No hit");
            interactionObject.GetComponent<Interaction>().NoHit();
            interactionObject = null;
            billboard.SetActive(false);
        }

    }
}