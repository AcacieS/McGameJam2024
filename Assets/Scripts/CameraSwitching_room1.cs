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
        
    }

    // Update is called once per frame
    public void ShowCameraAnim(){
        cameraRoom1.enabled = true;
        mainCamera.enable = false;
        
    }
    public void ShowMainCamera(){
        cameraRoom1.enabled = false;
        mainCamera.enable = true;
    }
}
