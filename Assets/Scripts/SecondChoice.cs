using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecondChoice : MonoBehaviour
{
    //public GameObject playerWalk;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Y)){
            Debug.Log("2222Yes");
            //playerWalk.GetComponent<PlayerController>().enabled=true;
            SceneManager.LoadScene("test");

        }else if(Input.GetKeyDown(KeyCode.N)){
            Debug.Log("2222No");
        }
        
    }
}
