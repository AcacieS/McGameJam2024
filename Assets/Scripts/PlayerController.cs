using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    private Rigidbody playerRb;
    private float speed = 10.0f;
    private float turnSpeed = 40.0f;
    public float jumpForce = 15.0f;
    public float gravityModifier = 2;
    public bool isOnGround = true;
    // Start is called before the first frame update
    void Start()
    {   
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }

            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            transform.Rotate(Vector3.up * turnSpeed *Time.deltaTime); 
    }
    private void OnCollisionEnter(Collision collision)
    {
         if(collision.gameObject.CompareTag("Ground"))
        {
           isOnGround = true; 
           }

    }
}
