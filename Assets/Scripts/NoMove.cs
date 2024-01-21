using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoMove : MonoBehaviour
{
    public GameObject playerCharacter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("hey??");
        if(collision.gameObject.name == "ball"){
            Debug.Log("hey");
            playerCharacter.GetComponent<PlayerController>().enabled =false;  
        }
    }
}
