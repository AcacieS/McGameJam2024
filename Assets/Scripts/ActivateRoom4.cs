using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateRoom4 : MonoBehaviour
{
    private bool Goal1Bool;
    private bool Goal2Bool;
    private bool Goal3Bool;
    private bool Goal4Bool;
    private bool Goal5Bool;

    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Goal1"){
            Goal1Bool = true;
        }
        if(collision.gameObject.name == "Goal2"){
            Goal2Bool = true;
        }
        if(collision.gameObject.name == "Goal3"){
            Goal3Bool = true;
        }
        if(collision.gameObject.name == "Goal4"){
            Goal4Bool = true;
        }
        if(collision.gameObject.name == "Goal5"){
            Goal5Bool = true;
        }
        if(Goal1Bool == true&&Goal2Bool == true&&Goal3Bool == true&&Goal4Bool == true&&Goal5Bool == true){//&&collision.gameObject.name == "Goal3"&&collision.gameObject.name == "Goal4"&&collision.gameObject.name == "Goal5"){
            gameObject.GetComponent<Activate_Switch_Scene_4to5>().enabled = true;
        }

    }
}
