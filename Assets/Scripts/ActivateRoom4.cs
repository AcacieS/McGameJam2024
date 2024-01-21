using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateRoom4 : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Goal1"&&collision.gameObject.name == "Goal2"&&collision.gameObject.name == "Goal3"&&collision.gameObject.name == "Goal4"&&collision.gameObject.name == "Goal5"){
            gameObject.GetComponent<Animator>().enabled = true;
        }

    }
}
