using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 700f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 1f;
    public float moveSpeed = 5000f; // Speed at which the player moves left/right
    public float forwardSpeed = 10000f; // Speed at which the player moves forward

    private Rigidbody rb;
    private bool isGrounded;
    private Vector3 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (!rb)
        {
            Debug.LogError("Rigidbody component missing!");
        }
    }

    
    void Update()
    {
        // Check if the character is on the ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);

        // Check for jumping
        if (Input.GetKeyDown(KeyCode.Space)  && isGrounded)
        {
            print("Jump");
            rb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
        }

        // Get horizontal input
        float horizontalInput = Input.GetAxisRaw("Horizontal"); // Immediate response
        movement = new Vector3(horizontalInput, 0, 0) * moveSpeed;
        Debug.Log("Current Speed: " + movement.magnitude); // Log the current speed
    }

    void FixedUpdate()
    {
        // Set the forward velocity and keep the existing vertical velocity
        rb.velocity = new Vector3(movement.x, rb.velocity.y, forwardSpeed);

        // Check for jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // Add vertical jump force
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }
    }
}
