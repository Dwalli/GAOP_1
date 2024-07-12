using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonControl : MonoBehaviour
{
    private Vector3 gravityForce = new Vector3 (0f, 0f, 0f);
    public float gravity = -9.81f;
    public float jumpForce = 20f;
    public float rotateSpeed = 9;
    public float speed = 9;
    public float moveSpeed;


    private bool isGrounded = true;
    public LayerMask whatIsGround;
    public float playerHight;

    public float drageForce;

    public KeyCode jumpKey = KeyCode.Space;

    public Transform player;
    public Transform orientation;
    public Transform playerObject;
    public Rigidbody rb;
    public Transform cam;

    public enum fixCam
    {
        Fix,
        Free
    }
    public fixCam camType = fixCam.Fix;

    private Vector3 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        GroundCheck();

     
        
    }

    private void FixedUpdate() {
        rotation();
        movePlayer();
        speedLimit();
        jump();
    }
    void speedLimit(){
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limit = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limit.x, rb.velocity.y, limit.z);
        }
    }

    void GroundCheck(){
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHight * 0.5f + 0.2f, whatIsGround);

        if (isGrounded) { rb.drag = drageForce; }
        else { rb.drag = 0f; }
    }

    void movePlayer(){
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        player.forward = orientation.forward;
        moveDirection = player.forward * verticalInput + player.right * horizontalInput;
        rb.AddForce(moveDirection.normalized * speed, ForceMode.Force);

    }

    void jump(){
        if (isGrounded == true && Input.GetKey(jumpKey))
        {
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }
    }

    void rotation(){
        Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (camType == fixCam.Fix)
        {
            Vector3 directionToLook = cam.position - new Vector3(transform.position.x, cam.position.y, transform.position.z);
            orientation.forward = -directionToLook.normalized; // to make free cam not to bug out
            playerObject.forward = -directionToLook.normalized;
        }
        else if (camType == fixCam.Free)
        {
            Vector3 moveDir = orientation.forward * verticalInput + orientation.right * horizontalInput;
        
            if (moveDir != Vector3.zero)
            {
                playerObject.forward = Vector3.Slerp(playerObject.forward, moveDir.normalized, Time.deltaTime * rotateSpeed);
            }
        }


    }
}
