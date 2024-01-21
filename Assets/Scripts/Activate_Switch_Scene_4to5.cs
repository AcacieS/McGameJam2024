using UnityEngine;

public class Activate_Switch_Scene_4to5 : MonoBehaviour
{
    public GameObject s_door;
    public GameObject b_door;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        s_door.GetComponent<Animator>().enabled = true;
        b_door.GetComponent<Animator>().enabled = true;
    }
}
