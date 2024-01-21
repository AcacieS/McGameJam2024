using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class telepor_4to5 : MonoBehaviour
{
        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.name == "Player"){
                SceneManager.LoadScene("room5"); 
            }
            
        } 
}

