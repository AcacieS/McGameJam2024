using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecondChoice : MonoBehaviour
{
    //public GameObject playerWalk;
    public GameObject cameraRoom1;
    public GameObject mainCamera;
    public GameObject sphereObject;
    // Start is called before the first frame update
    void Start()
    {
        //cameraRoom1.enabled = false;
        //mainCamera.SetActive
    }

    // Update is called once per frame
    

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Y)){
            Debug.Log("2222Yes");
            //playerWalk.GetComponent<PlayerController>().enabled=true;
            cameraRoom1.SetActive(true);
            mainCamera.SetActive(false);
            //sphereObject.SetActive(false);
            //SceneManager.LoadScene("room1Inside");

        }else if(Input.GetKeyDown(KeyCode.N)){
            Debug.Log("2222No");
        }
        
    }
}
