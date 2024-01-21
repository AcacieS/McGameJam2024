using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class ActivateButton : MonoBehaviour
{
    public GameObject cubeObject;
    public GameObject spotLight;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        //Animator anim = GetComponent<Animator>();
        //anim.enabled = true;  
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Cube"||collision.gameObject.name == "Player2"){
            gameObject.GetComponent<Animator>().enabled = true;
            if(collision.gameObject.name == "Player2"){
                Debug.Log("?????");
                spotLight.GetComponent<Animator>().enabled = true;
            }
        }

    }
}
