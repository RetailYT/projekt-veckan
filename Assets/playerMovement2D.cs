using UnityEngine;

public class playerMovement2D : MonoBehaviour
{

    public float moveSpeed = 5f; //Player's movement speed
    public float jumpForce = 5f; //How high the player can jump
    public Transform groundCheck; //Position to check if the player is grounded
    public float groundCheckRadius = 0.2f; //Radius of the ground check circle
    public LayerMask groundLayer; // LayerMask to specify what is considered ground

    private Rigidbody2D rb; // Reference to the player's Rigidbody2D component
    private bool isGrounded; // Flag to check if the player is on the ground

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component attached to the player
    }

    // Update is called once per frame
    void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");// Get horizontal input (A/D or Left/Right arrow keys)
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y); // Move the player horizontally based on input

        if (Input.GetKeyDown(KeyCode.Z) && isGrounded) // Check if the jump key (Z) is pressed and the player is grounded
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce); // Apply jump force to the player's Rigidbody2D
        }
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer); // Check if the player is grounded by checking for collisions with the ground layer
    } 
}

