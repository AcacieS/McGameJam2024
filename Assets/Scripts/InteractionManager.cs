using UnityEngine;
using UnityEngine.UIElements;

class InteractionManager : MonoBehaviour
{

    public GameObject raycastObject;

    public float billboardDistance = 10;

    public float reach = 100;

    public GameObject grabbedObject;

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

    public void HandleRaycast()
    {
        Debug.DrawRay(raycastObject.transform.position, raycastObject.transform.forward * 100, Color.red);

        if (interactionObject != null)
        {
            Interaction interaction = interactionObject.GetComponent<Interaction>();
            billboardTitle.text = interaction.title;
            billboardDescription.text = interaction.description;
            Vector3 difference = interactionObject.transform.position - camera.transform.position;

            billboard.transform.position = camera.transform.position + difference.normalized * billboardDistance;
            billboard.transform.LookAt(camera.transform.position);

            if (difference.magnitude > reach)
            {
                interactionObject = null;
                billboard.SetActive(false);
                interaction.NoHit();
            }
        }

        if (Physics.Raycast(raycastObject.transform.position, raycastObject.transform.forward, out RaycastHit hit, reach))
        {
            Debug.Log("Hit " + hit.collider.gameObject.name);

            GameObject hitObject = hit.collider.gameObject;

            float distance = Vector3.Distance(camera.transform.position, hitObject.transform.position);



            if (distance < reach && hitObject.TryGetComponent(out Interaction interaction))
            {
                Debug.Log("Hit " + hitObject.name);
                interactionObject = hitObject;
                interaction.OnHit();
                billboard.SetActive(true);

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
    public void Update()
    {
        HandleRaycast();

        if (Input.GetKeyDown(KeyCode.E))
        {
            interactionObject?.GetComponent<Interaction>().OnInteration();
        }
    }
}