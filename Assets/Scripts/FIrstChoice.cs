using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FIrstChoice : MonoBehaviour
{
    public GameObject sphereObject;// playerWalk;
    public GameObject secondChoice;
    // Start is called before the first frame update
    void Start()
    {
        // GameObject g = GameObject.Find("GameObject Name");
        //Then you can grab the script:

        //BombDrop bScript = g.GetComponent<BombDrop>();
        //playerWalk = GameObject.Find("player").GetComponent<>()
        //sphere_object = GameObject.Find("Sphere");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Y)){
            Debug.Log("Yes");
            sphereObject.SetActive(true);
            //playerWalk.GetComponent<PlayerController>().enabled=true;
            //hey.SetActive(true);
            secondChoice.SetActive(true);
            

        }else if(Input.GetKeyDown(KeyCode.N)){
            Debug.Log("No");
        }
        
    }
}
