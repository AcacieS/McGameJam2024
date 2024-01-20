using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitching_room1 : MonoBehaviour
{
    public Camera cameraRoom1;
    public Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        cameraRoom1.enabled = false;
        mainCamera.enabled = true;
        
    }

    // Update is called once per frame
    public void ShowCameraAnim(){
        cameraRoom1.enabled = true;
        mainCamera.enabled = false;
        
    }
    public void ShowMainCamera(){
        cameraRoom1.enabled = false;
        mainCamera.enabled = true;
    }
}
