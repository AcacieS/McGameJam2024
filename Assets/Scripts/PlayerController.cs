using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public new Camera camera;
    private AudioSource playerAudio;
    public AudioClip footStepSound;
    private float verticalInput;
    private float horizontalInput;
    private Rigidbody playerRb;
    private float speed = 10.0f;
    public float jumpForce = 15.0f;
    public float gravityModifier = 2;
    public bool isOnGround = true;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();

        Physics.gravity *= gravityModifier;
        playerAudio.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
        Vector3 forward = new(camera.transform.forward.x, 0, camera.transform.forward.z);
        Vector3 left = Quaternion.AngleAxis(90, Vector3.up) * forward;
        transform.Translate(forward * speed * Time.deltaTime * verticalInput);
        transform.Translate(left * speed * Time.deltaTime * horizontalInput);
        if (verticalInput != 0 || horizontalInput != 0) {
            playerAudio.PlayOneShot(footStepSound);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }

    }
}
