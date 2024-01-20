using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class ActivateButton : MonoBehaviour
{
    public GameObject cubeObject;
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
        if(collision.gameObject.name == "Cube"){
            gameObject.GetComponent<Animator>().enabled = true;
        }

    }
}
